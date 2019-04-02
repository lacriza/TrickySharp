using System;
using System.Buffers;

namespace TrickyCSharp.OptimizeAllocation
{
    public class AllocationTempArray
    {
        
        // Allocation on HEAP
        public char[] CreateBuffer(uint count)
        {
            return new char[count];
        }
        
        //Allocation on STACK
        public void CreateBufferOnStack(int count)
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
    }
}