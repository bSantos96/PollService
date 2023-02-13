// <copyright file="ShareController.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Controllers
{
    using AutoMapper;
    using Guards;
    using MicroService.Poll.Application.Services.Interfaces;
    using MicroService.Poll.WebApi.Attributes;
    using MicroService.Poll.WebApi.Models.Share;
    using MicroService.Poll.WebApi.Options;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using ApplicationModels = MicroService.Poll.Application.Models;

    /// <summary>
    /// The questions controller.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ShareController : ControllerBase
    {
        private readonly MailSettings mailSettings;
        private readonly IShareService shareService;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShareController"/> class.
        /// </summary>
        /// <param name="mailSettings">The <see cref="MailSettings"/>.</param>
        /// <param name="shareService">The <see cref="IShareService"/>.</param>
        /// <param name="mapper">The <see cref="IMapper"/>.</param>
        public ShareController(IOptions<MailSettings> mailSettings, IShareService shareService, IMapper mapper)
        {
            this.mailSettings = mailSettings?.Value;
            this.shareService = shareService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Sends an email with an url.
        /// </summary>
        /// <param name="model">The share model.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>
        /// <see cref="StatusCodes.Status200OK" />, if the email has been sent successufully<br />
        /// <see cref="StatusCodes.Status400BadRequest" />, if something wents wrong.
        /// </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ValidateModelState(ErrorMessage = "Bad Request. Either destination_email not valid or empty content_url", PrintSuccessMessage = true)]
        public async Task<IActionResult> Share([FromQuery] ShareModel model, CancellationToken ct)
        {
            Guard.ArgumentNotNull(model, nameof(model));

            var shareModel = this.mapper.Map<ApplicationModels.ShareModel>(model);
            var mailSettingsModel = this.mapper.Map<ApplicationModels.MailSettingsModel>(this.mailSettings);

            return await this.shareService.Share(shareModel, mailSettingsModel, ct)
                ? this.Ok()
                : this.BadRequest();
        }
    }
}
