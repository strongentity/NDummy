using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDummy.Factories;

namespace NDummy.Tests.Utilities
{
    public static class CommonExtensions
    {
        public static bool AreEqual<T>(this T value, T valueToCompare)
        {
            var _value =Convert.ToDouble(value);
            var _valueToCompare = Convert.ToDouble(valueToCompare);
            return Math.Abs(_value - _valueToCompare) <= 0.000001;
        }
    }
}
