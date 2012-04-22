namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NDummy.Factories;

    /// <summary>
    /// Provides a set of ways to get and set settings
    /// </summary>
    public class Settings : ISettings
    {
        private readonly IDictionary<Type, IFactory> sharedFactories;

        private readonly IDictionary<Type, Func<IFactory>> lazyFactories; 

        /// <summary>
        /// Initializes a new instance of the <see cref="Settings"/> class.
        /// </summary>
        public Settings()
        {
            sharedFactories = new Dictionary<Type, IFactory>();
            lazyFactories = new Dictionary<Type, Func<IFactory>>();
            CollectionGenerator = new CollectionGenerator(this);
        }

        /// <summary>
        /// Sets func to generate type T.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="func">The func.</param>
        public void SetFactory<T>(Func<T> func)
        {
            var factory = new FuncAdapter<T>(func);
            SetFactory(factory);
        }

        /// <summary>
        /// Sets the factory for type T.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="factory">The factory.</param>
        public void SetFactory<T>(IFactory<T> factory)
        {
            SetFactory(typeof(T), factory);
        }

        /// <summary>
        /// Sets the factory for target type.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="factory">The factory.</param>
        public void SetFactory(Type targetType, IFactory factory)
        {
            if (sharedFactories.ContainsKey(targetType))
            {
                sharedFactories[targetType] = factory;
            }
            else
            {
                sharedFactories.Add(targetType, factory);
            }
        }

        /// <summary>
        /// Sets the lazily evaluated factory.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="factory">The factory.</param>
        public void SetFactory<T>(Func<IFactory<T>> factory)
        {
            lazyFactories.Add(typeof(T), factory);
        }

        /// <summary>
        /// Gets the factories.
        /// </summary>
        public IDictionary<Type, IFactory> Factories
        {
            get { return sharedFactories; }
        }

        /// <summary>
        /// Gets or sets the max depth.
        /// </summary>
        /// <value>
        /// The max depth.
        /// </value>
        public int MaxDepth { get; set; }

        /// <summary>
        /// Gets the collection generator.
        /// </summary>
        public ICollectionGenerator CollectionGenerator { get; private set; }
    }
}
