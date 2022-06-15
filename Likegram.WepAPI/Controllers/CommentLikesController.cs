using Likegram.Business.Abstract;
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
            var result2 = await _commentLikeService.AddAysnc(new Entities.Concrete.CommentLike
            {
                UserId = model.UserId,
                PostCommentId = model.CommentId
            });
            return Ok(result2);
        }

        [HttpGet("checklike")]
        public async Task<IActionResult> CheckLike(CommentCheckLikeViewModel model)
        {
            var result = await _commentLikeService.GetByUserIdAndCommentId(model.UserId, model.CommentId);
            return Ok(result);
        }
    }
}
