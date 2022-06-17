using FluentEntity_ConsoleApp.FEntity;
using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Entities.Dtos;
using Likegram.Core.Utilities.Email;
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
        private readonly IEmailService _emailService;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService, IEmailService emailService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
            _emailService = emailService;
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
            if (user.Data == null)
            {
                return new ErrorDataResult<User>(user.Data, BusinessMessages.UserNameOrPasswordWrong);
            }
            if (!HashingHelper.VerifyPasswordHash(user.Data.PasswordHash, user.Data.PasswordSalt, userForLoginDto.Password))
            {
                return new ErrorDataResult<User>(BusinessMessages.UserNameOrPasswordWrong);
            }
            if (!user.Data.EmailConfirm)
            {
                var emailErrorResult = new ErrorDataResult<User>("Lütfen eposta adresinizi onaylayınız");

                int number = generateRandomNumber();
                user.Data.ConfirmCode = number.ToString();
                await _userService.Update(user.Data);

                string body = $"Merhaba {user.Data.Username},<br>Eposta adresinizi doğrulamak için anahtarınız.\n {number}";
                await _emailService.SendMailAsync(user.Data.Email, "Email Doğrulama", body);
                return emailErrorResult;
            }
            return new SuccessDataResult<User>(user.Data, BusinessMessages.SuccessfulLogin);
        }

        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            var checkUserByEmail = await _userService.GetByEmail(userForRegisterDto.Email);
            if (checkUserByEmail.Data != null)
            {
                return new ErrorDataResult<User>(BusinessMessages.UserEmailAlreadyExists);
            }
            var checkUserByUserName = await _userService.GetByUsername(userForRegisterDto.UserName);
            if (checkUserByUserName.Data != null)
            {
                return new ErrorDataResult<User>(BusinessMessages.UserUserNameAlreadyExists);
            }
            HashingHelper.CreatePasswordHash(out passwordHash, out passwordSalt, userForRegisterDto.Password);
            User user = new FluentEntity<User>()
                .AddParameter(u => u.Email, userForRegisterDto.Email)
                .AddParameter(u => u.Username, userForRegisterDto.UserName)
                .AddParameter(u => u.PasswordHash, passwordHash)
                .AddParameter(u => u.PasswordSalt, passwordSalt)
                .GetEntity();
            await _userService.Add(user);
            return new SuccessDataResult<User>(user, BusinessMessages.SuccessfulRegister);
        }
        private int generateRandomNumber()
        {
            Random rndm = new Random();
            return rndm.Next(1000, 9999);
        }
    }
}
