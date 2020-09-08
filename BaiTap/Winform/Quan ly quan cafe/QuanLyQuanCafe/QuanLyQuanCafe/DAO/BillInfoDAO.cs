using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillInfoDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int idBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.BillInfo WHERE idBill = " + idBill);
            foreach (DataRow item in data.Rows)
            {
                BillInfo billInfo = new BillInfo(item);
                listBillInfo.Add(billInfo);
            }
            return listBillInfo;
        }

        public void InsertBillInfo(int billID, int foodID, int count)
        {
            DataProvider.Instance.ExcuteNonQuery("USP_InsertBillInfo @billID  , @foodID  , @count  ", new object[] { billID, foodID, count });
        }

        public void DeleteBillInfoByIdFood(int idFood)
        {
            DataProvider.Instance.ExcuteNonQuery("Delete dbo.BillInfo WHERE idFood = " + idFood);
        }
    }
}
