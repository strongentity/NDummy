namespace NDummy.Tests.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Specs;

    using Xunit;

    public class CustomActionSpecTest 
    {
        [Fact]
        public void CanSetCustomAction()
        {
            var action = It.IsAny<Action<int,object>>();
            var spec = new CustomActionSpec<object>(action);
            var mock = new Mock<IGeneratorSettings>();
            spec.Apply(mock.Object);
            mock.Verify(s => s.AddCustomAction(action), Times.Once());
        }
    }
}
