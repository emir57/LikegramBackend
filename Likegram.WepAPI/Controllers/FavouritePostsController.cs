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
    public class FavouritePostsController : ControllerBase
    {
        private readonly IFavouritePostService _favouritePostService;

        public FavouritePostsController(IFavouritePostService favouritePostService)
        {
            _favouritePostService = favouritePostService;
        }
        [HttpGet("getfavouriteposts")]
        public async Task<IActionResult> GetFavouritePosts(int userId)
        {
            var result = await _favouritePostService.GetListByUserIdAsync(userId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("checkfavouritepost")]
        public async Task<IActionResult> CheckFavouritePost(int userId, int postId)
        {
            var result = await _favouritePostService.GetByUserIdAndPostIdAsync(userId, postId);
            return Ok(result);
        }
        [HttpPost("deleteoradd")]
        public async Task<IActionResult> DeleteOrAdd(FavouritePostAddOrDeleteViewModel model)
        {
            var result = await _favouritePostService.GetByUserIdAndPostIdAsync(model.UserId, model.PostId);
            if (!result.Success)
            {
                FavouritePost favouritePost = new FluentEntity<FavouritePost>()
                    .AddParameter(f => f.UserId, model.UserId)
                    .AddParameter(f => f.PostId, model.PostId)
                    .GetEntity();
                var addResult = await _favouritePostService.AddAsync(favouritePost);
                return Ok(addResult);
            }
            var deleteResult = await _favouritePostService.DeleteAsync(result.Data);
            return Ok(deleteResult);
        }

        [HttpPost]
        public async Task<IActionResult> Add(FavouritePost favouritePost)
        {
            var result = await _favouritePostService.AddAsync(favouritePost);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> Update(FavouritePost favouritePost)
        {
            var result = await _favouritePostService.UpdateAsync(favouritePost);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var favouritePostResult = await _favouritePostService.GetByIdAsync(id);
            if (!favouritePostResult.Success)
                return BadRequest(favouritePostResult);
            var result = await _favouritePostService.DeleteAsync(favouritePostResult.Data);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
