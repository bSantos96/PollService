// <copyright file="PutChoiceModelValidator.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Validations
{
    using FluentValidation;
    using MicroService.Poll.WebApi.Models;

    /// <summary>
    /// Validations for <see cref="PutChoiceModel"/>.
    /// </summary>
    public class PutChoiceModelValidator : AbstractValidator<PutChoiceModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PutChoiceModelValidator"/> class.
        /// </summary>
        public PutChoiceModelValidator()
        {
            this.RuleFor(x => x.Choice)
                .NotEmpty()
                .MaximumLength(255)
                .WithMessage("The question property must not be empty and must be lower than 255 characters.");

            this.RuleFor(x => x.Votes)
                .GreaterThanOrEqualTo(0)
                .WithMessage("The quantity of votes must be greater or equal to zero.");
        }
    }
}
