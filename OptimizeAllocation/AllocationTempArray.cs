using System;
using System.Buffers;

namespace TrickyCSharp.OptimizeAllocation
{
    public static class AllocationTempArray
    {
        
        // Allocation on HEAP
        public static char[] CreateBuffer(uint count)
        {
            return new char[count];
        }
        
        //Allocation on STACK
        public static void CreateBufferOnStack(int count)
        {
            char[] pool = null;
            Span<char> span = count <= 512
                ? stackalloc char[512]
                : pool = ArrayPool<char>.Shared.Rent(count);
            if (pool != null)
            {
                ArrayPool<char>.Shared.Return(pool);
            }
        }
        
        //Allocation array - most popular pattern - mixed on heap and stack
        public static void CreateBufferOnStackOrHeapDependOnSize(int size)
        {
            Span<char> spanBuffer = size <= 512 ? stackalloc char[512] : new char[size];
        }
    }
}