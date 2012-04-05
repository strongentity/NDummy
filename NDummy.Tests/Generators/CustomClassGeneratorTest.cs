namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Tests.CustomTypes;

    public class CustomClassGeneratorTest : ObjectGeneratorTestBase<CustomClass>
    {
        private Mock<ISettings> generalSettingsMock;

        public CustomClassGeneratorTest()
        {
            generalSettingsMock = new Mock<ISettings>();
            var param = new ObjectGeneratorParams { CurrentDepth = 1, GeneralSettings = generalSettingsMock.Object };
            Generator = new ObjectGenerator<CustomClass>(param);
        }

        protected override Func<ConstructorArguments, CustomClass> GetConstructor()
        {
            return args => new CustomClass();
        }
    }
}
