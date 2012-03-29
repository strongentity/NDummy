namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public interface ISettings
    {
        void SetFactory<T>(Func<T> func);

        void SetFactory<T>(IFactory<T> factory);

        void SetFactory(Type targetType, object factory);

        IDictionary<Type, object> Generators { get; }

        int MaxDepth { get; set; }
    }

    public interface IGeneratorSettings : ISettings
    {
        IDictionary<MemberInfo, object> MemberGenerators { get; }      
    }
}
