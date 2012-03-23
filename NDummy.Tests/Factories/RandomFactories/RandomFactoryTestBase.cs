namespace NDummy.Tests.Factories.RandomFactories
{
    using System;
    using NDummy.Factories;
    using Xunit;

    //public class RandomSByteFactoryTest : RandomFactoryTest<sbyte>
    //{
    //    protected override RandomFactory<sbyte> GetFactory(RandomFactorySettings<sbyte> settings)
    //    {
    //        throw new NotImplementedException();
    //    } 

    //    [Theory]
    //    [InlineData(sbyte.MinValue, sbyte.MaxValue)]
    //    [InlineData(1,23)]
    //    [InlineData(sbyte.MinValue)]
    //    public void CanGenerateSByteValueInRange(sbyte minValue, sbyte maxValue)
    //    {
    //        CanGenerateValueInsideRange(minValue, maxValue);
    //    }
    //}

    public abstract class RandomFactoryTestBase<T> where T : struct, IComparable
    {
        private RandomFactory<T> factory;

        protected RandomFactoryTestBase()
        {

        }

        protected abstract RandomFactory<T> GetFactory(RandomFactorySettings<T> settings);

        [Fact]
        public virtual void CanGenerateRandomValue()
        {
            factory = GetFactory(null);
            T value1 = factory.Generate();
            T value2 = factory.Generate();
            T value3 = factory.Generate();
            Assert.True(value1.CompareTo(value2) != 0 || value2.CompareTo(value3) != 0);
        }

        protected void CanGenerateValueInsideRange(T minValue, T maxValue)
        {
            var settings = new RandomFactorySettings<T>
                               {
                                   MinValue = minValue,
                                   MaxValue = maxValue
                               };
            factory = GetFactory(settings);
            T value = factory.Generate();
            Assert.InRange(value, minValue, maxValue);
        }

    }
}
