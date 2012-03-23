using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class RandomUInt64FactoryTest : RandomFactoryTestBase<ulong>
    {
        protected override RandomFactory<ulong> GetFactory(RandomFactorySettings<ulong> settings)
        {
            return settings != null ? new RandomUInt64Factory(settings) : new RandomUInt64Factory();
        }

        [Theory]
        [InlineData(ulong.MinValue, ulong.MaxValue)]
        [InlineData(ulong.MinValue, (ulong)1000)]
        [InlineData((ulong)950, ulong.MaxValue)]
        public void CanGenerateUInt64ValueInRange(ulong minValue, ulong maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
