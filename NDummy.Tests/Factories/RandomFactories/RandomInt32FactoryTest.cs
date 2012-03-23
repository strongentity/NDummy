namespace NDummy.Tests.Factories.RandomFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;


    public class RandomInt32FactoryTest : RandomFactoryTestBase<int>
    {
        protected override RandomFactory<int> GetFactory(RandomFactorySettings<int> settings)
        {
            return settings != null ? new RandomInt32Factory(settings) : new RandomInt32Factory();
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(int.MinValue, -100)]
        [InlineData(-200, 200)]
        public void CanGenerateIntValueInRange(int minValue, int maxValue)
        {
            CanGenerateValueInsideRange(minValue, maxValue);
        }
    }
}
