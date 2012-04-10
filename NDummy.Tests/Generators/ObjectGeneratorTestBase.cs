namespace NDummy.Tests.Generators
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Moq;

    using Xunit;

    public abstract class ObjectGeneratorTestBase<T>
    {
        protected IGenerator<T> Generator;

        protected abstract Func<ConstructorArguments, T> GetConstructor();        

        [Fact]
        public void EnsureConstructorMethodIsCalled()
        {
            bool isCalled = false;
            Func<ConstructorArguments, T> func = (args)=>
                {
                    isCalled = true;
                    return this.GetConstructor()(args);
                };
            Generator.ConstructWith(func).Generate();
            Assert.True(isCalled);
        }

        protected void ThrowsErrorIfConstructorMethodIsNotSuppliedAndTypeIsAbstract()
        {
            Assert.Throws<InvalidOperationException>(() => Generator.Generate());
        }

        [Fact]
        public void SpecShouldBeApplied()
        {
            var specMock = new Mock<IGeneratorSpec>();
            Generator.Configure(specMock.Object);
            specMock.Verify(s=>s.Apply(It.IsAny<IGeneratorSettings>()), Times.Once());

        }
    }
}
