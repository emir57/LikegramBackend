using Likegram.Core.Entities;
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
        public List<PostComment> PostComments { get; set; }
        public string Description { get; set; }
        public List<PostLike> PostLikes { get; set; }
    }
}
