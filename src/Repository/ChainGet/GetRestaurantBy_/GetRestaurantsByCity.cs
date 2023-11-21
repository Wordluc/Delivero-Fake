using Domain.Restaurant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantBy_
{
    internal class GetRestaurantsByCity : IChain<Restaurant, GetRestaurantsParams>
    {
        protected override bool CheckCondition(GetRestaurantsParams cmd)
        {
            if (cmd.City is null) return false;
            return true;
        }

        protected override IEnumerable<Restaurant> Execute(GetRestaurantsParams cmd, IEnumerable<Restaurant> collection)
        {
            return collection.Where(x => x?.Address.City == cmd.City).ToList();
        }
    }
}
