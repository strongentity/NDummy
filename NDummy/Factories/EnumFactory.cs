namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    ///  Provides methods for generating enum of T
    /// </summary>
    /// <typeparam name="T">Type to be generated</typeparam>
    public class EnumFactory<T> : IFactory<T> where T:struct, IConvertible
    {
        private readonly IList<T> values = new List<T>();
        private int index = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumFactory{T}"/> class.
        /// </summary>
        public EnumFactory()
        {
            var array = Enum.GetValues(typeof (T));

            foreach (T item in array)
            {
                values.Add(item);
            }
        }

        public T Generate()
        {
            if (index >= values.Count)
                index = 0;
            
            var result = values[index];
            index++;

            return result;
        }

        object IFactory.Generate()
        {
            return Generate();
        }
    }
}
