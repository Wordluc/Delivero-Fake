using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    public partial class Restaurant
    {
        public Guid Id {get; set;}
        public string? Name { get; private set;}
        public Address? Address { get; private set; }
        public List<Plate> Menu { get; private set; } = new();

    }
    public record Address(string Via, int AddressNumber);
}
