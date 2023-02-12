// <copyright file="DatabaseSettings.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Options
{
    /// <summary>
    /// Health Check Settings.
    /// </summary>
    public class DatabaseSettings
    {
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; init; }
    }
}
