// <copyright file="EntityFrameworkExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Extensions
{
    using System.Reflection;
    using MicroService.Poll.Infrastructure.Context;
    using MicroService.Poll.WebApi.Options;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="EntityFramework"/> extensions for dependency injection.
    /// </summary>
    public static class EntityFrameworkExtensions
    {
        /// <summary>
        /// Configures dependency injection with <see cref="EntityFramework"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> configured.</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            string connectionString = AppSettingsExtensions
                .GetSettings<DatabaseSettings>("Database.settings.json")
                .ConnectionString;

            return services
                .AddDbContext<PollsContext>((provider, options) => options.UseSqlServer(connectionString));
        }
    }
}
