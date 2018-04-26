//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace AdfsUITestManager
{
    class TaskConfigurationFactory
    {
        public static TaskConfiguration GetConfiguration()
        {
            TaskConfiguration config = ( TaskConfiguration ) System.Configuration.ConfigurationManager.GetSection( "taskConfigurationGroup/taskConfiguration" );
            return config;
        }
    }
}
