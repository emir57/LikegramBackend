using Likegram.Business.Abstract;
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
        public async Task<IActionResult> LikeOrUnlike()
        {

        }

        [HttpGet("checklike")]
        public async Task<IActionResult> CheckLike()
        {

        }
    }
}
