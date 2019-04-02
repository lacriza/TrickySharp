using System;
using System.Collections.Generic;
using System.Linq;
using TrickyCSharp.OptimizeAllocation;

namespace TrickyCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            PreferSpanApi.AllocationSubstring("Ada 3.14 1410 03/28/2019");
            PreferSpanApi.SliceWithoutAllocation("Ada 3.14 1410 03/28/2019");
 
            AllocationTempArray.CreateBuffer(512);
            AllocationTempArray.CreateBufferOnStack(1028);
            
            IEnumerable<String> str = new List<string>();
            str.Count();
            
            Console.ReadKey();
        }
    }
    
}