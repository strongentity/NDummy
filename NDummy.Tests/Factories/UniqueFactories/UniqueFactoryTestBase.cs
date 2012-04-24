using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDummy.Factories;
using Xunit;

namespace NDummy.Tests.Factories.UniqueFactories
{
    public abstract class UniqueFactoryTestBase<T> where T :struct,IComparable
    {
        private UniqueFactory<T> factory;
        protected abstract UniqueFactory<T> GetFactory(UniqueFactorySettings<T> settings);


        protected void CanGenerateRandomResult(bool isRandom ,int maxTry,T minValue, T maxValue,T step)
        {
            var settings = new UniqueFactorySettings<T>
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Step = step,
                IsRandom = isRandom,
                MaxTry = maxTry
            };

            factory = GetFactory(settings);
            T value1 = factory.Generate();
            Console.WriteLine(value1);
            Console.WriteLine(factory.MaxTry);
            T value2 = factory.Generate();
            Console.WriteLine(value2);
            Console.WriteLine(factory.MaxTry);
            T value3 = factory.Generate();
            Console.WriteLine(value3);
            Console.WriteLine(factory.MaxTry);
            Assert.True(value1.CompareTo(value2) != 0 && value2.CompareTo(value3) != 0);

        }
    }
}
