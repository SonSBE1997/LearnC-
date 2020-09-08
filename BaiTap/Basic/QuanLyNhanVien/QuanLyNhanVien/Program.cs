using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien {
    class Program {
        private List<PhongBan> lPB = new List<PhongBan>();
        public void quanLyNhanVien() {
            PhongBan phongNhanSu = new PhongBan(1, "Phòng nhân sự");
            NhanVien nv1 = new NhanVien(1, "Nguyễn Văn Tú", new DateTime(1987, 3, 12), LoaiChucVu.truongPhong);
            phongNhanSu.themNV(nv1);
            NhanVien nv2 = new NhanVien(2, "Hoàng Thị Khánh Ly", new DateTime(1990, 4, 2), LoaiChucVu.nhanVien);
            phongNhanSu.themNV(nv2);

            lPB.Add(phongNhanSu);

            PhongBan phongKeToan = new PhongBan(2, "Phòng kế toán");
            NhanVien nv3 = new NhanVien(3, "Vũ Minh Tuấn", new DateTime(1989, 12, 2), LoaiChucVu.phoPhong);
            phongKeToan.themNV(nv3);
            NhanVien nv4 = new NhanVien(4, "Lê Vân Lan", new DateTime(1991, 5, 3), LoaiChucVu.nhanVien);
            phongKeToan.themNV(nv4);
            lPB.Add(phongKeToan);

            //in toàn bộ nhân viên

            foreach(PhongBan pb in lPB) {
                Console.WriteLine(pb.ToString());
                pb.xuatNhanVien();
            }
        }

        static void Main(string[] args) {
            Console.OutputEncoding = Encoding.UTF8;
            Program pr = new Program();
            pr.quanLyNhanVien();
            Console.ReadLine();
        }
    }
}
