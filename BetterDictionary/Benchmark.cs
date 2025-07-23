using System.Collections.Concurrent;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BetterDictionary
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmark
    {
        public const int Count = 30_000_000;

        [Benchmark]
        public void DictionaryExtension()
        {
            var dictionary = new Dictionary<int, string>();

            for (int i = 0; i < Count; i++)
            {
                dictionary.GetOrAdd(i, i.ToString());
            }
        }

        [Benchmark]
        public void DictionaryContainsKey()
        {
            var dictionary = new Dictionary<int, string>();

            for (int i = 0; i < Count; i++)
            {
                if (!dictionary.ContainsKey(i))
                {
                    dictionary[i] = i.ToString();
                }
            }
        }

        [Benchmark]
        public void DictionaryTryAdd()
        {
            var dictionary = new Dictionary<int, string>();

            for (int i = 0; i < Count; i++)
            {
                if (!dictionary.TryAdd(i, i.ToString()))
                {
                    dictionary[i] = i.ToString();
                }
            }
        }

        [Benchmark]
        public void ConcurrentDictionaryGetOrAdd()
        {
            var dictionary = new ConcurrentDictionary<int, string>();

            for (int i = 0; i < Count; i++)
            {
                dictionary.GetOrAdd(i, i.ToString());
            }
        }
    }
}