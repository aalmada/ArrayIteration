using System;

namespace ArrayIteration
{
    static class Copy
    {
        public static void Array_For<T>(T[] source, int sourceOffset, T[] destination, int destinationOffset, int count)
        {
            for (var index = 0; index < count; index++)
                destination[index + destinationOffset] = source[index + sourceOffset];
        }

        public static void Span_For<T>(ReadOnlySpan<T> source, Span<T> destination)
        {
            for (var index = 0; index < source.Length; index++)
                destination[index] = source[index];
        }

    }
}