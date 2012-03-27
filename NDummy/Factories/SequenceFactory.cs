using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{
    /*
     * 
     * int, short, byte, bool, long, uint, ushort, sbyte, ulong, float, double, decimal, BigInteger
     */
    public abstract class SequenceFactory<T> : IFactory<T> where T:struct, IComparable
    {
        
        protected SequenceFactory(SequenceFactorySettings<T> settings)
        {

            if (settings != null)
            {
                MinValue = settings.MinValue;
                MaxValue = settings.MaxValue;
                Step = settings.Step;
                CurrentValue = settings.MinValue;
                IsFirstValue = true;
            }

        }

        /// <summary>
        /// generates T instance
        /// </summary>
        /// <returns> a T of course</returns>
        public abstract T Generate();
       
        /// <summary>
        /// gets minimum sequence value
        /// </summary>
        public T MinValue { get; private set; }

        /// <summary>
        /// gets maximux sequence value
        /// </summary>
        public T MaxValue { get; private set; }

        /// <summary>
        /// get step  
        /// </summary>
        public T Step { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        protected T CurrentValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        protected bool IsFirstValue { get; set; }
    }

    public class SequenceFactorySettings<T>
    {
        public T MinValue { get; set; }

        public T MaxValue { get; set; }

        public T Step { get; set; }

    }

    public class Int32SequenceFactory : SequenceFactory<int>
    {
        //private int _currentValue;
      

        /// <summary>
        /// 
        /// </summary>
        public Int32SequenceFactory() : 
           base( new SequenceFactorySettings<int>()
            {
                MaxValue = Int32.MaxValue,
                MinValue = Int32.MinValue,
                Step = 1
            })
         {

         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public Int32SequenceFactory(SequenceFactorySettings<int> settings):base(settings)
        {
            if (settings.Step == 0)
            {
                throw new System.ArgumentException("Step can not be zero","settings");
            }
            if ( settings.Step>0 && settings.MaxValue < settings.MinValue )
            {
                throw new System.ArgumentException("On Step positive(+) Max can not less than Min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("On Step negative(+) Max value can not bigger than Min value", "settings");
            }
        }

        public override int Generate()
        {
            int _currentValue = MinValue;
            if(IsFirstValue==true)
            {
                IsFirstValue = false;
            }
            else if(IsFirstValue==false)
            {
            
                if(_currentValue != CurrentValue);
                _currentValue = CurrentValue;
                int newValue = 0;
           
                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = _currentValue + Step;
                            if (newValue > MaxValue)
                                newValue = MinValue ;
                        }
                    }
                    catch
                    {
                        newValue = _currentValue + Step ;
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = _currentValue + Step;
                            if (newValue < MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = MaxValue + Step;
                    }
                }
                _currentValue = newValue;
                CurrentValue = _currentValue;
              }
            return _currentValue;
        }

    }



}
