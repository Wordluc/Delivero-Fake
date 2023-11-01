using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public record Address(string City, string Via, int AddressNumber)
    {
        internal bool IsValid()
        {
            if (string.IsNullOrEmpty(Via)) return false;
            if (AddressNumber <= 0) return false;
            if (string.IsNullOrEmpty(City)) return false;

            return true;
        }
    }
}
