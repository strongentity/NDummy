namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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
                throw new System.ArgumentException("If step is positive then max should be greater than min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("If step is negative then min should be greater than max", "settings");
            }
        }

        public override int Generate()
        {
            int _currentValue = MinValue;
            if(IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {
            
                if(_currentValue != CurrentValue)
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

    public class Int16SequenceFactory : SequenceFactory<short>
    {

        /// <summary>
        /// 
        /// </summary>
        public Int16SequenceFactory() :
            base(new SequenceFactorySettings<short>()
            {
                MaxValue = short.MaxValue,
                MinValue = short.MinValue,
                Step=1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public Int16SequenceFactory(SequenceFactorySettings<short> settings)
            : base(settings)
        {
            if (settings.Step == 0)
            {
                throw new System.ArgumentException("Step can not be zero", "settings");
            }
            if (settings.Step > 0 && settings.MaxValue < settings.MinValue)
            {
                throw new System.ArgumentException("If step is positive then max should be greater than min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("If step is negative then min should be greater than max", "settings");
            }
        }

        public override short Generate()
        {
            short _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {
                if (_currentValue != CurrentValue)
                _currentValue = CurrentValue;
                short newValue = 0;

                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (short) (_currentValue + Step);
                            if (newValue > MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (short) (_currentValue + Step);
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (short) (_currentValue + Step);
                            if (newValue < MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (short) (MaxValue + Step);
                    }
                }
                _currentValue = newValue;
                CurrentValue = _currentValue;
            }
            return _currentValue;
        }

    }

    public class Int64SequenceFactory : SequenceFactory<long>
    {

        /// <summary>
        /// 
        /// </summary>
        public Int64SequenceFactory() :
            base(new SequenceFactorySettings<long>()
            {
                MaxValue = long.MaxValue,
                MinValue = long.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public Int64SequenceFactory(SequenceFactorySettings<long> settings)
            : base(settings)
        {
            if (settings.Step == 0)
            {
                throw new System.ArgumentException("Step can not be zero", "settings");
            }
            if (settings.Step > 0 && settings.MaxValue < settings.MinValue)
            {
                throw new System.ArgumentException("If step is positive then max should be greater than min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("If step is negative then min should be greater than max", "settings");
            }
        }

        public override long Generate()
        {
            long _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {
                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                long newValue = 0;

                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = _currentValue + Step;
                            if (newValue > MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = _currentValue + Step;
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

    public class ByteSequenceFactory : SequenceFactory<byte>
    {

        /// <summary>
        /// 
        /// </summary>
        public ByteSequenceFactory() :
            base(new SequenceFactorySettings<byte>()
            {
                MaxValue = byte.MaxValue,
                MinValue = byte.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public ByteSequenceFactory(SequenceFactorySettings<byte> settings)
            : base(settings)
        {
            if (settings.Step == 0)
            {
                throw new System.ArgumentException("Step can not be zero", "settings");
            }
            if (settings.Step > 0 && settings.MaxValue < settings.MinValue)
            {
                throw new System.ArgumentException("If step is positive then max should be greater than min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("If step is negative then min should be greater than max", "settings");
            }
        }

        public override byte Generate()
        {
            byte _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {
                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                byte newValue = 0;

                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (byte) (_currentValue + Step);
                            if (newValue > MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (byte) (_currentValue + Step);
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (byte) (_currentValue + Step);
                            if (newValue < MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (byte) (MaxValue + Step);
                    }
                }
                _currentValue = newValue;
                CurrentValue = _currentValue;
            }
            return _currentValue;
        }

    }


    public class DoubleSequenceFactory : SequenceFactory<double>
    {
        /// <summary>
        /// 
        /// </summary>
         public DoubleSequenceFactory() : 
           base( new SequenceFactorySettings<double>()
            {
                MaxValue = double.MaxValue,
                MinValue = double.MinValue,
                Step = 1
            })
         {

         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
         public DoubleSequenceFactory(SequenceFactorySettings<double> settings):base(settings)
        {
            if (settings.Step == 0)
            {
                throw new System.ArgumentException("Step can not be zero","settings");
            }
            if ( settings.Step>0 && settings.MaxValue < settings.MinValue )
            {
                throw new System.ArgumentException("If step is positive then max should be greater than min", "settings");
            }
            if (settings.Step < 0 && settings.MaxValue > settings.MinValue)
            {
                throw new System.ArgumentException("If step is negative then min should be greater than max", "settings");
            }
        }

         public override double  Generate()
         {
             double _currentValue = MinValue;
             if (IsFirstValue)
             {
                 IsFirstValue = false;
             }
             else
             {

                 if (_currentValue != CurrentValue)
                 _currentValue = CurrentValue;
                 double newValue = 0;

                 if (Step > 0)
                 {
                     try
                     {
                         checked
                         {
                             newValue = _currentValue + Step;
                             if (newValue > MaxValue)
                                 newValue = MinValue;
                         }
                     }
                     catch
                     {
                         newValue = _currentValue + Step;
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
