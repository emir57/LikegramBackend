using Likegram.Business.Abstract;
using Likegram.Core.Entities.Concrete;
using Likegram.Core.Utilities.Result;
using Likegram.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task<IResult> Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetByUsername(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> UserRoles(User user)
        {
            throw new NotImplementedException();
        }
    }
}
