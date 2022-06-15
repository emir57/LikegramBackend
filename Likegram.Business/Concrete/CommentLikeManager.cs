using Likegram.Business.Abstract;
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
            return null;
        }

        public Task<IResult> CheckLike(int userId, int commentId)
        {
            throw new NotImplementedException();
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
