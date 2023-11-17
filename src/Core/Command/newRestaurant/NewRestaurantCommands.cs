using MediatR;
using SimpleSoft.Mediator;
using FluentResults;
namespace Application.Command.newRestaurant
{
    public class NewRestaurantCommands:Command<Result<NewRestaurantResult>>
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
