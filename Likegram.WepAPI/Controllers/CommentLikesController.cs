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
    public class CommentLikesController : ControllerBase
    {
        private readonly ICommentLikeService _commentLikeService;

        public CommentLikesController(ICommentLikeService commentLikeService)
        {
            _commentLikeService = commentLikeService;
        }
        [HttpPost("likeorunlike")]
        public async Task<IActionResult> LikeOrUnlike(CommentLikeOrUnlikeViewModel model)
        {
            var commentLikeResult = await _commentLikeService.GetByUserIdAndCommentId(model.UserId, model.CommentId);
            if (commentLikeResult.Success)
            {
                var result1 = await _commentLikeService.DeleteAsync(commentLikeResult.Data);
                return Ok(result1);
            }
            CommentLike commentLike = new FluentEntity<CommentLike>()
                .AddParameter(c => c.UserId, model.UserId)
                .AddParameter(c => c.PostCommentId, model.CommentId)
                .GetEntity();
            var result2 = await _commentLikeService.AddAysnc(commentLike);
            return Ok(result2);
        }

        [HttpGet("checklike")]
        public async Task<IActionResult> CheckLike([FromQuery] CommentCheckLikeViewModel model)
        {
            var result = await _commentLikeService.GetByUserIdAndCommentId(model.UserId, model.CommentId);
            return Ok(result);
        }
    }
}
