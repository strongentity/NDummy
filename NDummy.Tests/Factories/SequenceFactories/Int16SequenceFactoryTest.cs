using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class Int16SequenceFactoryTest : SequenceFactoryTestBase<short>
    {
        protected override SequenceFactory<short> GetFactory(SequenceFactorySettings<short> settings)
        {
            return settings != null ? new Int16SequenceFactory(settings) : new Int16SequenceFactory();
        }
        [Theory]
        [InlineData(short.MinValue, short.MaxValue, (short)5, (short)-32768, (short)-32763, (short)-32758)]
        [InlineData((short)-10, (short)10,(short)20, (short)-10,(short)10,(short)9)]
        [InlineData((short)10, (short)-1000, (short)-575, (short)10, (short)-565, (short)-129)]
        public void CheckGeneratedSequence(short minValue,short maxValue,short step,short val1, short val2, short val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }

    }
}
