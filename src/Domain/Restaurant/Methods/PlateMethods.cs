
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

        public bool AddStepToDishsRecepi(string nameDish,StepRecepi step)
        {
            if (GetDish(nameDish) is Dish dish)
            {
               if(!StepRecepiIsValid(step))return false;
                var Recepi = step;
                dish.Recipe.Add(Recepi);
                return true;
            }
            return false;
        }
        public void DeleteDishRecepi(string nameDish) {
            if (GetDish(nameDish) is Dish d)
                d.Recipe = new();
        }

        public bool UpdateDistCost(string nameDish,float cost)
        {
            if (GetDish(nameDish) is Dish d)
                return SetDishCost(d, cost);
            return false;
        }
        private static bool SetDishCost(Dish dish,float cost)
        {
            if(!DishCostIsValid(cost)) return false;

            dish.Cost = cost;
            return true;
        }

        public bool UpdateDishName(string oldName, string newName)
        {
            if (GetDish(oldName) is Dish d)
                return SetDishName(d, newName);
            return false;
        }
        private bool SetDishName(Dish dish,string newName)
        {
            if (GetDish(newName) is not null) return false;
            if (!DishNameIsValid(newName)) return false;

            dish.NameDish = newName;
            return true;
        }

        private static bool SetDishType(Dish dish, string type)
        {
            if (!DishTypeIsValid(type)) return false;

            dish.Type=type;
            return true;
        }
        
    }
}
