using System;

namespace TrickyCSharp.Pitfalls
{
    //if (i >= array.Length) throw new ArgumentOutOfRangeException();
    public static class BoundsCheck
    {
        public static double SumSqrt(double[] array)
        {
            double result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                //compiler is smart and will not include bound check in this situation
                result += Math.Sqrt(array[i]);
            }

            return result;
        }

        public static void Test1(char[] array)
        {
            //compiler will include boundsCheck every time
            
            //cmb 
            //jbe
            array[0] = 'F';
            //cmb 
            //jbe
            array[1] = 'A';
            //cmb 
            //jbe
            array[2] = 'L';
            //cmb 
            //jbe
            array[3] = 'S';
            //cmb 
            //jbe
            array[4] = 'E';
            //cmb 
            //jbe
            array[5] = '!';
        }

        public static void Test2(char[] array)
        {
            //compile will include boundsCheck once
            //cmb ...
            //jbe ...
            array[5] = '!';
            array[0] = 'F';
            array[1] = 'A';
            array[2] = 'L';
            array[3] = 'S'; 
            array[4] = 'E';
        }

        public static void Test3WithoutBoundCheck(char[] array)
        {
            //if using cast to uint - no bound check at all
            if ((uint)array.Length > 5)
            {
                array[5] = '!';
                array[0] = 'F';
                array[1] = 'A';
                array[2] = 'L';
                array[3] = 'S'; 
                array[4] = 'E';
            }
        }
    }
}