namespace NDummy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using NDummy.Utilities;

    public class ObjectGenerator<T> : IGenerator<T>, IHaveGeneratorSettings
    {
        private int index;

        private Func<ConstructorArguments, T> constructorFunc;

        private readonly IGeneratorSettings generatorSettings;

        private readonly Type type;

        private readonly IDictionary<MemberInfo, object> memberGenerators;

        private int currentDepth;

        private ISettings generalSettings;

        private bool resetMemberGenerators = true;

        private bool isBaseType;

        private IFactory<T> baseFactory; 

        public ObjectGenerator(ObjectGeneratorParams param)
        {
            if(param == null)
                throw new ArgumentNullException();

            generatorSettings = new GeneratorSettings();
            index = 1;
            type = typeof(T);
            memberGenerators = new Dictionary<MemberInfo, object>();
            generalSettings = param.GeneralSettings;
            generatorSettings.MaxDepth = generalSettings.MaxDepth;
            currentDepth = param.CurrentDepth;
            isBaseType = type.IsBaseType();
   
            if (isBaseType)
            {
                IFactory factory = null;

                if (generalSettings.Factories.TryGetValue(type, out factory))
                {
                    baseFactory = factory as IFactory<T>;
                }
                else if (Dummy.Settings.Factories.TryGetValue(type, out factory))
                {
                    baseFactory = factory as IFactory<T>;
                }
                else
                    throw new Exception("Can\'t find generator for specific type");
            }
        } 

        public IGenerator<T> ConstructWith(Func<ConstructorArguments, T> func)
        {
            constructorFunc = func;
            return this;
        }

        public IGenerator<T> Configure(params IGeneratorSpec[] specs)
        {
            if (specs == null || specs.Length == 0) return this;

            resetMemberGenerators = true;

            foreach(var spec in specs)
                spec.Apply(generatorSettings);

            return this;
        }

        public T Generate()
        {
            if (resetMemberGenerators)
            {
                if(! isBaseType)
                    this.ConstructMemberGenerators();
            }

            T instance = (isBaseType) ? this.CreateBaseTypes() : this.CreateComplexType();
            if(type.IsClass)
            {
                if(generatorSettings.CustomActions != null && generatorSettings.CustomActions.Count > 0)
                {
                    for(int i=0; i< generatorSettings.CustomActions.Count; i++)
                    {
                        (generatorSettings.CustomActions[i] as Action<T>)(instance);
                    }
                }
            }
            index++;
            return instance;
        }

        private T CreateBaseTypes()
        {
            return baseFactory.Generate();
        }

        private T CreateComplexType()
        {
            T instance;
            var constructorArgs = new ConstructorArguments { Index = 1 };
            if (constructorFunc != null)
            {
                instance = constructorFunc(constructorArgs);
            }
            else
            {
                if (type.IsAbstract || type.IsInterface)
                    throw new InvalidOperationException();

                instance = (T)Activator.CreateInstance(type);
            }
            foreach(var generatorPair in memberGenerators)
            {
                object value;
                ///TODO: need to cache using methodinfo
                if(generatorPair.Key.MemberType == MemberTypes.Property)
                {
                    var propInfo = generatorPair.Key as PropertyInfo;
                    value = (generatorPair.Value as IFactory).Generate();
                    propInfo.SetValue(instance, value, null);
                }
                else
                {
                    var fieldInfo = generatorPair.Key as FieldInfo;
                    value = (generatorPair.Value as IFactory).Generate(); ;
                    fieldInfo.SetValue(instance, value);
                }
            }
            return instance;
        }

        public ICollection<T> GenerateCollection(int numberOfItems)
        {
            IList<T> result = new List<T>();
            for(int i=0; i<numberOfItems; i++)
                result.Add(this.Generate());
            return result;
        }

        private void ConstructMemberGenerators()
        {
            memberGenerators.Clear();
            var enumerableType = typeof(IEnumerable);
            foreach(var memberInfo in type.GetMembers(BindingFlags.Public | BindingFlags.Instance))
            {
                if (memberInfo.MemberType != MemberTypes.Field && memberInfo.MemberType != MemberTypes.Property) continue;
                Type memberType = memberInfo.MemberType == MemberTypes.Property
                                      ? (memberInfo as PropertyInfo).PropertyType
                                      : (memberInfo as FieldInfo).FieldType;

                IFactory factory = null;
                if (memberType.IsCollectionType() && memberType != typeof(string))
                {
                    factory = generalSettings.CollectionGenerator.Generate(memberType);
                }
                if(generatorSettings.MemberFactories.ContainsKey(memberInfo))
                {
                    factory = generatorSettings.MemberFactories[memberInfo];
                }
                else if(generatorSettings.Factories.ContainsKey(memberType))
                {
                    factory = generatorSettings.Factories[memberType];
                }
                else if(generalSettings.Factories != null && generalSettings.Factories.ContainsKey(memberType))
                {
                    factory = generalSettings.Factories[memberType];
                }
                else if(generalSettings.LazyFactories != null && generalSettings.LazyFactories.ContainsKey(memberType))
                {
                    factory = generalSettings.LazyFactories[memberType]();
                }
                else
                {
                    if (generatorSettings.MaxDepth <= currentDepth) continue;
                    var childParams = new ObjectGeneratorParams{ CurrentDepth = currentDepth + 1, GeneralSettings = generalSettings };
                    var genericType = typeof(ObjectGenerator<>).MakeGenericType(memberType);
                    var newGenerator = Activator.CreateInstance(genericType,childParams);
                    //apply parent generator settings 
                    if(generatorSettings.OverrideChildSettings)
                        ((IHaveGeneratorSettings)newGenerator).Settings.Apply(generatorSettings);
                    factory = newGenerator as IFactory;
                }

                var needMemberInfo = factory as INeedMemberInfo;
                if(needMemberInfo != null)
                {
                    needMemberInfo.MemberInfo = memberInfo;
                }

                memberGenerators.Add(memberInfo, factory);
            }
        }

        public IGeneratorSettings Settings
        {
            get { return generatorSettings; }
        }

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }

    public class ObjectGeneratorParams
    {
        public int CurrentDepth { get; set; }

        public ISettings GeneralSettings { get; set; } 
    }
}
