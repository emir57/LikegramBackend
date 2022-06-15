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

        public Task<IResult> DeleteAsync(CommentLike commentLike)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CommentLike>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CommentLike>> GetByUserIdAndCommentId(int userId, int commentId)
        {
            throw new NotImplementedException();
        }
    }
}
