using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public abstract class IEqual<T>
    {
        public abstract bool Equals(T? other);

        public static bool operator ==(IEqual<T> o1, T o2)
        {
            return o1.Equals(o2);
        }

        public static bool operator !=(IEqual<T> o1, T o2)
        {
            return !o1.Equals(o2);
        }
    }
}
