using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Repository
{
    public static class MyServiceCollectionExtensions
    {
        public static IServiceCollection AddRepository(this IServiceCollection i)
        {
            i.AddSingleton<IRepository, Repository>();
            return i;
        }
    }
}
