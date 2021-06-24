using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class ReadSimdBenchmarks : ReadBenchmarksBase
    {

        [Benchmark(Baseline = true)]
        public int ForEach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int Simd()
            => Sum.Simd(_array);
        
    }
}