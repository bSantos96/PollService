// <copyright file="PollsContext.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure.Context
{
    using System.Diagnostics.CodeAnalysis;
    using Guards;
    using MicroService.Poll.Infrastructure.Context.Configurations;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The poll database context.
    /// </summary>
    /// <seealso cref="DbContext" />
    public class PollsContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PollsContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public PollsContext([NotNull] DbContextOptions options)
            : base(options)
        {
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guard.ArgumentNotNull(modelBuilder, nameof(modelBuilder));

            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
        }
    }
}
