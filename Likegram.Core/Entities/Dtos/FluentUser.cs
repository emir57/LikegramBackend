using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Entities.Dtos
{
    public class FluentUser
    {
        private User user = new User();
        public FluentUser SetEmail(string email)
        {
            user.Email = email;
            return this;
        }
        public FluentUser SetPasswordHash(byte[] passwordHash)
        {
            user.PasswordHash = passwordHash;
            return this;
        }
        public FluentUser SetPasswordSalt(byte[] passwordSalt)
        {
            user.PasswordSalt = passwordSalt;
            return this;
        }
        public FluentUser SetUserName(string userName)
        {
            user.Username = userName;
            return this;
        }
        public FluentUser SetFirstName(string firstName)
        {
            user.FirstName = firstName;
            return this;
        }
        public FluentUser SetLastName(string lastName)
        {
            user.LastName = lastName;
            return this;
        }
        public User GetUser()
        {
            return user;
        }
    }
}
