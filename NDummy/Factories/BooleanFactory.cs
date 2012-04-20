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

        public BooleanFactory(bool initialValue)
        {
            

        }
        protected bool CurrentValue { get; set; }
        public bool Generate()
        {
            bool _currentValue = false;
            if (_currentValue == CurrentValue)
            _currentValue  =!CurrentValue;
            CurrentValue = _currentValue;
            return _currentValue;
        }

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }
}
