using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace Domain.Order
{
    public class OrderedDish : IEqual<OrderedDish>
    {
        public Guid Id { get; internal set; }
        public int Quantity { get; internal set; }
        public string NameDish { get; internal set; }
        public List<OrderedIngredient> Ingredients { get; internal set; }
        public decimal BaseCost { get; internal set; }
        public decimal TotalCost { get { return CalculateTotalCostDish(this); } }

        public override bool Equals(OrderedDish? other)
        {
            return Id == other?.Id;
        }
        private static decimal CalculateTotalCostDish(OrderedDish dish)
        {
            decimal totalCost = dish.BaseCost;
            foreach (var i in dish.Ingredients)
                totalCost += i.Quantity * i.UnitCost;
            return totalCost;
        }
    }
    public record OrderedIngredient(string Name, int Quantity,decimal UnitCost);
}
