// <copyright file="AutoMapperExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Extensions
{
    using System.Reflection;

    /// <summary>
    /// <see cref="AutoMapper"/> extensions for dependency injection.
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// Configures dependency injection with <see cref="AutoMapper"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <param name="assemblies">The scanned assemblies.</param>
        /// <returns>The <see cref="IServiceCollection"/> configured.</returns>
        public static IServiceCollection AddCustomAutoMapper(this IServiceCollection services, IEnumerable<Assembly> assemblies)
        {
            return services.AddAutoMapper(assemblies);
        }
    }
}
