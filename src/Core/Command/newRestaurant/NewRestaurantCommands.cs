using MediatR;
using FluentResults;
using System.Runtime.Serialization;

namespace Application.Command.newRestaurant
{
    [DataContract]
    public class NewRestaurantCommands: IRequest<Result<NewRestaurantResult>>
    {
        public required string Name { get; init; }
        public required AddressCommand Address { get; init; }
    }
    public class AddressCommand
    {    
        public required string City { get; init; }
        public required  string Via { get; init; }
        public required int AddressNumber { get; init;}
    }
}
