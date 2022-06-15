using Likegram.Business.Abstract;
using Likegram.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [HttpGet("getcommentsbypost")]
        public async Task<IActionResult> GetComments(int postId)
        {
            var result = await _postCommentService.GetListByPostIdAsync(postId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(PostComment postComment)
        {
            var result = await _postCommentService.Add(postComment);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(PostComment postComment)
        {
            var result = await _postCommentService.Update(postComment);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
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
