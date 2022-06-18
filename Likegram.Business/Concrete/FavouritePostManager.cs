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

        public async Task<IDataResult<FavouritePost>> GetByIdAsync(int id)
        {
            var favouritePost = await _favouritePostDal.Get(f => f.Id == id);
            if (favouritePost != null)
                return new SuccessDataResult<FavouritePost>(favouritePost);
            return new ErrorDataResult<FavouritePost>();
        }

        public async Task<IDataResult<List<FavouritePost>>> GetListAsync()
        {
            var favouritePosts = await _favouritePostDal.GetAll();
            return new SuccessDataResult<List<FavouritePost>>(favouritePosts, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<List<FavouritePost>>> GetListByUserIdAsync(int userId)
        {
            var favouritePosts = await _favouritePostDal.GetAll(f => f.UserId == userId);
            return new SuccessDataResult<List<FavouritePost>>(favouritePosts, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<FavouritePost>> GetByUserIdAndPostIdAsync(int userId, int postId)
        {
            var favouritePost = await _favouritePostDal.Get(f => f.UserId == userId && f.PostId == postId);
            if (favouritePost != null)
                return new SuccessDataResult<FavouritePost>(favouritePost);
            return new ErrorDataResult<FavouritePost>();
        }

        public async Task<IResult> UpdateAsync(FavouritePost favouritePost)
        {
            var result = await _favouritePostDal.Update(favouritePost);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessUpdate);
            return new ErrorResult(BusinessMessages.UnSuccessfulUpdate);
        }
    }
}
