﻿using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class PostComment : BaseEntity
    {
        [ForeignKey("PostId")]
        public Post Post { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Comment { get; set; }
        public List<CommentAnswer> CommentAnswers { get; set; }
    }
}
