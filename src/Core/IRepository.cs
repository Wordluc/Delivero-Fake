using Domain.Restaurant;

namespace Application
{
    public interface IRepository
    {
        public Task<bool> AddRestaurant(Restaurant r);
    }
}
