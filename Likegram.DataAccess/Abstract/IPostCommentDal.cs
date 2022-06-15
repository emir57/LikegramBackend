using Likegram.Core.DataAccess;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Abstract
{
    public interface IPostCommentDal : IEntityRepository<PostComment>
    {
        Task<List<PostComment>> GetCommentsByPostId(int postId);
    }
}
