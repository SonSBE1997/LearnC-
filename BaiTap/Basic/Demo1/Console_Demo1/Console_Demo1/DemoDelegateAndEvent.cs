using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_event
{
    internal delegate int Calculate(int a, int b);
    class DemoDelegateAndEvent
    {
        //static void Main(string[] args)
        //{
        //    int a = 15;
        //    int b = 10;
        //    TestDelegate test = new TestDelegate();

        //    ////Khởi tạo delegate
        //    //Calculate cal = new Calculate(test.Addition);
        //    Calculate cal = test.Addition;

        //    ////Thực thi delegate
        //    //Console.WriteLine("{0} + {1} =  {2}", a, b, cal.Invoke(a, b));
        //    Console.WriteLine("{0} + {1} =  {2}", a, b, cal(a,b));

        //    Console.ReadLine();
        //}
    }
}
