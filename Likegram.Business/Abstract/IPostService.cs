using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IPostService
    {
        Task<IResult> Add(Post post);
        Task<IResult> Update(Post post);
        Task<IResult> Delete(Post post);
        Task<IDataResult<List<Post>>> GetAll();
        Task<IDataResult<List<Post>>> GetAllByFollowedUser(int followingUserId);
        Task<IDataResult<int>> GetPostCountByUserIdAsync(int userId);
    }
}
