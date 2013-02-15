namespace NDummy.Factories
{
    /// <summary>
    /// Provides method for generating boolean data
    /// </summary>s
    public class BooleanFactory : IFactory<bool>
    {
        public BooleanFactory():this(false)
        {}
        protected bool CurrentValue { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanFactory"/> class.
        /// </summary>
        /// <param name="initialValue">if set to <c>true</c> [initial value].</param>
        public BooleanFactory(bool initialValue)
        {
            CurrentValue = initialValue;
        }

        /// <summary>
        /// Generates this instance.
        /// </summary>
        /// <returns><c>true</c> if CurrentValue is false, <c>false</c> otherwise</returns>
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
