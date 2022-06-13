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
    public class PostLikeManager : IPostLikeService
    {
        private readonly IPostLikeDal _postLikeDal;

        public PostLikeManager(IPostLikeDal postLikeDal)
        {
            _postLikeDal = postLikeDal;
        }

        public async Task<IResult> AddAsync(PostLike postLike)
        {
            bool result = await _postLikeDal.Add(postLike);
            return result ?
                new SuccessResult(BusinessMessages.SuccessAdd) :
                new ErrorResult(BusinessMessages.UnSuccessfulAdd);
        }

        public async Task<IResult> CheckLike(int userId, int postId)
        {
            var postLike = await _postLikeDal.Get(x => x.UserId == userId && x.PostId == postId);
            return postLike == null ?
                new ErrorResult() :
                new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(PostLike postLike)
        {
            bool result = await _postLikeDal.Delete(postLike);
            return result ?
                new SuccessResult(BusinessMessages.SuccessDelete) :
                new ErrorResult(BusinessMessages.UnSuccessfulDelete);
        }

        public async Task<IDataResult<PostLike>> GetByIdAsync(int id)
        {
            var postLike = await _postLikeDal.Get(x => x.Id == id);
            return postLike == null ?
                new ErrorDataResult<PostLike>(BusinessMessages.NotFound) :
                new SuccessDataResult<PostLike>(postLike, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IDataResult<PostLike>> GetByUserIdAndPostId(int userId, int postId)
        {
            var postLike = await _postLikeDal.Get(x => x.UserId == userId && x.PostId == postId);
            return postLike == null ?
                new ErrorDataResult<PostLike>(BusinessMessages.NotFound) :
                new SuccessDataResult<PostLike>(postLike, BusinessMessages.UnSuccessfulList);
        }
    }
}
