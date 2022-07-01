using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using Likegram.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Contexts
{
    public class LikegramDbContext : DbContext
    {
        public LikegramDbContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-HVLQH67\SQLEXPRESS;Database=LikegramDb;integrated security=true;");
        }
        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                var _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now,
                    EntityState.Deleted => data.Entity.DeletedDate = DateTime.Now,
                    _ => DateTime.Now
                };
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<CommentAnswer> CommentAnswers { get; set; }
        public DbSet<PostLike> PostLikes { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<FollowUser> FollowUsers { get; set; }
        public DbSet<FavouritePost> FavouritePosts { get; set; }
    }
}
