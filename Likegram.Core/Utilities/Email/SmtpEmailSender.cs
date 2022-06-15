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
        private string _username = "name";
        private string _password = "password";
        private int _port = 587;
        private bool _enableSSL = true;
        private string _host = "smtp-mail.outlook.com";
        public Task SendMailAsync(string to, string title, string body)
        {
            var client = new SmtpClient(_host, _port)
            {
                Credentials = new NetworkCredential(_username, _password),
                EnableSsl = _enableSSL,
            };
            return client.SendMailAsync(new MailMessage(_username, to, title, body)
            {
                IsBodyHtml = true
            });
        }
    }
}
