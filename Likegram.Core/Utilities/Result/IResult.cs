using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.Result
{
    public interface IResult
    {
        string Message { get; }
        bool Success { get; }
    }
}
