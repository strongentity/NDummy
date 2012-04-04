namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class Dummy
    {
        static Dummy()
        {
            Settings = new DefaultSettings();
        }

        public static IGenerator<T> For<T>()
        {
            return null;
        }

        public static ISettings Settings { get; private set; }
    }
}
