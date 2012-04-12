namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;

    using NDummy.Specs;

    public static class Spec
    {
        public static IGeneratorPredicate<TProperty> For<TProperty>()
        {
            return new GeneratorPredicate<TProperty>();
        }

        public static IGeneratorPredicate<TProperty> For<TClass, TProperty>(Expression<Func<TClass, TProperty>> memberExp)
        {
            if(memberExp.Body.NodeType != ExpressionType.MemberAccess)
                throw new ArgumentException();

            var accessExp = memberExp.Body as MemberExpression;
            return new GeneratorPredicate<TProperty>(accessExp.Member);
        }

        public static IGeneratorSpec MaxDepth(int maxDepth)
        {
            return new MaxDepthSpec(maxDepth);
        }

        public static IGeneratorSpec Act<TClass>(Action<int, TClass> action) where TClass:class
        {
            return new CustomActionSpec<TClass>(action);
        }

        public static IGeneratorSpec OverrideChildGeneratorSettings(bool @override)
        {
            return new OverrideChildGeneratorSpec(@override);
        }
    }
}
