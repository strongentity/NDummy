namespace NDummy.Tests.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Moq;

    using NDummy.Specs;

    using Xunit;

    public class TypeFactorySpecTest 
    {
        [Fact]
        public void CanAddTypeFactory()
        {
            var type = It.IsAny<Type>();
            var factory = new object();
            var mock = new Mock<IGeneratorSettings>();
            var spec = new TypeFactorySpec(type, factory);
            spec.Apply(mock.Object);
            mock.Verify(s => s.SetFactory(type, factory), Times.Once());
        }

    }
}
