using Domain.Common;
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
        public static bool NameRestaurantIsValid(string name)
        {

            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length < 3 || name.Length > 20) return false;

            return true;
        }
        public static bool AddressRestaurantIsValid(Address address)
        {
            if (string.IsNullOrEmpty(address.Via)) return false;
            if (address.AddressNumber <= 0) return false;
            if (string.IsNullOrEmpty(address.City)) return false;

            return true;
        }
        public static bool DishCostIsValid(float cost)
        {
            if (cost <= 0) return false;
            return true;
        }
        public static bool DishNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length < 3 || name.Length > 20) return false;
            return true;
        }
        public static bool DishTypeIsValid(string type)
        {
            if (string.IsNullOrEmpty(type)) return false;
            if (!TypeDish.TryParse(type, false, out TypeDish _)) return false;
            return true;
        }
        public static bool StepRecepiIsValid(StepRecepi step)
        {
            if (step.NeededTime <= 0) return false;
            if (string.IsNullOrEmpty(step.Description)) return false;

            foreach (var ingredient in step.Ingredients!)
            {
                if (ingredient.Name is null) return false;
                if (string.IsNullOrEmpty(ingredient.Name)) return false;
            }
            return true;

        }
    }
}
