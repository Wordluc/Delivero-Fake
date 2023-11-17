
using Domain.Common;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Restaurant;

public partial class Restaurant
{

        public static Result<Restaurant> New(string name, Address address)
        {
            var result = NameRestaurantIsValid(name);
            if (result.IsFailed) return result;

        var newRestaurant = new Restaurant()
        {
            Id=Guid.NewGuid(),
            Name = name,
            Address = address
        };
        return Result.Ok(newRestaurant);
    }

        public Result UpdateName(string name)
        {
            var result = NameRestaurantIsValid(name);
            if (result.IsFailed) return result;

            Name = name;
            return Result.Ok();
    
        }
        public void UpdateAddress(Address address)
        {            
            Address = address;
        }     
    }

