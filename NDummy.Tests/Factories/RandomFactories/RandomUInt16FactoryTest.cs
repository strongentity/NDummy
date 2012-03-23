namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomUInt16FactoryTest : RandomFactoryTestBase<ushort>
    {
        protected override RandomFactory<ushort> GetFactory(RandomFactorySettings<ushort> settings)
        {
            return settings != null ? new RandomUInt16Factory(settings) : new RandomUInt16Factory();
        }

        [Theory]
        [InlineData(ushort.MinValue, ushort.MaxValue)]
        [InlineData(ushort.MinValue, (ushort) 1000)]
        [InlineData((ushort)950, ushort.MaxValue)]
        public void CanGenerateUInt16ValueInRange(ushort minValue, ushort maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
