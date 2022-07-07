using Likegram.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IPostService _postService;
        public UsersController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("postcount/{userId}")]
        public async Task<IActionResult> PostCount(int userId)
        {
            var result = await _postService.GetPostCountByUserIdAsync(userId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("followedUserCount/{followingUserId}")]
        public async Task<IActionResult> FollowedUserCount(int followingUserId)
        {
            return Ok();
        }
    }
}
