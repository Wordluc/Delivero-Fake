using Domain.Common;
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
        public static Cart New(Guid restaurantId) {
            return new Cart()
            {
                Id=Guid.NewGuid(),
                RestaurantId = restaurantId
            };
        }
        public bool BookDish(string nameDish,int quantity=1)
        {
            if(quantity<=0) return false;

            BookedDishs.Add(new (nameDish,quantity));
            return false;
        }
        public bool DeleteBookedDish(string nameDish)
        {
            if(BookedDishs.FirstOrDefault(x => x.NameDish == nameDish) is BookedDish d)
                return BookedDishs.Remove(d); 
            return true;
        }
        public bool CreateOrder(Guid accountId,Address address)
        {
            if (!address.IsValid()) return false;
            
            var order = new Order()
            {
                Id = Guid.NewGuid(),
                AccountId = accountId,
                Address = address,
                Date = new()
            };
            Order=order;
            return true;
        }


    }
}
