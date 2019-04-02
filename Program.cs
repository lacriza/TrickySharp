using System;
using TrickyCSharp.OptimizeAllocation;

namespace TrickyCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PreferSpanApi.AllocationSubstring("Ada 3.14 1410 03/28/2019");
            PreferSpanApi.SliceWithoutAllocation("Ada 3.14 1410 03/28/2019");
 
            AllocationTempArray alloc = new AllocationTempArray();
            alloc.CreateBuffer(512);
            alloc.CreateBufferOnStack(1028);
            
            Console.ReadKey();
        }
    }
}