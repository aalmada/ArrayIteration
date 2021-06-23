using System;

namespace ArrayIteration
{
    static class Clone
    {
        public static T[] Array_Copy<T>(T[] source)
        {
            var result = Utils.AllocateArray<T>(source.Length);
            Array.Copy(source, 0, result, 0, source.Length);
            return result;
        }
        
        public static T[] Span_CopyTo<T>(ReadOnlySpan<T> source)
        {
            var result = Utils.AllocateArray<T>(source.Length);
            source.CopyTo(result);
            return result;
        }
                
        public static T[] For<T>(T[] source)
        {
            var result = Utils.AllocateArray<T>(source.Length);
            for (var index = 0; index < source.Length; index++)
                result[index] = source[index];
            return result;
        }
        
        public static T[] For_Bounds<T>(T[] source)
        {
            var result = Utils.AllocateArray<T>(source.Length);
            for (var index = 0; index < source.Length && index < result.Length; index++)
                result[index] = source[index];
            return result;
        }
    }
}