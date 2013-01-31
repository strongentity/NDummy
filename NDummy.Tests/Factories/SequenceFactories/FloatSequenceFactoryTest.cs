namespace NDummy.Tests.Factories.SequenceFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;
    public class FloatSequenceFactoryTest : SequenceFactoryTestBase<float>
    {
        protected override SequenceFactory<float> GetFactory(SequenceFactorySettings<float> settings)
        {
            return settings != null ? new SingleSequenceFactory(settings) : new SingleSequenceFactory();
        }

        [Theory]
        [InlineData(0.0007f, 0.001f, 0.0001f, 0.0007f, 0.0008f, 0.00089999f)]
        [InlineData(1.2f, 2.0f, -2.2f, 1.2f, 1.5f, 1.8f)]
        [InlineData(1.0f,2.0f, 0.6f,1f,1.6f, 1.1f)]
        public void CheckGeneratedSequence(float minValue, float maxValue, float step, float val1, float val2, float val3)
        {
            IsValidDoubleSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
