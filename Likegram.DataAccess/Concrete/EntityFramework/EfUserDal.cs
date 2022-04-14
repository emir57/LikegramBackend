using Likegram.Core.DataAccess.Entityframework;
using Likegram.Core.Entities.Concrete;
using Likegram.DataAccess.Abstract;
using Likegram.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Likegram.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepostioryBase<User, LikegramDbContext>, IUserDal
    {
        public List<Role> UserRoles(User user)
        {
            using (var context = new LikegramDbContext())
            {
                var result = from r in context.Roles
                             join ur in context.UserRoles
                             on r.Id equals ur.RoleId
                             where ur.UserId == user.Id
                             select new Role
                             {
                                 Id = r.Id,
                                 Name = r.Name
                             };
                return result.ToList();
            }
        }
    }
}
