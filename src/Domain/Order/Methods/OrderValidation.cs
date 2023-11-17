using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    public partial class Order
    {
        private Result IsNameDishOrderedValid(string name)
        {
            if (string.IsNullOrEmpty(name)) return Result.Fail("Nome piatto ordinato non valido");
            return Result.Ok();
        }
        private Result IsQuantityDishOrderedValid(int quantity)
        {
            if (quantity is <= 0 or >100) Result.Fail("Quantità piatto ordinato non valido");
            return Result.Ok();
        }
        private Result IsUnitCostOrderredDishValid(decimal unitCost)
        {
            if(unitCost<=0) return Result.Fail("UnitCost piatto ordinato non valido");
            return Result.Ok();
        }
        private Result IsNameExtraIngredientValid(string name)
        {
            if (string.IsNullOrEmpty(name)) return Result.Fail("Nome ingredienti extra non valido");
            return Result.Ok();
        }
        private Result IsQuantityExtraIngredientValid(int quantity)
        {
            if (quantity is <= 0 or > 100) Result.Fail("Quantità ingredienti extra non valido");
            return Result.Ok();
        }
        private Result IsUnitCostExtraIngredientValid(decimal unitCost)
        {
            if (unitCost <= 0) return Result.Fail("UnitCost ingredienti extra non valido");
            return Result.Ok();
        }
        private Result IsStatusOrderValid(StatusOrder status)
        {
            if (status < StatusOrder) return Result.Fail("Stato ordine non valido");
            return Result.Ok();
        }
    }
}
