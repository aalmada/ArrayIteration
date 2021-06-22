using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class ListBenchmarks : BenchmarksBase
    {

        [Benchmark(Baseline = true)]
        public int List_For()
            => Sum.For(_list);

        [Benchmark]
        public int List_ForEach()
            => Sum.ForEach(_list);

#if NET5_0_OR_GREATER
        [Benchmark]
        public int List_AsSpan()
            => Sum.Simd(CollectionsMarshal.AsSpan(_list));
#endif

    }
}