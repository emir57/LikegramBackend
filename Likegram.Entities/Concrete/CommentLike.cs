using Likegram.Core.Entities;
using Likegram.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Entities.Concrete
{
    public class CommentLike
    {
        public int Id { get; set; }

        [NotMapped]
        public User User { get; set; }
        public int IserId { get; set; }

        [NotMapped]
        public PostComment PostComment { get; set; }
        public int PostCommentId { get; set; }
    }
}
