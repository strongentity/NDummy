using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{
    public class SequenceFactory<T> : IFactory<T>
    {
        public T Generate()
        {
            throw new NotImplementedException();
        }
    }
}
