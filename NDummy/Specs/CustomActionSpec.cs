namespace NDummy.Specs
{
    using System;

    public class CustomActionSpec<T> : IGeneratorSpec
    {
        private readonly Action<int, T> action;

        public CustomActionSpec(Action<int,T> action)
        {
            this.action = action;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.AddCustomAction(settings);
        }
    }
}
