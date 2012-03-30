﻿namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Provides a mechanism to generate T
    /// </summary>
    /// <typeparam name="T">Type to generate</typeparam>
    public interface IFactory<out T> 
    {
        /// <summary>
        /// Generates instance of T.
        /// </summary>
        /// <returns>New instance of T</returns>
        T Generate();
    }
}
