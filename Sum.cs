using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;

namespace ArrayIteration
{
    static class Sum
    {

        // ReSharper disable once ParameterTypeCanBeEnumerable.Global
        public static int ForEach(int[] array)
        {
            var sum = 0;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var item in array)
                sum += item;
            return sum;
        }
        
        public static int For(int[] array)
        {
            var sum = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index < array.Length; index++)
                sum += array[index];
            return sum;
        }
        
        public static int ForOptimized(int[] array)
        {
            // ReSharper disable once InlineTemporaryVariable
            var source = array;
            var sum = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index < source.Length; index++)
            {
                var item = source[index];
                sum += item;
            }
            return sum;
        }   
        
        public static int For(int[] source, int offset, int count)
        {
            var sum = 0;
            for (var index = offset; index < offset + count; index++)
                sum += source[index];
            return sum;        
        }  
        
        public static int ForEach(ReadOnlySpan<int> source)
        {
            var sum = 0;
            foreach (var item in source)
                sum += item;
            return sum;
        }
        
        public static int For(ArraySegment<int> source)
        {
            var sum = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;        
        }  
        
        public static int ForEach(ArraySegment<int> source)
        {
            var sum = 0;
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var item in source)
                sum += item;
            return sum;
        }
        
        public static int For(List<int> source)
        {
            var sum = 0;
            // ReSharper disable once ForCanBeConvertedToForeach
            // ReSharper disable once LoopCanBeConvertedToQuery
            for (var index = 0; index < source.Count; index++)
                sum += source[index];
            return sum;
        }

        public static int ForEach(List<int> source)
        {
            var sum = 0;
            // ReSharper disable once ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
            foreach (var item in source)
                sum += item;
            return sum;
        }    
        
        public static int Simd(ReadOnlySpan<int> source)
        {
            var sum = 0;
            if (Vector.IsHardwareAccelerated && source.Length > Vector<int>.Count) // use SIMD
            {
                var vectors = MemoryMarshal.Cast<int, Vector<int>>(source);
                var vectorSum = Vector<int>.Zero;

                foreach (var vector in vectors)
                    vectorSum += vector;

                for (var index = 0; index < Vector<int>.Count; index++)
                    sum += vectorSum[index];
                
                var count = source.Length % Vector<int>.Count;
                source = source.Slice(source.Length - count, count);
            }
            foreach (var item in source)
                sum += item;
            return sum;
        }
    }
}