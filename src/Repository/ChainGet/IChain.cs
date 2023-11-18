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
        internal IChain<T>? _queue;
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
