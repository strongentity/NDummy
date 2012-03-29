using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class Int32SequenceFactoryTest:SequenceFactoryTestBase<int>
    {
        protected override SequenceFactory<int> GetFactory(SequenceFactorySettings<int> settings )
        {
            return settings != null ? new Int32SequenceFactory(settings) : new Int32SequenceFactory();
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
        [InlineData(5,15,5,5,10,15)]
        [InlineData(-10, 10, 2, -10, -8, -6)]
        public  void CheckGeneratedSequence(int minValue,int maxValue,int step,int val1,int val2,int val3)
        {
            IsValidSequence(minValue,maxValue,step,val1,val2,val3);
        }

    }
}
