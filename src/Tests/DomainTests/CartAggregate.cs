﻿using Domain.Cart;
using Domain.Restaurant;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void CreateDish_WithIncorrectCost()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
            cart.AddDish("cous cous", 2, -3).Reasons[0].Message.Should().Be("Cost dish non valido");
        }
        [Fact]
        public void GetTotalCostSelectedDish()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
            var dishId = cart.AddDish("cous cous", 2, 2).Value;
            cart.AddExtraIngredient(dishId, "ketchup", 2, 9);
            cart.AddExtraIngredient(dishId, "maionese", 1, 2);
            cart.GetSelectedDish(dishId).Value!.TotalCost.Should().Be(22);
        }
        [Fact]
        public void AddIngredient_InNotExistingDish()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
            var dishId = Guid.NewGuid();
            cart.AddExtraIngredient(dishId, "ketchup", 2, 9).Reasons[0].Message.Should().Be("Dish non esistente");
        }
        [Fact]
        public void GetTotalCostCart()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;

            var dish1 = cart.AddDish("cous cous", 2, 2).Value;
            cart.AddExtraIngredient(dish1, "ketchup", 2, 9);
            cart.AddExtraIngredient(dish1, "maionese", 1, 2);

            var dish2=cart.AddDish("mela", 1, 2).Value;
            cart.AddExtraIngredient(dish2, "panna", 1, 2);

            cart.TotalCost.Should().Be(26);

        }
        [Fact]
        public void AddDish_WithWrongName_AndWrongQuantity()
        {
            var cart = Cart.New(Guid.NewGuid(), Guid.NewGuid()).Value;
            var result = cart.AddDish("", -2, 2);
            result.Reasons[0].Message.Should().Be("Quantità dish non valida");
            result.Reasons[1].Message.Should().Be("Nome Dish non valido");
        }

    }
}
