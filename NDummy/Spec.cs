namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;

    public static class Spec
    {
        public static IGeneratorPredicate<TClass, TProperty> For<TClass, TProperty>()
        {
            return null;
        }

        public static IGeneratorPredicate<TClass, TProperty> For<TClass, TProperty>(Expression<Func<TClass, TProperty>> memberExp)
        {
            return null;
        }

        public static IGeneratorSpec<T> MaxDepth<T>(int maxDepth)
        {
            return null;
        }
    }
}
