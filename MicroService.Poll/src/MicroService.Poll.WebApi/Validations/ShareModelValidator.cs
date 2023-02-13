// <copyright file="ShareModelValidator.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Validations
{
    using FluentValidation;
    using MicroService.Poll.WebApi.Models.Share;

    /// <summary>
    /// Validations for <see cref="ShareModel"/>.
    /// </summary>
    public class ShareModelValidator : AbstractValidator<ShareModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareModelValidator"/> class.
        /// </summary>
        public ShareModelValidator()
        {
            this.RuleFor(x => x.DestinationEmail)
                .EmailAddress();

            this.RuleFor(x => x.ContentUrl)
                .NotNull()
                .NotEmpty();
        }
    }
}
