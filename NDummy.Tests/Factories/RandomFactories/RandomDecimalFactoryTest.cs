namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomDecimalFactoryTest : RandomFactoryTestBase<decimal>
    {
        protected override RandomFactory<decimal> GetFactory(RandomFactorySettings<decimal> settings)
        {
            return settings != null ? new RandomDecimalFactory(settings) : new RandomDecimalFactory();
        }

        [Theory]
        [InlineData(-1.0f, 1000.3f)]
        [InlineData(short.MinValue,  short.MaxValue)]
        public void CanGenerateDecimalValueInRange(float minValue, float maxValue)
        {
            CanGenerateValueInsideRange((decimal)minValue, (decimal)maxValue);
        }
    }
}
