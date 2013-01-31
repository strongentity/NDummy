using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class DecimalSequenceFactoryTest:SequenceFactoryTestBase<decimal>
    {
        protected override SequenceFactory<decimal> GetFactory(SequenceFactorySettings<decimal> settings)
        {
            return settings != null ? new DecimalSequenceFactory(settings) : new DecimalSequenceFactory();
        }

        [Theory]
        [InlineData(-1.000001f, 1000.3f, 1.00000001f, -1.000001f, -1.000001f + 1.0000001f, 0.999998f)]
        [InlineData(1.2f, 2.0f, -2.2f, 1.2f, 1.5f, 1.8f)]
        [InlineData(1.0f, 2.0f, 0.6f, 1f, 1.6f, 1.1f)]
        public void CheckGeneratedSequence(float minValue, float maxValue, float step, float val1, float val2, float val3)
        {
            IsValidDoubleSequence((decimal)minValue, (decimal)maxValue, (decimal)step, (decimal)val1, (decimal)val2, (decimal)val3);
        }
    }
}
