using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class FollowUser
    {
        public int Id { get; set; }
        //Takip Eden
        [ForeignKey("FollowingUserId")]
        public User FollowingUser { get; set; }

        //Takip Edilen
        [ForeignKey("FollowedUserId")]
        public User FollowedUser { get; set; }
    }
}
