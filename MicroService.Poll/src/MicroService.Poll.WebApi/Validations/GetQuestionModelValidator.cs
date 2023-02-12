// <copyright file="GetQuestionModelValidator.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Validations
{
    using FluentValidation;
    using MicroService.Poll.WebApi.Models;
    using MicroService.Poll.WebApi.Models.Questions;

    /// <summary>
    /// Validations for <see cref="GetQuestionsModel"/>.
    /// </summary>
    public class GetQuestionModelValidator : AbstractValidator<GetQuestionsModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetQuestionModelValidator"/> class.
        /// </summary>
        public GetQuestionModelValidator()
        {
            this.RuleFor(x => x.Limit)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The limit parameter must be positive.");

            this.RuleFor(x => x.Offset)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The offset parameter must be positive.");

            this.RuleFor(x => x.Filter)
                .NotEmpty()
                .WithMessage("The filter parameter can't be empty.")
                .MaximumLength(255)
                .WithMessage("The filter parameter must can't be greater than 255 characters.")
                .When(x => x.Filter != null);
        }
    }
}
