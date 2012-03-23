namespace NDummy.Tests.Factories.RandomFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;

    public class RandomSByteFactoryTest : RandomFactoryTestBase<sbyte>
    {
        protected override RandomFactory<sbyte> GetFactory(RandomFactorySettings<sbyte> settings)
        {
            return settings != null ? new RandomSByteFactory(settings) : new RandomSByteFactory();
        }

        [Theory]
        [InlineData(sbyte.MinValue, sbyte.MaxValue)]
        [InlineData(sbyte.MinValue, (sbyte)10)]
        [InlineData((sbyte)-20, sbyte.MaxValue)]
        public void CanGenerateSByteValueInRange(sbyte minValue, sbyte maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
