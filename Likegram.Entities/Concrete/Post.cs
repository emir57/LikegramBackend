﻿using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string ImageUrl { get; set; }

        public List<PostComment> PostComments { get; set; }
        public string Description { get; set; }
        public List<PostLike> PostLikes { get; set; }
    }
}
