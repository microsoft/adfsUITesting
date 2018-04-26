//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using OpenQA.Selenium;

namespace AdfsUITestManager.Tasks
{
    /// <summary>
    /// A class containing the tasks that can be performed when requesting a Relying Party through AD FS 
    /// </summary>
    class RelyingPartyTasks : TaskBase
    {
        public static void GoToRpSignIn( IWebDriver driver, TaskConfiguration config )
        {
            string url = $"https://{config.Farm.FarmName}/adfs/ls/?wa=wsignin1.0&wtrealm={config.RelyingPartyData.Wtrealm}&wreply={config.RelyingPartyData.Wreply}";
            driver.Navigate().GoToUrl( url );
            LogAndScreenshot( driver, config );
        }

        public static bool ValidateRpIsSignedIn( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );
            return string.Compare( driver.Url, config.RelyingPartyData.Wreply, StringComparison.InvariantCultureIgnoreCase ) == 0;
        }
    }
}
