// <copyright file="Question.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure.Context
{
    /// <summary>
    /// The question entity.
    /// </summary>
    public class Question
    {
        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public int QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the question text.
        /// </summary>
        /// <value>
        /// The question text.
        /// </value>
        public string QuestionText { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
#pragma warning disable CA1056 // URI-like properties should not be strings
        public string ImageUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

        /// <summary>
        /// Gets or sets the thumb URL.
        /// </summary>
        /// <value>
        /// The thumb URL.
        /// </value>
#pragma warning disable CA1056 // URI-like properties should not be strings
        public string ThumbUrl { get; set; }
#pragma warning restore CA1056 // URI-like properties should not be strings

        /// <summary>
        /// Gets or sets the creation date UTC.
        /// </summary>
        /// <value>
        /// The creation date UTC.
        /// </value>
        public DateTimeOffset CreationDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        /// <value>
        /// The answers.
        /// </value>
#pragma warning disable CA2227 // Collection properties should be read only
        public ICollection<Answer> Answers { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
