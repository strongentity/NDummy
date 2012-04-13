using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.SequenceFactories
{
    public class CharSequenceFactoryTest:SequenceFactoryTestBase<char>
    {
        protected override SequenceFactory<char> GetFactory(SequenceFactorySettings<char> settings)
        {
            return settings != null ? new CharSequenceFactory(settings) : new CharSequenceFactory();
        }

        [Theory]
       
        [InlineData('B','Z',(char)1,'B','C','D')]
        [InlineData('B', 'E', (char)10, 'B', 'D', 'B')]
        public  void CheckGeneratedSequence(char minValue,char maxValue,char step,char val1,char val2,char val3)
        {
            IsValidSequence(minValue,maxValue,step,val1,val2,val3);
        }
    }
}
