using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentLikesController : ControllerBase
    {
        private readonly ICommentLikeService _commentLikeService;
    }
}
