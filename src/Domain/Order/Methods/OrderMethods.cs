using Domain.Common;
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
         public static Result<Order> New(Guid cartId,Address address) {
            return new Order()
            {
                CartId = cartId,
                Address = address,
                BookedDishes = new(),
                Date = new DateOnly(),
                Id = Guid.NewGuid()
            };
        }
    }
}
