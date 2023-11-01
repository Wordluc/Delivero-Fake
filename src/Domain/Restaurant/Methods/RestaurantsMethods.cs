
using Domain.Common;
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

        public static Restaurant? New(string name, Address address)
        {      
            if (!(
                NameRestaurantIsValid(name)&&
                address.IsValid())
                ) 
                return null;

            var newRestaurant = new Restaurant()
            {
                 Id=Guid.NewGuid(),
                Name = name,
                Address = address
            };
            return newRestaurant;
        }

        public bool SetName(string name)
        {
            if (!NameRestaurantIsValid(name)) return false;

            Name = name;
            return true;
    
        }
        public bool SetAddress(Address address)
        {
            if (!address.IsValid()) return false;
            
            Address = address;
            return false;
        }

     
    }
}
