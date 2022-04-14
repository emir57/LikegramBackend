using Likegram.Core.DataAccess.Entityframework;
using Likegram.DataAccess.Abstract;
using Likegram.DataAccess.Contexts;
using Likegram.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Concrete.EntityFramework
{
    public class EfCommentLikeDal : EFEntityRepostioryBase<CommentLike, LikegramDbContext>, ICommentLikeDal
    {
    }
}
