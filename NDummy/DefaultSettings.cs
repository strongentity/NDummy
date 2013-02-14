namespace NDummy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using NDummy.Factories;

    public class DefaultSettings : Settings
    {
        public DefaultSettings()
        {
            SetFactory<bool>(new BoolSequenceFactory());
            SetFactory<byte>(new ByteSequenceFactory());
            SetFactory(new SByteSequenceFactory());
            SetFactory(new Int16SequenceFactory());
            SetFactory(new UInt16SequenceFactory());
            SetFactory(new Int32SequenceFactory());
            SetFactory(new UInt32SequenceFactory());
            SetFactory(new Int64SequenceFactory());
            SetFactory(new UInt64SequenceFactory());
            SetFactory(new CharSequenceFactory());
            SetFactory(new RandomDoubleFactory());
            SetFactory(new RandomSingleFactory());
            SetFactory(new GuidFactory());
            SetFactory<string>(()=> new StringFactory());

            SetFactory(typeof(bool?), new BoolSequenceFactory());
            SetFactory(typeof(byte?), new ByteSequenceFactory());
            SetFactory(typeof(sbyte?), new SByteSequenceFactory());
            SetFactory(typeof(short?), new Int16SequenceFactory());
            SetFactory(typeof(ushort?), new UInt16SequenceFactory());
            SetFactory(typeof(int?), new Int32SequenceFactory());
            SetFactory(typeof(uint), new UInt32SequenceFactory());
            SetFactory(typeof(long), new Int64SequenceFactory());
            SetFactory(typeof(ulong), new UInt64SequenceFactory());
            SetFactory(typeof(char?) ,new CharSequenceFactory());
            SetFactory(typeof(double?), new RandomDoubleFactory());
            SetFactory(typeof(float?), new RandomSingleFactory());
            SetFactory(typeof(Guid?), new GuidFactory());

            CollectionGenerator.Register(typeof(IList<>),this.GetListFactory);
            CollectionGenerator.Register(typeof(ICollection<>), this.GetListFactory);
            CollectionGenerator.Register(typeof(IEnumerable<>), this.GetListFactory);
            CollectionGenerator.Register(typeof(IDictionary<,>), this.GetDictionaryFactory);
            CollectionGenerator.Register(typeof(IList), this.GetListFactory);
            CollectionGenerator.Register(typeof(ICollection), this.GetListFactory);
            CollectionGenerator.Register(typeof(IEnumerable), this.GetListFactory);
            CollectionGenerator.Register(typeof(IDictionary), this.GetDictionaryFactory);

            TotalCollectionItems = 1;
        }

        private IFactory GetListFactory(Type[] types, ISettings settings)
        {
            var listFactoryType = typeof(ListFactory<>).MakeGenericType(types[0]);
            IFactory factory = this.GetFactoryForType(types[0], settings);

            return Activator.CreateInstance(listFactoryType, factory) as IFactory;
        }

        private IFactory GetDictionaryFactory(Type[] types, ISettings settings)
        {
            var dictFactoryType = typeof(DictionaryFactory<,>).MakeGenericType(types[0], types[1]);
            IFactory keyFactory = this.GetFactoryForType(types[0], settings);
            IFactory valueFactory = this.GetFactoryForType(types[1], settings);
            return Activator.CreateInstance(dictFactoryType, keyFactory, valueFactory) as IFactory;
        }

        private IFactory GetFactoryForType(Type type, ISettings settings)
        {
            IFactory factory = null;

            if (settings.Factories.ContainsKey(type))
            {
                factory = settings.Factories[type];
            }
            else
            {
                factory = Activator.CreateInstance(typeof(ObjectGenerator<>).MakeGenericType(type)) as IFactory;
            }

            return factory;
        }
    }
}
