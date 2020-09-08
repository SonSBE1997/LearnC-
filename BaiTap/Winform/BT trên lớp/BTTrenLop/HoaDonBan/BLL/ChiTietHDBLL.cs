using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDonBan.BLL
{
    public class ChiTietHDBLL
    {
        private static ChiTietHDBLL instance;

        public static ChiTietHDBLL Instance
        {
            get
            {
                if (instance == null) instance = new ChiTietHDBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private ChiTietHDBLL() { }


        public DataTable GetAllBillInfo()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblChiTietHDBan");
        }

        public DataTable GetAllBillInfoByBillID(string billID)
        {
            return DataProvider.Instance.ExcuteQuery("SELECT ct.MaHang, h.TenHang, ct.SoLuong,ct.GiamGia,h.DonGiaBan as DonGia,ct.ThanhTien FROM  dbo.tblChiTietHDBan ct JOIN dbo.tblHang h ON h.Mahang = ct.MaHang WHERE MaHDBan= N'" + billID + "'");
        }
    }
}
