// <copyright file="AppSettingsExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Shared.Extensions
{
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Extension class for AppSettings files.
    /// </summary>
    public static class AppSettingsExtensions
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
            var configuration = GetConfiguration(appSettingsFile);
            return configuration.Get<T>();
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <param name="appSettingsFile">The application settings file.</param>
        /// <returns>The <see cref="IConfiguration"/>.</returns>
        public static IConfiguration GetConfiguration(string appSettingsFile)
        {
            return new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "App_Config"))
                .AddJsonFile(appSettingsFile, optional: false)
                .Build();
        }
    }
}
