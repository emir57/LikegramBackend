using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Email
{
    public class SmtpEmailSender : IEmailService
    {
        private readonly EmailSettings _emailSettings;
        public SmtpEmailSender(IConfiguration configuration)
        {
            _emailSettings = configuration.GetSection("EmailSettings").Get<EmailSettings>();
        }
        public Task SendMailAsync(string to, string title, string body)
        {
            var client = new SmtpClient(_emailSettings.Host, _emailSettings.Port)
            {
                Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password),
                EnableSsl = _emailSettings.EnableSSL,
            };
            return client.SendMailAsync(new MailMessage(_emailSettings.Username, to, title, body)
            {
                IsBodyHtml = true
            });
        }
    }
}
