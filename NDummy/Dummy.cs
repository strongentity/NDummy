namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Dummy
    {
        public static IGenerator<T> For<T>()
        {
            return null;
        }

        public static IGeneratorSettings Settings { get; set; }
    }
}
