using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NDummy.Factories
{
    public abstract class UniqueFactory<T>:IFactory<T> 
    {

        protected HashSet<T> Hash { get; set; }
        private readonly IFactory<T> factory; 

         public abstract IFactory<T> GetRandomFactory(RandomFactorySettings<T> settings);

        protected UniqueFactory(UniqueFactorySettings<T> settings)
        {
            if(settings!=null)
            {
                    if(settings.IsRandom)
                    {
                        //create Random Factory
                        RandomFactorySettings<T> randomSettings;
                        randomSettings.MaxValue = settings.MaxValue;
                        randomSettings.MinValue = settings.MinValue;
                        factory = new RandomFactory<T>(randomSettings);
                    }
                    else
                    {
                        //create Sequnece Factory
                        SequenceFactorySettings<T> sequenceSettings;
                        sequenceSettings.MaxValue = settings.MaxValue;
                        sequenceSettings.MinValue = settings.MinValue;
                        sequenceSettings.Step = settings.Step;
                        factory = new SequenceFactory<T>(sequenceSettings);
                    }
            }
        }

        public T Generate()
        {
            var value=null;
            do
            {
                value = factory.Generate();
                Hash.Add(value);

            } while (value == Hash.Last());
            {
                return value;
                
            }
            throw new Exception("The input cannot generate unique value");
        }

    }

    public class UniqueFactorySettings<T>
    {
        public bool IsRandom { get; private set; }
        public int MaxTry { get; private set; }
        public T Step { get; private set; }
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }
    }

}
