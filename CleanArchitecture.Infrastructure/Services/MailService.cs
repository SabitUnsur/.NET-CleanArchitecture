using CleanArchitecture.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericEmailService;
using System.Net.Mail;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Infrastructure.Services
{
    public sealed class MailService : IMailService
    {
        private readonly SmtpClient _smtpClient;

        public MailService(SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendMailAsync(string to, string subject, string body)
        {
            var mailMessage = new MailMessage("sabitunsur@gmail.com",to,subject,body);
            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
