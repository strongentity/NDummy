namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Provides a set of ways to get and set settings
    /// </summary>
    public interface ISettings
    {
        /// <summary>
        /// Sets func to generate type T.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="func">The func.</param>
        void SetFactory<T>(Func<T> func);

        /// <summary>
        /// Sets the factory for type T.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="factory">The factory.</param>
        void SetFactory<T>(IFactory<T> factory);

        /// <summary>
        /// Sets the lazily evaluated factory.
        /// </summary>
        /// <typeparam name="T">Type to generate</typeparam>
        /// <param name="factory">The factory.</param>
        void SetFactory<T>(Func<IFactory<T>> factory);

        /// <summary>
        /// Sets the factory for target type.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="factory">The factory.</param>
        void SetFactory(Type targetType, IFactory factory);

        /// <summary>
        /// Gets the factories.
        /// </summary>
        IDictionary<Type, IFactory> Factories { get; }


        /// <summary>
        /// Gets the lazily initialized factories.
        /// </summary>
        IDictionary<Type, Func<IFactory>> LazyFactories { get; } 

        /// <summary>
        /// Gets or sets the max depth.
        /// </summary>
        /// <value>
        /// The max depth.
        /// </value>
        int MaxDepth { get; set; }

        /// <summary>
        /// Gets the collection generator.
        /// </summary>
        ICollectionGenerator CollectionGenerator {get;}
    }

    /// <summary>
    /// Provides way to get and set generator specific settings
    /// </summary>
    public interface IGeneratorSettings : ISettings
    {
        /// <summary>
        /// Sets the member specific factory.
        /// </summary>
        /// <param name="memberInfo">The member info.</param>
        /// <param name="factory">The factory.</param>
        void SetMemberFactory(MemberInfo memberInfo, IFactory factory);

        /// <summary>
        /// Gets the member factories.
        /// </summary>
        IDictionary<MemberInfo, IFactory> MemberFactories { get; }

        /// <summary>
        /// Sets the custom action.
        /// </summary>
        /// <param name="customAction">The custom action.</param>
        void AddCustomAction(object customAction);

        IList<object> CustomActions { get; }

        void Apply(IGeneratorSettings settings);

        bool OverrideChildSettings { get; set; }
    }

    public interface IHaveGeneratorSettings
    {
        IGeneratorSettings Settings { get; }
    }
}
