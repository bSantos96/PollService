// <copyright file="ShareModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Models
{
    using System;

    /// <summary>
    /// The share model.
    /// </summary>
    public class ShareModel
    {
        /// <summary>
        /// Gets the receiver email.
        /// </summary>
        /// <value>
        /// The receiver email.
        /// </value>
        public string DestinationEmail { get; init; }

        /// <summary>
        /// Gets the content url.
        /// </summary>
        /// <value>
        /// The content url.
        /// </value>
        public Uri ContentUrl { get; init; }
    }
}
