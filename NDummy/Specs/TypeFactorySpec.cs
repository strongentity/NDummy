namespace NDummy.Specs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TypeFactorySpec : IGeneratorSpec
    {
        private readonly Type targetType;

        private readonly object factory;

        public TypeFactorySpec(Type targetType, object factory)
        {
            this.targetType = targetType;
            this.factory = factory;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.SetFactory(targetType, factory);
        }
    }
}
