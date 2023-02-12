// <copyright file="QuestionProfile.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Mapping
{
    using AutoMapper;
    using MicroService.Poll.WebApi.Models;
    using MicroService.Poll.WebApi.Models.Questions;
    using ApplicationModels = Application.Models;

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
            this.CreateMap<GetQuestionsModel, ApplicationModels.GetQuestionModel>();
            this.CreateMap<PostQuestionModel, ApplicationModels.SetQuestionModel>();
        }
    }
}
