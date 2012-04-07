namespace NDummy.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class TypeUtilities
    {
        private static readonly HashSet<Type> baseTypes;

        static TypeUtilities()
        {
            baseTypes = new HashSet<Type>
                {
                    typeof(bool),
                    typeof(byte),
                    typeof(sbyte),
                    typeof(short),
                    typeof(ushort),
                    typeof(int),
                    typeof(uint),
                    typeof(long),
                    typeof(ulong),
                    typeof(IntPtr),
                    typeof(UIntPtr),
                    typeof(char),
                    typeof(double),
                    typeof(float),
                    typeof(Guid),
                    typeof(string),
                    typeof(bool?),
                    typeof(byte?),
                    typeof(sbyte?),
                    typeof(short?),
                    typeof(ushort?),
                    typeof(int?),
                    typeof(uint?),
                    typeof(long?),
                    typeof(ulong?),
                    typeof(IntPtr?),
                    typeof(UIntPtr?),
                    typeof(char?),
                    typeof(double?),
                    typeof(float?),
                    typeof(Guid?)
                };
        }

        public static bool IsBaseType(this Type type)
        {
            return baseTypes.Contains(type);
        }
    }
}
