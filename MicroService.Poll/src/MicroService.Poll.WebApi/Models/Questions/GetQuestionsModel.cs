// <copyright file="GetQuestionsModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Models.Questions
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    /// <summary>
    /// Model to get questions.
    /// </summary>
    [BindProperties]
    public class GetQuestionsModel
    {
        /// <summary>
        /// Gets the limit.
        /// </summary>
        /// <value>
        /// The limit.
        /// </value>
        [BindRequired]
        [BindingBehavior(BindingBehavior.Required)]
        public int Limit { get; init; }

        /// <summary>
        /// Gets the offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        [BindRequired]
        [BindingBehavior(BindingBehavior.Required)]
        public int Offset { get; init; }

        /// <summary>
        /// Gets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        [BindingBehavior(BindingBehavior.Optional)]
        public string? Filter { get; init; }
    }
}
