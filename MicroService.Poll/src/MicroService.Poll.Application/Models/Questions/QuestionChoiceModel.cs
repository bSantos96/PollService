// <copyright file="QuestionChoiceModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Models
{
    /// <summary>
    /// Question choice model.
    /// </summary>
    public class QuestionChoiceModel
    {
        /// <summary>
        /// Gets or sets the choice.
        /// </summary>
        /// <value>
        /// The choice.
        /// </value>
        public string Choice { get; set; }

        /// <summary>
        /// Gets or sets the votes.
        /// </summary>
        /// <value>
        /// The votes.
        /// </value>
        public int Votes { get; set; }
    }
}
