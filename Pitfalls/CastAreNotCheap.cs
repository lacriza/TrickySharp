using System.Collections;
using System.Collections.Generic;

namespace TrickyCSharp.Pitfalls
{
    public static class CastAreNotCheap
    {
        public static void BenchmarkCastingResult()
        {
            object value = new List<string>();

            //0.3 ns cast to actual type
            var t1 = (List<string>) value;
            
            //2.0 ns
            var t2 = (ICollection<string>) value;
            
            //3.0 ns
            var t3 = (IList) value;
            
            //30.5 ns
            var t4 = (IEnumerable<string>) value;
        }

        /* IEnumerable & IReadOnlyCollection - are covariant interfaces 
         */
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            //fastPath:
            //~3ns   
            if (source is ICollection<TSource> sources)
                return sources.Count;
            //~3ns
            if (source is IIListProvider<TSource> ilistProvider)
                return ilistProvider.GetCount(false);
            //~3ns
            if (source is ICollection collection)
                return collection.Count;
            //~30ns !!!!!
            if (source is IReadOnlyCollection<TSource> rocollection)
                return rocollection.Count;


            int num = 0;
            using (IEnumerator<TSource> enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    checked
                    {
                        ++num;
                    }
            }

            return num;
        }
    }

    internal interface IIListProvider<TElement> : IEnumerable<TElement>, IEnumerable
    {
        TElement[] ToArray();

        List<TElement> ToList();

        int GetCount(bool onlyIfCheap);
    }
}