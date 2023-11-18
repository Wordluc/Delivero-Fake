
using Domain.Common;
using Domain.Restaurant;
using FluentResults;
using MediatR;

namespace Application.Command.getRestaurant;
public class GetRestaurantsHandler : IRequestHandler<GetRestaurantCommands, Result<List<Restaurant>>>
{
    private readonly IRepository _repository;
    public GetRestaurantsHandler(IRepository repository) { _repository = repository; }

    public async Task<Result<List<Restaurant>>> Handle(GetRestaurantCommands cmd, CancellationToken cancellationToken)
    {
        var r = await _repository.GetRestaurants(cmd.Name,
                                                 cmd.Address?.City,
                                                 cmd.Address?.Via,
                                                 cmd.Address?.AddressNumber);
        if (r.Count() <= 0)
            return Result.Fail("Non vi sono ristorante trovato");
        return Result.Ok(r);

    }
}

    
     