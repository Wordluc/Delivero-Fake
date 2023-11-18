using Domain.Restaurant;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public interface IRepository
    {
        public Task<bool> AddRestaurant(Restaurant r);
    }
    public static class prova{
        public static IServiceCollection AddhandlerMediator(this IServiceCollection i)
        {
            i.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return i;
        }

    }
}
