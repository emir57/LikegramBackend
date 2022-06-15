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
    public class CommentLikeManager : ICommentLikeService
    {
        private readonly ICommentLikeDal _commentLikeDal;

        public CommentLikeManager(ICommentLikeDal commentLikeDal)
        {
            _commentLikeDal = commentLikeDal;
        }

        public async Task<IResult> AddAysnc(CommentLike commentLike)
        {
            bool result = await _commentLikeDal.Add(commentLike);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessAdd);
            return new ErrorResult(BusinessMessages.UnSuccessfulAdd);
        }

        public async Task<IResult> CheckLike(int userId, int commentId)
        {
            var commentLike = await _commentLikeDal.Get(c => c.UserId == userId && c.PostCommentId == commentId);
            if (commentLike == null)
                return new ErrorResult(BusinessMessages.NotFound);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(CommentLike commentLike)
        {
            bool result = await _commentLikeDal.Delete(commentLike);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessDelete);
            return new ErrorResult(BusinessMessages.UnSuccessfulDelete);
        }

        public async Task<IDataResult<CommentLike>> GetById(int id)
        {
            var commentLike = await _commentLikeDal.Get(c => c.Id == id);
            if (commentLike == null)
                return new ErrorDataResult<CommentLike>(BusinessMessages.NotFound);
            return new SuccessDataResult<CommentLike>(commentLike);
        }

        public async Task<IDataResult<CommentLike>> GetByUserIdAndCommentId(int userId, int commentId)
        {
            var commentLike = await _commentLikeDal.Get(c => c.UserId == userId && c.PostCommentId == commentId);
            if (commentLike == null)
                return new ErrorDataResult<CommentLike>(BusinessMessages.NotFound);
            return new SuccessDataResult<CommentLike>(commentLike);
        }
    }
}
