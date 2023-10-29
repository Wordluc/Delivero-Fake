
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    public partial class Restaurant
    {

        public bool? AddNewDish(string nameDish, float cost, string type)
        {
            if (GetDish(nameDish) is not null) return null;

            var newDish = new Dish();
            if(!(
                SetDishName(newDish, nameDish) &&
                SetDishCost(newDish, cost) &&
                SetDishType (newDish, type))
               )return false;

            Menu.Add(newDish);
            return true;

        }
        public bool DeleteDish(Dish dish)
        {
            return Menu.Remove(dish);
        }
        public Dish? GetDish(string nomeDish)
        {
            return Menu.FirstOrDefault(x => x.NameDish == nomeDish);
        }

        public bool AddStepToDishsRecepi(string nameDish,string description, int neededTime, List<Ingredient> ingredients)
        {
            if (GetDish(nameDish) is Dish dish)
            {
                if (neededTime <= 0) return false;
                if (string.IsNullOrEmpty(description)) return false;

                foreach (var ingredient in ingredients)
                {
                    if (ingredient.Name is null) return false;
                    if (string.IsNullOrEmpty(ingredient.Name)) return false;
                }

                var Recepi = new StepRecepi(description, neededTime, ingredients);
                dish.Recipe.Add(Recepi);
                return true;
            }
            return false;
        }
        public void DeleteDishRecepi(Dish dish) {
            dish.Recipe = new();
        }

        public bool SetDishCost(string nameDish,float cost)
        {
            if (GetDish(nameDish) is Dish d)
                return SetDishCost(d, cost);
            return false;
        }
        private bool SetDishCost(Dish dish,float cost)
        {
            if (cost <= 0) return false;

            dish.Cost = cost;
            return true;
        }

        public bool SetDishName(string oldName, string newName)
        {
            if (GetDish(oldName) is Dish d)
                return SetDishName(d, newName);
            return false;
        }
        private bool SetDishName(Dish dish,string name)
        {
            if (GetDish(name) is not null) return false;
            if (string.IsNullOrEmpty(name))return false;
            if (name.Length<3 || name.Length > 20) return false;

            dish.NameDish = name;
            return true;
        }

        private bool SetDishType(Dish dish, string type)
        {
            if (string.IsNullOrEmpty(type)) return false;
            if (!Enum.TryParse(type, false, out TypeDish r)) return false;

            dish.Type=r;
            return true;
        }
        
    }
}
