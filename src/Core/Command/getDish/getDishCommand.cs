using MediatR;
using FluentResults;
using System.Runtime.Serialization;
using Domain.Restaurant;

namespace Application.Command.getDish;
public class GetDishCommand{
    public required Guid IdRestaurant{get;init;}
    public DishParms? Dish;
}
public class DishParms{
    public string? Name;
    public string? Type;
    public string[]? Ingredients;   
    public string[]? Intollerance;
}