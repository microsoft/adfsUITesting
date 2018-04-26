//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;

namespace AdfsUITestManager
{
    class TestListConfiguration : ConfigurationSection
    {
        [ConfigurationProperty( "testData" )]
        public TestDataElement TestData
        {
            get
            {
                return ( TestDataElement )this[ "testData" ];
            }
            set
            { this[ "testData" ] = value; }
        }

        public class TestDataElement : ConfigurationElement
        {
            [ConfigurationProperty( "testIds", IsRequired = true )]
            public string TestIdsString
            {
                get
                {
                    return ( String )this[ "testIds" ];
                }
            }

            public List<String> TestIds
            {
                get
                {
                    List<string> answers = new List<string>( TestIdsString.Split( ',' ) );
                    return answers;
                }
            }
        }


    }
}
