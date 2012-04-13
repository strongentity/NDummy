namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IListFactory<T> : IFactory<IList<T>>
    {
        IList<T> Generate(int numberOfItems);
    }

    public interface IDictionaryFactory<TKey,TValue>: IFactory<IDictionary<TKey,TValue>>
    {
        IDictionary<TKey, TValue> Generate(int numberOfItems);
    }
}
