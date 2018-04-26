//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;

namespace AdfsUITestManager
{
    /// <summary>
    /// A class containing the tasks that can be performed on the Paginated Login Page through AD FS 
    /// </summary>
    class PaginatedFormsTasks : TaskBase
    {
        public static void PasswordPageBackNavigate( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement backButton = driver.FindElement( By.Id( "backButton" ) );
            backButton.Click();

            LogAndScreenshot( driver, config );
        }

        public static void OptionsPageBackNavigate( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement backButton = driver.FindElement( By.Id( "optionsBackButton" ) );
            backButton.Click();

            LogAndScreenshot( driver, config );
        }

        public static void UsernamePageForwardNavigate( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement nextButton = driver.FindElement( By.Id( "nextButton" ) );
            nextButton.Click();

            LogAndScreenshot( driver, config );
        }
    }
}
