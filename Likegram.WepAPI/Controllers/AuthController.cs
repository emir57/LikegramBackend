﻿using Likegram.Business.Abstract;
using Likegram.Core.Entities.Dtos;
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

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var result = await _authService.Login(userForLoginDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            var token = _authService.CreateToken(result.Data);
            if (!token.Success)
            {
                return BadRequest(token);
            }
            return Ok(token);
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
    }
}
