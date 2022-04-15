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
            var result = from followUser in _context.FollowUsers
                         from post in _context.Posts
                         from postComment in _context.PostComments
                         from commentAnswer in _context.CommentAnswers
                         from user in _context.Users
                         where followUser.FollowingUserId == followingUserId &&
                         post.UserId == followUser.FollowedUserId &&
                         post.Id == postComment.PostId
                         select new Post
                         {
                             Id = post.Id,
                             User = followUser.FollowedUser,
                             CreatedDate = post.CreatedDate,
                             ImageUrl = post.ImageUrl,
                             Description = post.Description,
                             PostComments = new List<PostComment>
                             {
                                 new PostComment{
                                     Comment=postComment.Comment,
                                     Id = postComment.Id,
                                     User = _context.Users.SingleOrDefault(x=>x.Id == postComment.UserId),
                                     CreatedDate = postComment.CreatedDate,
                                     CommentAnswers = new List<CommentAnswer>
                                     {
                                         new CommentAnswer
                                         {
                                             Id = commentAnswer.Id,
                                             Answer = commentAnswer.Answer,
                                             CreatedDate = commentAnswer.CreatedDate,
                                             User = _context.Users.SingleOrDefault(x=>x.Id == commentAnswer.UserId)
                                         }
                                     }
                                 }
                             },
                             PostLikes = new List<PostLike>
                             {
                                 _context.PostLikes.SingleOrDefault(x=>x.PostId == post.Id)
                             }
                         };
            return Ok(await result.ToListAsync());
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
