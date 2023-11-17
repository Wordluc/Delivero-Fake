using Domain.Account;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace Domain.Order
{
    public partial class Order:IEqual<Order>
    {
        public Guid Id { get; private set; }
        public Guid RestaurantId { get; private set; }
        public Guid AccountId { get; private set; }
        public DateOnly Date { get; private set; }
        public Address Address { get; private set; }
        public List<OrderedDish> OrderedDishes { get; private set; }
        public StatusOrder StatusOrder { get; private set; } = StatusOrder.Awaiting;
        public decimal TotalCost { get { return CalculateTotalCostOrder(); } }
        internal Order() { }
        public override bool Equals(Order? other)
        {
            return Id == other?.Id;
        }

    }
    public enum StatusOrder
    {
        Awaiting,Confirmed,InProgess,InTransit,Delivered,Cancelled
    }
}
