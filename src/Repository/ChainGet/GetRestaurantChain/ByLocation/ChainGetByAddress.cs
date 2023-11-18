using Domain.Restaurant;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantChain.ByLocation
{
    internal class ChainGetByVia<T> : IChain<T> where T : Restaurant
    {
        protected override bool CheckToExecute(CommandGet cmd)
        {
            if (cmd.City is null) return false;
            if (cmd.Via is null) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection)
        {
            return collection.Where(x =>
                                        x.Address.City == cmd.City &&
                                        x.Address.Via == cmd.Via
                                    );
        }
    }
}
