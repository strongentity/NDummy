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
            return new ObjectGenerator<T>(new ObjectGeneratorParams
                {
                    CurrentDepth = 1,
                    GeneralSettings = Settings
                });
        }

        public static ISettings Settings { get; private set; }
    }
}
