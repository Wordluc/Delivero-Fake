using Domain.Common;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant
{
    public partial class Restaurant
    {
        private static Result NameRestaurantIsValid(string name)
        {

            if (string.IsNullOrEmpty(name) &&
                name.Length is < 3 or > 20) return Result.Fail("Nome ristorante non valido");

            return Result.Ok();
        }

        private static Result DishCostIsValid(decimal cost)
        {
            if (cost <= 0) return Result.Fail("Costo piatto non valido");
            return Result.Ok();
        }
        private static Result DishNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name)&&
                name.Length < 3 || name.Length > 20) return Result.Fail("Nome piatto non valido");
            return Result.Ok();
        }
        private static Result DishTypeIsValid(string type)
        {
            if (string.IsNullOrEmpty(type)&&
                !TypeDish.TryParse(type, false, out TypeDish _)) return Result.Fail("Tipo piatto non valido");
            return Result.Ok();
        }
        private static Result IngredientNameIsValid(string name)
        {
            if (string.IsNullOrEmpty(name)
                &&name.Length is <3 or >20) return Result.Fail("Nome ingrediente non valido");
            return Result.Ok();
        }

        private static Result IntolerancesAreValid(List<Intolerance>? Intolerances)
        {
            var result = Result.Ok();
            if(Intolerances is null)return Result.Ok();

            foreach (var i in Intolerances) {
                if (i.Name is null) result.WithError("Nome intolleranza non valido");
                if (i.Name?.Length is < 3 or > 20) result.WithError("Nome intolleranza non valido");
                if (i.Description is null) result.WithError("Nome intolleranza non valido");
                if (i.Description?.Length is < 3 or > 40) result.WithError("Nome intolleranza non valido");
            }

            return result;

        }
    }
}
