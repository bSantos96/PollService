// <copyright file="ShareProfile.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Mapping
{
    using AutoMapper;
    using MicroService.Poll.WebApi.Models.Share;
    using MicroService.Poll.WebApi.Options;
    using ApplicationModels = Application.Models;

    /// <summary>
    /// <see cref="Profile"/> that configures the mapping for the question models.
    /// </summary>
    public class ShareProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShareProfile"/> class.
        /// </summary>
        public ShareProfile()
        {
            this.CreateMap<ShareModel, ApplicationModels.ShareModel>();
            this.CreateMap<MailSettings, ApplicationModels.MailSettingsModel>();
        }
    }
}
