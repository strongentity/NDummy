using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class Int64SequenceFactoryTest:SequenceFactoryTestBase<long>
    {

        protected override SequenceFactory<long> GetFactory(SequenceFactorySettings<long> settings)
        {
            return settings != null ? new Int64SequenceFactory(settings) : new Int64SequenceFactory();
        }

        [Theory]
        [InlineData(long.MinValue, long.MaxValue, long.MaxValue,long.MinValue, -1, long.MaxValue-1)]
        
        [InlineData(10, -1000, -575, 10, -565,-129)]
        public void CheckGeneratedSequence(long minValue,long maxValue,long step,long val1, long val2, long val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
