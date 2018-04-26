//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System.Configuration;
using System;
using System.Collections.Generic;

namespace AdfsUITestManager
{
    public class TaskConfiguration : ConfigurationSection
    {
        [ConfigurationProperty( "farmData" )]
        public FarmDataElement Farm
        {
            get
            {
                return ( FarmDataElement )this[ "farmData" ];
            }
            set
            { this[ "farmData" ] = value; }
        }

        [ConfigurationProperty( "userData" )]
        public UserDataElement User
        {
            get
            {
                return ( UserDataElement )this[ "userData" ];
            }
            set
            { this[ "userData" ] = value; }
        }

        [ConfigurationProperty( "relyingPartyData" )]
        public RelyingPartyDataElement RelyingPartyData
        {
            get
            {
                return ( RelyingPartyDataElement )this[ "relyingPartyData" ];
            }
            set
            { this[ "relyingPartyData" ] = value; }
        }

        [ConfigurationProperty( "screenshot" )]
        public ScreenshotDataElement ScreenshotData
        {
            get
            {
                return ( ScreenshotDataElement )this[ "screenshot" ];
            }
            set
            { this[ "screenshot" ] = value; }
        }

        [ConfigurationProperty( "externalAuth" )]
        public ExternalAuthDataElement ExternalAuth
        {
            get
            {
                return ( ExternalAuthDataElement )this[ "externalAuth" ];
            }
            set
            { this[ "externalAuth" ] = value; }
        }
    }

    public class ExternalAuthDataElement : ConfigurationElement
    {
        [ConfigurationProperty( "challengeAnswers", IsRequired = true )]
        public string AnswersString
        {
            get
            {
                return ( String )this[ "challengeAnswers" ];
            }
        }

        public List<String> Answers
        {
            get
            {
                List<string> answers = new List<string>( AnswersString.Split( ',' ) );
                return answers;
            }
        }
    }

    public class ScreenshotDataElement : ConfigurationElement
    {
        [ConfigurationProperty( "shouldScreenshot", IsRequired = true )]
        public Boolean ShouldScreenshot
        {
            get
            {
                return ( Boolean )this[ "shouldScreenshot" ];
            }
            set
            {
                this[ "shouldScreenshot" ] = value;
            }
        }
    }

    public class RelyingPartyDataElement : ConfigurationElement
    {
        [ConfigurationProperty( "name", IsRequired = true )]
        public String Name
        {
            get
            {
                return ( String )this[ "name" ];
            }
            set
            {
                this[ "name" ] = value;
            }
        }

        [ConfigurationProperty( "wtrealm", IsRequired = true )]
        public String Wtrealm
        {
            get
            {
                return ( String )this[ "wtrealm" ];
            }
            set
            {
                this[ "wtrealm" ] = value;
            }
        }

        [ConfigurationProperty( "wreply", IsRequired = true )]
        public String Wreply
        {
            get
            {
                return ( String )this[ "wreply" ];
            }
            set
            {
                this[ "wreply" ] = value;
            }
        }
    }

    public class FarmDataElement : ConfigurationElement
    {
        [ConfigurationProperty( "farmName", IsRequired = true )]
        public String FarmName
        {
            get
            {
                return ( String )this[ "farmName" ];
            }
            set
            {
                this[ "farmName" ] = value;
            }
        }
    }

    public class UserDataElement : ConfigurationElement
    {
        [ConfigurationProperty( "misformattedUsername", IsRequired = true )]
        public String MisformattedUsername
        {
            get
            {
                return ( String )this[ "misformattedUsername" ];
            }
            set
            {
                this[ "misformattedUsername" ] = value;
            }
        }

        [ConfigurationProperty( "correctUsername", IsRequired = true )]
        public String CorrectUsername
        {
            get
            {
                return ( String )this[ "correctUsername" ];
            }
            set
            {
                this[ "correctUsername" ] = value;
            }
        }

        [ConfigurationProperty( "correctPassword", IsRequired = true )]
        public String CorrectPassword
        {
            get
            {
                return ( String )this[ "correctPassword" ];
            }
            set
            {
                this[ "correctPassword" ] = value;
            }
        }
        [ConfigurationProperty( "badPassword", IsRequired = true )]
        public String BadPassword
        {
            get
            {
                return ( String )this[ "badPassword" ];
            }
            set
            {
                this[ "badPassword" ] = value;
            }
        }
        [ConfigurationProperty( "externalAuthUsername", IsRequired = true )]
        public String ExternalAuthUsername
        {
            get
            {
                return ( String )this[ "externalAuthUsername" ];
            }
            set
            {
                this[ "externalAuthUsername" ] = value;
            }
        }
        [ConfigurationProperty( "adminUsername", IsRequired = true )]
        public String AdminUsername
        {
            get
            {
                return ( String )this[ "adminUsername" ];
            }
            set
            {
                this[ "adminUsername" ] = value;
            }
        }
        [ConfigurationProperty( "badUsername", IsRequired = true )]
        public String BadUsername
        {
            get
            {
                return ( String )this[ "badUsername" ];
            }
            set
            {
                this[ "badUsername" ] = value;
            }
        }
    }


}
