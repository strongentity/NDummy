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
        /* [Theory]
         [InlineData(5,10,10)]
         [InlineData(10,3,-4)]
         [InlineData(5,10,1)]
         [InlineData(int.MinValue,int.MaxValue,int.MaxValue)]
         public void CanGenerateSequence(int minValue,int maxValue,int step)
         {
             IsSequence(minValue, maxValue, step);
         }*/
        [Theory]
        [InlineData(short.MinValue, short.MaxValue, (short)5, (short)-32768, (short)-32763, (short)-32758)]
        [InlineData((short)-10, (short)10,(short)20, (short)-10,(short)10,(short)-10)]
        [InlineData((short)10, (short)-1000, (short)-575, (short)10, (short)-565, (short)10)]
        public void CheckGeneratedSequence(short minValue,short maxValue,short step,short val1, short val2, short val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }

    }
}
