//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace AdfsUITestManager
{
    public enum TestStatus
    {
        Passed,
        Failed
    }

    public class MarkTestData
    {
        public string status { get; set; }
    }

    public enum BrowserStackDataType
    {
        Build, 
        Session
    }

    class BrowserStackLogReader
    {
        public static NetworkCredential AuthCredential = new NetworkCredential( ConfigurationManager.AppSettings[ "BrowserStackUser" ], ConfigurationManager.AppSettings[ "BrowserStackKey" ] );

        /// <summary>
        /// BrowserStack API supports build and session queries for a given user.
        /// This method retrieves all builds or sessions, and then searches for the ID of the matching session/build by name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="url"></param>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private static string GetIdFromName( string name, string url, BrowserStackDataType dataType )
        {
            WebResponse response = null;
            StreamReader reader = null;
            // BrowserStack doesn't allow hyphens in remote names, and removes them silently 
            name = name.Replace( '-', ' ' );

            try
            {
                WebRequest request = WebRequest.Create( url );
                request.Credentials = AuthCredential;
                response = request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                reader = new StreamReader( dataStream );
                string responseFromServer = reader.ReadToEnd();
                string data = "{\"data\": " + responseFromServer + "}";
                var jsonData = JObject.Parse( data );

                // Iterate through builds until you find one that matches our build name 
                for ( int i = 0; i < jsonData[ "data" ].Count(); i++ )
                {
                    string automationElement = "automation_session";
                    if ( dataType == BrowserStackDataType.Build )
                    {
                        automationElement = "automation_build";
                    }
                    var nameRemote = ( string )jsonData[ "data" ][ i ][ automationElement ][ "name" ];

                    if ( nameRemote.Equals( name ) )
                    {
                        return ( string )jsonData[ "data" ][ i ][ automationElement ][ "hashed_id" ];
                    }
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine( "Error while trying to call BrowserStack." );
                Console.WriteLine( e.Message );
                Console.WriteLine( e.StackTrace );
            }
            finally
            {
                reader?.Close();
                response?.Close();
            }

            return null;
        }

        /// <summary>
        /// Locates the BrowserStack session ID for a given build and session name.
        /// </summary>
        /// <param name="buildName"></param>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        public static string GetSessionId(string buildName, string sessionName)
        {
            var buildId = GetIdFromName( buildName, $"https://api.browserstack.com/automate/builds.json", BrowserStackDataType.Build );

            if ( string.IsNullOrEmpty( buildId ) )
            {
                Console.WriteLine("Error getting build ID. No matching build ID found.");
                return null;
            }

            var sessionId = GetIdFromName( sessionName, $"https://api.browserstack.com/automate/builds/{buildId}/sessions.json", BrowserStackDataType.Session );
            if ( string.IsNullOrEmpty( sessionId ) )
            {
                Console.WriteLine( "Error getting session ID. No matching session ID found." );
                return null;
            }

            return sessionId;
        }

        /// <summary>
        /// Marks a test corresponding to the given session ID with the test status supplied. 
        /// This method is used to mark tests as "pass" or "fail", based on what occurs in the ADFS environment.
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="status"></param>
        public static void MarkTest( string sessionId, TestStatus status)
        {
            try
            {
                string url = $"https://api.browserstack.com/";
                var handler = new HttpClientHandler { Credentials = AuthCredential };
                HttpClient client = new HttpClient( handler );
                client.BaseAddress = new Uri( url );

                // Create the data to PUT 
                MarkTestData data = new MarkTestData();
                data.status = status.ToString();
                var output = JsonConvert.SerializeObject( data );

                var inputMessage = new HttpRequestMessage
                {
                    Content = new StringContent( output, Encoding.UTF8, "application/json" )
                };
                inputMessage.Headers.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

                HttpResponseMessage message = client.PutAsync( $"automate/sessions/{sessionId}.json", inputMessage.Content ).Result;

                if ( message.IsSuccessStatusCode )
                {
                    Console.WriteLine( "Test marked successfully" );
                }
            }
            catch ( Exception e )
            {
                Console.WriteLine( $"Failed to mark test {sessionId} with status {status}." );
                Console.WriteLine( e.Message );
                Console.WriteLine( e.StackTrace );
            }
        }
    }
}
