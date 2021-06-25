using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public abstract class ReadBenchmarksBase
    {
        const int Seed = 42;
        const int MaxValue = 100;
        protected int[] _array;
        protected ArraySegment<int> _arraySegment;
        protected List<int> _list;

        [Params(1_000_000)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _array = Utils.AllocateArray<int>(Count);

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var random = new Random(Seed);
            var temp = _array;
            for (var index = 0; index < temp.Length; index++)
                temp[index] = random.Next(MaxValue);

            _arraySegment = new ArraySegment<int>(_array);
            _list = new List<int>(_array);
        }
    }
}