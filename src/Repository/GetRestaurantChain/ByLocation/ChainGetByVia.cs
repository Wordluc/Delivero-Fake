using Domain.Restaurant;
using FluentValidation.Validators;
using Repository.GetRestaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetRestaurantChain.ByLocation
{
    internal class ChainGetByAddress<T> : IChain<T> where T : Restaurant
    {
        protected override bool CheckToExecute(CommandGet cmd)
        {
            if (cmd.City is null) return false;
            if (cmd.Via is null) return false;
            if (cmd.AddressNumber is null or 0) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection)
        {
            return collection.Where(x =>
                                        x.Address.City == cmd.City &&
                                        x.Address.Via == cmd.Via &&
                                        x.Address.AddressNumber == cmd.AddressNumber
                                    );
        }
    }
}
