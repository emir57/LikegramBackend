using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Likegram.Core.Utilities.IoC
{
    public class ServiceTool
    {
        public static IServiceProvider Provider { get; private set; }
        public static IServiceCollection Create(IServiceCollection services)
        {
            Provider = services.BuildServiceProvider();
            return services;
        }
    }
}
