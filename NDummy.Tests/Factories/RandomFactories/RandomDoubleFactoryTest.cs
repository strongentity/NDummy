namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomDoubleFactoryTest : RandomFactoryTestBase<double>
    {
        protected override RandomFactory<double> GetFactory(RandomFactorySettings<double> settings)
        {
            return settings != null ? new RandomDoubleFactory(settings) : new RandomDoubleFactory();
        }

        [Theory]
        [InlineData(double.MinValue, double.MaxValue)]
        [InlineData(double.MinValue, 1000.3)]
        [InlineData(950,  950.9)]
        public void CanGenerateDoubleValueInRange(double minValue, double maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
