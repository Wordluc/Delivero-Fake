using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace Domain.Order
{
    public class OrderedDish
    {
        public Guid Id { get;internal set; }
        public int Quantity { get; internal set; }
        public string NameDish { get; internal set; }
        public List<OrderedIngredient> Ingredients { get; internal set; }
        public float BaseCost { get; internal set; }
        public float TotalCost { get { return CalculateTotalCostOrder(); } }

        private float CalculateTotalCostOrder()
        {
            float totalCost = BaseCost;
            foreach (var i in Ingredients)
                totalCost += i.Quantity * i.UnitCost;
            return totalCost;
        }
    }
    public record OrderedIngredient(string Name, int Quantity,float UnitCost);
}
