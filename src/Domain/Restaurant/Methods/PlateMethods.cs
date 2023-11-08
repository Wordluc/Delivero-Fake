
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurant
{
    public partial class Restaurant
    {

        public bool AddNewDish(string nameDish, float cost, string type)
        {
            if (GetDish(nameDish) is not null) return false;
            if(!(
                 DishNameIsValid(nameDish) &&
                 DishCostIsValid(cost)&&
                 DishTypeIsValid(type))
               )return false;

            var newDish = new Dish()
            {
                Id = Guid.NewGuid(),
                NameDish = nameDish,
                Cost = cost,
                Type = type
            };
            Menu.Add(newDish);
            return true;

        }
        public bool DeleteDish(string nameDish)
        {
            if(GetDish(nameDish) is Dish d)
                return Menu.Remove(d);
            return false;
        }

        public bool AddIngredient(string nameDish,Ingredient ingredient)
        {
            if (!IngredientIsValid(ingredient)) return false;

            if (GetDish(nameDish) is Dish dish)
            {
                dish.Ingredients.Add(ingredient);
                return true;
            }
            return false;
        }

        public bool UpdateDistCost(string nameDish,float cost)
        {
            if (!DishCostIsValid(cost)) return false;

            if (GetDish(nameDish) is Dish d)
            {
                d.Cost = cost;
                return true;
            }
            return false;
        }

        public bool UpdateDishName(string oldName, string newName)
        {
            if(!DishNameIsValid(newName))return false;
            if(GetDish(newName) is not null) return false;

            if (GetDish(oldName) is Dish d)
            {
                d.NameDish = newName;
                return true;
            }
            return false;
        }
        private Dish? GetDish(string nomeDish)
        {
            return Menu.FirstOrDefault(x => x.NameDish == nomeDish);
        }
        
    }
}
