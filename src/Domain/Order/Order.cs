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
    public partial class Order
    {
        public Guid Id { get; internal set; }
        public Guid RestaurantId { get; internal set; }
        public Guid AccountId { get; internal set; }
        public DateOnly Date { get; internal set; }
        public Address Address { get; internal set; }
        public List<OrderedDish> OrderedDishes { get; internal set; }
        public StatusOrder StatusOrder { get; internal set; } = StatusOrder.Awaiting;
        public float TotalCost { get { return CalculateTotalCostOrder(); } }
        internal Order() { }

    }
    public enum StatusOrder
    {
        Awaiting,Confirmed,InProgess,InTransit,Delivered,Cancelled
    }
}
