using System;

namespace TrickyCSharp.OptimizeAllocation
{
    public static class PreferSpanApi
    {
        //Allocations on heap 189
        public static void AllocationSubstring(string testString)
        {
            var name = testString.Substring(0, 3);
            var pi = float.Parse(testString.Substring(4, 4));
            var num = uint.Parse(testString.Substring(9, 4));
            var date = DateTime.Parse(testString.Substring(14, 10));
        }


        //Allocations on heap 0 
        public static void SliceWithoutAllocation(string testString)
        {
            var spanStr = testString.AsSpan();
            var name = spanStr.Slice(0, 3);
            var pi = float.Parse(spanStr.Slice(4, 4));
            var num = uint.Parse(spanStr.Slice(9, 4));
            var date = DateTime.Parse(spanStr.Slice(14, 10));
        }
    }
}