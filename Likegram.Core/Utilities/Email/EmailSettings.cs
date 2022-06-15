using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Email
{
    public class EmailSettings
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public string Host { get; set; }
    }
}
