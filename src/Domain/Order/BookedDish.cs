using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Order
{
    public class BookedDish
    {
        public Guid Id { get;internal set; }
        public int Quantity { get; internal set; }
        public string NameDish { get; internal set; }
        public List<Ingredient> Ingredients { get; internal set; }
    }
    public record Ingredient(string Name, int Quantity);
}
