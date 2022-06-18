﻿using Likegram.Business.Abstract;
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
        public async Task<IActionResult> CheckFavouritePost(int userId,int postId)
        {
            var result = await _favouritePostService.GetByUserIdAndPostIdAsync(userId, postId);
            return Ok(result);
        }
    }
}
