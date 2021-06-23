using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class ReadForReadBenchmarks : ReadBenchmarksBase
    {
        [Benchmark(Baseline = true)]
        public int Foreach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int For()
            => Sum.For(_array);

        [Benchmark]
        public int ForOptimized()
            => Sum.ForOptimized(_array);
        
    }
}