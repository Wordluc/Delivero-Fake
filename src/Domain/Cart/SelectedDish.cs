using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8618

namespace Domain.Cart
{
    public class SelectedDish:IEqual<SelectedDish>
    {
        public Guid Id { get; internal set; }
        public string NameDish { get; internal set; }
        public int Quantity { get; internal set; }
        public List<ExtraIngredient> ExtraIngredients { get; internal set; }
        public float BaseCost { get; internal set; }
        public float TotalCost { get; set; }

        public override bool Equals(SelectedDish? other)
        {
            return Id == other?.Id;
        }
    }

    public class ExtraIngredient : IEqual<ExtraIngredient>
    {
        public Guid Id { get; internal set; }
        public string NameIngredient { get; internal set; }
        public int Quantity { get; internal set; }
        public float UnitCost { get; internal set; }

        public override bool Equals(ExtraIngredient? other)
        {
            return Id==other?.Id;
        }
    }

}
