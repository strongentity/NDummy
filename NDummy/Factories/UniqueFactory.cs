namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents methods for generating unique T values
    /// </summary>
    /// <typeparam name="T">Type to be generated</typeparam>
    public class UniqueFactory<T> : IFactory<T>
    {
        private ISet<T> set;
        private IFactory<T> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueFactory{T}"/> class.
        /// </summary>
        public UniqueFactory()
        {
            this.factory = new ObjectGenerator<T>(new ObjectGeneratorParams
            {
                CurrentDepth = 1,
                GeneralSettings = Dummy.Settings
            });
            this.set = new HashSet<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueFactory{T}"/> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        public UniqueFactory(IFactory<T> factory)
        {
            this.factory = factory;
            this.set = new HashSet<T>();
        }

        /// <summary>
        /// Gets or sets the max try before throwing NoUniqueValueException
        /// </summary>
        /// <value>The max try.</value>
        public int MaxTry { get; set; }

        /// <summary>
        /// Generates unique T instance.
        /// </summary>
        /// <returns>T value</returns>
        /// <exception cref="NDummy.Factories.NoUniqueValueException">Unable to generate unique value</exception>
        public T Generate()
        {
            T value;
            bool generated = false;
            int counter = 1;
            do
            {
                value = factory.Generate();
                if (set.Add(value))
                {
                    generated = true;
                    break;
                }
                counter++;
            } while (counter <= MaxTry);

            if(! generated)
                throw new NoUniqueValueException();

            return value;
        }

        object IFactory.Generate()
        {
            return Generate();
        }
    }

    public class NoUniqueValueException : Exception
    {
        public NoUniqueValueException()
            : base("Unable to generate unique value")
        {
            
        }
    }

}

