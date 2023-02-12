// <copyright file="PutChoiceModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Models
{
    /// <summary>
    /// Model to update choices.
    /// </summary>
    public class PutChoiceModel
    {
        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Choice { get; init; }

        /// <summary>
        /// Gets the votes.
        /// </summary>
        /// <value>
        /// The votes.
        /// </value>
        public int Votes { get; init; }
    }
}
