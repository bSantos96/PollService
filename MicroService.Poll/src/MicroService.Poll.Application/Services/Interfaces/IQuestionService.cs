// <copyright file="IQuestionService.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Services.Interfaces
{
    using MicroService.Poll.Application.Models;
    using DomainEntities = MicroService.Poll.Domain.Entities;

    /// <summary>
    /// The question service.
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// Gets the questions.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>Questions and its Choices.</returns>
        Task<IReadOnlyList<DomainEntities.QuestionModel>> GetQuestions(GetQuestionModel model, CancellationToken ct);

        /// <summary>
        /// Gets the question by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>The <see cref="DomainEntities.QuestionModel"/>.</returns>
        Task<DomainEntities.QuestionModel> GetQuestionById(int id, CancellationToken ct);

        /// <summary>
        /// Sets the question.
        /// </summary>
        /// <param name="questionToInsert">The question to insert.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<DomainEntities.QuestionModel> SetQuestion(SetQuestionModel questionToInsert, CancellationToken ct);
    }
}
