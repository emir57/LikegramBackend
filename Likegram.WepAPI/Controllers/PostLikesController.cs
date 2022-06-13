using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostLikesController : ControllerBase
    {
        private readonly IPostLikesService _postLikesService;
        public PostLikesController(IPostLikesService postLikesService)
        {
            _postLikesService = postLikesService;
        }
    }
}
