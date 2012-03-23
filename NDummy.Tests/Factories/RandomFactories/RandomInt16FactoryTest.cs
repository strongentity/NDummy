namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomInt16FactoryTest : RandomFactoryTestBase<short>
    {
        protected override RandomFactory<short> GetFactory(RandomFactorySettings<short> settings)
        {
            return settings != null ? new RandomInt16Factory(settings) : new RandomInt16Factory();
        }

        [Theory]
        [InlineData(short.MinValue, short.MaxValue)]
        [InlineData((short)1, (short)10)]
        [InlineData((short)-20, (short)20)]
        public void CanGenerateInt16ValueInRange(short minValue, short maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
