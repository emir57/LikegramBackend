using Likegram.Core.Entities.Concrete;
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
        private readonly LikegramDbContext _context;

        public PostsController(LikegramDbContext context)
        {
            _context = context;
        }
        [HttpGet("getbyfolloweduser")]
        public async Task<IActionResult> GetByFollowedUser(int followingUserId)
        {
            
            return Ok();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("update")]
        public async Task<IActionResult> Update(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("delete")]
        public async Task<IActionResult> Update(int postId)
        {
            var post = await _context.Posts.SingleOrDefaultAsync(x => x.Id == postId);
            if (post == null)
            {
                return BadRequest();
            }
            _context.Posts.Remove(post);
            return Ok();
        }
    }
}
