using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IFollowUserService
    {
        Task<IResult> AddAsync(FollowUser followUser);
        Task<IResult> DeleteAsync(FollowUser followUser);
        Task<IDataResult<FollowUser>> GetByIdAsync(int id);
        Task<IDataResult<List<FollowUser>>> GetListAsync();
        Task<IDataResult<List<FollowUser>>> GetListByFollowedUserAsync(int followingUserId); 
        Task<IDataResult<List<FollowUser>>> GetListByFollowingUserAsync(int followedUserId);
    }
}
