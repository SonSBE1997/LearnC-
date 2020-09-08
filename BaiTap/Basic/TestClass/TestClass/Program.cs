using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClass {
    class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            SinhVien sv1 = new SinhVien();
            sv1.ma = 1;
            sv1.ten = "Vũ Quang Hiếu";
            Console.WriteLine(sv1);

            KeThua kt = new KeThua();
            kt.a();
            Console.ReadLine();
        }
    }
}
