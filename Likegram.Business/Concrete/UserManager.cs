using Likegram.Business.Abstract;
using Likegram.Business.Constants;
using Likegram.Core.Aspects.Autofac.Performance;
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
            await _userDal.Add(user);
            return new SuccessResult(BusinessMessages.SuccessAdd);
        }

        public async Task<IResult> Delete(User user)
        {
            await _userDal.Delete(user);
            return new SuccessResult(BusinessMessages.SuccessDelete);
        }
        [PerformanceAspect(5)]
        public async Task<IDataResult<List<User>>> GetAll()
        {
            var result = await _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<User>> GetByEmail(string email)
        {
            var result = await _userDal.Get(u=>u.Email == email);
            return new SuccessDataResult<User>(result, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IDataResult<User>> GetById(int id)
        {
            var result = await _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IDataResult<User>> GetByUsername(string userName)
        {
            var result = await _userDal.Get(u => u.Username == userName);
            return new SuccessDataResult<User>(result, BusinessMessages.UnSuccessfulList);
        }

        public async Task<IResult> Update(User user)
        {
            await _userDal.Update(user);
            return new SuccessResult(BusinessMessages.SuccessUpdate);
        }

        public IDataResult<List<Role>> UserRoles(User user)
        {
            var roles = _userDal.UserRoles(user);
            return new SuccessDataResult<List<Role>>(roles, BusinessMessages.SuccessList);
        }
    }
}
