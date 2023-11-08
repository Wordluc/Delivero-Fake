
using Domain.Common;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant
{
    public partial class Restaurant
    {

        public static Result<Restaurant> New(string name, Address address)
        {
            if (!(
                NameRestaurantIsValid(name)
                ))
                return Result.Fail("parametri di creazione restaurant non validi") ;

            var newRestaurant = new Restaurant()
            {
                 Id=Guid.NewGuid(),
                Name = name,
                Address = address
            };
            return Result.Ok(newRestaurant);
        }

        public bool UpdateName(string name)
        {
            if (!NameRestaurantIsValid(name)) return false;

            Name = name;
            return true;
    
        }
        public bool UpdateAddress(Address address)
        {            
            Address = address;
            return false;
        }

     
    }
}
