using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ChainGet
{
    internal class ChainBuilder<T>
    {
        private IChain<T> head;
        private IChain<T> tail;
        public ChainBuilder<T> AddChain(IChain<T> chain)
        {
            if (head is null)
            {
                head = chain;
                tail = chain;
            }
            else
            {
                tail._queue = chain;
                tail = chain;
            }
            return this;
        }
        public List<T> RunAll(CommandGet cmd, IEnumerable<T> collection)
        {
            return head.TryToExecute(cmd, collection).ToList();
        }
    }
}
