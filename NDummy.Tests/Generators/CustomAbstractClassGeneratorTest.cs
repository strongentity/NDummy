namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Tests.CustomTypes;

    using Xunit;

    public class CustomAbstractClassGeneratorTest : ObjectGeneratorTestBase<CustomAbstractClass>
    {
        private Mock<ISettings> generalSettingsMock;

        public CustomAbstractClassGeneratorTest()
        {
            generalSettingsMock = new Mock<ISettings>();
            var param = new ObjectGeneratorParams { CurrentDepth = 1, GeneralSettings = generalSettingsMock.Object };
            Generator = new ObjectGenerator<CustomAbstractClass>(param);
        }

        protected override Func<ConstructorArguments, CustomAbstractClass> GetConstructor()
        {
            return args => new CustomAbstractClassImpl();
        }

        [Fact]
        public void ShouldThrowExceptionIfConstructorMethodIsNotSupplied()
        {
            this.ThrowsErrorIfConstructorMethodIsNotSuppliedAndTypeIsAbstract();
        }
    }
}
