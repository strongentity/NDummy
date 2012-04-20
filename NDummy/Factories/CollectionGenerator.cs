namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CollectionGenerator 
    {
        private ISettings settings;

        public CollectionGenerator(ISettings settings)
        {
            this.settings = settings;
        }
    }
}
