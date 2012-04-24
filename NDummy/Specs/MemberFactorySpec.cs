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

        private readonly IFactory factory;

        public MemberFactorySpec(MemberInfo memberInfo, IFactory factory)
        {
            this.memberInfo = memberInfo;
            this.factory = factory;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.SetMemberFactory(memberInfo, factory);
        }
    }
}
