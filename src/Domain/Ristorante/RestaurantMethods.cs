using Domain.Ristorante.Validation;
using Domain.Ristorante.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    partial class Restaurant
    {
        public static Restaurant? CreateRestaurant(string name,string via,int addressNumber)
        {
            var newRestaurant=new Restaurant() { 
                Id=Guid.NewGuid(),
                Name = name,
                Address = new Address(via,addressNumber)
            };
            if(new ValidatorRestaurant().Validate(newRestaurant).IsValid)
                return newRestaurant;
            return null;
        }
        public bool AddItemToMenu(string namePlate,float cost,string type,List<StepRecepi> recipe)
        {
            var ValidatorItem = new ValidatorPlate();
            recipe.ForEach(item => {
                if (!ValidatorItem.Validate(item).IsValid) return false;
            });
            var ItemMenu=new Plate() {
                Id=Guid.NewGuid(),
                NamePlate=namePlate,
                Cost= cost,
                Type=type,
                Recipe = recipe
            };
            if()
        }
    }
}
