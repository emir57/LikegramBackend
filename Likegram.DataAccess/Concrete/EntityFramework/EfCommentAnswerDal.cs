using FluentEntity_ConsoleApp.FEntity;
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
    public class EfCommentAnswerDal : EFEntityRepostioryBase<CommentAnswer, LikegramDbContext>, ICommentAnswerDal
    {
        public async Task<List<CommentAnswer>> GetAllByCommentIdAsync(int commentId)
        {
            using (var context = new LikegramDbContext())
            {
                var result = from a in context.CommentAnswers
                             where a.PostCommentId == commentId
                             select new CommentAnswer
                             {
                                 Id = a.Id,
                                 Answer = a.Answer,
                                 CreatedDate = a.CreatedDate,
                                 UpdatedDate = a.UpdatedDate,
                                 DeletedDate = a.DeletedDate,
                                 User = context.Users
                                    .Select(u => new FluentEntity<User>()
                                    .AddParameter(x => x.Username, u.Username)
                                    .AddParameter(x => x.Email, u.Email)
                                    .AddParameter(x => x.ProfilePhoto, u.ProfilePhoto)
                                    .GetEntity())
                                    .SingleOrDefault(u => u.Id == a.UserId)
                             };
                return await result.ToListAsync();
            }
        }
    }
}
