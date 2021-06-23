using System;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public abstract class WriteBenchmarksBase
    {
        const int Seed = 42;
        const int MaxValue = 100;
        protected int[] _source;
        protected int[] _destination;

        [Params(1_000_000)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _source = Utils.AllocateArray<int>(Count);
            _destination = Utils.AllocateArray<int>(Count);

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var random = new Random(Seed);
            var temp = _source;
            for (var index = 0; index < temp.Length; index++)
                temp[index] = random.Next(MaxValue);
        }
    }
}