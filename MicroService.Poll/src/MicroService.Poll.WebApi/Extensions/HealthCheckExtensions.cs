// <copyright file="HealthCheckExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Extensions
{
    using System;
    using MicroService.Poll.WebApi.Options;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.Extensions.Diagnostics.HealthChecks;

    /// <summary>
    /// Extension class to configure HealthCheck.
    /// </summary>
    public static class HealthCheckExtensions
    {
        /// <summary>
        /// Configures dependency injection with <see cref="AutoMapper"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IEndpointRouteBuilder"/>.</param>
        /// <returns>The <see cref="IEndpointConventionBuilder"/> configured.</returns>
        public static IEndpointConventionBuilder MapCustomHealthCheck(this IEndpointRouteBuilder builder)
        {
            HealthCheckSettings settings = AppSettingsExtensions
                .GetSettings<HealthCheckSettings>("HealthCheck.settings.json");

            return builder.MapHealthChecks(settings.Route, GetHealthCheckOptions(settings));
        }

        private static HealthCheckOptions GetHealthCheckOptions(HealthCheckSettings settings)
        {
            IDictionary<HealthStatus, int> resultStatusCodes = new Dictionary<HealthStatus, int>
            {
                { HealthStatus.Healthy, StatusCodes.Status200OK },
                { HealthStatus.Degraded, StatusCodes.Status200OK },
                { HealthStatus.Unhealthy, StatusCodes.Status503ServiceUnavailable },
            };

            return new HealthCheckOptions
            {
                ResponseWriter = GetResponseWriter(),
                ResultStatusCodes = resultStatusCodes,
            };

            Func<HttpContext, HealthReport, Task> GetResponseWriter()
            {
                return async (context, report) =>
                {
                    context.Response.ContentType = settings.ResponseContentType;

                    var response = new
                    {
                        Status = (report.Status == HealthStatus.Unhealthy)
                                ? "Service Unavailable. Please try again later."
                                : "Ok",
                    };

                    await context.Response.WriteAsJsonAsync(response);
                };
            }
        }
    }
}
