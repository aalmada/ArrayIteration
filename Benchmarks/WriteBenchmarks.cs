using System;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public class WriteBenchmarks : WriteBenchmarksBase
    {
        [Benchmark(Baseline = true)]
        public void Array_Copy()
            => Array.Copy(_source, 0, _destination, 0, _source.Length);

        [Benchmark]
        public void Span_CopyTo()
            => _source.AsSpan().CopyTo(_destination);
        
        [Benchmark]
        public void Array_For()
            => Copy.Array_For(_source, 0, _destination, 0, _source.Length);
        
        [Benchmark]
        public void Span_For()
            => Copy.Span_For<int>(_source, _destination);
    }
}