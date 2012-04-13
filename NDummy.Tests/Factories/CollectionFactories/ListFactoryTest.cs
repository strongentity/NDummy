namespace NDummy.Tests.Factories.CollectionFactories
{
    using System.Collections.Generic;

    using Moq;

    using NDummy.Factories;

    using Xunit;
    using Xunit.Extensions;

    public  class ListFactoryTest
    {
        private Mock<IFactory<int>> factoryMock;

        private IListFactory<int> listFactory;

        [Fact]
        public void EnsurePassedListIsUsed()
        {
            factoryMock = new Mock<IFactory<int>>();
            var listMock = new Mock<IList<int>>(); 

            listFactory = new ListFactory<int>(listMock.Object, factoryMock.Object);
            //int result = 1;
            //factoryMock.Setup(c => c.Generate()).Returns(result);
            var result = listFactory.Generate();
            Assert.Same(result, listMock.Object);
        }

        private int GetArrayValue(ref int counter, int[] values)
        {
            int result = values[counter];
            counter++;
            return result;
        }

        [Theory]
        [InlineData(1,2,100)]
        public void EnsurePassedFactoryIsUsed(int value1, int value2, int value3)
        {
            int[] values = new[] { value1, value2, value3 };
            factoryMock = new Mock<IFactory<int>>();
            listFactory = new ListFactory<int>(factoryMock.Object);
            int counter = 0;
            factoryMock.Setup(f => f.Generate()).Returns(()=>this.GetArrayValue(ref counter, values));
            var result = listFactory.Generate(3);
            for (int i = 0; i < result.Count; i++)
            {
                Assert.Equal(values[i],result[i]);
            }
        }
    
    }
}
