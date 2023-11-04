using Domain.Restaurant;
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
        public Result<Guid> SelectDish(string nameDish,int quantity)
        {

            if (!(string.IsNullOrEmpty(nameDish) &&
                  QuantitySelectedDishIsValid(quantity))                 
                  ) return Result.Fail("Parametri ordine non corretti");
            var dish = new SelectedDish()
            {
                Ingredients = new(),
                Quantity = quantity,
                NameDish = nameDish,
                Id = Guid.NewGuid(),
            };
            SelectedDishes.Add(dish);
            return Result.Ok(dish.Id);
        }
        private SelectedDish? GetSelectedDish(Guid dishId)
        {
            return SelectedDishes!.FirstOrDefault(x => x.Id == dishId);
        }
        public bool AddDishIngredient(Guid dishId,string nameIngredient,int quantity)
        {
            if (!(IngredientQuantityIsValid(quantity) &&
                IngredientNameIsValid(nameIngredient)
                )) return false;
            var newIngredient = new Ingredient()
            {
                Id = Guid.NewGuid(),
                NameIngredient = nameIngredient,
                Quantity = quantity
            };
            if (GetSelectedDish(dishId) is SelectedDish dish)
            {
                dish.Ingredients.Add(newIngredient);
                return true;
            }
            return false;
           
        }
        public bool DeleteSelectedDish(Guid dishId)
        {
            if (GetSelectedDish(dishId) is SelectedDish dish)
                return SelectedDishes.Remove(dish);
            return true;
        }
        public bool ChangeIngredientNumber(Guid dishId,string nameIngredient,int quantity)
        {
            if(!IngredientQuantityIsValid(quantity)) return false;

            if (GetSelectedDish(dishId) is SelectedDish dish)
                if (dish.Ingredients.FirstOrDefault(x => x.NameIngredient == nameIngredient) is Ingredient ingredient)
                {
                    if (quantity == 0) dish.Ingredients.Remove(ingredient);
                    ingredient.Quantity = quantity;
                    return true;
                }
                    
            return false;
        }

    }
}
