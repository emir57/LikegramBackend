using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Aspects.Autofac.Performance;
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
    public class PostManager : IPostService
    {
        private readonly IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }

        public async Task<IResult> Add(Post post)
        {
            await _postDal.Add(post);
            return new SuccessResult(BusinessMessages.SuccessAdd);
        }

        public async Task<IResult> Delete(Post post)
        {
            await _postDal.Delete(post);
            return new SuccessResult(BusinessMessages.SuccessDelete);
        }

        public async Task<IDataResult<List<Post>>> GetAll()
        {
            var result = await _postDal.GetAll();
            return new SuccessDataResult<List<Post>>(result, BusinessMessages.SuccessList);
        }
        [PerformanceAspect(3)]
        public async Task<IDataResult<List<Post>>> GetAllByFollowedUser(int followingUserId)
        {
            var result = await _postDal.GetAllByFollowedUser(followingUserId);
            return new SuccessDataResult<List<Post>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<int>> GetPostCountByUserIdAsync(int userId)
        {
            var posts = await _postDal.GetAll(p => p.UserId == userId);
            return new SuccessDataResult<int>(posts.Count);
        }

        public async Task<IResult> Update(Post post)
        {
            await _postDal.Update(post);
            return new SuccessResult(BusinessMessages.SuccessUpdate);
        }
    }
}
