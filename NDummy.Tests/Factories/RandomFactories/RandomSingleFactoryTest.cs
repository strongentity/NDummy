using Xunit.Extensions;

namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;

    public class RandomSingleFactoryTest : RandomFactoryTestBase<float>
    {
        protected override RandomFactory<float> GetFactory(RandomFactorySettings<float> settings)
        {
            return settings != null ? new RandomSingleFactory(settings) : new RandomSingleFactory();
        }

        [Theory]
        [InlineData(float.MinValue, float.MaxValue)]
        [InlineData(float.MinValue, (float)1000)]
        [InlineData((float)950, (float) 950.9)]
        public void CanGenerateSingleValueInRange(float minValue, float maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
