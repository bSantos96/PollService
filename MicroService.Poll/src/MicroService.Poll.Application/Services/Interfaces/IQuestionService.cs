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
    }
}
