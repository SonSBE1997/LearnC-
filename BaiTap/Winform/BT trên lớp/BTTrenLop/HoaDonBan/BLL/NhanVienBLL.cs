using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDonBan.BLL
{
    public class NhanVienBLL
    {
        private static NhanVienBLL instance;

        public static NhanVienBLL Instance
        {
            get
            {
                if (instance == null) instance = new NhanVienBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private NhanVienBLL() { }

        public DataTable LayTatCaNV()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblNhanVien");
        }
    }
}
