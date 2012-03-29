namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ObjectGenerator<T> : IGenerator<T>
    {
        private int index;

        private Func<ConstructorArguments, T> constructorFunc; 

        public IGenerator<T> ConstructWith(Func<ConstructorArguments, T> func)
        {
            constructorFunc = func;
            return this;
        }

        public IGenerator<T> Configure(params IGeneratorSpec<T>[] specs)
        {

            return this;
        }

        public T Generate()
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GenerateCollection(int numberOfItems)
        {
            throw new NotImplementedException();
        }
    }
}
