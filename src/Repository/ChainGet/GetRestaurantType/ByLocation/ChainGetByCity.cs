﻿using Domain.Restaurant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet.GetRestaurantType.ByLocation
{
    internal class ChainGetByCity<T> : IChain<T> where T : Restaurant
    {
        protected override bool CheckCondition(CommandGet cmd)
        {
            if (cmd.City is null) return false;
            return true;
        }

        protected override IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection)
        {
            return collection.Where(x => x.Address.City == cmd.City).ToList();
        }
    }
}