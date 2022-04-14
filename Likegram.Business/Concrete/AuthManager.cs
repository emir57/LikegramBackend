using Likegram.Business.Abstract;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Entities.Dtos;
using Likegram.Core.Utilities.Result;
using Likegram.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        public Task<IDataResult<AccessToken>> CreateToken(User user, List<Role> roles)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }
    }
}
