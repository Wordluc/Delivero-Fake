using Domain.Cart;
using Domain.Common;
using Domain.Restaurant;
using FluentResults;

namespace Domain.Order
{
    public partial class Order
    {
        public Result<Guid> AddOrderedDish(string nameDish,int quantity,decimal unitCost)
        {
            var result = IsNameDishOrderedValid(nameDish)
                 .And(IsQuantityDishOrderedValid(quantity)
                 .And(IsUnitCostOrderredDishValid(unitCost)));


            if (result.IsFailed) return result;     

            var dish = new OrderedDish()
            {
                Id=Guid.NewGuid(),
                Ingredients = new(),
                Quantity = quantity,
                NameDish = nameDish,
                BaseCost = unitCost
            };

            OrderedDishes.Add(dish);
            return Result.Ok(dish.Id);
        }
        public Result AddExtraIngredientToOrderedDish(Guid dishId, OrderedIngredient orderedIngredient)
        {
            var result = IsNameExtraIngredientValid(orderedIngredient.Name)
                        .And(IsQuantityExtraIngredientValid(orderedIngredient.Quantity)
                        .And(IsUnitCostExtraIngredientValid(orderedIngredient.UnitCost)));

            if (result.IsFailed) return result;

            var resultDish = GetOrderedDish(dishId);
            if (result.IsFailed) return result;

            resultDish.Value.Ingredients.Add(orderedIngredient);
            return Result.Ok();

        }

            public Result UpdateStatus(StatusOrder status)
            {
            var result = IsStatusOrderValid(status);
            if (result.IsFailed) return result;

            StatusOrder = status;
            return Result.Ok();
            }

            public Result<OrderedDish> GetOrderedDish(Guid dishId)
            {
                if (OrderedDishes.FirstOrDefault(x => x.Id == dishId) is OrderedDish dish)
                {
                    return Result.Ok(dish);
                }
                return Result.Fail("Piatto ordinato non trovato");

            }
        }
        
    }
