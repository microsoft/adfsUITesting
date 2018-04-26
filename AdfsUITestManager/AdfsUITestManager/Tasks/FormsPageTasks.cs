//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;

namespace AdfsUITestManager
{
    /// <summary>
    /// A class containing the tasks that can be performed on the Username/Password Page through AD FS 
    /// </summary>
    class FormsPageTasks : TaskBase
    {
        // TODO: Add tasks to use 'Next' button instead of Return key 

        public static void EnterMisformattedUsername( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement usernameField = driver.FindElement( By.Id( "userNameInput" ) );
            usernameField.SendKeys( $"{config.User.MisformattedUsername}" );
            usernameField.SendKeys( Keys.Return );

            // TODO: Validate that the error message appears 

            LogAndScreenshot( driver, config );
        }

        public static void ClearUsername( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement usernameField = driver.FindElement( By.Id( "userNameInput" ) );
            usernameField.Clear();
        }

        public static void EnterBadUsername( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement usernameField = driver.FindElement( By.Id( "userNameInput" ) );
            usernameField.SendKeys( $"{config.User.BadUsername}" );

            LogAndScreenshot( driver, config );

            usernameField.SendKeys( Keys.Return );

            // TODO: Validate that the error message appears 
        }

        public static void EnterCorrectUsername( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement usernameField = driver.FindElement( By.Id( "userNameInput" ) );
            usernameField.SendKeys( $"{config.User.CorrectUsername}" );
            LogAndScreenshot( driver, config );
            usernameField.SendKeys( Keys.Return );
        }

        public static void EnterCorrectUsernameAndTab( IWebDriver driver, TaskConfiguration config )
        {
            IWebElement usernameField = driver.FindElement( By.Id( "userNameInput" ) );
            usernameField.SendKeys( $"{config.User.CorrectUsername}" );
            LogAndScreenshot( driver, config );
            usernameField.SendKeys( Keys.Tab );
        }

        public static void EnterBadPassword( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement passwordField = driver.FindElement( By.Id( "passwordInput" ) );
            passwordField.SendKeys( $"{config.User.BadPassword}" );
            passwordField.SendKeys( Keys.Return );

            LogAndScreenshot( driver, config );
        }

        public static void EnterCorrectPassword( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            IWebElement passwordField = driver.FindElement( By.Id( "passwordInput" ) );
            passwordField.SendKeys( $"{config.User.CorrectPassword}" );
            passwordField.SendKeys( Keys.Return );
            LogAndScreenshot( driver, config );
        }
    }
}
