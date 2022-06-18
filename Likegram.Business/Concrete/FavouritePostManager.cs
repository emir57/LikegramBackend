using Likegram.Business.Abstract;
using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Concrete
{
    public class FavouritePostManager : IFavouritePostService
    {
        public Task<IResult> AddAsync(FavouritePost favouritePost)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(FavouritePost favouritePost)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<FavouritePost>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<FavouritePost>>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<FavouritePost>>> GetListByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Post>> GetListByUserIdAndPostId(int userId, int postId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateAsync(FavouritePost favouritePost)
        {
            throw new NotImplementedException();
        }
    }
}
