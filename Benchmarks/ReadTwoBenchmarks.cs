using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace ArrayIteration
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ReadTwoBenchmarks : ReadBenchmarksBase
    {
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Sum")]
        public int ForEach()
            => Sum.ForEach(_array);
        
        [Benchmark]
        [BenchmarkCategory("Sum")]
        public int Sum2()
            => Sum.Sum2(_array);
        
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Sum_Predicate")]
        public int Predicate()
            => Sum.Predicate(_array, item => (item & 0x01) == 0);
        
        [Benchmark]
        [BenchmarkCategory("Sum_Predicate")]
        public int Predicate2()
            => Sum.Predicate2(_array, item => (item & 0x01) == 0);
    }
}