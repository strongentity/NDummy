namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NDummy.Factories;

    public class Settings : ISettings
    {
        private readonly IDictionary<Type, object> factories; 

        public Settings()
        {
            factories = new Dictionary<Type, object>();
        }

        public void SetFactory<T>(Func<T> func)
        {
            var factory = new FuncAdapter<T>(func);
            SetFactory(factory);
        }

        public void SetFactory<T>(IFactory<T> factory)
        {
            SetFactory(typeof(T), factory);
        }

        public void SetFactory(Type targetType, object factory)
        {
            if (factories.ContainsKey(targetType))
            {
                factories[targetType] = factory;
            }
            else
            {
                factories.Add(targetType, factory);
            }
        }

        public IDictionary<Type, object> Factories
        {
            get { return factories; }
        }

        public int MaxDepth { get; set; }
        
    }
}
