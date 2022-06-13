using Likegram.Core.Utilities.Result;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IPostLikeService
    {
        Task<IResult> AddAsync(PostLike postLike);
        Task<IResult> DeleteAsync(PostLike postLike);
    }
}
