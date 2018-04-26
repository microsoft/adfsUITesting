//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;

namespace AdfsUITestManager
{
    /// <summary>
    /// A class containing the tasks that can be performed on the External Authentication UI Page through AD FS 
    /// </summary>
    class ExternalAuthTasks : TaskBase
    {
        /// <summary>
        /// A task to enter an answer to a challenge question provided by an External Auth Provider
        /// that prompts with challenge questions
        /// 
        /// Note: This External Auth Adapter is based on a test auth adapter used by the AD FS Product Group 
        /// 
        /// </summary>
        /// <param name="driver">A web driver</param>
        /// <param name="config">Configuration data for this task</param>
        public static void EnterChallengeAnswers( IWebDriver driver, TaskConfiguration config )
        {
            LogAndScreenshot( driver, config );

            foreach ( string answer in config.ExternalAuth.Answers )
            {
                IWebElement challengeField = driver.FindElement( By.Id( "challengeQuestionInput" ) );
                challengeField.SendKeys( $"{answer}" );
                challengeField.SendKeys( Keys.Return );
                LogAndScreenshot( driver, config );
            }
        }
    }
}
