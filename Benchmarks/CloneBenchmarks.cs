using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class CloneBenchmarks : WriteBenchmarksBase
    {
        [Benchmark(Baseline = true)]
        public int[] Array_Clone()
            => (int[])_source.Clone();

        [Benchmark]
        public int[] Array_Copy()
            => Clone.Array_Copy(_source);

        [Benchmark]
        public int[] Span_CopyTo()
            => Clone.Span_CopyTo<int>(_source);
        
        [Benchmark]
        public int[] Linq()
            => _source.ToArray();

        [Benchmark]
        public int[] For()
            => Clone.For(_source);

        [Benchmark]
        public int[] For_Bounds()
            => Clone.For_Bounds(_source);
    }
}