//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using OpenQA.Selenium;

namespace AdfsUITestManager
{
    class TaskBase
    {
        public static void LogAndScreenshot( IWebDriver driver, TaskConfiguration config )
        {
            Console.WriteLine( $"Current Page Title: {driver.Title}" );
            if ( config.ScreenshotData.ShouldScreenshot )
            {
                Screenshot ss = ( ( ITakesScreenshot )driver ).GetScreenshot();
                ss.SaveAsFile( $"{ DateTime.Now:yyyy - MM - dd_hh - mm - ss - fff}.png", ScreenshotImageFormat.Png );
            }
        }
    }
}
