namespace NDummy.Tests.Factories.SequenceFactories
{
    using NDummy.Factories;
    using Xunit.Extensions;
    public class DoubleSequenceFactoryTest:SequenceFactoryTestBase<double>
    {
        protected override SequenceFactory<double> GetFactory(SequenceFactorySettings<double> settings)
        {
            return settings != null ? new DoubleSequenceFactory(settings) : new DoubleSequenceFactory();
        }

        [Theory]
        [InlineData(0.0007, 0.001, 0.0001, 0.0007, 0.0008, 0.0009)]
        [InlineData(1.2, 3.6, 1.2, 1.2, 2.4, 3.6)]
        [InlineData(1.2, 2.0, -2.2, 1.2, 1.5, 1.8)]
        [InlineData(1.0, 2.0, 0.6, 1, 1.6, 1.1)]
        [InlineData(-10, 10, 2, -10, -8, -6)]
        public void CheckGeneratedSequence(double  minValue, double maxValue, double step, double val1, double val2, double val3)
        {
            IsValidDoubleSequence(minValue, maxValue, step, val1, val2, val3);
        }
    }
}
