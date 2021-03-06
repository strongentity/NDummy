﻿namespace NDummy.Factories
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CollectionGenerator : ICollectionGenerator
    {
        private readonly ISettings settings;

        private readonly IDictionary<Type, CollectionGeneratorCreator> creators;

        public CollectionGenerator(ISettings settings)
        {
            this.settings = settings;
            creators = new Dictionary<Type, CollectionGeneratorCreator>();
        }

        public void Register(Type type, CollectionGeneratorCreator handler)
        {
            if (!creators.ContainsKey(type))
                creators.Add(type, handler);
            else 
                creators[type] = handler;
        }

        public IFactory Generate(Type collectionType)
        {
            Type typeDefinition = null;
            if(collectionType.IsArray)
            {
                return this.InternalGenerateFactory(collectionType, null, collectionType.GetGenericArguments());
            }
            else if(collectionType.IsGenericType)
            {
                var genericArgs = collectionType.GetGenericArguments();
                typeDefinition = collectionType.GetGenericTypeDefinition();
                return this.InternalGenerateFactory(collectionType, null, genericArgs);
            }
            else
            {
                return this.InternalGenerateFactory(collectionType, null, null);
            }
        }

        private IFactory InternalGenerateFactory(Type collectionType, Type typeDefinition, Type[] genericArgs)
        {
            if(collectionType.IsArray)
            {
                return creators[typeof(Array)].Invoke(new Type[]{collectionType}, settings);
            }
            if(collectionType.IsGenericType)
            {
                if(creators.ContainsKey(typeDefinition))
                {
                    return creators[typeDefinition].Invoke(genericArgs, settings);
                }
                if (typeof(IList<>).IsAssignableFrom(typeDefinition))
                {
                    return this.creators[typeof(IList<>)].Invoke(genericArgs, this.settings);
                }
                if (typeof(IDictionary<,>).IsAssignableFrom(typeDefinition))
                {
                    return this.creators[typeof(IDictionary<,>)].Invoke(genericArgs, this.settings);
                }
                if (typeof(ICollection<>).IsAssignableFrom(typeDefinition))
                {
                    return this.creators[typeof(ICollection<>)].Invoke(genericArgs, this.settings);
                }
                if (typeof(IEnumerable<>).IsAssignableFrom(typeDefinition))
                {
                    return this.creators[typeof(IEnumerable<>)].Invoke(genericArgs, this.settings);
                }
            }
            if (typeof(IList).IsAssignableFrom(collectionType))
            {
                return creators[typeof(IList)].Invoke(null, settings);
            }
            else if (typeof(IDictionary).IsAssignableFrom(collectionType))
            {
                return creators[typeof(IDictionary)].Invoke(null, settings);
            }
            else if (typeof(ICollection).IsAssignableFrom(collectionType))
            {
                return creators[typeof(ICollection)].Invoke(null, settings);
            }
            else if(typeof(IEnumerable).IsAssignableFrom(collectionType))
            {
                return creators[typeof(IEnumerable)].Invoke(null, settings);
            }
            return null;
        }
    }
}
