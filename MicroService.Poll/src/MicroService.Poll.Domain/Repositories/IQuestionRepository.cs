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

        /// <summary>
        /// Gets the question by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>The <see cref="QuestionModel"/>.</returns>
        Task<QuestionModel> GetQuestionById(int id, CancellationToken ct);

        /// <summary>
        /// Sets the question.
        /// </summary>
        /// <param name="questionToInsert">The question to insert.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>The inserted question.</returns>
        Task<QuestionModel> SetQuestion(SetQuestionModel questionToInsert, CancellationToken ct);
    }
}
