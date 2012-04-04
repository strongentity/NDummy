namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using NDummy.Utilities;

    public class ObjectGenerator<T> : IGenerator<T>
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
            currentDepth = param.CurrentDepth;
            isBaseType = type.IsBaseType();
            baseFactory = generatorSettings.Factories[type] as IFactory<T>;
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
                    value = generatorPair.Value.GetType().InvokeMember(
                        "Generate", BindingFlags.Public | BindingFlags.InvokeMethod, null, generatorPair.Value, null);
                    propInfo.SetValue(instance, value, null);
                }
                else
                {
                    var fieldInfo = generatorPair.Key as FieldInfo;
                    value = generatorPair.Value.GetType().InvokeMember(
                        "Generate", BindingFlags.Public | BindingFlags.InvokeMethod, null, generatorPair.Value, null);
                    fieldInfo.SetValue(instance, value);
                }
            }
            return instance;
        }

        public ICollection<T> GenerateCollection(int numberOfItems)
        {
            throw new NotImplementedException();
        }

        private void ConstructMemberGenerators()
        {
            foreach(var memberInfo in type.GetMembers(BindingFlags.Public))
            {
                if (memberInfo.MemberType != MemberTypes.Field || memberInfo.MemberType != MemberTypes.Property) continue;
                Type memberType = memberInfo.MemberType == MemberTypes.Property
                                      ? (memberInfo as PropertyInfo).PropertyType
                                      : (memberInfo as FieldInfo).FieldType;
                
                if(generatorSettings.MemberFactories.ContainsKey(memberInfo))
                {
                    memberGenerators.Add(memberInfo, generatorSettings.MemberFactories[memberInfo]);
                }
                else if(generatorSettings.Factories.ContainsKey(memberType))
                {
                    memberGenerators.Add(memberInfo, generatorSettings.Factories[memberType]);
                }
                else if(generalSettings.Factories.ContainsKey(memberType))
                {
                    memberGenerators.Add(memberInfo, generalSettings.Factories[memberType]);        
                }
                else
                {
                    var childParams = new ObjectGeneratorParams{ CurrentDepth = currentDepth + 1, GeneralSettings = generalSettings };
                    var genericType = typeof(ObjectGenerator<>).MakeGenericType(memberType);
                    var newGenerator = Activator.CreateInstance(genericType, BindingFlags.Public, null, childParams);
                    memberGenerators.Add(memberInfo, newGenerator);
                }
            }
        }
    }

    public class ObjectGeneratorParams
    {
        public int CurrentDepth { get; set; }

        public ISettings GeneralSettings { get; set; } 
    }
}
