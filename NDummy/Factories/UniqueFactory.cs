using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{
    public abstract class UniqueFactory<T> : IFactory<T> where T : struct, IComparable
    {

        protected HashSet<T> Hash=new HashSet<T>();
        private readonly IFactory<T> factory;
        public int MaxTry { get; set; }

        protected abstract IFactory<T> GetRandomFactory(RandomFactorySettings<T> settings);
        protected abstract IFactory<T> GetSequenceFactory(SequenceFactorySettings<T> settings);


        protected UniqueFactory(UniqueFactorySettings<T> settings)
        {
            if(settings!=null)
            {
                MaxTry = settings.MaxTry;
                    if(settings.IsRandom)
                    {
                        //create Random Factory
                        RandomFactorySettings<T> randomSettings = new RandomFactorySettings<T>
                                                                      {
                                                                          MaxValue = settings.MaxValue,
                                                                          MinValue = settings.MinValue
                                                                      };
                        factory = GetRandomFactory(randomSettings);
                    }
                    else
                    {
                        //create Sequnece Factory
                        SequenceFactorySettings<T> sequenceSettings = new SequenceFactorySettings<T>
                                                                          {
                                                                              MaxValue = settings.MaxValue,
                                                                              MinValue =settings.MinValue,
                                                                              Step = settings.Step
                                                                          };
                      
                       
                        factory = GetSequenceFactory(sequenceSettings);
                    }
            }
        }

 

        public T Generate()
        {
           //  UniqueFactory<T> factory = new UniqueFactory<T>
           // ((IFactory)factory).Generate();
           // var value = factory.Generate();
            int cek = 0;
            T value;
            do
            {
             value = factory.Generate();
             Hash.Add(value);
             if (Hash.Contains(value) == true)
             {
                 cek++;
             }
               

            } 
            while (cek<MaxTry);
            {
            return (T) value;    
            }


            throw new Exception("The input cannot generate unique value");
        }


        object IFactory.Generate()
        {
            return this.Generate();
        }
    }

    public class UniqueFactorySettings<T>
    {
        public bool IsRandom { get;  set; }
        public int MaxTry { get;  set; }
        public T Step { get;  set; }
        public T MinValue { get;  set; }
        public T MaxValue { get;  set; }
    }

    public class Int32UniqueFactory : UniqueFactory<int>
    {
        protected override IFactory<int> GetRandomFactory(RandomFactorySettings<int> settings)
        {
            return settings != null ? new RandomInt32Factory(settings) : new RandomInt32Factory();
        }

        protected override IFactory<int> GetSequenceFactory(SequenceFactorySettings<int> settings)
        {
            return settings != null ? new Int32SequenceFactory(settings) : new Int32SequenceFactory();
        }

        public Int32UniqueFactory() : base( new UniqueFactorySettings<int>()
            {
                IsRandom = true,
                MaxValue = Int32.MaxValue,
                MinValue = 1,
                Step = 1,
                MaxTry = 5
            })
         {

         }
         public Int32UniqueFactory(UniqueFactorySettings<int> settings)
            : base(settings)
        {

        }

    }

    

}

