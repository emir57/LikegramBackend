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
        [ForeignKey("FollowingUserId")]
        //Takip Eden
        public User FollowingUserId { get; set; }
        [ForeignKey("FollowedUserId")]
        //Takip Edilen
        public User FollowedUserId { get; set; }
    }
}
