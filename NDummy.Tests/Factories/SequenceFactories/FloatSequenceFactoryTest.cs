namespace NDummy.Tests.Factories.SequenceFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;
    public class FloatSequenceFactoryTest : SequenceFactoryTestBase<float>
    {
        protected override SequenceFactory<float> GetFactory(SequenceFactorySettings<float> settings)
        {
            return settings != null ? new FloatSequenceFactory(settings) : new FloatSequenceFactory();
        }

        [Theory]
        [InlineData(0.0007f, 0.001f, 0.0001f, 0.0007f, 0.0008f, 0.00089999f)]
      //  [InlineData(1.2, 3.6, 1.2, 1.2, 2.4, 3.6)]
       // [InlineData(1.2, -1.0, -1.2, 1.2, 0, 1.2)]
        // [InlineData(-10, 10, 2, -10, -8, -6)]
        public void CheckGeneratedSequence(float minValue, float maxValue, float step, float val1, float val2, float val3)
        {
            IsValidDoubleSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
