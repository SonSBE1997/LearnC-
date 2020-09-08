using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get
            {
                if (instance == null) instance = new TableDAO();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }

        public void SwitchTale(int idTable1, int idTable2)
        {
            DataProvider.Instance.ExcuteQuery("USP_SwitchTable @idTable1 , @idTable2 ", new object[] { idTable1, idTable2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> tablesList = new List<Table>();
            DataTable data = DataProvider.Instance.ExcuteQuery("dbo.USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tablesList.Add(table);
            }
            return tablesList;
        }

        public DataTable GetListTable()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT id AS [ID], name AS [tên bàn], status AS [trạng thái] FROM dbo.TableFood");
        }

        public bool InsertTable(string name)
        {
            return DataProvider.Instance.ExcuteNonQuery("INSERT INTO dbo.TableFood ( name )VALUES  ( N'" + name + "')") > 0;
        }

        public bool UpdateTable(int id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.TableFood SET name = N'{0}' WHERE id = {1}", name, id)) > 0;
        }

        public bool DeleteTable(int id)
        {
            return DataProvider.Instance.ExcuteNonQuery("Exec USP_DeleteTable @idTable = " + id) > 0;
        }
    }
}
