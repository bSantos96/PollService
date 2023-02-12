// <copyright file="UpdateQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Domain.Entities
{
    /// <summary>
    /// Model to update questions.
    /// </summary>
    public class UpdateQuestionModel
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
        public IEnumerable<QuestionChoiceModel> Choices { get; init; }
    }
}
