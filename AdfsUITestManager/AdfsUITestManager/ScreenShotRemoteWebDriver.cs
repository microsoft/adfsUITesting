//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace AdfsUITestManager
{
    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenShotRemoteWebDriver( Uri uri, DesiredCapabilities dc )
            : base( uri, dc )
        {
        }

        public Screenshot GetScreenshot()
        {
            Response screenshotResponse = this.Execute( DriverCommand.Screenshot, null );
            string base64 = screenshotResponse.Value.ToString();
            return new Screenshot( base64 );
        }
    }
}
