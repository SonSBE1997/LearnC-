using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yield
{
    class DemoYield
    {

        public static IEnumerable<int> DemoArray(int number)
        {
            int[] a = new int[number];
            for (int i = 0; i < number; i++)
            {
                a[i] = i;
            }
            return a;
        }


        public static IEnumerable<int> DemoArray2(int number)
        {
            int[] a = new int[number];
            for (int i = 0; i < number; i++)
            {
                if (i == 5) yield break;
                yield return a[i] = i;
            }
        }
        //static void Main(string[] args)
        //{
        //    Console.WriteLine("----BT------");
        //    foreach (var item in DemoArray(10))
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.WriteLine("----Yield------");
        //    foreach (var item in DemoArray2(10))
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.Read();
        //}
    }
}
    