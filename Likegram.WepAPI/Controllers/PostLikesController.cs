using FluentEntity_ConsoleApp.FEntity;
using Likegram.Business.Abstract;
using Likegram.Entities.Concrete;
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
        public async Task<IActionResult> LikeOrUnLike(PostLikeOrUnlikeViewModel likeOrUnlikeViewModel)
        {
            var result = await _postLikesService.GetByUserIdAndPostId(likeOrUnlikeViewModel.UserId, likeOrUnlikeViewModel.PostId);
            if (result.Success)
            {
                var result2 = await _postLikesService.DeleteAsync(result.Data);
                return Ok(result2);
            }
            PostLike postLike = new FluentEntity<PostLike>()
                .AddParameter(p => p.PostId, likeOrUnlikeViewModel.PostId)
                .AddParameter(p => p.UserId, likeOrUnlikeViewModel.UserId)
                .GetEntity();
            var result3 = await _postLikesService.AddAsync(postLike);
            return Ok(result3);
        }
        [HttpGet("checklike")]
        public async Task<IActionResult> CheckLike([FromQuery] PostCheckLikeViewModel checkLikeViewModel)
        {
            var result = await _postLikesService.CheckLike(checkLikeViewModel.UserId, checkLikeViewModel.PostId);
            return Ok(result);
        }
    }
}
