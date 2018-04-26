# AD FS Automated User Interface Testing

## Overview

This project provides a set of automated UI tests that can be performed to validate the user interface of an AD FS deployment. 
Note that in order to execute these tests, you must have either your own Selenium infrastructure, or a subscription to a remote Selenium infrastructure. 
This project is set up to support BrowserStack as the remote Selenium infrastructure. You can use a free BrowserStack subscription for 100 hours of testing, after which you will need a paid subscription.
For more details, see [BrowserStack](https://www.browserstack.com)


## Requirements

1. Visual Studio 

2. BrowserStack subscription, free trial, or custom Selenium infrastructure 

3. Internet access from your AD FS Domain Controller 


## Building the Project 

1. Open the `AdfsUITestManager.sln` solution in Visual Studio

2. In the project directory containing `AdfsUITestManager.csproj`, add an application configuration (`App.config`) file. Your `App.config` file should contain the following: 

        <?xml version="1.0" encoding="utf-8" ?>
        <configuration>
            <configSections>
              <sectionGroup name="taskConfigurationGroup">
                <section
                  name="taskConfiguration"
                  type="AdfsUITestManager.TaskConfiguration, AdfsUITestManager"
                  allowLocation="true"
                  allowDefinition="Everywhere" />
              </sectionGroup>
              <sectionGroup name="testListConfigurationGroup">
                <section
                  name="testListConfiguration"
                  type="AdfsUITestManager.TestListConfiguration, AdfsUITestManager"
                  allowLocation="true"
                  allowDefinition="Everywhere" />
              </sectionGroup>
            </configSections>
            <startup> 
                <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.5.2" />
            </startup>
            <appSettings>
              <add key="RemoteDriverUri" value="http://hub-cloud.browserstack.com/wd/hub/"/>
              <add key="BrowserStackUser" value=<ENTER BROWSERSTACK USERNAME>/>
              <add key="BrowserStackKey" value=<ENTER BROWSERTACK API KEY>/>
            </appSettings>
            <!-- Task Configuration -->
            <taskConfigurationGroup>
              <taskConfiguration>
                <farmData farmName=<ENTER FARMNAME>/>
                <userData correctUsername=<ENTER CORRECT USERNAME> 
                          correctPassword=<ENTER CORRECT PASSWORD>
                          badPassword="badpassword"
                          externalAuthUsername=<ENTER A USERNAME REGISTERED FOR EXTERNAL AUTH>
                          adminUsername=<ENTER ADMIN USERNAME>
                          badUsername="badUser@farm.com"
                          misformattedUsername="wronguser"
                          />
                <relyingPartyData name=<ENTER RP NAME>
                                  wtrealm=<ENTER WTREALM>
                                  wreply=<ENTER WREPLY>
                                  />
                <screenshot shouldScreenshot="true"/>
                <externalAuth challengeAnswers=<ENTER ANSWERS, COMMA SEPARATED> />
              </taskConfiguration>
            </taskConfigurationGroup>
            <!-- Test List Configuration -->
            <testListConfigurationGroup>
              <testListConfiguration>
                <testData testIds="BasicRpSignOn_WithOptions_Password" />
              </testListConfiguration>
            </testListConfigurationGroup>
        </configuration>

You can locate the BrowserStack settings [here](https://www.browserstack.com/automate/c-sharp)

3. Update the list of test IDs under the `<testListConfiguration>` element to include the comma-separated list of tests you wish to run against your environment. 
    The list of supported test cases is in `TestCases.cs`. If you wish to add more tests, please add them under `TestCases.cs`. 

4. Build the project using Visual Studio


## Setting Up Your Environment 

To execute the UI tests against your own AD FS environment, you must: 

**Deploy BrowserStack Test Agent**

1. Install the [BrowserStack local testing agent](https://www.browserstack.com/browserstack-local/BrowserStackLocal-win32.zip) on your AD FS Domain Controller.
For more details on BrowserStack local testing, see [here](https://www.browserstack.com/local-testing)

2. Determine your BrowserStack Automate Access Key, under ["Settings" > "Automate"](https://www.browserstack.com/accounts/settings)

3. Execute the BrowerStackLocal agent by running the following in a command prompt on your AD FS Domain Controller: 
    `BrowserStackLocal.exe --key <key>`


## Running the Tests

1. Decide what test cases you want to run. Note that different test cases have different environment requirements. You should only run the tests that match your environment. 
All test cases, along with the environment requirements, are listed in `TestCases.cs`. 

2. Update the list of test IDs under the `<testListConfiguration>` element to include the comma-separated list of tests you wish to run against your environment.

3. Execute the test manager by running:
    `.\AdfsUITestManager.exe`

## Validating the Results

You can find the BrowserStack results [here](https://www.browserstack.com/automate). These results will contain screenshots for all steps, along with a video you can review. 
Each test case validates that the user scenario works correctly, but it does not validate the "look and feel" of any customizations, branding, etc. you have applied. 
To ensure that the pages look and operate as you expect, we encourage you to manually examine the screenshots and video of the test runs. 

## Submitting AD FS UI Bugs 

If you find issues with the base AD FS User Interface, please open an [Issue](https://github.com/Microsoft/adfsUITests/issues) against this project. Please include the following information: 

1. Your AD FS Build Number and Behavior Level (major and minor, if applicable) 

2. A detailed description of the problem you see

3. Screenshots of the issue you see 


## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.