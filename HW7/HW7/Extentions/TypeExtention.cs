using System;
using System.Collections.Generic;

namespace HW7.Extentions
{
    public static class TypeExtention
    {
        private static readonly HashSet<Type> IntegerTypes = new()
        {
            typeof(int),
            typeof(uint),
            typeof(byte),
            typeof(sbyte),
            typeof(long),
            typeof(ulong),
            typeof(short),
            typeof(ushort)
        };


        public static bool IsIntegerType(this Type type)
        {
            return IntegerTypes.Contains(type) ||
                   IntegerTypes.Contains(Nullable.GetUnderlyingType(type));
        }
    }
}