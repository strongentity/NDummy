namespace NDummy.Tests.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Specs;

    using Xunit;

    public class MaxDepthSpecTest
    {
        [Fact]
        public void CanChangeGeneratorSettingsDepth()
        {
            int value = 3;
            var spec = new MaxDepthSpec(value);
            var settingsMock = new Mock<IGeneratorSettings>();
            spec.Apply(settingsMock.Object);
            settingsMock.VerifySet(s => s.MaxDepth = value);
        }
    }
}
