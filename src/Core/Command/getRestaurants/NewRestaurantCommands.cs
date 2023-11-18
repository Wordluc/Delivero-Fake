using MediatR;
using FluentResults;
using System.Runtime.Serialization;
using static Application.Command.ElemetalCommand;
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
