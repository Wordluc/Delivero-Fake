﻿using Domain.Common;
using Domain.Order;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DomainTests
{
    public class OrderAggregate
    {
        [Fact]
        public void AddIngredientToOrderedDish()
        {
            var address = Address.New("pavia", "via bello", 34).Value;
            var order = Order.New(Guid.NewGuid(),Guid.NewGuid(),address).Value;
            var orderedDishid=order.AddOrderedDish("cous cous", 1, 10).Value;
            order.AddIngredientToOrderedDish(orderedDishid, new("piselli", 2, 2)).Should().BeTrue();
        }
        [Fact]
        public void GetTotalCostOrder()
        {
            var address = Address.New("pavia", "via bello", 34).Value;
            var order = Order.New(Guid.NewGuid(), Guid.NewGuid(), address).Value;
            var orderedDishid = order.AddOrderedDish("cous cous", 1, 10).Value;
            order.AddIngredientToOrderedDish(orderedDishid, new("piselli", 2, 2));
            order.TotalCost.Should().Be(14);
        }
    }
}