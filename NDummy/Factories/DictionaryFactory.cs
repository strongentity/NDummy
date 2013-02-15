namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    ///Provides method for generating dictionary of 
    /// </summary>
    /// <typeparam name="TKey">The type of the T key.</typeparam>
    /// <typeparam name="TValue">The type of the T value.</typeparam>
    public class DictionaryFactory<TKey, TValue> : IDictionaryFactory<TKey, TValue>
    {
        private IDictionary<TKey, TValue> collection;

        private IFactory<TKey> keyFactory;

        private IFactory<TValue> valueFactory;
 
        public DictionaryFactory(IFactory<TKey> keyFactory, IFactory<TValue> valueFactory):
            this (new Dictionary<TKey, TValue>(), keyFactory, valueFactory)
        {
            
        }

        public DictionaryFactory(IDictionary<TKey, TValue> collection, 
            IFactory<TKey> keyFactory, IFactory<TValue> valueFactory)
        {
            this.collection = collection;
            this.keyFactory = keyFactory;
            this.valueFactory = valueFactory;
        }

        public IDictionary<TKey, TValue> Generate()
        {
            return this.Generate(Dummy.Settings.TotalCollectionItems);
        }

        public IDictionary<TKey, TValue> Generate(int numberOfItems)
        {
            try
            {
                for (int i=0; i<numberOfItems; i++)
                {
                    TKey key = keyFactory.Generate();
                    TValue value = valueFactory.Generate();
                    collection.Add(key, value);
                }
            }
            catch 
            {
                
            }
            return collection;
        }

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }
}
