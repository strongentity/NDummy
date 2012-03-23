namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomInt64FactoryTest : RandomFactoryTestBase<long>
    {
        protected override RandomFactory<long> GetFactory(RandomFactorySettings<long> settings)
        {
            return settings != null ? new RandomInt64Factory(settings) : new RandomInt64Factory();
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(long.MinValue, -100)]
        [InlineData(-200, 200)]
        public void CanGenerateIntValueInRange(long minValue, long maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
