﻿using FluentResults;
#pragma warning disable CS8618

namespace Domain.Cart
{
    public partial class Cart
    {
        public Guid Id { get;internal set; }
        public Guid AccountId { get; internal set; }
        public Guid RestaurantId { get; internal set; }
        public List<SelectedDish> SelectedDishes {  get; internal set; }
        public static Result<Cart> New(Guid accountId,Guid restaurantId)
        {

            return Result.Ok(new Cart()
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                RestaurantId=restaurantId,
                SelectedDishes = new()
            });
        }
    }
}