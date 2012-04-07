namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Tests.CustomTypes;

    public class CustomDerivedClassGeneratorTest : ObjectGeneratorTestBase<CustomDerivedClass>
    {
        private Mock<ISettings> generalSettingsMock;
        
        public CustomDerivedClassGeneratorTest()
        {
            generalSettingsMock = new Mock<ISettings>();
            var param = new ObjectGeneratorParams { CurrentDepth = 1, GeneralSettings = generalSettingsMock.Object };
            Generator = new ObjectGenerator<CustomDerivedClass>(param);
        }

        protected override Func<ConstructorArguments, CustomDerivedClass> GetConstructor()
        {
            return args => new CustomDerivedClass();
        }

    }
}
