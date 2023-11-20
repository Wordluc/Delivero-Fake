using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GetRestaurantsParams
    {
        public string? Name { get; init; }
        public string? City { get; init; }
        public string? Via { get; init; }
        public int? AddressNumber { get; init; }

    }
}
