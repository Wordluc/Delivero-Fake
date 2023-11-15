
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant
{
    public partial class Restaurant
    {

        public Result<Dish> NewDish(string nameDish, float cost, string type)
        {
            if(!(
                 (IsDishNameExist(nameDish)==false)&&
                 DishNameIsValid(nameDish) &&
                 DishCostIsValid(cost)&&
                 DishTypeIsValid(type))
               )return Result.Fail("Impossibile creare un piatto");

            var newDish = new Dish()
            {
                Id = Guid.NewGuid(),
                NameDish = nameDish,
                Cost = cost,
                Type = type
            };
            return Result.Ok(newDish);

        }
        public void AddDish(Dish dish)
        {
            Menu.Add(dish);
        }
        public bool DeleteDish(Dish dish)
        {
            return Menu.Remove(dish);
        }

        public bool AddIngredientTo(Dish dish, Ingredient ingredient)
        {
            if (!IngredientIsValid(ingredient)) return false;

            dish.Ingredients.Add(ingredient);
            return true;
            
        }

        public bool UpdateDistCost(Dish dish,float cost)
        {
            if (!DishCostIsValid(cost)) return false;

            dish.Cost = cost;
            return true;
        }

        public bool UpdateDishName(Dish dish, string newName)
        {
            if(IsDishNameExist(newName)==false) return false;

             dish.NameDish = newName;
             return true;
        }
        public Dish? GetDish(Guid dishId)
        {
            return Menu.FirstOrDefault(x => x.Id == dishId);
        }
        public bool IsDishNameExist(string nameDish)
        {
            return Menu.FirstOrDefault(x => x.NameDish == nameDish) is not null;
        }

    }
}
