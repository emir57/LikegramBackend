using Likegram.Core.DataAccess;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<Role> UserRoles(User user);
    }
}
