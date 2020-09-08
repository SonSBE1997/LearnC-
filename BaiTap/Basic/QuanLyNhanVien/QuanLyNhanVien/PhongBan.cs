using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien {
    public class PhongBan {
        private int maPB;
        private string tenPB;
        private NhanVien truongPhong;
        private List<NhanVien> lNV = new List<NhanVien>();

        public PhongBan() {
        }

        public PhongBan(int maPB,string tenPB) {
            this.maPB = maPB;
            this.tenPB = tenPB;
        }
        public int getMaPB() {
            return maPB;
        }
        public void setMaPB(int maPB) {
            this.maPB = maPB;
        }
        public string getTenPB() {
            return tenPB;
        }
        public void setTenPB(string tenPB) {
            this.tenPB = tenPB;
        }

        public NhanVien getTruongPhong() {
            return truongPhong;
        }

        public void setTruongPhong(NhanVien truongPhong) {
            this.truongPhong = truongPhong;
        }

        public override string ToString() {
            return "Mã PB: " + maPB + "\tTên PB: " + tenPB;
        }

        public bool themNV(NhanVien nv) {

            if (lNV.Contains(nv)) {
                return false;
            }
            lNV.Add(nv);
            nv.setPB(this);
            return true;
        }

        public void xuatNhanVien() {
            foreach (NhanVien nv in lNV ) {
                Console.WriteLine(nv);
            }
        }
    }
}
