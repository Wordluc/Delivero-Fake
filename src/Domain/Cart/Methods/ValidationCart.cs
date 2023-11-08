using Domain.Order;
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

        private static Result QuantitySelectedDishIsValid(int quantity)
        {
            if (quantity is < 0 or > 10) return Result.Fail("Quantità dish non valida");
            return Result.Ok();
        }
        private static Result IngredientQuantityIsValid(int quantity)
        {
            if (quantity is < 0 or > 10) return Result.Fail("Quantità ingredient non valida");
            return Result.Ok();
        }
        private static Result IngredientNameIsValid(string name)
        {
            if(name.Length is < 3 or > 30) return Result.Fail("Nome ingredient non valido");
            return Result.Ok();
        }
        private static Result DishNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name)) return Result.Fail("Nome Dish non valido");
            return Result.Ok();
        }
        private static Result DishCostIsValid(float cost)
        {
            if (cost <= 0) return Result.Fail("Cost dish non valido");
            return Result.Ok();
        }
        private static Result IngredientCostIsValid(float cost)
        {
            if (cost <= 0) return Result.Fail("Cost dish non valido");
            return Result.Ok();
        }
    }
}
