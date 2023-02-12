// <copyright file="HealthCheckSettings.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Options
{
    using System.Net;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    /// <summary>
    /// Health Check Settings.
    /// </summary>
    public class HealthCheckSettings
    {
        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public string Route { get; init; }

        /// <summary>
        /// Gets the type of the response content.
        /// </summary>
        /// <value>
        /// The type of the response content.
        /// </value>
        public string ResponseContentType { get; init; }
    }
}
