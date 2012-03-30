namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Acts as base class for random data factories
    /// </summary>
    /// <typeparam name="T">Type of objects to generate</typeparam>
    public abstract class RandomFactory<T> :IFactory<T> where T : struct, IComparable
    {
        protected Random Random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomFactory&lt;T&gt;"/> class.
        /// </summary>
        protected RandomFactory()
        {
            this.Random = new Random();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomFactory&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        protected RandomFactory(RandomFactorySettings<T> settings)
        {
            if(settings != null)
            {
                MinValue = settings.MinValue;
                MaxValue = settings.MaxValue;
            }
            this.Random = new Random();
        }

        /// <summary>
        /// Generates T instance.
        /// </summary>
        /// <returns>An instance of T</returns>
        public abstract T Generate();

        /// <summary>
        /// Gets the min value.
        /// </summary>
        public T MinValue { get; private set; }

        /// <summary>
        /// Gets the max value.
        /// </summary>
        public T MaxValue { get; private set; }

    }

    /// <summary>
    /// Contains settings for RandomFactory
    /// </summary>
    /// <typeparam name="T">Type of objects to generate</typeparam>
    public class RandomFactorySettings<T>
    {
        /// <summary>
        /// Gets or sets the min value.
        /// </summary>
        /// <value>
        /// The min value.
        /// </value>
        public T MinValue { get; set; }

        /// <summary>
        /// Gets or sets the max value.
        /// </summary>
        /// <value>
        /// The max value.
        /// </value>
        public T MaxValue { get; set; }
    }

    /// <summary>
    /// Generates integer randomly 
    /// </summary>
    public class RandomInt32Factory : RandomFactory<int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt32Factory"/> class.
        /// </summary>
        public RandomInt32Factory()
            : base(new RandomFactorySettings<int>()
            {
                MaxValue = int.MaxValue,
                MinValue = int.MinValue
            })
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt32Factory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public RandomInt32Factory(RandomFactorySettings<int> settings)
            : base(settings)
        {

        }

        /// <summary>
        /// Generates integer.
        /// </summary>
        /// <returns>Integer value</returns>
        public override int Generate()
        {
            return this.Random.Next(MinValue, MaxValue);
        }

    }

    /// <summary>
    /// Generates Int64 value
    /// </summary>
    public class RandomInt64Factory : RandomFactory<long>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt64Factory"/> class.
        /// </summary>
        public RandomInt64Factory() : base(new RandomFactorySettings<long>()
                                               {
                                                   MaxValue = long.MaxValue,
                                                   MinValue = long.MinValue
                                               })
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt64Factory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public RandomInt64Factory(RandomFactorySettings<long> settings):base(settings)
        {
        }

        /// <summary>
        /// Generates Int64 value.
        /// </summary>
        /// <returns>Int64 value</returns>
        public override long Generate()
        {
            //TODO: check this
            var dblValue = this.Random.NextDouble();
            long range =0;
            try
            {
                checked
                {
                    range = MaxValue - MinValue;
                }
            }
            catch
            {
                range = long.MaxValue;
            }
            if (range > long.MaxValue) range = long.MaxValue;
            return (long) (dblValue*range) + MinValue;
        }
    }

    /// <summary>
    /// Generates Int16 randomly
    /// </summary>
    public class RandomInt16Factory : RandomFactory<short>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt16Factory"/> class.
        /// </summary>
        public RandomInt16Factory():base(new RandomFactorySettings<short>
                                             {
                                                 MinValue = short.MinValue,
                                                 MaxValue = short.MaxValue
                                             })
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomInt16Factory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public RandomInt16Factory(RandomFactorySettings<short> settings) : base(settings)
        {   
        }

        /// <summary>
        /// Generates Int16.
        /// </summary>
        /// <returns>Int16 value</returns>
        public override short Generate()
        {
            return (short) this.Random.Next(MinValue, MaxValue);
        }
    }

    /// <summary>
    /// Generates byte randomly
    /// </summary>
    public class RandomByteFactory : RandomFactory<byte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomByteFactory"/> class.
        /// </summary>
        public RandomByteFactory() : base(new RandomFactorySettings<byte>()
                                              {
                                                  MinValue = byte.MinValue,
                                                  MaxValue = byte.MaxValue
                                              })
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomByteFactory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public RandomByteFactory(RandomFactorySettings<byte> settings) : base(settings)
        {}

        /// <summary>
        /// Generates byte value.
        /// </summary>
        /// <returns>Byte value</returns>
        public override byte Generate()
        {
            return (byte)this.Random.Next(MinValue, MaxValue);
        }
    }

    /// <summary>
    /// Generates SByte randomly
    /// </summary>
    public class RandomSByteFactory : RandomFactory<sbyte>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RandomSByteFactory"/> class.
        /// </summary>
        public RandomSByteFactory()
            : base(new RandomFactorySettings<sbyte>()
            {
                MinValue = sbyte.MinValue,
                MaxValue = sbyte.MaxValue
            })
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomSByteFactory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public RandomSByteFactory(RandomFactorySettings<sbyte> settings)
            : base(settings)
        { }

        /// <summary>
        /// Generates sbyte instance.
        /// </summary>
        /// <returns>SByte value</returns>
        public override sbyte Generate()
        {
            return (sbyte) this.Random.Next(MinValue, MaxValue);
        }
    }

    public class RandomUInt16Factory : RandomFactory<ushort>
    {
        public RandomUInt16Factory() : base(new RandomFactorySettings<ushort>()
                                                {
                                                    MinValue = ushort.MinValue,
                                                    MaxValue = ushort.MaxValue
                                                }){}

        public RandomUInt16Factory(RandomFactorySettings<ushort> settings):base(settings)
        {}

        public override ushort Generate()
        {
            return (ushort) this.Random.Next(MinValue, MaxValue);
        }
    }

    public class RandomUInt32Factory : RandomFactory<uint>
    {
        public RandomUInt32Factory()
            : base(new RandomFactorySettings<uint>()
            {
                MinValue = uint.MinValue,
                MaxValue = uint.MaxValue
            })
        {
        }

        public RandomUInt32Factory(RandomFactorySettings<uint> settings)
            : base(settings)
        {
        }

        public override uint Generate()
        {
            var range = MaxValue - MinValue;
            return (uint)(this.Random.NextDouble() * range) + MinValue;
        }
    }

    public class RandomUInt64Factory : RandomFactory<ulong>
    {
        public RandomUInt64Factory()
            : base(new RandomFactorySettings<ulong>()
            {
                MinValue = ulong.MinValue,
                MaxValue = ulong.MaxValue
            }) { }

        public RandomUInt64Factory(RandomFactorySettings<ulong> settings)
            : base(settings)
        { }

        public override ulong Generate()
        {
            var dblValue = this.Random.NextDouble();
            return (ulong)(dblValue * MaxValue - dblValue * MinValue) + MinValue;
        }
    }

    public class RandomSingleFactory : RandomFactory<float>
    {
        public RandomSingleFactory()
            : base(new RandomFactorySettings<float>()
            {
                MinValue = float.MinValue,
                MaxValue = float.MaxValue
            })
        { }

        public RandomSingleFactory(RandomFactorySettings<float> settings)
            : base(settings)
        {
        }

        public override float Generate()
        {
            var dblValue = this.Random.NextDouble();
            float range = MaxValue - MinValue;
            if (range > float.MaxValue)
                range = float.MaxValue;
            return (float)(dblValue * range) + MinValue;
        }
    }

    public class RandomDoubleFactory : RandomFactory<double>
    {
        public RandomDoubleFactory()
            : base(new RandomFactorySettings<double>()
            {
                MinValue = double.MinValue,
                MaxValue = double.MaxValue
            })
        { }

        public RandomDoubleFactory(RandomFactorySettings<double> settings)
            : base(settings)
        {
        }

        public override double Generate()
        {
            var dblValue = this.Random.NextDouble();
            var range = MaxValue - MinValue;
            if (range > double.MaxValue)
                range = double.MaxValue;
            return (dblValue * range) + MinValue;
        }
    }

    public class RandomDecimalFactory : RandomFactory<decimal>
    {
        public RandomDecimalFactory()
            : base(new RandomFactorySettings<decimal>()
            {
                MinValue = int.MinValue,
                MaxValue = int.MaxValue
            })
        { }

        public RandomDecimalFactory(RandomFactorySettings<decimal> settings)
            : base(settings)
        {
        }

        public override decimal Generate()
        {
            decimal range = 0;
            try
            {
                range = MaxValue - MinValue;
            }
            catch
            {
                range = MaxValue;
            }
            
            var dblValue = (decimal)this.Random.NextDouble();
            return (dblValue * range) + MinValue;
        }
    }

    public class RandomBooleanFactory : RandomFactory<bool>
    {
        public override bool Generate()
        {
            double nextDouble = this.Random.NextDouble();
            int value = (int)Math.Round(nextDouble);
            return value == 1;
        }
    }
}
