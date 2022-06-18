using Likegram.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
