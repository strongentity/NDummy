namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

<<<<<<< HEAD

    /// <summary>
    /// Provides methods for generating array of T 
    /// </summary>
    /// <typeparam name="T">Type to be generated</typeparam>
    public interface IArrayFactory<T> : IFactory
=======
    public interface IArrayFactory<T>
>>>>>>> remotes/origin/feature_uniquefactory
    {
        /// <summary>
        /// Generates array of T
        /// </summary>
        /// <returns>Array of T</returns>
        Array Generate();
    }
   
}
