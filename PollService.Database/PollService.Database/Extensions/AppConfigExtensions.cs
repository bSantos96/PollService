// <copyright file="AppSettingsExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace PollService.Database.Extensions
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Extension class to perform operation on App_Config files.
    /// </summary>
    public static class AppConfigExtensions
    {
        /// <summary>
        /// Gets settings.
        /// </summary>
        /// <typeparam name="T">The settings type.</typeparam>
        /// <param name="appSettingsFile">The application settings file.</param>
        /// <returns>The mapped settings.json file.</returns>
        public static T GetSettings<T>(string appSettingsFile)
            where T : class
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "App_Config"))
                .AddJsonFile(appSettingsFile, optional: false)
                .Build();

            return configuration.Get<T>();
        }
    }
}
