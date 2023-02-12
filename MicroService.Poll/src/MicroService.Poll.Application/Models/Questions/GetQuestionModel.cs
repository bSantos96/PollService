// <copyright file="GetQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Models
{
    /// <summary>
    /// Model to get questions.
    /// </summary>
    public class GetQuestionModel
    {
        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        public int Limit { get; init; }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        public int Offset { get; init; }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string? Filter { get; set; }
    }
}
