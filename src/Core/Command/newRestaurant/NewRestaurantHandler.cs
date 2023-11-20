
using Domain.Common;
using Domain.Restaurant;
using FluentResults;
using MediatR;

namespace Application.Command.newRestaurant
{
    public class NewRestaurantHandler : IRequestHandler<NewRestaurantCommands, Result<NewRestaurantResult>>
    {
        private readonly IRepository _repository;
        public NewRestaurantHandler(IRepository repository) { _repository = repository; }

        public async Task<Result<NewRestaurantResult>> Handle(NewRestaurantCommands cmd, CancellationToken cancellationToken)
        {
            Result<Address> addressResult = Address.New(cmd.Address.City!, cmd.Address.Via!, cmd.Address.AddressNumber);
            if (addressResult.IsFailed) return addressResult.ToResult();

            Result<Restaurant> restaurantResult = Restaurant.New(cmd.Name, addressResult.Value);
            if (restaurantResult.IsFailed) return restaurantResult.ToResult();

            await _repository.AddRestaurant(restaurantResult.Value);

            return Result.Ok(new NewRestaurantResult()
            {
                Id = restaurantResult.Value.Id
            }
            );
        }
    }
}
     