using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDummy.Factories;
using Xunit;

namespace NDummy.Tests.Factories
{
    
    public class RandomInt32FactoryTest : RandomFactoryTest<int>
    {

    }

    public class RandomInt16FactoryTest : RandomFactoryTest<short>
    {
    }

    public abstract class RandomFactoryTest<T> where T : struct, IComparable
    {
        private RandomFactory<T> factory;

        public RandomFactoryTest()
        {
            factory = new RandomFactory<T>();
        }

        [Fact]
        public void CanGenerateRandomNumber()
        {
            T value1 = factory.Generate();
            T value2 = factory.Generate();
            T value3 = factory.Generate();
            Assert.True(value1.CompareTo(value2) > 0 || value2.CompareTo(value3) > 0);
        }
    }
}
