namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IArrayFactory<T>:IFactory
    {
        /// <summary>
        /// Generates array of T
        /// </summary>
        /// <returns>Array of T</returns>
        Array Generate();
    }
   
}
