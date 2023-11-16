using Domain.Cart;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests
{
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
            cart.GetSelectedDish(dishId)?.TotalCost.Should().Be(22);
        }
        [Fact]
        public void GetTotalCartCost()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;

            var dish1 = cart.AddDish("cous cous", 2, 2).Value;
            cart.AddExtraIngredient(dish1, "ketchup", 2, 9);
            cart.AddExtraIngredient(dish1, "maionese", 1, 2);

            var dish2=cart.AddDish("mela", 1, 2).Value;
            cart.AddExtraIngredient(dish2, "panna", 1, 2);

            cart.TotalCost.Should().Be(26);

        }

    }
}
