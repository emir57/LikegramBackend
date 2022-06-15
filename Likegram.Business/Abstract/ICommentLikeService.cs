using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface ICommentLikeService
    {
        Task<IResult> AddAysnc(CommentLike commentLike);
        Task<IResult> DeleteAsync(CommentLike commentLike);
        Task<IDataResult<CommentLike>> GetById(int id);
        Task<IDataResult<CommentLike>> GetByUserIdAndCommentId(int userId, int commentId);
        Task<IResult> CheckLike(int userId, int commentId);
    }
}
