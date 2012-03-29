using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDummy.Factories;

namespace NDummy.Tests.Utilities
{
    public static class CommonExtensions
    {
        public static bool AreEqual(this double value, double valueToCompare)
        {
            return Math.Abs(value - valueToCompare) <= 0.000001;
        }
    }
}
