using Application;
using Domain.Restaurant;
using Repository.GetRestaurantChain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.GetRestaurant
{
    internal abstract class IChain<T>{
        protected IChain<T> _queue;
        public IChain<T> AddChain(IChain<T> chain)
        {
            _queue=chain;
            return this;
        }
        protected abstract bool CheckToExecute(CommandGet cmd);
        protected abstract IEnumerable<T> Execute(CommandGet cmd, IEnumerable<T> collection);
        public IEnumerable<T> TryToExecute(CommandGet cmd, IEnumerable<T> collection)
        {

            if (CheckToExecute(cmd))
            {
                var r = Execute(cmd, collection);
                if (_queue is not null)
                    return _queue.TryToExecute(cmd, r);
                else
                    return r;
            }
            else
            {
                if (_queue is not null)
                    return _queue.TryToExecute(cmd, collection);
                else
                    return collection;
            }
        } 
    }
}
