namespace NDummy.Tests.Specs
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using Xunit;

    public class SpecTest
    {
        [Fact]
        public void ForDoesntAcceptNonMemberAccessExpression()
        {
            Assert.Throws<ArgumentException>(()=>Spec.For<AnyClass, string>(a => "a"));
        }

        internal class AnyClass
        {
            public string Id { get; set; }
        }
    }
}
