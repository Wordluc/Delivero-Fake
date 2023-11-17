
using Domain.Common;
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

        public Result<Guid> AddNewDish(string nameDish, decimal cost, string type)
        {
            var result=(DishNameIsValid(nameDish))
                           .And(DishCostIsValid(cost))
                           .And(DishTypeIsValid(type));
            if(result.IsFailed) return result;
            if(DishNameExist(nameDish).IsSuccess) return Result.Fail("Nome piatto già esiste");

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
        public Result DeleteDish(string nameDish)
        {
            var result = GetDish(nameDish);
            if (result.IsFailed == false) return result.ToResult();
            Menu.Remove(result.Value);
            return Result.Ok();
        }

        public Result AddIngredient(string nameDish, Ingredient ingredient)
        {
            var result = IngredientNameIsValid(ingredient.Name).And(
                IntolerancesAreValid(ingredient.Intolerances));
            if (result.IsFailed) return result;

            var resultGet = GetDish(nameDish);
            if(resultGet.IsFailed)return resultGet.ToResult();
      
            resultGet.Value.Ingredients.Add(ingredient);
            return Result.Ok();
                        
        }

        public Result UpdateDistCost(string nameDish, decimal cost)
        {
            var result = DishCostIsValid(cost);
            if(result.IsFailed) return result;

            var resultGet = GetDish(nameDish);
            if (resultGet.IsFailed) return resultGet.ToResult();
            
            resultGet.Value.Cost = cost;
            return Result.Ok();
            
        }

        public Result UpdateDishName(string nameDish, string newName)
        {
            if(DishNameExist(newName).IsSuccess) return Result.Fail("Nome piatto già esiste");

            var resultGet = GetDish(nameDish);
            if (resultGet.IsFailed) return resultGet.ToResult();

            resultGet.Value.NameDish = newName;
            return Result.Ok();
                           
        }
        public Result<Dish> GetDish(string nameDish)
        {
            if(Menu.FirstOrDefault(x => x.NameDish == nameDish) is Dish d)
                return Result.Ok(d);
            return Result.Fail("Piatto non trovato");
        }
        public Result<Dish> DishNameExist(string nameDish)
        {
            if (Menu.FirstOrDefault(x => x.NameDish == nameDish) is Dish d)
                return Result.Ok(d);
            return Result.Fail("Piatto non esiste");
        }

    }
}
