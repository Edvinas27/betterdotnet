using System.Text.Json;
using BenchmarkDotNet.Running;

namespace BetterDictionary;

public static class Program
{
    public static void Main()
    {
        //* This is problematic, because we calculate hash twice, once for ContainsKey and once for [123] = "123".
        // if (!dictionary.ContainsKey(123))
        // {
        //     dictionary[123] = "123";
        // }
        //* Problem is solved with DicionaryExtension by calculating hash once.
        //* Difference will not be noticeable for small dictionaries, but for large dictionaries it will be significant if performance is important.
        //! Bypasses security checks.

        BenchmarkRunner.Run<Benchmark>();
    }
}
