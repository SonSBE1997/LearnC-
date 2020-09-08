using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegate_and_event
{
    class TestDelegate
    {
        public int Addition(int a,int b)
        {
            return a + b;
        }

        public int Subtraction(int a, int b)
        {
            return a - b;
        }

        public void SayHello(string s)
        {
            Console.WriteLine("Hello "+s);
        }
    }
}
