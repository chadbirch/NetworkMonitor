/*
 * Copyright 2020 Chad Birch. All rights reserved.
 */

using System.IO;
using Microsoft.Extensions.Configuration;

namespace NetworkMonitor.Library.Configuration
{
    public class ConfigurationHelper
    {
        public static IConfiguration GetConfiguration()
        {
            // Get Configuration
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddUserSecrets<ConfigurationHelper>()
                .AddEnvironmentVariables()
                .Build();
        }
    }
}