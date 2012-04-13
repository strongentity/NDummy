namespace NDummy.Tests.Factories
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NDummy.Factories;

    using Xunit;
    public class BooleanFactoryTest
    {
        [Fact]
        public void CanGenerateBooleanIdentifier()
        {
            var factory = new BooleanFactory();
            var value1 = factory.Generate();
            var value2 = factory.Generate();
            var value3 = factory.Generate();
            Assert.NotEqual(value1, value2);
            //Assert.Equal(value1, value3);

        }
    }
}
