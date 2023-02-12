// <copyright file="PutQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Models
{
    /// <summary>
    /// Model to update questions.
    /// </summary>
    public class PutQuestionModel
    {
        /// <summary>
        /// Gets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        // [JsonProperty(Required = Required.Always)]
        public string Question { get; init; }

        /// <summary>
        /// Gets the image URL.
        /// </summary>
        /// <value>
        /// The image URL.
        /// </value>
        // [JsonProperty(Required = Required.Always)]
        public Uri ImageUrl { get; init; }

        /// <summary>
        /// Gets the thumb URL.
        /// </summary>
        /// <value>
        /// The thumb URL.
        /// </value>
        // [JsonProperty(Required = Required.Always)]
        public Uri ThumbUrl { get; init; }

        /// <summary>
        /// Gets the choices.
        /// </summary>
        /// <value>
        /// The choices.
        /// </value>
        // [JsonProperty(Required = Required.Always)]
        public List<PutChoiceModel> Choices { get; init; }
    }
}
