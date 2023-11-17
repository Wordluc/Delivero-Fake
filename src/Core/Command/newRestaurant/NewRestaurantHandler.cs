
using Domain.Common;
using Domain.Restaurant;
using FluentResults;
using MediatR;
using SimpleSoft.Mediator;

namespace Application.Command.newRestaurant
{
    public class NewRestaurantHandler : ICommandHandler<NewRestaurantCommands, Result<NewRestaurantResult>>
    {
        private readonly IRepository _repository;
        public NewRestaurantHandler(IRepository repository) { _repository = repository; }
        public async Task<Result<NewRestaurantResult>> HandleAsync(NewRestaurantCommands cmd, CancellationToken ct)
        {
            Result<Address> addressResult = Address.New(cmd.Address.City, cmd.Address.Via, cmd.Address.AddressNumber);
            if (addressResult.IsFailed) return Result.Fail(addressResult.Reasons.ToString());

            Result<Restaurant> restaurantResult = Restaurant.New(cmd.Name, addressResult.Value);
            if (restaurantResult.IsFailed) return Result.Fail(restaurantResult.Reasons.ToString());

            await _repository.AddRestaurant(restaurantResult.Value);

            return Result.Ok(new NewRestaurantResult() {
                Id = restaurantResult.Value.Id }
            );
        }
    }
}
     