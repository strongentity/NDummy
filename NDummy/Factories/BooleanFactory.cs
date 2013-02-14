namespace NDummy.Factories
{
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

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }
}
