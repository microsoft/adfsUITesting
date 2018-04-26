//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;

namespace AdfsUITestManager
{
    /// <summary>
    /// A class containing the tasks that can be performed on the IDP Initiated Sign On Page through AD FS 
    /// </summary>
    class IdpPageTasks : TaskBase
    {
        public static void GoToIdpSignOnPage( IWebDriver driver, TaskConfiguration config )
        {
            string url = $"https://{config.Farm.FarmName}/adfs/ls/idpinitiatedsignon";
            driver.Navigate().GoToUrl( url );
            LogAndScreenshot( driver, config );
        }

        public static void GoToIdpSignOnPageWithLoginHint( IWebDriver driver, TaskConfiguration config )
        {
            driver.Navigate().GoToUrl( $"https://{config.Farm.FarmName}/adfs/ls/idpinitiatedsignon?login_hint={config.User.CorrectUsername}" );
            LogAndScreenshot( driver, config );
        }

        public static void ClickSignInOnIdpPage( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement signInButton = driver.FindElement( By.Id( "idp_SignInButton" ) );
            signInButton.Click();
            LogAndScreenshot( driver, config );
        }

        public static bool ValidateSignedIn( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement signOutButton = driver.FindElement( By.Id( "idp_SignOutPanel" ) );
            LogAndScreenshot( driver, config );
            return signOutButton != null;
        }
    }
}
