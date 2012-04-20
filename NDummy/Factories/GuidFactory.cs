namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GuidFactory : IFactory<Guid>
    {
        public Guid Generate()
        {
            return Guid.NewGuid();
        }

        object IFactory.Generate()
        {
            return this.Generate();
        }
    }
}
