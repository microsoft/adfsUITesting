//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using OpenQA.Selenium;
using System.Diagnostics;

namespace AdfsUITestManager
{
    using AdfsUITestManager.Tasks;

    public class TestCases
    {
        #region IDP Initiated Sign On Tests
        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available 
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_WithOptions_Password( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterMisformattedUsername( driver, configuration );
            FormsPageTasks.ClearUsername( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterBadPassword( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Clean up 
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available (including certificate) 
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_WithOptions_CertThenForms( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterMisformattedUsername( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            OptionsPageTasks.SelectCertOnOptionPage( driver, configuration );
            OptionsPageTasks.SignInWithOtherOptions( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available (including external) 
        ///     3. User configured for external auth 
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_WithOptions_External( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            OptionsPageTasks.SelectExternalOnOptionPage( driver, configuration );
            ExternalAuthTasks.EnterChallengeAnswers( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available (including external) 
        ///     3. User configured for external auth 
        /// </summary>
        /// <param name="driver"></param>
        static void HintIdpSignOn_WithOptions_External( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPageWithLoginHint( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            OptionsPageTasks.SelectExternalOnOptionPage( driver, configuration );
            ExternalAuthTasks.EnterChallengeAnswers( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available (including external) 
        /// </summary>
        /// <param name="driver"></param>
        static void HintIdpSignOn_WithOptions_Password_ChangeUser( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPageWithLoginHint( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            PaginatedFormsTasks.OptionsPageBackNavigate( driver, configuration );
            FormsPageTasks.ClearUsername( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Only forms auth options available 
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_NoOptions_Password( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterMisformattedUsername( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            PaginatedFormsTasks.PasswordPageBackNavigate( driver, configuration );
            PaginatedFormsTasks.UsernamePageForwardNavigate( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature disabled
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_Password_Legacy( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterCorrectUsernameAndTab( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );
            
            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert(success);

            // Clean up 
            driver.Quit();
        }

        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature disabled
        /// </summary>
        /// <param name="driver"></param>
        static void BasicIdpSignOn_Password_Failure_Legacy( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            IdpPageTasks.GoToIdpSignOnPage( driver, configuration );
            IdpPageTasks.ClickSignInOnIdpPage( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            FormsPageTasks.EnterBadPassword( driver, configuration );

            // Perform test validation
            var success = IdpPageTasks.ValidateSignedIn( driver, configuration );
            Debug.Assert( success );

            // Cleanup
            driver.Quit();
        }

        #endregion

        #region Basic RP Sign On Tests
        /// <summary>
        /// ENVIRONMENT REQUIREMENTS:
        ///     1. Paginated UI feature enabled
        ///     2. Multiple auth options available 
        ///     3. Relying party exists, and user has access to it 
        /// </summary>
        /// <param name="driver"></param>
        static void BasicRpSignOn_WithOptions_Password( IWebDriver driver, TaskConfiguration configuration )
        {
            // Perform UI Operations
            RelyingPartyTasks.GoToRpSignIn( driver, configuration );
            FormsPageTasks.EnterCorrectUsername( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterBadPassword( driver, configuration );
            OptionsPageTasks.SelectFormsOnOptionPage( driver, configuration );
            FormsPageTasks.EnterCorrectPassword( driver, configuration );

            // Perform test validation
            var success = RelyingPartyTasks.ValidateRpIsSignedIn( driver, configuration );
            Debug.Assert( success );

            // Clean up 
            driver.Quit();
        }

        #endregion 
    }
}
