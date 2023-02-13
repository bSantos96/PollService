// <copyright file="ShareService.cs" company="Bruno Santos">
// Copyright (c) Bruno Santos. All rights reserved.
// </copyright>

namespace MicroService.Poll.Application.Services
{
    using System.Runtime;
    using System.Threading;
    using System.Threading.Tasks;
    using Guards;
    using MailKit.Net.Smtp;
    using MailKit.Security;
    using MicroService.Poll.Application.Models;
    using MicroService.Poll.Application.Services.Interfaces;
    using MimeKit;

    /// <inheritdoc/>
    public class ShareService : IShareService
    {
        /// <inheritdoc/>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Just want to return the result of smtp request.")]
        public async Task<bool> Share(ShareModel shareModel, MailSettingsModel mailSettingsModel, CancellationToken ct)
        {
            Guard.ArgumentNotNull(shareModel, nameof(shareModel));
            Guard.ArgumentNotNull(mailSettingsModel, nameof(mailSettingsModel));

            try
            {
                using (var mail = new MimeMessage())
                {
                    SetMailMessage(mail, shareModel, mailSettingsModel);

                    using (SmtpClient smtp = new SmtpClient())
                    {
                        if (mailSettingsModel.UseSSL)
                        {
                            await smtp.ConnectAsync(mailSettingsModel.Host, mailSettingsModel.Port, SecureSocketOptions.SslOnConnect, ct);
                        }
                        else if (mailSettingsModel.UseStartTls)
                        {
                            await smtp.ConnectAsync(mailSettingsModel.Host, mailSettingsModel.Port, SecureSocketOptions.StartTls, ct);
                        }

                        await smtp.AuthenticateAsync(mailSettingsModel.UserName, mailSettingsModel.Password, ct);
                        await smtp.SendAsync(mail, ct);
                        await smtp.DisconnectAsync(true, ct);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static MimeMessage SetMailMessage(MimeMessage mail, ShareModel shareModel, MailSettingsModel mailSettingsModel)
        {
            var body = new BodyBuilder
            {
                HtmlBody = $"<a href='{shareModel.ContentUrl.ToString()}'>{shareModel.ContentUrl.ToString()}</a>",
            };

            mail.From.Add(new MailboxAddress(mailSettingsModel.DisplayName, mailSettingsModel.From));
            mail.Sender = new MailboxAddress(mailSettingsModel.DisplayName, mailSettingsModel.From);

            mail.To.Add(MailboxAddress.Parse(shareModel.DestinationEmail));

            mail.Body = body.ToMessageBody();

            return mail;
        }
    }
}
