using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class UInt32SequenceFactoryTest : SequenceFactoryTestBase<uint>
    {
        protected override SequenceFactory<uint> GetFactory(SequenceFactorySettings<uint> settings)
        {
            return settings != null ? new UInt32SequenceFactory(settings) : new UInt32SequenceFactory();
        }
         
        [Theory]
        [InlineData((uint)1, (uint)2, (uint)1, (uint)1, (uint)2, (uint)1)]
        [InlineData(uint.MinValue, uint.MaxValue, uint.MaxValue, (uint)0,4294967295, 4294967294)]
        public void CheckGeneratedSequence(uint minValue, uint maxValue, uint step, uint val1, uint val2, uint val3)
        {
             IsValidSequence( minValue, maxValue, step, val1, val2, val3);
        }

    }
}
