using Likegram.Business.Abstract;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Entities.Dtos;
using Likegram.Core.Utilities.Email;
using Likegram.Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IEmailService emailService, IUserService userService)
        {
            _authService = authService;
            _emailService = emailService;
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            if (!result.Data.EmailConfirm)
            {
                var emailErrorResult = new ErrorDataResult<User>("Lütfen eposta adresinizi onaylayınız");
                //TODO: send email
                var rndm = new Random();
                int number = rndm.Next(1000, 9999);
                var user = result.Data;
                user.ConfirmKey = number.ToString();
                await _userService.Update(user);
                string body = $"Eposta adresinizi doğrulamak için anahtarınız.\n {number}";
                await _emailService.SendMailAsync(result.Data.Email, "Email Doğrulama", body);
                return BadRequest(emailErrorResult);
            }
            var token = _authService.CreateToken(result.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            var loginResponse = new LoginResponseDto
            {
                User = result.Data,
                AccessToken = token.Data
            };
            var data = new SuccessDataResult<LoginResponseDto>(loginResponse, "Giriş Başarılı");
            return Ok(data);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = await _authService.Register(userForRegisterDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpGet("emailconfirm")]
        public async Task<IActionResult> EmailConfirm(int userId, string confirmKey)
        {
            var userResult = await _userService.GetById(userId);
            if (confirmKey == userResult.Data.ConfirmKey)
            {
                var successResult = new SuccessResult("Doğrulama başarılı");
                return Ok(successResult);
            }
            var errorREsult = new ErrorResult("Doğrulama başarısız");
            return BadRequest(errorREsult);

        }

    }
}
