using Application;
using Domain.Restaurant;
using Microsoft.Extensions.DependencyInjection;

namespace Repository
{ 

    public class Repository : IRepository
    {
        public Task<bool> AddRestaurant(Restaurant r)
        {
            return Task.FromResult(true);
        }
    }
}