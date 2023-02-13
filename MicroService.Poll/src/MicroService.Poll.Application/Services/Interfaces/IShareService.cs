// <copyright file="IShareService.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Services.Interfaces
{
    using MicroService.Poll.Application.Models;

    /// <summary>
    /// The share service.
    /// </summary>
    public interface IShareService
    {
        /// <summary>
        /// Send email to the destination containing an url.
        /// </summary>
        /// <param name="shareModel">The share model.</param>
        /// <param name="mailSettingsModel">The mail settings model.</param>
        /// <param name="ct">The ct.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        Task<bool> Share(ShareModel shareModel, MailSettingsModel mailSettingsModel, CancellationToken ct);
    }
}
