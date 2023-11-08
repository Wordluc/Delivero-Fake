using Domain.Order;
using Domain.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cart
{
    public partial class Cart
    {

        private static bool QuantitySelectedDishIsValid(int quantity)
        {
            if (quantity is < 0 or > 10) return false;
            return true;
        }
        private static bool IngredientQuantityIsValid(int quantity)
        {
            if (quantity is < 0 or > 10) return false;
            return true;
        }
        private static bool IngredientNameIsValid(string name)
        {
            if(name.Length is < 3 or > 30)return false;
            return true;
        }
    }
}
