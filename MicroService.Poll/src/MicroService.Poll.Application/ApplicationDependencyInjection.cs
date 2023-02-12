// <copyright file="ApplicationDependencyInjection.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension class to define the depency injection on the Application layer.
    /// </summary>
    public static class ApplicationDependencyInjection
    {
        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromApplicationDependencies()
                    .AddClasses(type => type.Where(t => t.Namespace?.EndsWith("Application.Services", StringComparison.Ordinal) ?? false))
                    .AsImplementedInterfaces();
            });

            return services;
        }
    }
}
