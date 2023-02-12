// <copyright file="QuestionsController.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Controllers
{
    using AutoMapper;
    using Guards;
    using MicroService.Poll.Application.Services.Interfaces;
    using MicroService.Poll.WebApi.Models.Questions;
    using Microsoft.AspNetCore.Mvc;

    using ApplicationModels = MicroService.Poll.Application.Models;

    /// <summary>
    /// The questions controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService questionService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionsController"/> class.
        /// </summary>
        /// <param name="questionService">The <see cref="IQuestionService"/>.</param>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        public QuestionsController(IQuestionService questionService, IMapper mapper)
        {
            this.questionService = questionService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Gets all questions.
        /// </summary>
        /// <param name="questionsModel">The questions model.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>All questions based on a limit, offset and filter.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestions([FromQuery] GetQuestionsModel questionsModel, CancellationToken ct)
        {
            Guard.ArgumentNotNull(questionsModel, nameof(questionsModel));

            var questions = await this.questionService.GetQuestions(
                new ApplicationModels.GetQuestionModel
                {
                    Limit = questionsModel.Limit,
                    Offset = questionsModel.Offset,
                    Filter = questionsModel.Filter,
                }, ct);

            return this.Ok(questions);
        }
    }
}
