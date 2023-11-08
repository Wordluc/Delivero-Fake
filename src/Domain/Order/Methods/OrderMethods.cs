using Domain.Common;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    public partial class Order
    {
         public static Result<Order> New(Guid accountId, Guid restaurantId, Address address) {
            return new Order()
            {
                AccountId = accountId,
                RestaurantId = restaurantId,
                Address = address,
                OrderedDishes = new(),
                Date = new DateOnly(),
                Id = Guid.NewGuid()
            };
        }
        private float CalculateTotalCostOrder()
        {
            float totalCost = 0;
            foreach (var item in OrderedDishes) {
               totalCost += item.TotalCost;
            }
            return totalCost;
        }
    }
}
