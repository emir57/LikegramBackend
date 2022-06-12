﻿using Likegram.Core.Entities.Concrete;
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
        public int FollowingUserId { get; set; }
        //Takip Eden
        public User FollowingUser { get; set; }

        public int FollowedUserId { get; set; }
        //Takip Edilen
        public User FollowedUser { get; set; }
    }
}
