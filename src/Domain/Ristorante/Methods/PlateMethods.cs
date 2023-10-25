using Domain.Ristorante.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    public partial class Restaurant
    {
        public bool AddPlate(string namePlate, float cost, string type)
        {
            var newPlate = new Plate()
            {
                Id = Guid.NewGuid(),
                NamePlate = namePlate,
                Cost = cost,
                Type = type,
                Recipe = new()
            };
            if (new ValidatorPlate().Validate(newPlate).IsValid)
            {
                
                Menu.Add(newPlate);
                return true;
            }
            return false;
        }
        public bool DeletePlate(Guid idPlate)
        {
            var Plate = Menu.FirstOrDefault(p => p.Id == idPlate);
            if (Plate is null) return false;

            Menu.Remove(Plate);
            return true;
        }
        public bool AddStepToPlateRecepi(Guid idPlate, string description, int neededTime, List<Ingredient> ingredients)
        {
            var Plate = Menu.FirstOrDefault(x => x.Id == idPlate);
            if (Plate is null) return false;

            if (neededTime < 0) return false;
            if (description is null) return false;
            foreach (var i in ingredients)
                if (i is null) return false;

            var Recepi = new StepRecepi(description, neededTime, ingredients);
            Plate.Recipe.Add(Recepi);
            return true;
        }
    }
}
