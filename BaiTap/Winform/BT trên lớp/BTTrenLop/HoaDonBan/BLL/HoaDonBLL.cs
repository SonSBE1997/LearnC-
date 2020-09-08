using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoaDonBan.BLL
{
    public class HoaDonBLL
    {
        private static HoaDonBLL instance;

        public static HoaDonBLL Instance
        {
            get
            {
                if (instance == null) instance = new HoaDonBLL();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private HoaDonBLL() { }

        public DataTable GetAllBill()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblHDBan");
        }
    }
}
