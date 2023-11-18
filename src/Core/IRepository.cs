using Domain.Restaurant;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using System.Reflection;

namespace Application
{
    public interface IRepository
    {
        public Task AddRestaurant(Restaurant r);
        public Task<List<Restaurant>> GetRestaurants(CommandGet cmd);
    }
    public static class InjectMedietor{
        public static IServiceCollection AddhandlerMediator(this IServiceCollection i)
        {
            i.AddMediatR(o => o.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return i;
        }

    }
}
