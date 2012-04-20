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

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectTypeFactorySpec(string input)
        {
            var stringFactoryMock = new Mock<IFactory<string>>();
            stringFactoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            var spec = new TypeFactorySpec(typeof(string), stringFactoryMock.Object);
            Generator.ConstructWith(args => new CustomAbstractClassImpl());
            Generator.Configure(spec);
            var result = Generator.Generate();
            Assert.Equal(input,result.AbstractClassID);
        }

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectMemberFactorySpec(string input)
        {
            var memberFactoryMock = new Mock<IFactory<string>>();
            memberFactoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            var spec = new MemberFactorySpec(
                typeof(CustomAbstractClass).GetProperty("AbstractClassID"), memberFactoryMock.Object);
            Generator.ConstructWith(args => new CustomAbstractClassImpl());
            Generator.Configure(spec);
            var result = Generator.Generate();
            Assert.Equal(input, result.AbstractClassID);
        }

        [Theory]
        [InlineData("csharp rocks")]
        public void GenerateShouldRespectGeneralSettings(string input)
        {
            var generalDictionary = new Dictionary<Type, object>();
            var factoryMock = new Mock<IFactory<string>>();
            factoryMock.As<IFactory>().Setup(s => s.Generate()).Returns(input);
            generalDictionary.Add(typeof(string), factoryMock.Object);
            generalSettingsMock.SetupGet(s => s.Factories).Returns(generalDictionary);
            Generator.ConstructWith(args => new CustomAbstractClassImpl());
            var result = Generator.Generate();
            Assert.Equal(input, result.AbstractClassID);
        }
    }
}
