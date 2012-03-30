namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FuncAdapter<T> : IFactory<T>
    {
        private readonly Func<T> func;

        public FuncAdapter(Func<T> func)
        {
            this.func = func;
        }

        public T Generate()
        {
            return func();
        }
    }
}
