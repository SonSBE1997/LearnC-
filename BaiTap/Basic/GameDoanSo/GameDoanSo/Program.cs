using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDoanSo {
    class Program {
        static void Game() {
            Console.OutputEncoding = Encoding.UTF8;
            Random ran = new Random();
            int soCanDoan = ran.Next(501);
            int nguoiDoan;
            int soLanDoan = 10;
            Console.WriteLine("Số ngẫu nhiên đã được sinh ra trong [0-500]!");
            while (true) {
                Console.WriteLine("Mời bạn đoán số, bạn còn {0} lần đoán", soLanDoan);
                nguoiDoan = int.Parse(Console.ReadLine());
                soLanDoan--;
                if (nguoiDoan == soCanDoan) {
                    Console.WriteLine("SUCCESSFUL!");
                    break;
                }
                if (nguoiDoan < soCanDoan) {
                    Console.WriteLine("Số cần đoán lớn hơn {0}", nguoiDoan);
                } else {
                    Console.WriteLine("Số cần đoán nhỏ hơn {0}", nguoiDoan);
                }
                if (soLanDoan == 0) {
                    Console.WriteLine("Game Over! Số cần đoán là {0}", soCanDoan);
                    Console.ReadLine();
                    break;
                }
            }
        }

        static void Main(string[] args) {
            while (true) {
                Game();
                Console.WriteLine("Bạn có muốn chơi nữa không!(Yes/No)");
                string next = Console.ReadLine();
                if (next.ToLower().Equals("No") == true) {
                    break;
                }
            }
        }
    }
}
