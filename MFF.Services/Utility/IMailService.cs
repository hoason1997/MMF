using MFF.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MFF.Infrastructure.Utility
{
    public interface IMailService
    {
        Task SendAsync(string toEmail
            , string displayName
            , string subject
            , string body
            , List<MailAttachmentModel> attachments = null
            , IEnumerable<string> cc = null
            , IEnumerable<string> bcc = null
            , bool isBodyHtml = true);

        Task SendAsync(IEnumerable<(string email, string displayName)> toEmails
            , string subject
            , string body
            , List<MailAttachmentModel> attachments = null
            , IEnumerable<string> cc = null
            , IEnumerable<string> bcc = null
            , bool isBodyHtml = true);
    }
}
