using Domain.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantBy_
{
    internal class GetRestaurantsByName : IChain<Restaurant, GetRestaurantsParams>
    {
        protected override bool CheckCondition(GetRestaurantsParams cmd)
        {
            if (cmd.Name is null) return false;
            return true;
        }

        protected override IEnumerable<Restaurant?> Execute(GetRestaurantsParams cmd, IEnumerable<Restaurant?> collection)
        {
            return collection.Where(x => x?.Name == cmd.Name);
        }
    }
}
