
using Domain.Common;
using Domain.Restaurant;
using FluentResults;
using MediatR;
using Repository;

namespace Application.Command.getRestaurant;
public class GetRestaurantsHandler : IRequestHandler<GetRestaurantCommands, Result<List<Restaurant>>>
{
    private readonly IRepository _repository;
    public GetRestaurantsHandler(IRepository repository) { _repository = repository; }

    public async Task<Result<List<Restaurant>>> Handle(GetRestaurantCommands cmd, CancellationToken cancellationToken)
    {
        GetRestaurantsParams cmdGet = new()
        {
            AddressNumber = cmd.Address?.AddressNumber,
            City = cmd.Address?.City,
            Via = cmd.Address?.Via,
            Name = cmd.Name,
        };
        var r = await _repository.GetRestaurants(cmdGet);
        if (r.Count() <= 0)
            return Result.Fail("Nessun ristorante trovato con i seguenti parametri");
        return Result.Ok(r);

    }
}

    
     