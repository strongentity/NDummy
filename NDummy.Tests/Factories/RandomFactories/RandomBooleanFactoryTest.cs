using Xunit;

namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;

    public class RandomBooleanFactoryTest : RandomFactoryTestBase<bool>
    {
        [Fact]
        public override void CanGenerateRandomValue()
        {
            var factory = GetFactory(null);
            bool value1 = factory.Generate();
            int counter = 0;
            bool isRandom = false;
            do
            {
                bool value2 = factory.Generate();
                if (value1 != value2)
                {
                    isRandom = true;
                    break;
                }
                counter++;
            } while (counter < 10);
            Assert.True(isRandom);
        }

        protected override RandomFactory<bool> GetFactory(RandomFactorySettings<bool> settings)
        {
            return new RandomBooleanFactory();
        }
    }
}
