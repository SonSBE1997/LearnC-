using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchDictionary {
    class Program {

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        public int menu() {
            Console.Clear();
            Console.WriteLine("1. Thêm từ mới");
            Console.WriteLine("2. Sửa từ");
            Console.WriteLine("3. Tra cứu từ");
            Console.WriteLine("4. Xóa từ");
            Console.WriteLine("5. Thoát");
            Console.WriteLine("Mời bạn chọn chức năng:");
            int cn = 0;
            try {
                cn = int.Parse(Console.ReadLine());
            } catch (Exception e) {
                Console.WriteLine("Error :" + e.Message);
                Console.ReadLine();
            }
            return cn;
        }


        public void add() {
            Console.WriteLine("Nhập từ tiếng anh thêm vào:  ");
            string ta = Console.ReadLine();
            if (dic.ContainsKey(ta) == true) {
                Console.WriteLine("Từ {0} đã tồn tại", ta);
            } else {
                Console.WriteLine("Nhập nghĩa tiếng việt tương ứng: ");
                string tv = Console.ReadLine();
                dic.Add(ta, tv);
                Console.WriteLine("Thêm thành công!");
            }
            Console.ReadLine();
        }

        public void edit() {
            Console.WriteLine("Nhập từ tiếng anh cần sửa: ");
            string ta = Console.ReadLine();
            if (dic.ContainsKey(ta) == false) {
                Console.WriteLine("Từ điển không có từ " + ta);
            } else {
                Console.WriteLine("Nhập lại nghĩa tiếng việt: ");
                string tv = Console.ReadLine();
                dic[ta] = tv;
                Console.WriteLine("Sửa thành công!");
            }
            Console.ReadLine();
        }

        public void search() {
            Console.WriteLine("Nhập từ tiếng anh cần tra cứu: ");
            string ta = Console.ReadLine();
            if (dic.ContainsKey(ta) == false) {
                Console.WriteLine("Từ điển chưa có nghĩa của từ " + ta);
            } else {
                Console.WriteLine("Nghĩa của từ " + ta + " la " + dic[ta]);
            }
            Console.ReadLine();
        }

        public void delete() {
            Console.WriteLine("Nhập từ tiếng anh cần xóa: ");
            string ta = Console.ReadLine();
            if (dic.ContainsKey(ta) == false) {
                Console.WriteLine("Từ điển không có từ " + ta);
            } else {
                dic.Remove(ta);
                Console.WriteLine("Xóa thành công từ " + ta);
            }
            Console.ReadLine();
        }



        public void run() {
            int choise;
            do {
                choise = menu();
                Console.Clear();
                switch (choise) {
                    case 1:
                        add();
                        break;
                    case 2:
                        edit();
                        break;
                    case 3:
                        search();
                        break;
                    case 4:
                        delete();
                        break;
                    default:
                        break;
                }
            } while (choise != 5);
        }

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Program test = new Program();
            test.run();
        }
    }
}
