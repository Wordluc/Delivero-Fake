using Domain.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantType
{
    internal class GetRestaurantByName<T,C> : IChain<T,C> where T : Restaurant where C:GetRestaurantsParams
    {
        protected override bool CheckCondition(C cmd)
        {
            if (cmd.Name is null) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(C cmd, IEnumerable<T> collection)
        {
            return collection.Where(x => x.Name == cmd.Name);
        }
    }
}
