using Likegram.Business.Abstract;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Utilities.Result;
using Likegram.DataAccess.Abstract;
using Likegram.DataAccess.Contexts;
using Likegram.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet("getbyfolloweduser")]
        public async Task<IActionResult> GetByFollowedUser(int followingUserId)
        {
            return Ok(await _postService.GetAllByFollowedUser(followingUserId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Post post)
        {

            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Post post)
        {

            return Ok();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Update(int postId)
        {

            return Ok();
        }
    }
}
