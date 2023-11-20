using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;
public class GetDishParams{
    public required Guid IdRestaurant{get;init;}
    public string? Name;
    public string? Type;
    public List<string>? Ingredients;   
    public List<string>? Intollerance;
}