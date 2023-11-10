using Domain.Cart;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests;

public class CartAggregate
{
    [Fact]
    public void CreateDish_WithCorrectParameters()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
        var result = cart.AddDish("cous cous", 2, 2).IsSuccess;
        result.Should().BeTrue();
    }
          
    [Fact]
    public void GetTotalCostSelectedDish()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
        var dishId = cart.AddDish("cous cous", 2, 2).Value;
        cart.AddExtraIngredient(dishId, "ketchup", 2, 9);
        cart.AddExtraIngredient(dishId, "maionese", 1, 2);
        cart.GetSelectedDish(dishId)!.TotalCost.Should().Be(22);
    }
    [Fact]
    public void AddIngredient_InNotExistingDish()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
        var dishId = Guid.NewGuid();
        cart.AddExtraIngredient(dishId, "ketchup", 2, 9).Should().BeFalse();
    }
    [Fact]
    public void GetTotalCostCart()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;

        var dishId1 = cart.AddDish("cous cous", 2, 2).Value;
        cart.AddExtraIngredient(dishId1, "ketchup", 2, 9);
        cart.AddExtraIngredient(dishId1, "maionese", 1, 2);

        var dishId2=cart.AddDish("mela", 1, 2).Value;
        cart.AddExtraIngredient(dishId2, "panna", 1, 2);

        cart.TotalCost.Should().Be(26);

    }

}