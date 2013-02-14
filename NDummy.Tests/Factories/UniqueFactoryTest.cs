using Moq;
using NDummy.Factories;
using Xunit;

namespace NDummy.Tests.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class UniqueFactoryTest
    {
        [Fact]
        public void ThrowExceptionIfCantGenerateUniqueValues()
        {
            var factoryMock = new Mock<IFactory<bool>>(); 
            var factory = new UniqueFactory<bool>(factoryMock.Object);
            factoryMock.Setup(m => m.Generate()).Returns(true);
            factory.Generate();
            factoryMock.Setup(m => m.Generate()).Returns(true);
            Assert.Throws<NoUniqueValueException>(() => factory.Generate());
        }

        [Fact]
        public void CanGenerateUniqueValues()
        {
            var factoryMock = new Mock<IFactory<int>>();
            var factory = new UniqueFactory<int>(factoryMock.Object);
            int i = 1;
            factoryMock.Setup(m => m.Generate()).Returns(() => i++);
            Assert.DoesNotThrow(()=>factory.Generate());
            Assert.DoesNotThrow(() => factory.Generate());
            Assert.DoesNotThrow(() => factory.Generate());
        }
    }
}
