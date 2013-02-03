namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;


    /// <summary>
    /// Represents methods for generating set
    /// </summary>
    /// <typeparam name="T">Type of set to be generated</typeparam>
    public class SetFactory<T> : IFactory<ISet<T>>
    {
        private readonly IFactory<T> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetFactory{T}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public SetFactory(IFactory<T> factory)
        {
            this.factory = factory;
            MaxTry = 3;
        }

        /// <summary>
        /// Gets or sets the max number of try 
        /// </summary>
        /// <value>The max try.</value>
        public int MaxTry { get; set; }

        /// <summary>
        /// Generates set with the specified number of items
        /// </summary>
        /// <param name="numberOfItems">The number of items.</param>
        /// <returns>set of type T</returns>
        public ISet<T> Generate(int numberOfItems)
        {
            var result = new HashSet<T>();

            for (int i = 0; i < numberOfItems; i++)
            {
                int j = 0;
                bool generated = false;
                do
                {
                    if (result.Add(factory.Generate()))
                    {
                        generated = true;
                        break;
                    }

                } while (j < MaxTry);

                if (!generated)
                    break;
            }

            return result;
        }

        /// <summary>
        /// Generates set of T
        /// </summary>
        /// <returns>set of T</returns>
        public ISet<T> Generate()
        {
            return Generate(Dummy.Settings.TotalCollectionItems);
        }

        object IFactory.Generate()
        {
            return Generate();
        }
    }
}