using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class CommentLike : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int CommentId { get; set; }
        public PostComment PostComment { get; set; }
    }
}
