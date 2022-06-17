using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface ICommentAnswerService
    {
        Task<IResult> Add(CommentAnswer commentAnswer);
        Task<IResult> Update(CommentAnswer commentAnswer);
        Task<IResult> Delete(CommentAnswer commentAnswer);
        Task<IDataResult<List<CommentAnswer>>> GetAll();
        Task<IDataResult<CommentAnswer>> GetById(int id);
        Task<IDataResult<List<CommentAnswer>>> GetListByCommentIdAsync(int commentId);
        Task<IDataResult<int>> CommentAnswersCount(int commentId);
    }
}
