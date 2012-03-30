namespace NDummy.Specs
{
    public class MaxDepthSpec : IGeneratorSpec
    {
        private readonly int maxDepth;

        public MaxDepthSpec(int maxDepth)
        {
            this.maxDepth = maxDepth;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.MaxDepth = maxDepth;
        }
    }
}
