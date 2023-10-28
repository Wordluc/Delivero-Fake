using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
#pragma warning disable CS8618
    public partial class Restaurant
    {
        public Guid Id {get; internal set;}
        public string Name { get; internal set;}
        public Address Address { get; internal set; }
        public List<Plate> Menu { get; internal set; } 

    }
    public record Address(string Via, int AddressNumber);
}
