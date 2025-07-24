using BenchmarkDotNet.Running;

namespace StringBuilder;

public static class Program
{
    public static void Main()
    {
        //* StringBuilder is mutable buffer, it does not allocate new memory for each string, this makes it more efficient for large data operations.
        //* String concatenation {result += i;} creates a new string in memory each time it is run, for 1M iterations there will be 1M new strings created.
        //* String interpolation {result += $"{i}"}, calls ToString() on each iteration and then concatenates, which is also slow.
        //* String.Concat method is similar to string concatenation, but it is optimized for concatenating

        //! String concatenation, interpolation and Concat methods are similar enough in performance that the choice between them is more about readability.
        //! StringBuilder is by far the best choice when dealing with large amount of string operations, especially in loops.


        //? Prefer StringBuilder for loops and large data operations.
        //? Prefer string concatenation or interpolation for small, readable operations.

        BenchmarkRunner.Run<Benchmark>();
    }
}
