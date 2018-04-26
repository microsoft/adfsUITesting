//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium.Remote;
using System.Configuration;

namespace AdfsUITestManager
{
    using System;

    using OpenQA.Selenium;

    /// <summary>
    /// Class responsible for creating web drivers to be used for UI testing 
    /// </summary>
    class DriverFactory
    {
        static readonly string RemoteDriverUri = ConfigurationManager.AppSettings[ "RemoteDriverUri" ];

        public static IWebDriver GenerateDriver( DesiredCapabilities capability )
        {
            var driver = new RemoteWebDriver(
              new Uri( RemoteDriverUri ), capability
            );

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds( 10 );

            return driver;
        }

        public static void AddCommonCapabilities( DesiredCapabilities capability )
        {
            var user = ConfigurationManager.AppSettings[ "BrowserStackUser" ];
            var key = ConfigurationManager.AppSettings[ "BrowserStackKey" ];

            var sessionName = $"AD FS {DateTime.UtcNow.ToFileTimeUtc()}";
            var buildName = $"AD FS Build {DateTime.UtcNow.ToString("yyyy-MM-dd")}";

            capability.SetCapability( "browserstack.local", "true" );
            capability.SetCapability( "browserstack.user", user );
            capability.SetCapability( "browserstack.key", key );
            capability.SetCapability( "browserstack.debug", "true" );
            capability.SetCapability( "resolution", "1024x768" );
            capability.SetCapability( "build", buildName );
            capability.SetCapability( "name", sessionName );
        }

        public static DesiredCapabilities GetChromeDriverCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability( "browser", "Chrome" );
            capability.SetCapability( "browser_version", "62.0" );
            capability.SetCapability( "os", "Windows" );
            capability.SetCapability( "os_version", "10" );
            capability.SetCapability( "ignore-certificate", true );

            AddCommonCapabilities( capability );

            return capability;
        }

        public static DesiredCapabilities GetFirefoxDriverCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability( "os", "Windows" );
            capability.SetCapability( "os_version", "10" );
            capability.SetCapability( "browser", "Firefox" );
            capability.SetCapability( "browser_version", "58.0" );
            capability.SetCapability( "acceptInsecureCerts", true );

            AddCommonCapabilities( capability );
            return capability;
        }

        public static DesiredCapabilities GetIEDriverCapabilities()
        {
            DesiredCapabilities capability = new DesiredCapabilities();
            capability.SetCapability( "os", "Windows" );
            capability.SetCapability( "os_version", "10" );
            capability.SetCapability( "browser", "IE" );
            capability.SetCapability( "browser_version", "11.0" );

            AddCommonCapabilities( capability );
            return capability;
        }
    }
}
