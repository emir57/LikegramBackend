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
    public class EfPostDal : EFEntityRepostioryBase<Post, LikegramDbContext>, IPostDal
    {
        public List<Post> GetAllByFollowedUser(int followingUserId)
        {
            using(var context = new LikegramDbContext())
            {
                var result = from fu in context.FollowUsers
                             from p in context.Posts
                             where fu.FollowingUser.Id == followingUserId && p.UserId == fu.FollowedUser.Id
                             select new Post
                             {
                                 Id = p.Id,
                                 User = fu.FollowedUser,
                                 CreatedDate = p.CreatedDate,
                                 ImageUrl = p.ImageUrl,
                                 Description = p.Description,
                                 PostComments = context.PostComments.Where(x => x.Post.Id == p.Id).ToList(),
                                 PostLikes = context.PostLikes.Where(x => x.Post.Id == p.Id).ToList()
                             };
                return result.ToList();
            }
        }
    }
}
