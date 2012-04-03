namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ObjectGenerator<T> : IGenerator<T>
    {
        private int index;

        private Func<ConstructorArguments, T> constructorFunc;

        private readonly IGeneratorSettings generatorSettings;

        private readonly Type type;

        public ObjectGenerator()
        {
            generatorSettings = new GeneratorSettings();
            index = 1;
            type = typeof(T);
        }

        public IGenerator<T> ConstructWith(Func<ConstructorArguments, T> func)
        {
            constructorFunc = func;
            return this;
        }

        public IGenerator<T> Configure(params IGeneratorSpec[] specs)
        {
            if(specs == null || specs.Length == 0)
                throw new ArgumentException();

            foreach(var spec in specs)
                spec.Apply(generatorSettings);

            return this;
        }

        public T Generate()
        {
            T instance;
            var constructorArgs = new ConstructorArguments { Index = 1 };
            if (constructorFunc != null)
            {
                instance = constructorFunc(constructorArgs);
            }
            else
            {
                if(type.IsAbstract || type.IsInterface)
                    throw new InvalidOperationException();

                instance = (T) Activator.CreateInstance(type);
            }
            index++;
            return instance;
        }

        public ICollection<T> GenerateCollection(int numberOfItems)
        {
            throw new NotImplementedException();
        }
    }
}
