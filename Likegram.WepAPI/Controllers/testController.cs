using Likegram.Core.Entities.Concrete;
using Likegram.Core.Extensions;
using Likegram.Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        private ITokenHelper _tokenHelper;
        private IHttpContextAccessor _httpContextAccessor;
        public testController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _tokenHelper = new JwtHelper(configuration);
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("token")]
        public IActionResult CreateToken()
        {
            var user = new User { FirstName = "Emir", LastName = "Gürbüz", Email = "asd", Id = 1 };
            var roles = new List<Role> { new Role { Name = "Admin" },new Role { Name = "User" } };
            var token = _tokenHelper.CreateToken(user, roles);
            return Ok(token);
        }

        [HttpGet("get")]
        public IActionResult GetToken()
        {
            var roles = _httpContextAccessor.HttpContext.User.GetRoles();
            return Ok(roles);
        }
    }
}
