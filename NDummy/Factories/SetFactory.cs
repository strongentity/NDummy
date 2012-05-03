using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{

    public class SetFactory<T>: IFactory<ISet<T>> where T : struct, IComparable
    {
        private readonly ISet<T> set;
        private readonly UniqueFactory<T>  unique;

      

        public ISet<T> Generate(int MaxGenerate)
        {
            for (int i = 1; i <= MaxGenerate; i++)
            {
                var value = unique.Generate();
                set.Add(value);
            }
            return set;
        }

        public ISet<T> Generate()
        {
            return this.Generate(5);
        }

        object IFactory.Generate()
        {
            return this.Generate(5);
        }


      
    }
}