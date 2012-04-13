using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class BoolSequenceFactoryTest:SequenceFactoryTestBase<bool>
    {
        protected override SequenceFactory<bool> GetFactory(SequenceFactorySettings<bool> settings)
        {
            return settings != null ? new BoolSequenceFactory(settings) : new BoolSequenceFactory();
        }
        [Theory]
        
        [InlineData(false, true,true, false, true, false)]
        [InlineData(false, true, true, false, true, false)]
        public void CheckGeneratedSequence(bool minValue, bool maxValue, bool step, bool val1, bool val2, bool val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
