using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace BetterDictionary
{
    public static class DictionaryExtension
    {
        public static TValue? GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue? value)
        where TKey : notnull
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrAddDefault(dictionary, key, out bool exists);

            if (exists)
            {
                return val;
            }

            val = value;
            return value;

        }

        public static bool TryUpdate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue? value)
        where TKey : notnull
        {
            ref var val = ref CollectionsMarshal.GetValueRefOrNullRef(dictionary, key);

            if (Unsafe.IsNullRef(ref val))
            {
                return false;
            }

            val = value;
            return true;

        }
    }
}