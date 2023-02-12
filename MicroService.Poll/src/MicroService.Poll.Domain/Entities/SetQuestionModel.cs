// <copyright file="SetQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Domain.Entities
{
    /// <summary>
    /// Model to insert a new question.
    /// </summary>
    public class SetQuestionModel
    {
        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Question { get; init; }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        public Uri ImageUrl { get; init; }

        /// <summary>
        /// Gets the thumb URL.
        /// </summary>
        /// <value>
        /// The thumb URL.
        /// </value>
        public Uri ThumbUrl { get; init; }

        /// <summary>
        /// Gets the choices.
        /// </summary>
        /// <value>
        /// The choices.
        /// </value>
        public IEnumerable<string> Choices { get; init; }
    }
}
