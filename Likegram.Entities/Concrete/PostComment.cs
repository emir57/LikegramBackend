using Likegram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class PostComment : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public List<CommentAnswer> CommentAnswers { get; set; }
    }
}
