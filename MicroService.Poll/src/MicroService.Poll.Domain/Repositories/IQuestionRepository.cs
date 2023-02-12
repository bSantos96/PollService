// <copyright file="IQuestionRepository.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Domain.Repositories
{
    using MicroService.Poll.Domain.Entities;

    /// <summary>
    /// The question repository.
    /// </summary>
    public interface IQuestionRepository
    {
        /// <summary>
        /// Gets the questions.
        /// </summary>
        /// <param name="model">Settings to get the questions.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>The questions.</returns>
        Task<IReadOnlyList<QuestionModel>> GetQuestions(GetQuestionModel model, CancellationToken ct);

        /// <summary>
        /// Gets the filtered questions.
        /// </summary>
        /// <param name="model">Settings to get the filtered questions.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>The filtered questions.</returns>
        Task<IReadOnlyList<QuestionModel>> GetFilteredQuestions(GetFilteredQuestionModel model, CancellationToken ct);
    }
}
