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
    public class AnswersController : ControllerBase
    {
        private readonly ICommentAnswerService _commentAnswerService;

        public AnswersController(ICommentAnswerService commentAnswerService)
        {
            _commentAnswerService = commentAnswerService;
        }
        [HttpGet("getbycommentid")]
        public async Task<IActionResult> GetByCommentId(int commentId)
        {
            var result = await _commentAnswerService.GetListByCommentIdAsync(commentId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("answerscount")]
        public async Task<IActionResult> GetByCommentAnswersCount(int commentId)
        {
            var result = await _commentAnswerService.CommentAnswersCount(commentId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(CommentAnswer commentAnswer)
        {
            var result = await _commentAnswerService.Add(commentAnswer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(CommentAnswer commentAnswer)
        {
            var result = await _commentAnswerService.Update(commentAnswer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var commentResult = await _commentAnswerService.GetById(id);
            if (commentResult.Data == null)
            {
                return BadRequest("Cevap bulunamadı");
            }
            var result = await _commentAnswerService.Delete(commentResult.Data);
            return Ok(result);
        }
    }
}
