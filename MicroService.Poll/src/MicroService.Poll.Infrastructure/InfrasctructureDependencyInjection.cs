// <copyright file="InfrasctructureDependencyInjection.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure
{
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Extension class to define the depency injection on the Infrastructure layer.
    /// </summary>
    public static class InfrasctructureDependencyInjection
    {
        /// <summary>
        /// Adds the application.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns>The <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(scan =>
            {
                scan.FromApplicationDependencies()
                    .AddClasses(type => type.Where(t => t.Namespace?.EndsWith("Infrastructure.Repositories", StringComparison.Ordinal) ?? false))
                    .AsImplementedInterfaces();
            });

            return services;
        }
    }
}
