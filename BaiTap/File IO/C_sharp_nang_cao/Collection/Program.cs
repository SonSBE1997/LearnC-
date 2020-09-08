using System;
using System.Collections.Generic;

namespace Collection
{
    class MyGenerics<T>
    {
        public void Swap(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //List<int> arr = new List<int>();
            //arr.Add(5);
            //arr.Add(6);

            int a = 10;
            int b = 12;
            MyGenerics<int> gen = new MyGenerics<int>();
            Console.WriteLine("a = {0} va b = {1}", a, b);
            gen.Swap(ref a, ref b);
            Console.WriteLine("a = {0} va b = {1}", a, b);
            Console.Read();
        }
    }
}
