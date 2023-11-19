using Application;
using Domain.Restaurant;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet
{
    internal abstract class IChain<T>
    {
        private IChain<T>? next;
        public IChain<T> AddChain(IChain<T> chain){
            if(next is not null)
                next.AddChain(chain);
            else
                next=chain;
            return this;
        }

        protected abstract bool CheckCondition(CommandGet cmd);
        protected abstract IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection);
        public IEnumerable<T> TryToExecute(CommandGet cmd, IEnumerable<T> collection)
        {
            if (CheckCondition(cmd))
            {
                var r = Execute(cmd, collection);
                return next?.TryToExecute(cmd, r)??r;             
            }
            else
                return next?.TryToExecute(cmd,collection)??collection;  
        }
    }
}
