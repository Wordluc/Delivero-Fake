
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Ristorante
{
    public partial class Restaurant
    {

        public static Restaurant? CreateRestaurant(string name, string via, int addressNumber)
        {
            if (via is null) return null;
            if(addressNumber <=0) return null;

            var newRestaurant = new Restaurant();
            if (
                newRestaurant.SetName(name) &&
                newRestaurant.SetAddress(via, addressNumber)) return newRestaurant;

            return null;
        }

        public bool SetName(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (name.Length < 3 || name.Length > 20) return false;

            Name = name;
            return true;
        }
        public bool SetAddress(string via,int addressNumber)
        {
            if (string.IsNullOrEmpty(via)) return false;
            if(addressNumber <= 0) return false;

            Address = new Address(via, addressNumber); 
            return true;
        }
    }
}
