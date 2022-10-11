using Likegram.Business.Abstract;
using Likegram.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Likegram.WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IPostCommentService _postCommentService;

        public CommentsController(IPostCommentService postCommentService)
        {
            _postCommentService = postCommentService;
        }
        [HttpGet("postComments/{postId}")]
        public async Task<IActionResult> GetComments([FromRoute] int postId)
        {
            var result = await _postCommentService.GetListByPostIdAsync(postId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PostComment postComment)
        {
            var result = await _postCommentService.Add(postComment);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PostComment postComment)
        {
            var result = await _postCommentService.Update(postComment);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commentResult = await _postCommentService.GetById(id);
            if (commentResult.Data == null)
            {
                return BadRequest("Yorum bulunamadı");
            }
            var result = await _postCommentService.Delete(commentResult.Data);
            return Ok(result);
        }
    }
}
