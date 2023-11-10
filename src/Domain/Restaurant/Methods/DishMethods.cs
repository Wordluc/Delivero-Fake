
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant;

public partial class Restaurant
{

    public Result<Guid> AddNewDish(string nameDish, float cost, string type)
    {
        if(!(
               (IsDishNameExist(nameDish)==false)&&
               DishNameIsValid(nameDish) &&
               DishCostIsValid(cost)&&
               DishTypeIsValid(type))
          )return Result.Fail("Impossibile creare un piatto ");

        var newDish = new Dish()
        {
            Id = Guid.NewGuid(),
            NameDish = nameDish,
            Cost = cost,
            Type = type
        };
        Menu.Add(newDish);
        return Result.Ok(newDish.Id);

    }
    public bool DeleteDish(Guid dishId)
    {
        if(GetDish(dishId) is Dish d)
            return Menu.Remove(d);
        return false;
    }

    public bool AddIngredient(Guid dishId, Ingredient ingredient)
    {
        if (!IngredientIsValid(ingredient)) return false;

        if (GetDish(dishId) is Dish dish)
        {
            dish.Ingredients.Add(ingredient);
            return true;
        }
        return false;
    }

    public bool UpdateDistCost(Guid dishId,float cost)
    {
        if (!DishCostIsValid(cost)) return false;

        if (GetDish(dishId) is Dish d)
        {
            d.Cost = cost;
            return true;
        }
        return false;
    }

    public bool UpdateDishName(Guid dishId, string newName)
    {
        if(IsDishNameExist(newName)==false) return false;

        if (GetDish(dishId) is Dish d)
        {
            d.NameDish = newName;
            return true;
        }
        return false;
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