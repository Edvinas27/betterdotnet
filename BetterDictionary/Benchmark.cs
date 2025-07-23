using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BetterDictionary
{
    public class Benchmark
    {
        public const int _i = 30_000_000;
        public static void BenchmarkGetOrAdd()
        {
            var dictionary = new Dictionary<int, string>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < _i; i++)
            {
                dictionary.GetOrAdd(i, i.ToString());
            }
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"GetOrAdd took {elapsed} ms for {_i} items.");
        }

        public static void BenchmarkDefault()
        {
            var dictionary = new Dictionary<int, string>();

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < _i; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary[i] = i.ToString();
                }
            }
            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            Console.WriteLine($"Default took {elapsed} ms for {_i} items.");
        }
    }
}