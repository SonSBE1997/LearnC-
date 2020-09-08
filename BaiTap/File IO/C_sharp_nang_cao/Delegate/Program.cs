using System;
using System.Text;

namespace Delegate
{
    delegate void ChangeNumber(int number);
    class Program
    {
        static int number = 3;

        static void Add(int changeNumber)
        {
            number += changeNumber;
        }

        static void Mul(int changeNumber)
        {
            number *= changeNumber;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ChangeNumber cn1 = Add;
            cn1(3);
            Console.WriteLine("Số sau khi cộng thêm:" + number);
            ChangeNumber cn2 = Mul;
            cn2(4);
            Console.WriteLine("Số sau khi nhân thêm:" + number);
            ChangeNumber cn3 = cn2 + cn1;
            cn3(2);
            Console.WriteLine("After:" + number);
            Console.Read();
        }
    }
}
