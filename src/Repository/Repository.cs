using Application;
using Domain.Restaurant;
using Repository.ChainGet;
using Repository.ChainGet.GetRestaurantType;
using Repository.ChainGet.GetRestaurantType.ByLocation;

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
            IChain<Restaurant> head = new ChainGetByName<Restaurant>()
                                          .AddChain(new ChainGetByAddress<Restaurant>())
                                          .AddChain(new ChainGetByVia<Restaurant>())
                                          .AddChain(new ChainGetByCity<Restaurant>());
        
            return await Task.Run(()=>head.TryToExecute(cmd, restaurants).ToList());
        }
    }
}