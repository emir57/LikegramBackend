using Likegram.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
