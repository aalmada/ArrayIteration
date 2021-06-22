﻿using System.Linq;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class Benchmarks : BenchmarksBase
    {
        [Benchmark(Baseline = true)]
        public int For()
            => Sum.For(_array);
        
        [Benchmark]
        public int ForEach()
            => Sum.ForEach(_array);

        [Benchmark]
        public int Linq()
            => _array.Sum();

    }
}