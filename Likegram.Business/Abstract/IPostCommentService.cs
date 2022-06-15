using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IPostCommentService
    {
        Task<IResult> Add(PostComment postComment);
        Task<IResult> Update(PostComment postComment);
        Task<IResult> Delete(PostComment postComment);
        Task<IDataResult<List<PostComment>>> GetAll();
        Task<IDataResult<List<PostComment>>> GetListByPostIdAsync(int postId);
        Task<IDataResult<PostComment>> GetById(int id);
    }
}
