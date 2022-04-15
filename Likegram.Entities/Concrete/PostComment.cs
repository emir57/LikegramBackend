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
    public class PostComment : BaseEntity
    {
        public int PostId { get; set; }
        [NotMapped]
        public Post Post { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public User User { get; set; }
        public string Comment { get; set; }
        [NotMapped]
        public List<CommentAnswer> CommentAnswers { get; set; }
    }
}
