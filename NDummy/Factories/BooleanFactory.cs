namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BooleanFactory : IFactory<bool>
    {
        public BooleanFactory():this(false)
        {}
        protected bool CurrentValue { get; set; }

        public BooleanFactory(bool initialValue)
        {
            CurrentValue = initialValue;
        }
        
        public bool Generate()
        {
            CurrentValue  =!CurrentValue;
            return CurrentValue;
        }
    }
}
