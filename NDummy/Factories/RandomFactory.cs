using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{
    public class RandomFactory<T> :IFactory<T> where T : struct, IComparable
    {

        public T Generate()
        {
            throw new NotImplementedException();
        }
    }
}
