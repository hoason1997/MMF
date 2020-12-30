using MFF.DTO.Settings;
using MFF.Infrastructure.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Utility
{
    public class MailService : IMailService
    {
        private readonly MailSetting _mailSetting;
        public MailService(IOptions<MailSetting> mailSetting)
        {
            _mailSetting = mailSetting.Value;
        }

        public async Task SendAsync(string toEmail
            , string displayName
            , string subject
            , string body
            , List<MailAttachmentModel> attachments = null
            , IEnumerable<string> cc = null
            , IEnumerable<string> bcc = null
            , bool isBodyHtml = true)
        {
            await HandleSendAsync(toEmail, displayName, subject, body, attachments, cc, bcc, isBodyHtml);
        }

        public async Task SendAsync(IEnumerable<(string email, string displayName)> toEmails
            , string subject
            , string body
            , List<MailAttachmentModel> attachments = null
            , IEnumerable<string> cc = null
            , IEnumerable<string> bcc = null
            , bool isBodyHtml = true)
        {
            await Task.WhenAll(toEmails.Select(x => HandleSendAsync(x.email, x.displayName, subject, body, attachments, cc, bcc, isBodyHtml)));
        }

        private async Task HandleSendAsync(string toEmail
            , string displayName
            , string subject
            , string body
            , IEnumerable<MailAttachmentModel> mailAttachments = null
            , IEnumerable<string> ccEmails = null
            , IEnumerable<string> bccEmails = null
            , bool? isBodyHtml = true)
        {
            try
            {
                var client = new SmtpClient(_mailSetting.Host)
                {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_mailSetting.Username, _mailSetting.Password),
                    Port = _mailSetting.Port,
                    EnableSsl = _mailSetting.EnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_mailSetting.Username, _mailSetting.DisplayName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml.Value,
                };
                mailMessage.To.Add(new MailAddress(toEmail, displayName));

                if (ccEmails != null && ccEmails.Any())
                {
                    foreach (var item in ccEmails)
                    {
                        mailMessage.CC.Add(new MailAddress(item));
                    }
                }

                if (bccEmails != null && bccEmails.Any())
                {
                    foreach (var item in bccEmails)
                    {
                        mailMessage.Bcc.Add(new MailAddress(item));
                    }
                }

                if (mailAttachments != null && mailAttachments.Any())
                {
                    foreach (var attachment in mailAttachments)
                    {
                        var memoryStream = await DownloadDataTaskAsync(new Uri(attachment.AttachmentUrl));
                        mailMessage.Attachments.Add(new Attachment(memoryStream, attachment.AttachmentName));
                    }
                }

                await client.SendMailAsync(mailMessage);

                client.Dispose();
            }
            catch { }
        }

        private async Task<MemoryStream> DownloadDataTaskAsync(Uri address)
        {
            try
            {
                WebClient webClient = new WebClient();
                byte[] bytes = await webClient.DownloadDataTaskAsync(address);
                var data = new MemoryStream(bytes);
                webClient.Dispose();
                return data;
            }
            catch
            {
                return null;
            }
        }
    }
}
