//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;

namespace AdfsUITestManager
{
    /// <summary>
    /// A class containing the tasks that can be performed on the Primary/Secondary Credential Options Page through AD FS 
    /// </summary>
    class OptionsPageTasks : TaskBase
    {
        public static void SelectFormsOnOptionPage( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement passwordOption = driver.FindElement( By.Id( "FormsAuthentication" ) );
            passwordOption.Click();
        }

        public static void SelectCertOnOptionPage( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement certOption = driver.FindElement( By.Id( "CertificateAuthentication" ) );
            certOption.Click();

            LogAndScreenshot( driver, config );
        }

        public static void SelectExternalOnOptionPage( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement externalOption = driver.FindElement( By.Id( "ExternalAuth" ) );
            externalOption.Click();

            LogAndScreenshot( driver, config );
        }

        public static void SignInWithOtherOptions( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement otherOption = driver.FindElement( By.Id( "otherOptions" ) );
            otherOption.Click();

            LogAndScreenshot( driver, config );
        }
    }
}
