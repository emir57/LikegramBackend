using Likegram.Core.Entities.Concrete;
using Likegram.Core.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Abstract
{
    public interface IUserService
    {
        Task<IResult> Add(User user);
        Task<IResult> Update(User user);
        Task<IResult> Delete(User user);

        Task<IDataResult<User>> GetByEmail(string email);
        Task<IDataResult<User>> GetByUsername(string userName);
        Task<IDataResult<User>> GetById(int id);
        Task<IDataResult<List<User>>> GetAll();

        IDataResult<List<Role>> UserRoles(User user);
    }
}
