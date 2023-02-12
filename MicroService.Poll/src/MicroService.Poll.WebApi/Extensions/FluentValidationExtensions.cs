// <copyright file="FluentValidationExtensions.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Extensions
{
    using System.Reflection;
    using FluentValidation.AspNetCore;

    /// <summary>
    /// FluentValidation extensions for dependency injection.
    /// </summary>
    public static class FluentValidationExtensions
    {
        /// <summary>
        /// Configures dependency injection with FluentValidation.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <param name="assemblies">The scanned assemblies.</param>
        /// <returns>The <see cref="IMvcBuilder"/> configured.</returns>
        public static IMvcBuilder AddCustomFluentValidation(this IMvcBuilder builder, IEnumerable<Assembly> assemblies)
        {
            return builder.AddFluentValidation(fvc =>
            {
                foreach (var assembly in assemblies)
                {
                    fvc.RegisterValidatorsFromAssembly(assembly);
                }

                fvc.LocalizationEnabled = false;
                fvc.ImplicitlyValidateChildProperties = true;
                fvc.ImplicitlyValidateRootCollectionElements = true;
            });
        }
    }
}
