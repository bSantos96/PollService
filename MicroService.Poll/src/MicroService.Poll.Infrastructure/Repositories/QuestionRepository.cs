// <copyright file="QuestionRepository.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Infrastructure.Repositories
{
    using System.Diagnostics.CodeAnalysis;
    using AutoMapper;
    using Guards;
    using MicroService.Poll.Domain.Entities;
    using MicroService.Poll.Domain.Repositories;
    using MicroService.Poll.Infrastructure.Context;
    using Microsoft.EntityFrameworkCore;

    /// <inheritdoc/>
    public class QuestionRepository : IQuestionRepository
    {
        private readonly PollsContext context;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        public QuestionRepository(PollsContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyList<QuestionModel>> GetQuestions(GetQuestionModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            List<Question> fetchedQuestions = await this.context
                .Set<Question>()
                .Include(q => q.Answers)
                .AsNoTracking()
                .Skip(model.Offset)
                .Take(model.Limit)
                .ToListAsync(ct);

            return this.mapper.Map<IReadOnlyList<QuestionModel>>(fetchedQuestions);
        }

        /// <inheritdoc/>
        [SuppressMessage("Globalization", "CA1307:Specify StringComparison for clarity", Justification = "EFCore doesn't support StringComparision on Contains method.")]
        public async Task<IReadOnlyList<QuestionModel>> GetFilteredQuestions(GetFilteredQuestionModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            List<Question> filteredQuestions = await this.context
                .Set<Question>()
                .Include(q => q.Answers)
                .AsNoTracking()
                .Take(model.Limit)
                .Skip(model.Offset)
                .Where(q => q.QuestionText.Contains(model.Filter))
                .ToListAsync(ct);

            return this.mapper.Map<IReadOnlyList<QuestionModel>>(filteredQuestions);
        }

        /// <inheritdoc/>
        public async Task<QuestionModel> GetQuestionById(int id, CancellationToken ct)
        {
            var questionById = await this.context
                .Set<Question>()
                .Include(q => q.Answers)
                .AsNoTracking()
                .FirstOrDefaultAsync(q => q.QuestionId == id, ct);

            return this.mapper.Map<QuestionModel>(questionById);
        }

        /// <inheritdoc/>
        public async Task<QuestionModel> SetQuestion(SetQuestionModel questionToInsert, CancellationToken ct)
        {
            Guard.ArgumentNotNull(questionToInsert, nameof(questionToInsert));

            using (var transaction = await this.context.Database.BeginTransactionAsync(ct))
            {
                var insertedQuestion = this.mapper.Map<Question>(questionToInsert);

                this.context.Set<Question>().Add(insertedQuestion);
                await this.context.SaveChangesAsync(ct);

                await transaction.CommitAsync(ct);

                return this.mapper.Map<QuestionModel>(insertedQuestion);
            }
        }

        /// <inheritdoc/>
        public async Task<QuestionModel> UpdateQuestion(int questionId, UpdateQuestionModel questionToUpdate, CancellationToken ct)
        {
            Guard.ArgumentNotNull(questionToUpdate, nameof(questionToUpdate));

            using (var transaction = await this.context.Database.BeginTransactionAsync(ct))
            {
                var updatedQuestion = await this.context
                    .Set<Question>()
                    .Include(q => q.Answers)
                    .AsTracking()
                    .FirstOrDefaultAsync(q => q.QuestionId == questionId, ct);

                if (updatedQuestion != null)
                {
                    updatedQuestion.QuestionText = questionToUpdate.Question;
                    updatedQuestion.ImageUrl = questionToUpdate.ImageUrl.ToString();
                    updatedQuestion.ThumbUrl = questionToUpdate.ThumbUrl.ToString();
                    MapChoicesToAnswers(questionId, questionToUpdate.Choices, updatedQuestion.Answers);

                    await this.context.SaveChangesAsync(ct);
                }

                await transaction.CommitAsync(ct);

                return this.mapper.Map<QuestionModel>(updatedQuestion);
            }

            static void MapChoicesToAnswers(int questionId, IEnumerable<QuestionChoiceModel> choices, ICollection<Answer> answers)
            {
                answers = choices
                    .Select(c => new Answer
                    {
                        QuestionId = questionId,
                        AnswerText = c.Choice,
                        Votes = c.Votes,
                    })
                    .ToList();
            }
        }
    }
}
