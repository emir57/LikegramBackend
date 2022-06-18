using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IFavouritePostService
    {
        Task<IResult> AddAsync(FavouritePost favouritePost);
        Task<IResult> UpdateAsync(FavouritePost favouritePost);
        Task<IResult> DeleteAsync(FavouritePost favouritePost);
        Task<IDataResult<FavouritePost>> GetByIdAsync(int id);
        Task<IDataResult<List<FavouritePost>>> GetListByUserId(int userId);
        Task<IDataResult<Post>> GetListByUserIdAndPostId(int userId,int postId);
        Task<IDataResult<List<FavouritePost>>> GetList();
    }
}
