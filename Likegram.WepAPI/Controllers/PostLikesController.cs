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
        [HttpPost]
        public async Task<IActionResult> LikeOrUnLike(LikeOrUnlikeViewModel likeOrUnlikeViewModel)
        {
            return Ok();
        }
    }
}
