// <copyright file="QuestionConfiguration.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure.Context.Configurations
{
    using Guards;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Question Configuration.
    /// </summary>
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            Guard.ArgumentNotNull(builder, nameof(builder));

            builder
                .Property(q => q.QuestionText)
                .HasColumnName("Question");

            builder
                .HasMany(q => q.Answers)
                .WithOne(q => q.Question);

            builder.HasKey(q => q.QuestionId);
        }
    }
}
