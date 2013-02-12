namespace NDummy.Tests.Factories.CollectionFactories
{
    using Moq;
    using Xunit;
    using NDummy.Factories;

    public class ArrayFactoryTest
    {
        [Fact]
        public void CanGenerateOneDimensionArray()
        {
            int fixedValue = 9;

            var factoryMock = new Mock<IFactory<int>>();
            factoryMock.Setup(f => f.Generate()).Returns(fixedValue);
            int[] dimension = new[] {5};
            var arrayFactory = new ArrayFactory<int>(factoryMock.Object, dimension);
            var result = (int[]) arrayFactory.Generate();

            for (int i = 0; i < result.Length; i++)
            {
                Assert.Equal(fixedValue, result[i]);
            }
        }

        [Fact]
        public void CanGenerateMultiDimensionArray()
        {
            int fixedValue = 9;

            var factoryMock = new Mock<IFactory<int>>();
            factoryMock.Setup(f => f.Generate()).Returns(fixedValue);
            int[] dimension = new[] { 5,2,3,8,9};
            var arrayFactory = new ArrayFactory<int>(factoryMock.Object, dimension);
            var result =arrayFactory.Generate() as int[,,,,];

            bool anyDiff = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        for (int l = 0; l < 8; l++)
                        {
                            for (int m = 0; m < 9; m++)
                            {
                                if (result[i,j,k,l,m] != fixedValue)
                                    anyDiff = true;
                            }
                        }
                    }
                }
            }

            Assert.False(anyDiff);
        }

    }
}
