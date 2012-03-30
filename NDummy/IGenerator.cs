﻿namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenerator<T> : IFactory<T>
    {
        /// <summary>
        /// Defines how to construct T.
        /// </summary>
        /// <param name="func">The func.</param>
        /// <returns></returns>
        IGenerator<T> ConstructWith(Func<ConstructorArguments, T> func);

        /// <summary>
        /// Creates specs for generator.
        /// </summary>
        /// <param name="specs">The specs.</param>
        /// <returns>The current generator instance</returns>
        IGenerator<T> Configure(params IGeneratorSpec[] specs);

        /// <summary>
        /// Generates the collection of T.
        /// </summary>
        /// <param name="numberOfItems">The number of items.</param>
        /// <returns>Collection of T</returns>
        ICollection<T> GenerateCollection(int numberOfItems);
    }

    public class ConstructorArguments
    {
        public int Index { get; set; }
    }
}
