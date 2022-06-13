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
    public class PostLikeManager : IPostLikeService
    {
        private readonly IPostLikeDal _postLikeDal;

        public PostLikeManager(IPostLikeDal postLikeDal)
        {
            _postLikeDal = postLikeDal;
        }

        public async Task<IResult> AddAsync(PostLike postLike)
        {
            bool result = await _postLikeDal.Add(postLike);
            return result ?
                new SuccessResult(BusinessMessages.EklemeBasarili) :
                new ErrorResult(BusinessMessages.EklemeBasarisiz);
        }

        public async Task<IResult> DeleteAsync(PostLike postLike)
        {
            bool result = await _postLikeDal.Delete(postLike);
            return result ?
                new SuccessResult(BusinessMessages.SilmeBasarili) :
                new ErrorResult(BusinessMessages.SilmeBasarisiz);
        }
    }
}
