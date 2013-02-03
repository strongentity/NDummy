using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NDummy.Factories;
using Xunit;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.CollectionFactories
{
    public class SetFactoryTest
    {
        private Mock<IFactory<int>> factoryMock;

        public SetFactoryTest()
        {
            factoryMock = new Mock<IFactory<int>>();
        }

        [Theory]
        [InlineData(1,3,5)]
        public void EnsurePassedFactoriesAreUsed(int value1, int value2, int value3)
        {
            int[] values={value1,value2,value3};
            int i = 0;
            factoryMock.Setup(f => f.Generate()).Returns(() =>
                {
                    var value = values[i];
                    i++;
                    return value;
                });
            var factory = new SetFactory<int>(factoryMock.Object);
            var result = factory.Generate(3);
            i = 0;
            foreach (var value in values)
            {
               Assert.Contains(value,result);
            }
        }
    }
}
