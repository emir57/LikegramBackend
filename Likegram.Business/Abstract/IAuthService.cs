using Likegram.Core.Entities.Concrete;
using Likegram.Core.Entities.Dtos;
using Likegram.Core.Utilities.Result;
using Likegram.Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> CreateToken(User user);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto);
    }
}
