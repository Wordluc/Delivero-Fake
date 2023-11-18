using Application;
using Domain.Restaurant;
using Repository.ChainGet;
using Repository.ChainGet.GetRestaurantChain;
using Repository.ChainGet.GetRestaurantChain.ByLocation;

namespace Repository
{

    public class Repository : IRepository
    {
        internal List<Restaurant> restaurants = new List<Restaurant>();
        public  Task AddRestaurant(Restaurant r)
        {
            return Task.Run(()=>restaurants.Add(r));
        }
        public async Task<List<Restaurant>> GetRestaurants(CommandGet cmd)
        {
            ChainBuilder<Restaurant> head = new ChainBuilder<Restaurant> ()
                                            .AddChain(new ChainGetByName<Restaurant>())
                                            .AddChain(new ChainGetByAddress<Restaurant>())
                                            .AddChain(new ChainGetByVia<Restaurant>())
                                            .AddChain(new ChainGetByCity<Restaurant>());

            return await Task.Run(()=>head.RunAll(cmd, restaurants));
        }
    }
}