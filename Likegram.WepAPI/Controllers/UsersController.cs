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
        private readonly IFollowUserService _followUserService;
        public UsersController(IPostService postService, IFollowUserService followUserService)
        {
            _postService = postService;
            _followUserService = followUserService;
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
            var result = await _followUserService.GetListByFollowedUserAsync(followingUserId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("followingUserCount/{followedUserId}")]
        public async Task<IActionResult> FollowingUserCount(int followedUserId)
        {
            var result = await _followUserService.GetListByFollowingUserAsync(followedUserId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
