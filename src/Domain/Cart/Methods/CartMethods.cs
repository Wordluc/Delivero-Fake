using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cart
{
    public partial class Cart
    {
        public static Result<Cart> New(Guid accountId, Guid restaurantId)
        {
            return Result.Ok(new Cart()
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                RestaurantId = restaurantId,
                SelectedDishes = new()
            });
        }
        private float CalculateTotalCostCart()
        {
            float totalCost = 0;
            foreach (var item in SelectedDishes)
            {
                totalCost += item.TotalCost;
            }
            return totalCost;
        }
    }
}
