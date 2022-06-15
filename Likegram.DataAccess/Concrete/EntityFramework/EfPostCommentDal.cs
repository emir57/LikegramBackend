using Likegram.Core.DataAccess.Entityframework;
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
    public class EfPostCommentDal : EFEntityRepostioryBase<PostComment, LikegramDbContext>, IPostCommentDal
    {
        public async Task<List<PostComment>> GetCommentsByPostId(int postId)
        {
            using (var context = new LikegramDbContext())
            {
                var result = from c in context.PostComments
                             where c.PostId == postId
                             select new PostComment
                             {
                                 Id = c.Id,
                                 PostId = postId,
                                 Comment = c.Comment,
                                 User = context.Users.SingleOrDefault(x => x.Id == c.UserId),
                                 CreatedDate = c.CreatedDate,
                                 UpdatedDate = c.UpdatedDate,
                                 DeletedDate = c.DeletedDate,
                                 CommentLikes = context.CommentLikes.Where(x => x.PostCommentId == c.Id).ToList()
                             };
                return await result.ToListAsync();
            }
        }
    }
}
