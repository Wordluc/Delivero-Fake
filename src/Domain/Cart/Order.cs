using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cart
{
    public class Order
    {
        public Guid Id { get; internal set; }
        public Guid AccountId { get; internal set; }
        public DateOnly Date { get; internal set; }
        public Address Address { get; internal set; }

    }
}
