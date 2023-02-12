// <copyright file="GetFilteredQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Domain.Entities
{
    /// <summary>
    /// Model to get the filtered questions.
    /// </summary>
    public class GetFilteredQuestionModel
    {
        /// <summary>
        /// Gets the limit value.
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
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter { get; init; }
    }
}
