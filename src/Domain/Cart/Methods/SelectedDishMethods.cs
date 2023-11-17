using Domain.Common;
using Domain.Order;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Cart.SelectedDish;

namespace Domain.Cart
{
    public partial class Cart
    {
        public Result<Guid> AddDish(string nameDish,int quantity,decimal baseCost)
        {

            var resultValidation = DishNameIsValid(nameDish)
                                        .And(QuantitySelectedDishIsValid(quantity))
                                        .And(DishCostIsValid(baseCost));

            if (resultValidation.IsFailed)
                return resultValidation;

            var dish = new SelectedDish()
            {
                ExtraIngredients = new(),
                Quantity = quantity,
                NameDish = nameDish,
                Id = Guid.NewGuid(),
                BaseCost = baseCost
            };
            SelectedDishes.Add(dish);
            return Result.Ok(dish.Id);
        }
        public Result AddExtraIngredient(Guid dishId,string nameIngredient,int quantity,decimal unitCost)
        {
            var resultValidation = IngredientQuantityIsValid(quantity)
                                    .And(IngredientNameIsValid(nameIngredient))
                                    .And(IngredientCostIsValid(unitCost));
            if (resultValidation.IsFailed)
                return resultValidation;

            var newIngredient = new ExtraIngredient()
            {
                Id = Guid.NewGuid(),
                NameIngredient = nameIngredient,
                Quantity = quantity,
                UnitCost = unitCost
            };
            var result = GetSelectedDish(dishId);
            if (result.IsFailed) return result.ToResult();
                       
            result.Value.ExtraIngredients.Add(newIngredient);
            return Result.Ok();
        }
        public Result<SelectedDish> DeleteSelectedDish(Guid dishId)
        {
            var result = GetSelectedDish(dishId);
            if (result.IsFailed) return result;
            
            return SelectedDishes.Remove(result.Value)?Result.Ok():Result.Fail("Impossibile eliminare il piatto");
        }
        public Result ChangeIngredientNumber(Guid dishId,string nameIngredient,int quantity)
        {
            var result = IngredientQuantityIsValid(quantity);
            if(result.IsFailed)return result;

            var resultDish = GetSelectedDish(dishId);
            if (resultDish.IsFailed) return result;

            var dish = resultDish.Value;
            if (dish.ExtraIngredients.FirstOrDefault(x => x.NameIngredient == nameIngredient) is ExtraIngredient ingredient)
            {
                if (quantity == 0) dish.ExtraIngredients.Remove(ingredient);
                ingredient.Quantity = quantity;
                return Result.Ok();
            }
            return Result.Fail("Ingredient non esiste");
   

        }
        public Result<SelectedDish> GetSelectedDish(Guid dishId)
        {
            if (SelectedDishes!.FirstOrDefault(x => x.Id == dishId) is SelectedDish dish) return Result.Ok(dish);
            return Result.Fail("Dish non esistente");
        }   
    }
}
