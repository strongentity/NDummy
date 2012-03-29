namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IFactory<out T> 
    {
        T Generate();
    }
}
