using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace Domain.Cart
{
    public class SelectedDish
    {
        public Guid Id { get; internal set; }
        public string NameDish { get; internal set; }
        public int Quantity { get; internal set; }
        public List<ExtraIngredient> ExtraIngredients { get; internal set; }
        public float BaseCost { get; internal set; }
        public float TotalCost { get {return GetTotalCostSelectedDish(); } }

        private float GetTotalCostSelectedDish()
        {
            float totalCost = BaseCost;
            foreach (var i in ExtraIngredients)
                totalCost += i.Quantity * i.UnitCost;
            return totalCost;
        }

    }

    public class ExtraIngredient {
        public Guid Id { get; internal set; }
        public string NameIngredient { get; internal set; }
        public int Quantity { get; internal set; }
        public float UnitCost { get; internal set; }
    }

}
