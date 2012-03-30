namespace NDummy.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class MemberFactorySpec : IGeneratorSpec
    {
        private readonly MemberInfo memberInfo;

        private readonly object factory;

        public MemberFactorySpec(MemberInfo memberInfo, object factory)
        {
            this.memberInfo = memberInfo;
            this.factory = factory;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.SetFactory(memberInfo, factory);
        }
    }
}
