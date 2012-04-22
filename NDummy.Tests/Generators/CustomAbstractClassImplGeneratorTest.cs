namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using NDummy.Specs;
    using NDummy.Tests.CustomTypes;

    using Xunit;
    using Xunit.Extensions;

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

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectTypeFactorySpec(string input)
        {
            var stringFactoryMock = new Mock<IFactory<string>>();
            stringFactoryMock.Setup(s => s.Generate()).Returns(input);
            stringFactoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            var spec = new TypeFactorySpec(typeof(string), stringFactoryMock.Object);
            Generator.Configure(spec);
            var result = Generator.Generate();
            Assert.Equal(input, result.AbstractClassID);
        }

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectMemberFactorySpec(string input)
        {
            var memberFactoryMock = new Mock<IFactory<string>>();
            memberFactoryMock.Setup(s => s.Generate()).Returns(input);
            memberFactoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            var spec = new MemberFactorySpec
                (typeof(CustomAbstractClassImpl).GetProperty("AbstractClassID"), memberFactoryMock.Object);
            Generator.Configure(spec);
            var result = Generator.Generate();
            Assert.Equal(input, result.AbstractClassID);
        }

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectGeneralSettings(string input)
        {
            var generalDictionary = new Dictionary<Type, IFactory>();
            var factoryMock = new Mock<IFactory<string>>();
            factoryMock.Setup(s => s.Generate()).Returns(input);
            factoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            generalDictionary.Add(typeof(string), factoryMock.Object);
            generalSettingsMock.SetupGet(s => s.Factories).Returns(generalDictionary);
            var result = Generator.Generate();
            Assert.Equal(input, result.AbstractClassID);
        }
    }
}
