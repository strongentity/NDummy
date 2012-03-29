namespace NDummy.Tests.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using NDummy.Factories;

    using Xunit;

    public class GuidFactoryTest
    {
        [Fact]
        public void CanGenerateUniqueIdentifier()
        {
            var factory = new GuidFactory();
            var value1 = factory.Generate();
            var value2 = factory.Generate();
            Assert.NotEqual(value1,value2);
        }
    }
}
