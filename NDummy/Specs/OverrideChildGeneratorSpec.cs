namespace NDummy.Specs
{
    public class OverrideChildGeneratorSpec : IGeneratorSpec
    {
        private readonly bool @override;

        public OverrideChildGeneratorSpec(bool @override)
        {
            this.@override = @override;
        }

        public void Apply(IGeneratorSettings settings)
        {
            settings.OverrideChildSettings = @override;
        }
    }
}
