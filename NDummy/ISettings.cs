namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Provides way to get and set settings
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
        /// Sets the factory for target type.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="factory">The factory.</param>
        void SetFactory(Type targetType, object factory);

        /// <summary>
        /// Gets the factories.
        /// </summary>
        IDictionary<Type, object> Factories { get; }

        /// <summary>
        /// Gets or sets the max depth.
        /// </summary>
        /// <value>
        /// The max depth.
        /// </value>
        int MaxDepth { get; set; }
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
        void SetMemberFactory(MemberInfo memberInfo, object factory);

        /// <summary>
        /// Gets the member factories.
        /// </summary>
        IDictionary<MemberInfo, object> MemberFactories { get; }

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
