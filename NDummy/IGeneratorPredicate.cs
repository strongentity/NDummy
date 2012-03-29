namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;


    public interface IGeneratorPredicate<TClass, TProperty>
    {
        IGeneratorSpec<TClass> GenerateWith(IFactory<TProperty> generator);

        IGeneratorSpec<TClass> GenerateWith(Expression<Func<PropertySetterArgs, TProperty>> propertyExpression);

        IGeneratorSpec<TClass> GenerateWith(Expression<Func<PropertySetterArgs, IFactory<TProperty>>> propertyExpression);
    }

    public class PropertySetterArgs
    {
        public int Index { get; set; }
    }
}
