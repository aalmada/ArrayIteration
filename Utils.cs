using System;
using System.Runtime.CompilerServices;

namespace ArrayIteration
{
    static class Utils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T[] AllocateArray<T>(int length)
#if NET5_0_OR_GREATER        
            => GC.AllocateUninitializedArray<T>(length);
#else
            => new T[source.Length];
#endif
    }
}