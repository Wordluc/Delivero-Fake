using Domain.Restaurant;
using Repository.GetRestaurant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetRestaurantChain.ByLocation
{
    internal class ChainGetByCity<T > : IChain<T> where T: Restaurant
    {
        protected override bool CheckToExecute(CommandGet cmd)
        {
            if (cmd.City is null) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection)
        {
            return collection.Where(x =>x.Address.City == cmd.City).ToList();
        }
    }
}
