using Likegram.Core.DataAccess.Entityframework;
using Likegram.Core.Entities.Concrete;
using Likegram.DataAccess.Abstract;
using Likegram.DataAccess.Contexts;
using Likegram.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EFEntityRepostioryBase<Post, LikegramDbContext>, IPostDal
    {
        public async Task<List<Post>> GetAllByFollowedUserAsync(int followingUserId)
        {
            using(var context = new LikegramDbContext())
            {
                var posts = from fu in context.FollowUsers
                             from p in context.Posts
                            where fu.FollowingUserId == followingUserId && p.UserId == fu.FollowedUserId
                            select new Post
                             {
                                 Id = p.Id,
                                 User = fu.FollowedUser,
                                 CreatedDate = p.CreatedDate,
                                 ImageUrl = p.ImageUrl,
                                 Description = p.Description,
                             };
                foreach (var post in posts)
                {
                    var comments = await context.PostComments.Where(x => x.PostId == post.Id).ToListAsync();
                    foreach (var comment in comments)
                    {
                        comment.User = await context.Users.SingleOrDefaultAsync(x => x.Id == comment.UserId);
                        comment.CommentAnswers = await context.CommentAnswers.Where(x => x.PostCommentId == comment.Id).ToListAsync();
                        foreach (var answer in comment.CommentAnswers)
                        {
                            answer.User = await context.Users.SingleOrDefaultAsync(x => x.Id == answer.UserId);
                        }
                    }
                    post.User = await context.Users.SingleOrDefaultAsync(x => x.Id == post.UserId);
                    post.PostLikes = await context.PostLikes.Where(x => x.PostId == post.Id).ToListAsync();
                    post.PostComments = comments;
                }
                return posts.ToList();
            }
        }
    }
}
