using System;
using System.Threading;

namespace ThreadTest
{
    class Program
    {


        static void A()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            }
            Console.WriteLine("A counting done.");
        }

        static void B()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            }
            Console.WriteLine("B counting done.");
        }
        static void Main(string[] args)
        {
            //ThreadStart is delegate
            ThreadStart ts1 = A;
            ThreadStart ts2 = B;
            Thread t1 = new Thread(ts1);
            Thread t2 = new Thread(ts2);

            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();

            Console.WriteLine("A and B counting done!");

            //dùng từ khoá lock để đồng bộ tiểu trình
            Console.Read();
        }
    }
}
