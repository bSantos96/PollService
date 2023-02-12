// <copyright file="QuestionService.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Services
{
    using AutoMapper;
    using Guards;
    using MicroService.Poll.Application.Services.Interfaces;
    using MicroService.Poll.Domain.Entities;
    using MicroService.Poll.Domain.Repositories;

    using ApplicationModels = Models;
    using DomainEntities = Domain.Entities;

    /// <inheritdoc/>
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository questionRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionService"/> class.
        /// </summary>
        /// <param name="questionRepository">The question repository.</param>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        public QuestionService(IQuestionRepository questionRepository, IMapper mapper)
        {
            this.questionRepository = questionRepository;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public Task<IReadOnlyList<DomainEntities.QuestionModel>> GetQuestions(ApplicationModels.GetQuestionModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            if (model.Filter == null)
            {
                return this.questionRepository.GetQuestions(this.mapper.Map<DomainEntities.GetQuestionModel>(model), ct);
            }

            return this.questionRepository.GetFilteredQuestions(this.mapper.Map<DomainEntities.GetFilteredQuestionModel>(model), ct);
        }

        /// <inheritdoc/>
        public Task<QuestionModel> GetQuestionById(int id, CancellationToken ct)
        {
            return this.questionRepository.GetQuestionById(id, ct);
        }

        /// <inheritdoc/>
        public async Task<DomainEntities.QuestionModel> SetQuestion(ApplicationModels.SetQuestionModel questionToInsert, CancellationToken ct)
        {
            Guard.ArgumentNotNull(questionToInsert, nameof(questionToInsert));

            DomainEntities.SetQuestionModel insert = this.mapper.Map<DomainEntities.SetQuestionModel>(questionToInsert);

            return await this.questionRepository.SetQuestion(insert, ct);
        }

        /// <inheritdoc/>
        public async Task<DomainEntities.QuestionModel> PutQuestion(int id, ApplicationModels.UpdateQuestionModel questionToUpdate, CancellationToken ct)
        {
            Guard.ArgumentNotNull(questionToUpdate, nameof(questionToUpdate));

            DomainEntities.UpdateQuestionModel update = this.mapper.Map<DomainEntities.UpdateQuestionModel>(questionToUpdate);

            return await this.questionRepository.UpdateQuestion(id, update, ct);
        }
    }
}
