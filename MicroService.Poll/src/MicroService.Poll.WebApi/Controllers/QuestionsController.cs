// <copyright file="QuestionsController.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Controllers
{
    using AutoMapper;
    using Guards;
    using MicroService.Poll.Application.Services.Interfaces;
    using MicroService.Poll.WebApi.Models;
    using MicroService.Poll.WebApi.Models.Questions;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            var questionsFilter = this.mapper.Map<ApplicationModels.GetQuestionModel>(questionsModel);

            var fetchedQuestions = await this.questionService.GetQuestions(questionsFilter, ct);
            return this.Ok(fetchedQuestions);
        }

        /// <summary>
        /// Gets the question by id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ct">The <see cref="CancellationToken"/>.</param>
        /// <returns>Question.</returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetQuestionsById([FromRoute] int id, CancellationToken ct = default)
        {
            var fetchedQuestion = await this.questionService.GetQuestionById(id, ct);

            return fetchedQuestion == null ? this.NotFound() : this.Ok(fetchedQuestion);
        }

        /// <summary>Creates a new question.</summary>
        /// <param name="model">The question model.</param>
        /// <param name="ct">The <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// <see cref="StatusCodes.Status200OK" />, if the question were successfully inserted.<br />
        /// <see cref="StatusCodes.Status400BadRequest" />, if something wents wrong.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostQuestions([FromBody] PostQuestionModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            ApplicationModels.SetQuestionModel questionToInsert = this.mapper.Map<ApplicationModels.SetQuestionModel>(model);
            var insertedQuestion = await this.questionService.SetQuestion(questionToInsert, ct);

            return this.Ok(insertedQuestion);
        }

        /// <summary>Updates a question.</summary>
        /// <param name="id">The question id to update.</param>
        /// <param name="model">The question model.</param>
        /// <param name="ct">The <see cref="CancellationToken"/>.</param>
        /// <returns>
        /// <see cref="StatusCodes.Status200OK" />, if the question were successfully inserted.<br />
        /// <see cref="StatusCodes.Status400BadRequest" />, if something wents wrong.
        /// </returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutQuestions([FromRoute, BindRequired] int id, [FromBody] PutQuestionModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            ApplicationModels.UpdateQuestionModel questionToUpdate = this.mapper.Map<ApplicationModels.UpdateQuestionModel>(model);
            var updatedQuestion = await this.questionService.PutQuestion(id, questionToUpdate, ct);

            return this.Ok(updatedQuestion);
        }
    }
}
