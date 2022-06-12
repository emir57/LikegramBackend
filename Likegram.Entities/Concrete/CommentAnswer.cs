using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class CommentAnswer : BaseEntity
    {
        public int PostCommentId { get; set; }
        public PostComment PostComment { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Answer { get; set; }
    }
}
