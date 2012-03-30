namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Defines the generator specification
    /// </summary>
    public interface IGeneratorSpec
    {
        /// <summary>
        /// Applies the specification to generator settings.
        /// </summary>
        /// <param name="settings">The generator settings.</param>
        void Apply(IGeneratorSettings settings);
    }
}
