using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Entities.Dtos;
using Likegram.Core.Utilities.Result;
using Likegram.Core.Utilities.Security.Hash;
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
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserService _userService;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateToken(User user)
        {
            var roles = _userService.UserRoles(user);
            var token = _tokenHelper.CreateToken(user, roles.Data);
            return new SuccessDataResult<AccessToken>(token, BusinessMessages.CreateToken);
        }

        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var user = await _userService.GetByEmail(userForLoginDto.Email);
            if(user.Data == null)
            {
                return new ErrorDataResult<User>(user.Data, BusinessMessages.UserNameOrPasswordWrong);
            }
            if (!HashingHelper.VerifyPasswordHash(user.Data.PasswordHash, user.Data.PasswordSalt, userForLoginDto.Password))
            {
                return new ErrorDataResult<User>(BusinessMessages.UserNameOrPasswordWrong);
            }
            return new SuccessDataResult<User>(user.Data, BusinessMessages.SuccessfulLogin);
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            var checkUserByEmail = await _userService.GetByEmail(userForRegisterDto.Email);
            if(checkUserByEmail.Data != null)
            {
                return new ErrorDataResult<User>(BusinessMessages.UserEmailAlreadyExists);
            }
            var checkUserByUserName = await _userService.GetByUsername(userForRegisterDto.UserName);
            if (checkUserByUserName.Data != null)
            {
                return new ErrorDataResult<User>(BusinessMessages.UserUserNameAlreadyExists);
            }
            HashingHelper.CreatePasswordHash(out passwordHash, out passwordSalt, userForRegisterDto.Password);
            var user = new FluentUser()
                .SetEmail(userForRegisterDto.Email)
                .SetUserName(userForRegisterDto.UserName)
                .SetPasswordHash(passwordHash)
                .SetPasswordSalt(passwordSalt)
                .GetUser();
            await _userService.Add(user);
            return new SuccessDataResult<User>(user, BusinessMessages.SuccessfulRegister);
        }
    }
}
