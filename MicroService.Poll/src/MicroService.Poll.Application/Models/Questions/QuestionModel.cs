// <copyright file="QuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Models
{
    /// <summary>
    /// Model to get the questions and its choices.
    /// </summary>
    public class QuestionModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public Uri ImageUrl { get; set; }

        /// <summary>
        /// Gets or sets the thumb URL.
        /// </summary>
        /// <value>
        /// The thumb URL.
        /// </value>
        public Uri ThumbUrl { get; set; }

        /// <summary>
        /// Gets or sets the created date UTC.
        /// </summary>
        /// <value>
        /// The created date UTC.
        /// </value>
        public DateTimeOffset CreatedDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the choices.
        /// </summary>
        /// <value>
        /// The choices.
        /// </value>
        public IEnumerable<QuestionChoiceModel> Choices { get; set; }
    }
}
