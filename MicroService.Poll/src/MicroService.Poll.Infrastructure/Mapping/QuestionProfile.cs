// <copyright file="QuestionProfile.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Mapping
{
    using AutoMapper;
    using MicroService.Poll.Domain.Entities;
    using MicroService.Poll.Infrastructure.Context;

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
            this.CreateMap<Question, QuestionModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.QuestionId))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.QuestionText))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => new Uri(src.ImageUrl, UriKind.RelativeOrAbsolute)))
                .ForMember(dest => dest.ThumbUrl, opt => opt.MapFrom(src => new Uri(src.ThumbUrl, UriKind.RelativeOrAbsolute)))
                .ForMember(dest => dest.CreatedDateUtc, opt => opt.MapFrom(src => src.CreationDateUtc))
                .ForMember(dest => dest.Choices, opt => opt.MapFrom(src => src.Answers));

            this.CreateMap<SetQuestionModel, Question>()
                .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Question))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl.ToString()))
                .ForMember(dest => dest.ThumbUrl, opt => opt.MapFrom(src => src.ThumbUrl.ToString()))
                .ForMember(dest => dest.CreationDateUtc, opt => opt.MapFrom(src => DateTimeOffset.UtcNow))
                .ForMember(dest => dest.Answers, opt => opt.MapFrom(src => MapChoicesToAnswers(src.Choices)));

            this.CreateMap<Answer, QuestionChoiceModel>()
                .ForMember(dest => dest.Choice, opt => opt.MapFrom(src => src.AnswerText));
        }

        private static ICollection<Answer> MapChoicesToAnswers(IEnumerable<string> choices)
        {
            return choices
                .Select(choice => new Answer { AnswerText = choice })
                .ToList();
        }
    }
}
