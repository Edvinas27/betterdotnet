using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using System.Text;

namespace StringBuilder
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class Benchmark
    {
        public const int Count = 100_000;
        [Benchmark]
        public string StringBuilderAppend()
        {
            var sb = new System.Text.StringBuilder();

            for (int i = 0; i < Count; i++)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }

        [Benchmark]
        public string StringConcatenation()
        {
            string result = string.Empty;

            for (int i = 0; i < Count; i++)
            {
                result += i;
            }

            return result;
        }

        [Benchmark]
        public string StringInterpolation()
        {
            string result = string.Empty;

            for (int i = 0; i < Count; i++)
            {
                result += $"{i}";
            }

            return result;
        }

        [Benchmark]
        public string StringConcatMethod()
        {
            string result = string.Empty;
            for (int i = 0; i < Count; i++)
            {
                result = string.Concat(result, i);
            }

            return result;
        }
    }
}