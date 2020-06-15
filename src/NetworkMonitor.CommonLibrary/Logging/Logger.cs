/*
 * Copyright 2020 Chad Birch. All rights reserved.
 */

using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace NetworkMonitor.Library.Logging
{
    /// <summary>
    /// Handle creation of the Logger
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Creates a logger for the
        /// </summary>
        /// <typeparam name="T">The caller represented as a Type</typeparam>
        public static void CreateLogger<T>(IConfiguration configuration = null)
        {
            // Create the LoggerConfiguration with default configuration.
            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails();

            loggerConfiguration = loggerConfiguration.WriteTo.Console(
               applyThemeToRedirectedOutput: true,
               outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}");

            if (configuration != null)
                loggerConfiguration = loggerConfiguration.ReadFrom.Configuration(configuration);

            Log.Logger = loggerConfiguration
                .CreateLogger()
                .ForContext<T>();
        }
    }
}