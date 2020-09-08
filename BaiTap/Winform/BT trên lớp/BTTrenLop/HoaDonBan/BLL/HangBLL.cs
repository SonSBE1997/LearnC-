using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDonBan.BLL
{
   public class HangBLL
    {
        private static HangBLL instance;

        public static HangBLL Instance
        {
            get
            {
                if (instance == null) instance = new HangBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private HangBLL() { }

        public DataTable LayTatCaHang()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblHang");
        }
    }
}
