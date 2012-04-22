namespace NDummy.Tests.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    using Moq;

    using NDummy.Factories;

    using Xunit;
    using Xunit.Extensions;

    public class StringFactoryTest
    {
        private StringFactory factory;

        [Fact]
        public void CanGenerateRandomValue()
        {
            factory = new StringFactory(new StringFactorySettings
                {
                    Delimiter = string.Empty,
                    IsRandom = true,
                    Prefix = string.Empty,
                    Suffix = string.Empty
                });
            int value1 = int.Parse(factory.Generate());
            int value2 = int.Parse(factory.Generate());
            int value3 = int.Parse(factory.Generate());
            Assert.True(value1 != value2 || value2 != value3);
        }

        [Fact]
        public void CanGenerateSequenceValue()
        {
            factory = new StringFactory(new StringFactorySettings
            {
                Delimiter = string.Empty,
                IsRandom = false,
                Prefix = string.Empty,
                Suffix = string.Empty
            });
            int value1 = int.Parse(factory.Generate());
            int value2 = int.Parse(factory.Generate());
            int value3 = int.Parse(factory.Generate());
            int step1 = value2 - value1;
            int step2 = value3 - value2;
            Assert.Equal(step1, step2);
        }

        [Theory]
        [InlineData("Hasil ")]
        public void PrefixShouldBeInFront(string prefix)
        {
            factory = new StringFactory(new StringFactorySettings
                {
                    Delimiter = string.Empty,
                    Prefix = prefix,
                    Suffix = string.Empty
                });
            string result = factory.Generate();
            Assert.True(result.StartsWith(prefix));
        }

        [Theory]
        [InlineData("nuff")]
        public void SuffixShouldBeInTheEnd(string suffix)
        {
            factory = new StringFactory(new StringFactorySettings
                {
                    Delimiter = string.Empty,
                    Prefix = string.Empty,
                    Suffix = suffix
                });
            string result = factory.Generate();
            Assert.True(result.EndsWith(suffix));
        }

        [Theory]
        [InlineData("Name")]
        public void ShouldPrintMemberInfo(string memberName)
        {
            var memberMock = new Mock<MemberInfo>();
            var settings = new StringFactorySettings { Delimiter = "-", Prefix = "Ax ", Suffix = " xyz" };
            factory = new StringFactory(settings);
            factory.MemberInfo = memberMock.Object;
            memberMock.Setup(m => m.Name).Returns(memberName);
            var reMember =
                new Regex(
                    "^" + settings.Prefix + @"(?<member>\D+)" + settings.Delimiter + @"\d+" + settings.Suffix +
                    "$");
            var result = factory.Generate();
            var matchResult = reMember.Match(result);
            Assert.True(matchResult.Success);
            string member = matchResult.Groups["member"].Value;
            Assert.Equal(memberName, member);
        }

        [Theory]
        [InlineData("-")]
        public void DelimiterShouldBeBetweenMemberInfoAndValue(string delimiter)
        {
            var memberMock = new Mock<MemberInfo>();
            var settings = new StringFactorySettings { Delimiter = delimiter, Prefix = "Ax ", Suffix = " xyz" };
            factory = new StringFactory(settings);
            factory.MemberInfo = memberMock.Object;
            string memberName = "test";
            memberMock.Setup(m => m.Name).Returns(memberName);
            var reMember =
                 new Regex(
                     "^" + settings.Prefix + memberName + delimiter  + @"\d+" + settings.Suffix +
                     "$");
            var result = factory.Generate();
            var matchResult = reMember.Match(result);
            Assert.True(matchResult.Success);

        }
    }
}
