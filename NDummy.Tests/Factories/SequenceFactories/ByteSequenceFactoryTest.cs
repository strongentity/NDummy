
using NDummy.Factories;
using Xunit.Extensions;
namespace NDummy.Tests.Factories.SequenceFactories
{
    public class ByteSequenceFactoryTest:SequenceFactoryTestBase<byte>
    {
        protected override SequenceFactory<byte> GetFactory(SequenceFactorySettings<byte> settings)
        {
            return settings != null ? new ByteSequenceFactory(settings) : new ByteSequenceFactory();
        }

        [Theory]
        [InlineData(byte.MinValue, byte.MaxValue, (byte)5, (byte)0, (byte)5, (byte)10)]
        [InlineData((byte)3, (byte)255, (byte)200, (byte)3, (byte)203, (byte)150)]
       // [InlineData((byte)10, (byte)-1000, (byte)-575, (byte)10, (byte)-565, (byte)10)]
        public void CheckGeneratedSequence(byte minValue, byte maxValue, byte step, byte val1, byte val2, byte val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }

    

}
