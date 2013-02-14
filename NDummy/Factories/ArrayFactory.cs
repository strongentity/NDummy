namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Provides methods for generating array of T
    /// </summary>
    /// <typeparam name="T">Type to be generated</typeparam>
    public class ArrayFactory<T>:IArrayFactory<T>
    {
        private readonly IFactory<T> factory;
        private readonly int[] length;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArrayFactory{T}"/> class.
        /// </summary>
        /// <param name="factory">factory of T.</param>
        /// <param name="length">dimensions of array</param>
        public ArrayFactory(IFactory<T> factory, int[] length)
        {
            this.factory = factory;
            this.length = length;
        }

        /// <summary>
        ///  Generates array of T
        /// </summary>
        /// <returns>array of T</returns>
        public Array Generate()
        {
            var array = Array.CreateInstance(typeof (T), length);
            int rank = length.Length;
            var indexList = new List<int>();
            
            for (int i = 0; i <= array.GetUpperBound(0); i++)
            {
                InternalRecursion(array, indexList, i, 0, rank);
            }

            return array;
        }

        void InternalRecursion(Array value, IList<int> indexList, int currentCounter, int currentDepth, int rank)
        {
            if (indexList.Count <= currentDepth)
                indexList.Add(currentCounter);
            else
                indexList[currentDepth] = currentCounter;

            if (currentDepth < rank - 1)
            {
                for (int i = 0; i <= value.GetUpperBound(currentDepth + 1); i++)
                {
                    InternalRecursion(value, indexList, i, currentDepth+1, rank);
                }
            }
            else
            {
                int[] indices = indexList.ToArray();
                value.SetValue(factory.Generate(), indices);
            }
        }

        object IFactory.Generate()
        {
            return Generate();
        }
    }
}
