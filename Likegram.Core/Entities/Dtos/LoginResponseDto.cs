using Likegram.Core.Entities.Concrete;
using Likegram.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Entities.Dtos
{
    public class LoginResponseDto : IDto
    {
        public AccessToken AccessToken { get; set; }
        public User User { get; set; }
    }
}
