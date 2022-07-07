using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Utilities.Result;
using Likegram.DataAccess.Abstract;
using Likegram.Entities.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Likegram.Business.Concrete
{
    public class FollowUserManager : IFollowUserService
    {
        private readonly IFollowUserDal _followUserDal;

        public FollowUserManager(IFollowUserDal followUserDal)
        {
            _followUserDal = followUserDal;
        }

        public async Task<IResult> AddAsync(FollowUser followUser)
        {
            await _followUserDal.Add(followUser);
            return new SuccessResult(BusinessMessages.SuccessAdd);
        }

        public async Task<IResult> DeleteAsync(FollowUser followUser)
        {
            await _followUserDal.Delete(followUser);
            return new SuccessResult(BusinessMessages.SuccessDelete);
        }

        public async Task<IDataResult<FollowUser>> GetByIdAsync(int id)
        {
            var result = await _followUserDal.Get(f => f.Id == id);
            return new SuccessDataResult<FollowUser>(result);
        }

        public async Task<IDataResult<List<FollowUser>>> GetListAsync()
        {
            var result = await _followUserDal.GetAll();
            return new SuccessDataResult<List<FollowUser>>(result);
        }

        public async Task<IDataResult<List<FollowUser>>> GetListByFollowedUserAsync(int followingUserId)
        {
            var result = await _followUserDal.GetAll(f => f.FollowingUserId == followingUserId);
            return new SuccessDataResult<List<FollowUser>>(result);
        }

        public async Task<IDataResult<List<FollowUser>>> GetListByFollowingUserAsync(int followingUserId)
        {
            var result = await _followUserDal.GetAll(f => f.FollowedUserId == followingUserId);
            return new SuccessDataResult<List<FollowUser>>(result);
        }
    }
}
