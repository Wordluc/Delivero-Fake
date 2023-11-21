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
    internal abstract class IChain<T,C>
    {
        private IChain<T,C>? next;
        public IChain<T,C> AddChain(IChain<T,C> chain){
            if(next is not null)
                next.AddChain(chain);
            else
                next=chain;
            return this;
        }

        protected abstract bool CheckCondition(C cmd);
        protected abstract IEnumerable<T> Execute(C cmd, IEnumerable<T> collection);
        public IEnumerable<T> TryToExecute(C cmd, IEnumerable<T> collection)
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
