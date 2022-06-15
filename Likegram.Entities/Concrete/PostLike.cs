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
    public class PostLike : BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("PostId")]
        public Post Post { get; set; }
        public int? PostId { get; set; }
    }
}
