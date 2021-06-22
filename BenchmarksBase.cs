﻿using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace ArrayIteration
{
    public abstract class BenchmarksBase
    {
        const int Seed = 42;
        const int MaxValue = 100;
        protected int[] _array;
        protected List<int> _list;

        [Params(1_000_000)]
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public int Count { get; set; }

        [GlobalSetup]
        public void GlobalSetup()
        {
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            _array = new int[Count];

            // ReSharper disable once HeapView.ObjectAllocation.Evident
            var random = new Random(Seed);
            var temp = _array;
            for (var index = 0; index < temp.Length; index++)
                temp[index] = random.Next(MaxValue);

            _list = new List<int>(_array);
        }
    }
}