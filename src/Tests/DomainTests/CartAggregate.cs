using Domain.Cart;
using Domain.Restaurant;
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
        var result = cart.NewDish("cous cous", 2, 2).IsSuccess;
        result.Should().BeTrue();
    }
          
    [Fact]
    public void GetTotalCostSelectedDish()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
        var dish = cart.NewDish("cous cous", 2, 2).Value;
        cart.AddExtraIngredient(dish, "ketchup", 2, 9);
        cart.AddExtraIngredient(dish, "maionese", 1, 2);
        dish.TotalCost.Should().Be(22);
    }

    [Fact]
    public void GetTotalCostCart()
    {
        var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;

        var dish1 = cart.NewDish("cous cous", 2, 2).Value;
        cart.AddExtraIngredient(dish1, "ketchup", 2, 9);
        cart.AddExtraIngredient(dish1, "maionese", 1, 2);
        cart.AddDish(dish1);

        var dish2=cart.NewDish("mela", 1, 2).Value;
        cart.AddExtraIngredient(dish2, "panna", 1, 2);
        cart.AddDish(dish2);

        cart.TotalCost.Should().Be(26);

    }

}