namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomByteFactoryTest : RandomFactoryTestBase<byte>
    {
        protected override RandomFactory<byte> GetFactory(RandomFactorySettings<byte> settings)
        {
            return settings != null ? new RandomByteFactory(settings) : new RandomByteFactory();
        }

        [Theory]
        [InlineData(byte.MinValue, byte.MaxValue)]
        [InlineData((byte)1, (byte)10)]
        [InlineData((byte)30, (byte)50)]
        public void CanGenerateByteValueInRange(byte minValue, byte maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
