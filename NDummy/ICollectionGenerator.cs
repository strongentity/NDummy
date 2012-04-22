namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines collection creation mechanism
    /// </summary>
    public interface ICollectionGenerator
    {
        void Register(Type type, CollectionGeneratorCreator handler);

        IFactory Generate(Type collectionType);
    }

    public delegate IFactory CollectionGeneratorCreator(Type[] targetType, ISettings settings); 
}
