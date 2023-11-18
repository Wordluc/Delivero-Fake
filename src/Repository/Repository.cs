using Application;
using Domain.Restaurant;
using Repository.GetRestaurant;
using Repository.GetRestaurantChain;
using Repository.GetRestaurantChain.ByLocation;

namespace Repository
{ 

    public class Repository : IRepository
    {
        internal List<Restaurant> restaurants = new List<Restaurant>();
        public  Task AddRestaurant(Restaurant r)
        {
            return Task.Run(()=>restaurants.Add(r));
        }
        public async Task<List<Restaurant>> GetRestaurants(string? name,string? city,string? via,int? addressNumber)
        {
            CommandGet cmd = new CommandGet() {
                AddressNumber = addressNumber,
                City = city,
                Via = via ,
                Name=name
            };

            IChain<Restaurant> head = new ChainGetByName<Restaurant>()
                                      .AddChain(new ChainGetByAddress<Restaurant>()
                                      .AddChain(new ChainGetByVia<Restaurant>()
                                      .AddChain(new ChainGetByCity<Restaurant>())));

            return await Task.Run(()=>head.TryToExecute(cmd, restaurants).ToList());
        }
    }
}