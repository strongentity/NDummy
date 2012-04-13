namespace NDummy.Tests.Factories.CollectionFactories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Factories;

    using Xunit;
    using Xunit.Extensions;

    public class DictionaryFactoryTest
    {
        private IDictionaryFactory<int, string> dictionaryFactory; 

        private Mock<IFactory<int>> keyFactoryMock;

        private Mock<IFactory<string>> valueFactoryMock;

        public DictionaryFactoryTest()
        {
            keyFactoryMock = new Mock<IFactory<int>>();
            valueFactoryMock = new Mock<IFactory<string>>();
        }

        [Fact]
        public void EnsurePassedDictionaryIsUsed()
        {
            var anyDictionary = It.IsAny<IDictionary<int, string>>();
            dictionaryFactory = new DictionaryFactory<int, string>(anyDictionary, keyFactoryMock.Object, valueFactoryMock.Object);
            var result = dictionaryFactory.Generate();
            Assert.Same(anyDictionary, result);
        }

        private T GetValue<T>(ref int counter, T[] values)
        {
            T result = values[counter];
            counter++;
            return result;
        }

        [Theory]
        [InlineData(1,2,3,"a","bc","de")]
        public void EnsurePassedFactoriesAreUsed(int value1, int value2, int value3, string strValue1, string strValue2, string strValue3)
        {
            int[] intValues= new[]{value1, value2, value3};
            string[] strValues = new[]{strValue1, strValue2, strValue3};
            dictionaryFactory = new DictionaryFactory<int, string>(keyFactoryMock.Object, valueFactoryMock.Object);
            int intCounter = 0, stringCounter =0;
            keyFactoryMock.Setup(k => k.Generate()).Returns(() => this.GetValue(ref intCounter, intValues));
            valueFactoryMock.Setup(v => v.Generate()).Returns(() => this.GetValue(ref stringCounter, strValues));
            var result = dictionaryFactory.Generate(3);
            for(int i=0; i<intValues.Length; i++)
            {
                int intValue = intValues[i];
                string strValue = strValues[i];
                Assert.True(result.ContainsKey(intValue));
                Assert.Equal(strValue, result[intValue]);
            }
        }
    }
}
