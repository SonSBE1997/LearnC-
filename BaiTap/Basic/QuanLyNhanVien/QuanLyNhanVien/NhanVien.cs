using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanVien {
    public class NhanVien {
        public const long LUONG = 10000000;

        private int maNV;
        private string tenNV;
        private DateTime ngaySinh;
        private LoaiChucVu chucVu;
        private PhongBan phong;

        public NhanVien() {
        }

        public NhanVien(int maNV, string tenNV, DateTime ngaySinh, LoaiChucVu chucVu) {
            this.maNV = maNV;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.chucVu = chucVu;
        }

        public int getMaNV() {
            return maNV;
        }

        public void setMaNV(int maNV) {
            this.maNV = maNV;
        }

        public string getTenNV() {
            return tenNV;
        }

        public void setTenNV(string tenNV) {
            this.tenNV = tenNV;
        }

        public DateTime getNgaySinh() {
            return ngaySinh;
        }

        public void setNgaySinh(DateTime ngaySinh) {
            this.ngaySinh = ngaySinh;
        }

        public LoaiChucVu getChucVu() {
            return chucVu;
        }

        public void setChucVu(LoaiChucVu chucVu) {
            this.chucVu = chucVu;
        }

        public PhongBan getPB() {
            return phong;
        }

        public void setPB(PhongBan phong) {
            this.phong = phong;
        }

        public override string ToString() {
            return "\tMã NV: " + maNV + "\tTên NV: " + tenNV + "\tNgày sinh: " + ngaySinh.ToString("dd/MM/yyyy") + "\tChức vụ:" + this.tenChucVu() + "\tLương:" + tinhLuong();
        }

        //Method
        public string tenChucVu() {
            if (chucVu == LoaiChucVu.giamDoc)
                return "Giám đốc";
            if (chucVu == LoaiChucVu.truongPhong)
                return "Trưởng phòng";
            if (chucVu == LoaiChucVu.phoPhong)
                return "Phó phòng";
            return "Nhân viên";
        }

        public long tinhLuong() {
            if (chucVu == LoaiChucVu.giamDoc)
                return LUONG + (long)(LUONG * 0.25);
            if (chucVu == LoaiChucVu.truongPhong)
                return LUONG + (long)(LUONG * 0.15);
            if (chucVu == LoaiChucVu.phoPhong)
                return LUONG + (long)(LUONG * 0.05);
            return LUONG;
        }
    }
}
