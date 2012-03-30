namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;

    using NDummy.Specs;

    public class GeneratorPredicate<T> : IGeneratorPredicate<T>
    {
        private readonly MemberInfo memberInfo;

        private readonly Type targetType;

        public GeneratorPredicate()
        {
            targetType = typeof(T);
        }
 
        public GeneratorPredicate(MemberInfo memberInfo) :this()
        {
            this.memberInfo = memberInfo;
        }
        
        public IGeneratorSpec GenerateWith(IFactory<T> factory)
        {
            if(memberInfo != null)
                return new MemberFactorySpec(memberInfo, factory);

            return new TypeFactorySpec(targetType, factory);
        }
    }
}
