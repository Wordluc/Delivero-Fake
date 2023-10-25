using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ristorante
{
    partial class Restaurant
    {
        public Guid Id {get; set;}
        public required string Name { get; set;}
        public required Address Address { get; set; }
        public List<Plate> Menu { get; set; } = new();

    }
}
