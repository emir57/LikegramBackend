using Likegram.Business.Abstract;
using Likegram.WepAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostLikesController : ControllerBase
    {
        private readonly IPostLikeService _postLikesService;
        public PostLikesController(IPostLikeService postLikesService)
        {
            _postLikesService = postLikesService;
        }
        [HttpPost("likeorunlike")]
        public async Task<IActionResult> LikeOrUnLike(LikeOrUnlikeViewModel likeOrUnlikeViewModel)
        {
            var result = await _postLikesService.GetByUserIdAndPostId(likeOrUnlikeViewModel.UserId, likeOrUnlikeViewModel.PostId);
            if (result.Success)
            {
                var result2 = await _postLikesService.DeleteAsync(result.Data);
                return Ok(result2);
            }
            var result3 = await _postLikesService.AddAsync(new Entities.Concrete.PostLike
            {
                PostId = likeOrUnlikeViewModel.PostId,
                UserId = likeOrUnlikeViewModel.UserId
            });
            return Ok(result3);
        }
        [HttpGet("checklike")]
        public async Task<IActionResult> CheckLike([FromQuery]CheckLikeViewModel checkLikeViewModel)
        {
            var result = await _postLikesService.CheckLike(checkLikeViewModel.UserId, checkLikeViewModel.PostId);
            return Ok(result);
        }
    }
}
