// <copyright file="Program.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi
{
    using System.Reflection;
    using MicroService.Poll.Application;
    using MicroService.Poll.Infrastructure;
    using MicroService.Poll.WebApi.Extensions;
    using Microsoft.Extensions.DependencyModel;

    /// <summary>
    /// This class has the entry point for the application.
    /// </summary>
    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                var applicationAssemblies = GetApplicationAssemblies();

                builder.Services.AddApplication();
                builder.Services.AddInfrastructure();

                builder.Services
                    .AddControllers()
                    .AddCustomFluentValidation(applicationAssemblies);

                builder.Services
                    .AddCustomAutoMapper(applicationAssemblies);

                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }

            var app = builder.Build();
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI(options =>
                    {
                        options.DefaultModelsExpandDepth(-1);
                    });
                }

                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
            }

            app.Run();
        }

        private static List<Assembly> GetApplicationAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>();

            foreach (var lib in DependencyContext.Default?.CompileLibraries ?? Enumerable.Empty<CompilationLibrary>())
            {
                try
                {
                    assemblies.Add(Assembly.Load(new AssemblyName(lib.Name)));
                }
#pragma warning disable CA1031 // Do not catch general exception types
                catch
                {
                }
#pragma warning restore CA1031 // Do not catch general exception types
            }

            return assemblies;
        }
    }
}
