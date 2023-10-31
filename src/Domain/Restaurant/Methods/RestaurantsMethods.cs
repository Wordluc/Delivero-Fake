
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
            var newRestaurant = new Restaurant();
            if (
                newRestaurant.SetName(name) &&
                newRestaurant.SetAddress(address)
                ) 
                return newRestaurant;

            return null;
        }

        public bool SetName(string name)
        {
            if (NameRestaurantIsValid(name))
            {
                Name = name;
                return true;
            }
            return false;
    
        }
        public bool SetAddress(Address address)
        {
            if (AddressRestaurantIsValid(address))
            {
                Address = address;
                return true;
            }
            return false;
        }

     
    }
}
