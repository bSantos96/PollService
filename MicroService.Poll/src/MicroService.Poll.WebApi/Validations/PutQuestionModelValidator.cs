// <copyright file="PutQuestionModelValidator.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Validations
{
    using FluentValidation;
    using MicroService.Poll.WebApi.Models;

    /// <summary>
    /// Validations for <see cref="PutQuestionModel"/>.
    /// </summary>
    public class PutQuestionModelValidator : AbstractValidator<PutQuestionModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutQuestionModelValidator"/> class.
        /// </summary>
        public PutQuestionModelValidator()
        {
            this.RuleFor(x => x.Question)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("The question property must not be empty and must be lower than 255 characters.");

            this.RuleFor(x => x.ImageUrl)
                .NotEmpty();

            this.RuleFor(x => x.ImageUrl.ToString())
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("The ImageUrl path must not be empty and must be lower than 255 characters.")
                .When(x => x.ImageUrl != null);

            this.RuleFor(x => x.ThumbUrl)
                .NotEmpty();

            this.RuleFor(x => x.ThumbUrl.ToString())
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("The ImageUrl path must not be empty and must be lower than 255 characters.")
                .When(x => x.ThumbUrl != null);

            this.RuleFor(x => x.Choices)
                .NotEmpty()
                .Must(x => x?.Count >= 2)
                .WithMessage("Must be passed at least two choices for each question.");
        }
    }
}
