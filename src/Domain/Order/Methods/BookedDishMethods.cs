using Domain.Cart;
using Domain.Restaurant;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    public partial class Order
    {
        public Result<Guid> AddBookedDish(string nameDish,int quantity)
        {
            var dish = new BookedDish()
            {
                Id=Guid.NewGuid(),
                Quantity = quantity,
                Ingredients = new(),
                NameDish = nameDish
            };

            BookedDishes.Add(dish);
            return Result.Ok(dish.Id);
        }
        public bool AddIngredientToBookedDish(Guid dishId,string nameIngredient,int quantity)
        {
            if (string.IsNullOrEmpty(nameIngredient)) return false;
            if (quantity <= 0) return false;

            if (GetBookedDish(dishId) is BookedDish dish)
            {
                var ingredient = new Ingredient(nameIngredient, quantity);
                dish.Ingredients.Add(ingredient);
                return true;
            }
            return false;
        }
        public bool UpdateStatus(StatusOrder status)
        {
            if(status<StatusOrder)
                return false;

            StatusOrder = status;
            return true;
        }
        private BookedDish? GetBookedDish(Guid dishId)
        {
            return BookedDishes.FirstOrDefault(x=>x.Id == dishId);
        }
    }
}
