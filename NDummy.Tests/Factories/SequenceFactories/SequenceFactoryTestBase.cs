using System;
using NDummy.Factories;
using Xunit;
namespace NDummy.Tests.Factories.SequenceFactories
{
    public abstract class SequenceFactoryTestBase<T> where T :struct,IComparable
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
                ((step.CompareTo(0)==1)
                && ( ((value1.CompareTo(value2) == -1) || (value1.CompareTo(value2) == 0) )
                && ((value2.CompareTo(value3) == -1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                ||
                ((step.CompareTo(0)==-1)
                && ( ((value1.CompareTo(value2) == 1) || (value1.CompareTo(value2) == 0) )
                && ((value2.CompareTo(value3) == 1) || (value2.CompareTo(value3) == 0) || (value3.CompareTo(value1) == 0))
                )
                )
                );
            
        }

        protected void IsValidSequence(T minValue, T maxValue, T step,T val1,T val2,T val3)
        {
            
        
        Assert.True(
                ((step.CompareTo(0)==1)
                && ( minValue.CompareTo(maxValue)==-1 )
                && ( ((val1.CompareTo(val2) == -1) || (val1.CompareTo(val2) == 0) )
                && ((val2.CompareTo(val3) == -1) || (val2.CompareTo(val3) == 0) || (val3.CompareTo(val1) == 0))
                )
                )
                ||
                ((step.CompareTo(0)==-1)
                && ( ((val1.CompareTo(val2) == 1) || (val1.CompareTo(val2) == 0) )
                && ((val2.CompareTo(val3) == 1) || (val2.CompareTo(val3) == 0) || (val3.CompareTo(val1) == 0))
                )
                )
                );
        
        }

    }
}
