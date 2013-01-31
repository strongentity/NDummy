using System;
using NDummy.Factories;
using Xunit;
using NDummy.Tests.Utilities;



namespace NDummy.Tests.Factories.SequenceFactories
{
    public abstract class SequenceFactoryTestBase<T> where T : struct,IComparable
    {
        private SequenceFactory<T> _factory;

        protected abstract SequenceFactory<T> GetFactory(SequenceFactorySettings<T> settings);

        protected void IsSequence(T minValue, T maxValue, T step)
        {
            var settings = new SequenceFactorySettings<T>
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Step = step
            };

            _factory = GetFactory(settings);
            T value1 = _factory.Generate();
            Console.WriteLine(value1);
            T value2 = _factory.Generate();
            Console.WriteLine(value2);
            T value3 = _factory.Generate();
            Console.WriteLine(value3);


            Assert.True(
                ((step.CompareTo(0) == 1)
                && (((value1.CompareTo(value2) == -1) || (value1.CompareTo(value2) == 0))
                && ((value2.CompareTo(value3) == -1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                ||
                ((step.CompareTo(0) == -1)
                && (((value1.CompareTo(value2) == 1) || (value1.CompareTo(value2) == 0))
                && ((value2.CompareTo(value3) == 1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                );

        }


        protected void IsDoubleSequence(T minValue, T maxValue, T step)
        {
            var settings = new SequenceFactorySettings<T>
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Step = step
            };

            _factory = GetFactory(settings);
            T value1 = _factory.Generate();
            Console.WriteLine(value1);
            T value2 = _factory.Generate();
            Console.WriteLine(value2.ToString());
            T value3 = _factory.Generate();
            Console.WriteLine(value3.ToString());
            double zero = 0;

            Assert.True(
                ((step.CompareTo(zero) == 1)
                && (((value1.CompareTo(value2) == -1) || (value1.CompareTo(value2) == 0))
                && ((value2.CompareTo(value3) == -1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                ||
                ((step.CompareTo(zero) == -1)
                && (((value1.CompareTo(value2) == 1) || (value1.CompareTo(value2) == 0))
                && ((value2.CompareTo(value3) == 1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                );

        }


        protected void IsValidSequence(T minValue, T maxValue, T step, T val1, T val2, T val3)
        {
            var settings = new SequenceFactorySettings<T>
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Step = step
            };

            _factory = GetFactory(settings);
            T value1 = _factory.Generate();
            Console.WriteLine(val1);
            Console.WriteLine(value1);
            Console.WriteLine(val1.CompareTo(value1));
            T value2 = _factory.Generate();
            Console.WriteLine(val2);
            Console.WriteLine(value2);
            Console.WriteLine(val2.CompareTo(value2));
            T value3 = _factory.Generate();
            Console.WriteLine(val3);
            Console.WriteLine(value3);
            Console.WriteLine(val3.CompareTo(value3));

            Assert.True(val1.CompareTo(value1) == 0 && val2.CompareTo(value2) == 0 && val3.CompareTo(value3) == 0);

        }

        protected void IsValidDoubleSequence(T minValue, T maxValue, T step, T val1, T val2, T val3)
        {

            var settings = new SequenceFactorySettings<T>
            {
                MinValue = minValue,
                MaxValue = maxValue,
                Step = step
            };

            _factory = GetFactory(settings);
            T value1 = _factory.Generate();
            T value2 = _factory.Generate();
            T value3 = _factory.Generate();

            var check1 = val1.AreEqual(value1);
            var check2 = val2.AreEqual(value2);
            var check3 = val3.AreEqual(value3);
            Assert.True(check1 && check2 && check3);
 
        }

    }
}
