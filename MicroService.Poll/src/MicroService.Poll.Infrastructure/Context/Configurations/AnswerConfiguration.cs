// <copyright file="AnswerConfiguration.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure.Context.Configurations
{
    using Guards;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// Answer Configuration.
    /// </summary>
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            Guard.ArgumentNotNull(builder, nameof(builder));

            builder
                .ToTable(tb => tb.HasTrigger("TR_Answer_LastUpdateDateUtc"));

            builder
                .Property(q => q.AnswerText)
                .HasColumnName("Answer");

            builder
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers);

            builder.HasKey(q => q.AnswerId);
        }
    }
}
