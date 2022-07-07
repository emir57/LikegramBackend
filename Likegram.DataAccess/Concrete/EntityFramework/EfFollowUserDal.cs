using Likegram.Core.DataAccess.Entityframework;
using Likegram.DataAccess.Abstract;
using Likegram.DataAccess.Contexts;
using Likegram.Entities.Concrete;

namespace Likegram.DataAccess.Concrete.EntityFramework
{
    public class EfFollowUserDal : EFEntityRepostioryBase<FollowUser, LikegramDbContext>, IFollowUserDal
    {
    }
}
