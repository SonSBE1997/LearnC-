using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null) instance = new BillDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private BillDAO() { }

        /// <summary>
        /// Thành công: Bill ID
        /// Thất bại : -1
        /// </summary>
        /// <param name="tableID"></param>
        /// <returns></returns>
        public int GetUncheckOutBillIDByTableID(int tableID)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + tableID + " AND status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }
            return -1;
        }
        public void CheckOut(int billID, int discount, float totalPrice)
        {
            string query = "UPDATE dbo.Bill SET dateCheckOut = GETDATE() , status = 1 , totalPrice = " + totalPrice + " , discount = " + discount + " WHERE id = " + billID;
            DataProvider.Instance.ExcuteNonQuery(query);
        }

        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExcuteNonQuery("USP_InsertBill @tableID = " + idTable);
        }

        public int GetMaxBillID()
        {
            return (int)DataProvider.Instance.ExcuteScalar("SELECT MAX(id) FROM dbo.Bill");
        }

        public DataTable GetListBillByDateAndPage(DateTime checkIn, DateTime checkOut, int page, int pageRows)
        {
            return DataProvider.Instance.ExcuteQuery("EXEC USP_GetListBillByDateAndPage @CheckIn , @CheckOut , @page , @pageRows ", new Object[] { checkIn, checkOut, page, pageRows });
        }

        public int GetCountBillByDate(DateTime checkIn, DateTime checkOut)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("EXEC USP_GetBillByDate @CheckIn , @CheckOut ", new Object[] { checkIn, checkOut });

            return data.Rows.Count;
        }
    }
}
