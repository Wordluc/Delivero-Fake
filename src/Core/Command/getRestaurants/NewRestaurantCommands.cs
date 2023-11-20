using MediatR;
using FluentResults;
using System.Runtime.Serialization;
using Domain.Restaurant;

namespace Application.Command.getRestaurant
{
    [DataContract]
    public class GetRestaurantCommands: IRequest<Result<List<Restaurant>>>
    {
        public string? Name { get; init; }
        public AddressCommand? Address { get; init; }
    }
}
