using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Demo1
{
    class Demo1
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private string myString;

        private static void Swap(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }

        static void Main(string[] args)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            //float a = 05.123f;
            //string a2 = String.Format("{0:C}", a);
            //Console.WriteLine(a2);

            //int a = 6;
            //int b = 7;
            //Swap(ref a, ref b);
            //Console.WriteLine(a);
            //Console.WriteLine(b); 

            //DateTime date = new DateTime(1997, 5, 30);
            //DateTime date = DateTime.Parse("5-30-1997");
            //Console.WriteLine(date.ToString("dd-MM-yyyy"));
            //int y = 10000;
            //Console.WriteLine("{0}",y);
            
            Console.ReadLine();
        }
    }
}
