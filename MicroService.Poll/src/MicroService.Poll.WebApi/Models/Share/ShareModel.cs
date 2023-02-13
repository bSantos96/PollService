// <copyright file="ShareModel.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Models.Share
{
    /// <summary>
    /// The share model.
    /// </summary>
    public class ShareModel
    {
        /// <summary>
        /// Gets or sets the destination email.
        /// </summary>
        /// <value>
        /// The destination email.
        /// </value>
        public string DestinationEmail { get; set; }

        /// <summary>
        /// Gets or sets the content URL.
        /// </summary>
        /// <value>
        /// The content URL.
        /// </value>
        public Uri ContentUrl { get; set; }
    }
}
