﻿using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Cart.SelectedDish;

namespace Domain.Cart
{
    public partial class Cart
    {
        public Result<Guid> SelectDish(string nameDish,int quantity,float baseCost)
        {

            if (!(string.IsNullOrEmpty(nameDish) &&
                  QuantitySelectedDishIsValid(quantity))                 
                  ) return Result.Fail("Parametri ordine non corretti");
            var dish = new SelectedDish()
            {
                ExtraIngredients = new(),
                Quantity = quantity,
                NameDish = nameDish,
                Id = Guid.NewGuid(),
                BaseCost = baseCost,
            };
            SelectedDishes.Add(dish);
            return Result.Ok(dish.Id);
        }
        public bool AddDishIngredient(Guid dishId,string nameIngredient,int quantity,float unitCost)
        {
            if (!(IngredientQuantityIsValid(quantity) &&
                  IngredientNameIsValid(nameIngredient)&&
                  unitCost>=0)
                ) return false;
            var newIngredient = new ExtraIngredient()
            {
                Id = Guid.NewGuid(),
                NameIngredient = nameIngredient,
                Quantity = quantity,
                UnitCost = unitCost
            };
            if (GetSelectedDish(dishId) is SelectedDish dish)
            {
                dish.ExtraIngredients.Add(newIngredient);
                return true;
            }
            return false;
           
        }
        public bool DeleteSelectedDish(Guid dishId)
        {
            if (GetSelectedDish(dishId) is SelectedDish dish)
                return SelectedDishes.Remove(dish);
            return true;
        }
        public bool ChangeIngredientNumber(Guid dishId,string nameIngredient,int quantity)
        {
            if(!IngredientQuantityIsValid(quantity)) return false;

            if (GetSelectedDish(dishId) is SelectedDish dish)
                if (dish.ExtraIngredients.FirstOrDefault(x => x.NameIngredient == nameIngredient) is ExtraIngredient ingredient)
                {
                    if (quantity == 0) dish.ExtraIngredients.Remove(ingredient);
                    ingredient.Quantity = quantity;
                    return true;
                }
                    
            return false;
        }
        private SelectedDish? GetSelectedDish(Guid dishId)
        {
            var dish=SelectedDishes!.FirstOrDefault(x => x.Id == dishId);
            if(dish is null) return null;

            dish.TotalCost = CalculateTotalCost(dishId);
            return dish;
        }
        private float CalculateTotalCost(Guid dishId)
        {
            if (GetSelectedDish(dishId) is SelectedDish dish)
            {
                float totalCost = dish.BaseCost;
                foreach (var i in dish.ExtraIngredients)
                    totalCost = +i.Quantity * i.UnitCost;
                return totalCost;
            }
            return 0;
        }
    }
}
