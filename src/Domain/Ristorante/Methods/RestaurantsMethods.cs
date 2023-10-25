using Domain.Ristorante.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    public partial class Restaurant
    {
        public static Restaurant? CreateRestaurant(string name, string via, int addressNumber)
        {
            if (via is null) return null;
            if(addressNumber <=0) return null;

            var newRestaurant = new Restaurant()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = new Address(via, addressNumber)
            };
            if (new ValidatorRestaurant().Validate(newRestaurant).IsValid)
                return newRestaurant;
            return null;
        }

        public bool ChangeAddress(string via,int AddressNumber)
        {
            Address = new Address(via, AddressNumber);
            if (new ValidatorRestaurant().Validate(this).IsValid)
                return true;
            return false;
        }
    }
}
