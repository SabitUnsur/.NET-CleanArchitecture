using CleanArchitecture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        public Task SendMailAsync(string body,IList<string> emails,IList<Attachment>? attachments)
        {
            throw new NotImplementedException();
        }
    }
}
