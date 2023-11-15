using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{

    public class Address:IEqual<Address>
    {
        public string City { get; init; }
        public string Via { get; init; }
        public int AddressNumber { get; init; }

        private Address(string City, string Via, int AddressNumber)
        {
            this.City = City;
            this.Via = Via;
            this.AddressNumber = AddressNumber;
        }

        public static Result<Address> New(string City, string Via, int AddressNumber)
        {
            if (IsValid(City, Via, AddressNumber))
                return new Address(City, Via, AddressNumber);

            return Result.Fail("Parametri di creazione indirizzo non validi ");
        }

        internal static bool IsValid(string City, string Via, int AddressNumber)
        {
            if (string.IsNullOrEmpty(Via)) return false;
            if (AddressNumber <= 0) return false;
            if (string.IsNullOrEmpty(City)) return false;

            return true;
        }

        public override bool Equals(Address? other)
        {
            return City.Equals(other?.City)&&
                   Via.Equals(other?.Via)&&  
                   AddressNumber.Equals(other?.AddressNumber);
        }
    }
}
