using MediatR;
using FluentResults;
using System.Runtime.Serialization;
using static Application.Command.ElemetalCommand;

namespace Application.Command.newRestaurant
{
    [DataContract]
    public class NewRestaurantCommands: IRequest<Result<NewRestaurantResult>>
    {
        public required string Name { get; init; }
        public required AddressCommand Address { get; init; }
    }

}
