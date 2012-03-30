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

    public class MemberFactorySpecTest
    {
        [Fact]
        public void CanAddMemberFactory()
        {
            var memberInfo = It.IsAny<MemberInfo>();
            var factory = new object();
            var mock = new Mock<IGeneratorSettings>();
            var spec = new MemberFactorySpec(memberInfo,factory);
            spec.Apply(mock.Object);
            mock.Verify(s => s.SetFactory(memberInfo,factory), Times.Once());
        }
    }
}
