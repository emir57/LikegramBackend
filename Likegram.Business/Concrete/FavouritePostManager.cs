using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Utilities.Result;
using Likegram.DataAccess.Abstract;
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
        private readonly IFavouritePostDal _favouritePostDal;

        public FavouritePostManager(IFavouritePostDal favouritePostDal)
        {
            _favouritePostDal = favouritePostDal;
        }

        public async Task<IResult> AddAsync(FavouritePost favouritePost)
        {
            var result = await _favouritePostDal.Add(favouritePost);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessAdd);
            return new ErrorResult(BusinessMessages.UnSuccessfulAdd);
        }

        public async Task<IResult> DeleteAsync(FavouritePost favouritePost)
        {
            var result = await _favouritePostDal.Delete(favouritePost);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessDelete);
            return new ErrorResult(BusinessMessages.UnSuccessfulDelete);
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
