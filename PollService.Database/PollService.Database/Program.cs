// <copyright file="Program.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace PollService.Database
{
    using DbUp;
    using DbUp.Engine;
    using PollService.Database.Extensions;
    using PollService.Database.Options;
    using System.Reflection;

    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>Result of app execution.</returns>
        static int Main(string[] args)
        {
            var result = UpgradeDatabase();
            return ProcessResult(result);
        }
        
        private static DatabaseUpgradeResult UpgradeDatabase()
        {
            var connectionString = AppConfigExtensions
                .GetSettings<DatabaseSettings>("Database.settings.json")
                .ConnectionString;

            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            EnsureDatabase.For.SqlDatabase(connectionString);

            return upgrader.PerformUpgrade();
        }

        private static int ProcessResult(DatabaseUpgradeResult result)
        {
            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Success");
            Console.ResetColor();

            return 0;
        }
    }
}