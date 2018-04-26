//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
namespace AdfsUITestManager
{
    class Manager
    {
        static void Main( string[] args )
        {
            // Contract: 
            // .\BrowserStackTestManager.exe 

            TestContext context = new TestContext();
            InvokeTests( context.DriversPerTestCase, context.Configuration );
            Console.WriteLine( "Done" );
        }
        
        private static void InvokeTests( Dictionary<MethodInfo, List<DesiredCapabilities>> driversPerTest, TaskConfiguration config )
        {
            foreach ( var test in driversPerTest.Keys )
            {
                foreach ( var driverData in driversPerTest[ test] )
                {
                    IWebDriver driver = DriverFactory.GenerateDriver( driverData );
                    string sessionName = ( string )driverData.GetCapability( "name" );
                    string buildName = ( string )driverData.GetCapability( "build" );

                    try
                    {
                        Console.WriteLine( $"Executing test: {test.Name}" );
                        test.Invoke( null, new object[] { driver, config } );   
                        BrowserStackLogReader.MarkTest(BrowserStackLogReader.GetSessionId( buildName, sessionName ), TestStatus.Passed);
                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine("Exception thrown during test execution.");
                        Console.WriteLine( e.Message );
                        Console.WriteLine( e.StackTrace );
                        BrowserStackLogReader.MarkTest( BrowserStackLogReader.GetSessionId( buildName, sessionName ), TestStatus.Failed );
                        driver.Quit();
                    }
                }
            }
        }
    }
}
