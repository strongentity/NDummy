using System.Numerics;

namespace NDummy.Factories
{
    using System;

    /*
     * 
     * int+, short+, byte+, bool, long+, uint++, ushort++, sbyte+, ulong++, float+, double+, decimal+, BigInteger+
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
                MinValue = 1,
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
                            {
                                var diff = newValue - MaxValue - 1;
                                newValue = MinValue + diff;

                                //newValue = (MinValue - 1) + ((Step) - (MaxValue - _currentValue));
                            }
                        }
                    }
                    catch
                    {
                        var rangeBetweenCyclic = MaxValue - _currentValue + 1;
                        newValue = MinValue + Step - rangeBetweenCyclic;

                        //newValue = _currentValue + Step ;
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

         public override double Generate()
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

    public class FloatSequenceFactory : SequenceFactory<float>
    {
        /// <summary>
        /// 
        /// </summary>
        public FloatSequenceFactory() :
            base(new SequenceFactorySettings<float>()
            {
                MaxValue = float.MaxValue,
                MinValue = float.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public FloatSequenceFactory(SequenceFactorySettings<float> settings)
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

        public override float Generate()
        {
            float _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {

                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                float newValue = 0;

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

    public class DecimalSequenceFactory : SequenceFactory<decimal>
    {

        /// <summary>
        /// 
        /// </summary>
        public DecimalSequenceFactory() :
        base(new SequenceFactorySettings<decimal>()
                {
                     MaxValue = decimal.MaxValue,
                MinValue = decimal.MinValue,
                Step = 1
                })

        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public DecimalSequenceFactory(SequenceFactorySettings<decimal> settings):base(settings)
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

        public override decimal Generate()
        {
            decimal _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {

                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                decimal newValue = 0;

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

    public class UInt32SequenceFactory : SequenceFactory<uint>
    {
        //private int _currentValue;


        /// <summary>
        /// 
        /// </summary>
        public UInt32SequenceFactory() :
            base(new SequenceFactorySettings<uint>()
            {
                MaxValue = uint.MaxValue,
                MinValue = uint.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public UInt32SequenceFactory(SequenceFactorySettings<uint> settings)
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

        public override uint Generate()
        {
            uint _currentValue = MinValue;
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
                            newValue = (long) (_currentValue) + Step;
                            if (newValue > MaxValue)
                                newValue = (long) MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (long) (_currentValue + Step);
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (long) (_currentValue) + Step;
                            if (newValue < MaxValue)
                                newValue = (long) MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (long) (MaxValue + Step);
                    }
                }
                _currentValue = (uint)newValue;
                CurrentValue = _currentValue;
            }
            return _currentValue;
        }

    }

    public class UInt16SequenceFactory : SequenceFactory<ushort>
    {
        //private int _currentValue;


        /// <summary>
        /// 
        /// </summary>
        public UInt16SequenceFactory() :
            base(new SequenceFactorySettings<ushort>()
            {
                MaxValue = ushort.MaxValue,
                MinValue = ushort.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public UInt16SequenceFactory(SequenceFactorySettings<ushort> settings)
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

        public override ushort Generate()
        {
            ushort _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {

                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                ushort newValue = 0;

                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (ushort) (_currentValue + Step);
                            if (newValue > MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (ushort) (_currentValue + Step);
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (ushort) (_currentValue + Step);
                            if (newValue < MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (ushort) (MaxValue + Step);
                    }
                }
                _currentValue = newValue;
                CurrentValue = _currentValue;
            }
            return _currentValue;
        }

    }

    public class UInt64SequenceFactory : SequenceFactory<ulong>
    {
        //private int _currentValue;


        /// <summary>
        /// 
        /// </summary>
        public UInt64SequenceFactory() :
            base(new SequenceFactorySettings<ulong>()
            {
                MaxValue = ushort.MaxValue,
                MinValue = ushort.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public UInt64SequenceFactory(SequenceFactorySettings<ulong> settings)
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

        public override ulong Generate()
        {
            ulong _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {

                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                ulong newValue = 0;

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

    public class SByteSequenceFactory : SequenceFactory<sbyte>
    {

        /// <summary>
        /// 
        /// </summary>
        public SByteSequenceFactory() :
            base(new SequenceFactorySettings<sbyte>()
            {
                MaxValue = sbyte.MaxValue,
                MinValue = sbyte.MinValue,
                Step = 1
            })
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settings"></param>
        public SByteSequenceFactory(SequenceFactorySettings<sbyte> settings)
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

        public override sbyte Generate()
        {
            sbyte _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {
                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                sbyte newValue = 0;

                if (Step > 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (sbyte) (_currentValue + Step);
                            if (newValue > MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (sbyte) (_currentValue + Step);
                    }
                }
                else if (Step < 0)
                {
                    try
                    {
                        checked
                        {
                            newValue = (sbyte) (_currentValue + Step);
                            if (newValue < MaxValue)
                                newValue = MinValue;
                        }
                    }
                    catch
                    {
                        newValue = (sbyte) (MaxValue + Step);
                    }
                }
                _currentValue = newValue;
                CurrentValue = _currentValue;
            }
            return _currentValue;
        }

    }

    public class BigIntSequenceFactory : SequenceFactory<BigInteger>
    {
        //private int _currentValue;


        /// <summary>
        /// 
        /// </summary>
        public BigIntSequenceFactory() :
            base(new SequenceFactorySettings<BigInteger>()
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
        public BigIntSequenceFactory(SequenceFactorySettings<BigInteger> settings)
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

        public override BigInteger Generate()
        {
            BigInteger _currentValue = MinValue;
            if (IsFirstValue)
            {
                IsFirstValue = false;
            }
            else
            {

                if (_currentValue != CurrentValue)
                    _currentValue = CurrentValue;
                BigInteger newValue = 0;

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
