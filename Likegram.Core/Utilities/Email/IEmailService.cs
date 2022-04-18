using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Email
{
    public interface IEmailService
    {
        Task SendMailAsync(string to, string title, string body);
    }
}
