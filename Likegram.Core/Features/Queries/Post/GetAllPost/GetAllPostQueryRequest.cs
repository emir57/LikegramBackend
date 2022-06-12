using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Features.Queries.Post.GetAllPost
{
    public class GetAllPostQueryRequest : IRequest<GetAllPostQueryResponse>
    {
        public int FollowingUserId { get; set; }
    }
}
