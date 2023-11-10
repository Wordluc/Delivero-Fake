using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Restaurant;
#pragma warning disable CS8618
public partial class Restaurant
{
    public Guid Id {get; private set;}= Guid.NewGuid();
    public string Name { get; private set;}
    public Address Address { get; private set; }
    public virtual List<Dish> Menu { get; private set; } = new();

}