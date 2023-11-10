using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant;

public partial class Restaurant
{
    private static bool NameRestaurantIsValid(string name)
    {

        if (string.IsNullOrEmpty(name)) return false;
        if (name.Length < 3 || name.Length > 20) return false;

        return true;
    }
     
    private static bool DishCostIsValid(float cost)
    {
        if (cost <= 0) return false;
        return true;
    }
    private static bool DishNameIsValid(string name)
    {
        if (string.IsNullOrEmpty(name)) return false;
        if (name.Length < 3 || name.Length > 20) return false;
        return true;
    }
    private static bool DishTypeIsValid(string type)
    {
        if (string.IsNullOrEmpty(type)) return false;
        if (!TypeDish.TryParse(type, false, out TypeDish _)) return false;
        return true;
    }
    private static bool IngredientIsValid(Ingredient ingredient)
    {
        if (ingredient?.Intolerances is null)return false;
        if (ingredient.Name is null) return false;
        if (string.IsNullOrEmpty(ingredient.Name)) return false;

        foreach (var i in ingredient.Intolerances) {
            if (i.Name is null) return false;
            if (i.Name.Length is < 3 or > 20) return false;
            if (i.Description is null) return false;
            if (i.Description.Length is < 3 or > 40) return false;
        }
        
        return true;

    }
}