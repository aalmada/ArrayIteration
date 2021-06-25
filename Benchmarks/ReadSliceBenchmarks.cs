using System;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class ReadSliceBenchmarks : ReadBenchmarksBase
    {

        [Benchmark(Baseline = true)]
        public int Array_ForEach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int Array_For()
            => Sum.For(_array, 0, _array.Length);

        [Benchmark]
        public int Span_Foreach()
            => Sum.ForEach(_array.AsSpan());
        
        [Benchmark]
        public int ArraySegment_For()
            => Sum.For(_arraySegment);
        
        [Benchmark]
        public int ArraySegment_ForEach()
            => Sum.ForEach(_arraySegment);
        
        [Benchmark]
        public int ArraySegment_ArrayFor()
            => Sum.For(_arraySegment.Array, _arraySegment.Offset, _arraySegment.Count);
        
        [Benchmark]
        public int ArraySegment_SpanForEach()
            => Sum.ForEach(_arraySegment.AsSpan());

    }
}