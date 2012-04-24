namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ListFactory<T> : IListFactory<T>
    {
        private readonly IList<T> list;

        private readonly IFactory<T> factory; 

        public ListFactory(IFactory<T> typefactory) : this(new List<T>(), typefactory)
        {

        }

        public ListFactory(IList<T> initialList, IFactory<T> typeFactory)
        {
            list = initialList;
            factory = typeFactory;
        }

        public IList<T> Generate()
        {
            return this.Generate(1);
        }

        public IList<T> Generate(int numberOfItems)
        {
            for(int i=0; i< numberOfItems; i++)
                list.Add(factory.Generate());

            return list;
        }

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }
}
