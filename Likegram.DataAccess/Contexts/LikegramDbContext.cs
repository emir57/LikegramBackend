using Likegram.Core.Entities.Concrete;
using Likegram.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Contexts
{
    public class LikegramDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HVLQH67\SQLEXPRESS;Database=LikegramDb;integrated security=true;");
        }
        public List<User> Users { get; set; }
        public List<Role> Roles { get; set; }
        public List<UserRole> UserRoles { get; set; }

        public List<Post> Posts { get; set; }
        public List<PostComment> PostComments { get; set; }
        public List<CommentAnswer> CommentAnswers { get; set; }
        public List<PostLike> PostLikes { get; set; }
        public List<CommentLike> CommentLikes { get; set; }
    }
}
