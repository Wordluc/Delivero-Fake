using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class GetDishesParams
    {
        public required Guid IdRestaurant { get; init; }
        public List<string>? Intollerance { get; init; }
        public string? Type {  get; init; }
        public string? Category {  get; init; }
    }
}
