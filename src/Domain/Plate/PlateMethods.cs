
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Plate
{
    public partial class Plate
    {
        private Plate() {}
        public static Plate Create(string namePlate, float cost, string type)
        {
            var newPlate = new Plate()
            {
                NamePlate = namePlate,
                Cost = cost,
                Type = type,
                Id=Guid.NewGuid(),
                Recipe=new()
            };

            if (new ValidatorPlate().Validate(newPlate).IsValid)
            {
                return newPlate;
            }
            return null;
        }
        public bool AddStepToRecepi(string description, int neededTime, List<Ingredient> ingredients)
        {
            if (neededTime <= 0) return false;
            if (string.IsNullOrEmpty(description)) return false;

            foreach (var ingredient in ingredients)
            {
                if (ingredient.Name is null) return false;
                if (string.IsNullOrEmpty(ingredient.Name)) return false;
            }
                
            var Recepi = new StepRecepi(description, neededTime, ingredients);
            this.Recipe.Add(Recepi);
            return true;
        }
        public void DeleteRecepi() {
            this.Recipe = new();
        }
        public bool ChangeCost(float cost)
        {
            if (cost <= 0) return false;

            this.Cost = cost;
            return true;
        }
    }
}
