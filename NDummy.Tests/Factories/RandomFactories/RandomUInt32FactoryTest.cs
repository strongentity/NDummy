using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RandomUInt32FactoryTest : RandomFactoryTestBase<uint>
    {
        protected override RandomFactory<uint> GetFactory(RandomFactorySettings<uint> settings)
        {
            return settings != null ? new RandomUInt32Factory(settings) : new RandomUInt32Factory();
        }

        [Theory]
        [InlineData(uint.MinValue, uint.MaxValue)]
        [InlineData(uint.MinValue, (uint)1000)]
        [InlineData((uint)950, uint.MaxValue)]
        public void CanGenerateUInt32ValueInRange(uint minValue, uint maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
