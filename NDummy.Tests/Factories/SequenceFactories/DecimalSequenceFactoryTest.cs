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
     //  [InlineData(short.MinValue, short.MaxValue,1,0,1,2)]
        public void CheckGeneratedSequence(float minValue, float maxValue, float step, float val1, float val2, float val3)
        {
           // IsValidSequence((decimal) minValue, (decimal) maxValue, (decimal) step, (decimal) val1, (decimal) val2, (decimal) val3);
            IsValidDoubleSequence((decimal)minValue, (decimal)maxValue, (decimal)step, (decimal)val1, (decimal)val2, (decimal)val3);
        }
    }
}
