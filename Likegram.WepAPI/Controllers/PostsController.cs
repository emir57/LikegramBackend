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
            var result = await _postService.GetAllByFollowedUser(followingUserId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Post post)
        {

            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Post post)
        {

            return Ok();
        }
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            return Ok();
        }
    }
}
