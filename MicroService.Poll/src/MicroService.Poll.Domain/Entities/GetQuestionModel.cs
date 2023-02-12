// <copyright file="GetQuestionModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Domain.Entities
{
    /// <summary>
    /// Model to get questions base on a limit and an offset.
    /// </summary>
    public class GetQuestionModel
    {
        /// <summary>Gets the limit.</summary>
        /// <value>The limit.</value>
        public int Limit { get; init; }

        /// <summary>Gets the offset.</summary>
        /// <value>The offset.</value>
        public int Offset { get; init; }
    }
}
