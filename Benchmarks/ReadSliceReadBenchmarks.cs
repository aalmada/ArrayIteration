using System;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class ReadSliceReadBenchmarks : ReadBenchmarksBase
    {

        [Benchmark(Baseline = true)]
        public int Full_ForEach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int Slice_For()
            => Sum.For(_array, 0, _array.Length);

        [Benchmark]
        public int Slice_Foreach()
            => Sum.ForEach(_array.AsSpan());

    }
}