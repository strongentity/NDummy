namespace NDummy.Tests.Factories.SequenceFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;
    class DoubleSequenceFactoryTest:SequenceFactoryTestBase<double>
    {
        protected override SequenceFactory<double> GetFactory(SequenceFactorySettings<double> settings)
        {
            return settings != null ? new DoubleSequenceFactory(settings) : new DoubleSequenceFactory();
        }
       /* [Theory]
        [InlineData(0.00000000021, 0.000000001, 0.0000000001)]
        [InlineData(278.97,100.92,-90.46)]
        [InlineData(double.MinValue,double.MaxValue,double.MaxValue )]
        public void CanGenerateSequence(double minValue, double maxValue, double step)
        {
            IsDoubleSequence(minValue, maxValue, step);
        }*/

        [Theory]
        [InlineData(0.0007, 0.001, 0.0001, 0.0007, 0.0008, 0.0009)]
        [InlineData(1.2, 3.6, 1.2, 1.2, 2.4, 3.6)]
       // [InlineData(-10, 10, 2, -10, -8, -6)]
        public void CheckGeneratedSequence(double  minValue, double maxValue, double step, double val1, double val2, double val3)
        {
            IsValidSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
