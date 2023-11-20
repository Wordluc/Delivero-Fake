using Application;
using Application.Command.getDish;
using Domain.Restaurant;
using GetDishByName;
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

        public Task<List<Restaurant>> GetDishFromRestaurants(GetDishesParams cmd)
        {
            var restaurant = restaurants.Where(x=>x.Id==cmd.IdRestaurant).FirstOrDefault();
            if (restaurant is null) return Task.Run(null);
            IChain<Dish, GetDishesParams> head = new GetDishByIntollerance()
                                                 .AddChain(new GetDishByType());

            return await Task.Run(() => head.TryToExecute(cmd, restaurants).ToList());

        }

        public async Task<List<Restaurant>> GetRestaurants(GetRestaurantsParams cmd)
        {
            IChain<Restaurant, GetRestaurantsParams> head = new GetRestaurantByAddress()
                                                               .AddChain(new GetRestaurantByName())
                                                               .AddChain(new GetRestaurantByVia())
                                                               .AddChain(new GetRestaurantByCity());
        
            return await Task.Run(()=>head.TryToExecute(cmd, restaurants).ToList());
        }
    }
}