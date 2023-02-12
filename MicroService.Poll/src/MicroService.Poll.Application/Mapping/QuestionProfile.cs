// <copyright file="QuestionProfile.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Mapping
{
    using AutoMapper;
    using ApplicationModels = MicroService.Poll.Application.Models;
    using DomainEntities = MicroService.Poll.Domain.Entities;

    /// <summary>
    /// <see cref="Profile"/> that configures the mapping for the question models.
    /// </summary>
    public class QuestionProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionProfile"/> class.
        /// </summary>
        public QuestionProfile()
        {
            this.CreateMap<ApplicationModels.GetQuestionModel, DomainEntities.GetQuestionModel>();
            this.CreateMap<ApplicationModels.GetQuestionModel, DomainEntities.GetFilteredQuestionModel>();
        }
    }
}
