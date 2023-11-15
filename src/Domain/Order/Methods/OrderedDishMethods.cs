using Domain.Cart;
using Domain.Restaurant;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    public partial class Order
    {
        public Result<OrderedDish> NewOrderedDish(string nameDish,int quantity,float unitCost)
        {
            if (!string.IsNullOrEmpty(nameDish) &&
                (quantity <= 0) &&
                (unitCost < 0)) return Result.Fail("Parametri non corretti per la creazione");

            var dish = new OrderedDish()
            {
                Id=Guid.NewGuid(),
                Ingredients = new(),
                Quantity = quantity,
                NameDish = nameDish,
                BaseCost = unitCost,
                TotalCost=unitCost*quantity
            };

            return Result.Ok(dish);
        }
        public void AddOrderedDish(OrderedDish order)
        {
            OrderedDishes.Add(order);
        }
        public bool AddExtraIngredientToOrderedDish(OrderedDish dish, OrderedIngredient orderedIngredient)
        {
            if (!(
                   !string.IsNullOrEmpty(orderedIngredient.Name) &&
                   orderedIngredient.Quantity > 0 &&
                   orderedIngredient.UnitCost > 0)) return false;

            dish.Ingredients.Add(orderedIngredient);
            dish.TotalCost = CalculateTotalCostDish(dish);
            return true;

        }
        public bool UpdateStatus(StatusOrder status)
        {
            if(status<StatusOrder)
                return false;

            StatusOrder = status;
            return true;
        }
        public OrderedDish? GetOrderedDish(Guid dishId)
        {
            if(OrderedDishes.FirstOrDefault(x=>x.Id == dishId) is OrderedDish dish)
            {
                return dish;
            }
            return null;
            
        }
        private static float CalculateTotalCostDish(OrderedDish dish)
        {
            float totalCost = dish.BaseCost;
            foreach (var i in dish.Ingredients)
                totalCost += i.Quantity * i.UnitCost;
            return totalCost;
        }
    }
}
