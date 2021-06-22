using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class SimdBenchmarks : BenchmarksBase
    {

        [Benchmark(Baseline = true)]
        public int ForEach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int Simd()
            => Sum.Simd(_array);
        
    }
}