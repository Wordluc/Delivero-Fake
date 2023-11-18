using Domain.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantChain
{
    internal class ChainGetByName<T> : IChain<T> where T : Restaurant
    {
        protected override bool CheckToExecute(CommandGet cmd)
        {
            if (cmd.Name is null) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection)
        {
            return collection.Where(x => x.Name == cmd.Name);
        }
    }
}
