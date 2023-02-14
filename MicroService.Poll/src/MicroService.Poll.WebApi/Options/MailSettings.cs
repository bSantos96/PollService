// <copyright file="MailSettings.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.WebApi.Options
{
    /// <summary>
    /// The mail settings.
    /// </summary>
    public class MailSettings
    {
        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; init; }

        /// <summary>
        /// Gets from.
        /// </summary>
        /// <value>
        /// From.
        /// </value>
        public string From { get; init; }

        /// <summary>
        /// Gets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; init; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; init; }

        /// <summary>
        /// Gets the port.
        /// </summary>
        /// <value>
        /// The port.
        /// </value>
        public int Port { get; init; }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; init; }

        /// <summary>
        /// Gets a value indicating whether [use SSL].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use SSL]; otherwise, <c>false</c>.
        /// </value>
        public bool UseSSL { get; init; }

        /// <summary>
        /// Gets a value indicating whether [use start TLS].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use start TLS]; otherwise, <c>false</c>.
        /// </value>
        public bool UseStartTls { get; init; }
    }
}
