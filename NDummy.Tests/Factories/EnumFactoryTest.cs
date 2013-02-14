namespace NDummy.Tests.Factories
{
    using NDummy.Factories;
    using NDummy.Tests.CustomTypes;

    using Xunit;
    
    public class EnumFactoryTest
    {
        [Fact]
        public void CanGenerateDifferentEnumValues()
        {
            var factory = new EnumFactory<CustomEnum>();
            var value1 = factory.Generate();
            var value2 = factory.Generate();
            var value3 = factory.Generate();
            Assert.NotEqual(value1,value2);
            Assert.NotEqual(value1, value3);
            Assert.NotEqual(value2, value3);
        }
    }

}
