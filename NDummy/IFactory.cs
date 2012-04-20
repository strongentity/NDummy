namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IFactory
    {
        object Generate();
    }

    /// <summary>
    /// Provides a mechanism to generate T
    /// </summary>
    /// <typeparam name="T">Type to generate</typeparam>
    public interface IFactory<out T> : IFactory
    {
        /// <summary>
        /// Generates instance of T.
        /// </summary>
        /// <returns>New instance of T</returns>
        T Generate();
    }

    
}
