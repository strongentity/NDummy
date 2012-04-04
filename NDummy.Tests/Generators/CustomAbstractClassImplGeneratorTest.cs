namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Tests.CustomTypes;

    public class CustomAbstractClassImplGeneratorTest : ObjectGeneratorTestBase<CustomAbstractClassImpl>
    {
        private Mock<ISettings> generalSettingsMock;

        public CustomAbstractClassImplGeneratorTest()
        {
            generalSettingsMock = new Mock<ISettings>();
            var param = new ObjectGeneratorParams { CurrentDepth = 1, GeneralSettings = generalSettingsMock.Object };
            Generator = new ObjectGenerator<CustomAbstractClassImpl>(param);
        }

        protected override Func<ConstructorArguments, CustomAbstractClassImpl> GetConstructor()
        {
            return (args)=> new CustomAbstractClassImpl();
        }
    }
}
