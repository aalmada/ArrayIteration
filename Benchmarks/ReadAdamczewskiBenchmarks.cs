using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;

namespace ArrayIteration
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    public class ReadAdamczewskiBenchmarks : ReadBenchmarksBase
    {
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("Sum")]
        public int ForEach()
            => Sum.ForEach(_array);
        
        [Benchmark]
        [BenchmarkCategory("Sum")]
        public int ForAdamczewski()
            => Sum.SumAdamczewski(_array);
        
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("SumPredicate")]
        public int SumPredicate()
            => Sum.SumPredicate(_array, item => item.IsEven());
        
        [Benchmark]
        [BenchmarkCategory("SumPredicate")]
        public int SumPredicateNoBranches()
            => Sum.SumPredicateNoBranches(_array, item => item.IsEven());
        
        [Benchmark]
        [BenchmarkCategory("SumPredicate")]
        public int SumPredicateAdamczewski()
            => Sum.SumPredicateAdamczewski(_array, item => item.IsEven());
    }
}