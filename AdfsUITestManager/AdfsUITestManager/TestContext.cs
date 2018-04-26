//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;
using OpenQA.Selenium.Remote;

namespace AdfsUITestManager
{
    using System;

    class TestContext
    {
        public List<MethodInfo> TestCases;
        //public List<IWebDriver> BrowserDrivers;
        public TaskConfiguration Configuration;
        public Dictionary<MethodInfo, List<DesiredCapabilities>> DriversPerTestCase;

        public TestContext()
        {
            TestListConfiguration testListConfig = ( TestListConfiguration )System.Configuration.ConfigurationManager.GetSection( "testListConfigurationGroup/testListConfiguration" );
            List<string> testCases = new List<string>( testListConfig.TestData.TestIds );
            this.TestCases = this.TestCases = ParseAndVerifyTestIds( testCases );    

            this.Configuration = TaskConfigurationFactory.GetConfiguration();

            this.DriversPerTestCase = new Dictionary<MethodInfo, List<DesiredCapabilities>>();
            foreach ( var testcase in this.TestCases )
            {
                this.DriversPerTestCase[testcase] = new List<DesiredCapabilities> { DriverFactory.GetChromeDriverCapabilities() };
            }
        }

        private List<MethodInfo> ParseAndVerifyTestIds( List<string> testIdsRaw )
        {
            if ( testIdsRaw.Count == 0 )
            {
                throw new ArgumentNullException( $"Cannot find any test names in string {testIdsRaw}. Please check the string, and ensure that test names are comma-separated." );
            }

            List<MethodInfo> methods = new List<MethodInfo>();
            Type type = typeof( TestCases );

            foreach ( var testLine in testIdsRaw )
            {
                if ( string.IsNullOrEmpty( testLine ) )
                {
                    // Skip blank lines 
                    continue;
                }

                // Handle the case where tests are comma-separated 
                List<string> testIds = new List<string>( testLine.Split( ',' ) );
                foreach ( var test in testIds )
                {
                    MethodInfo methodInfo = type.GetMethod( test, BindingFlags.Static | BindingFlags.NonPublic );
                    if ( methodInfo == null )
                    {
                        throw new ArgumentNullException( $"Cannot find test name {test}. Please check BrowserStackTestManager.TestCases.cs to ensure your test case exists. Note: names are case-sensitive." );
                    }

                    methods.Add( methodInfo );
                }

            }

            return methods;
        }
    }
}
