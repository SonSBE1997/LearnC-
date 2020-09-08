using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDonBan.BLL
{
    public class KhachHangBLL
    {
        private static KhachHangBLL instance;

        public static KhachHangBLL Instance
        {
            get
            {
                if (instance == null) instance = new KhachHangBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private KhachHangBLL() { }

        public DataTable LayTatCaKH()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblKhach");
        }
    }
}
