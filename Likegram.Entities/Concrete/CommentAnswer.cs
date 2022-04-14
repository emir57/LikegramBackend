using Likegram.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class CommentAnswer : BaseEntity
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string Answer { get; set; }
    }
}
