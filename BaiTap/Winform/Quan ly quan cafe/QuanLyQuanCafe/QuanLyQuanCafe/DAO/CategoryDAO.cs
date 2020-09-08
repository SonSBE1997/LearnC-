using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null) instance = new CategoryDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM FoodCategory");
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listCategory.Add(category);
            }
            return listCategory;
        }

        public DataTable GetListCategory2()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT id AS [ID], name AS [tên danh mục] FROM dbo.FoodCategory");
        }

        public Category GetCategoryByID(int ID)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("select * from FoodCategory where id = " + ID);
            foreach (DataRow item in data.Rows)
            {
                return new Category(item);
            }
            return null;
        }

        public Category GetCategoryByName(string name)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery(string.Format("select * from FoodCategory where name = N'{0}'", name));
            foreach (DataRow item in data.Rows)
            {
                return new Category(item);
            }
            return null;
        }

        public bool InsertCategory(string name)
        {
            return DataProvider.Instance.ExcuteNonQuery("INSERT INTO dbo.FoodCategory ( name ) VALUES ( N'" + name + "')") > 0;
        }

        public bool UpdateCategory(int id, string name)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.FoodCategory SET name = N'{0}' WHERE id = {1}", name, id)) > 0;
        }

        public bool DeleteCategory(int id)
        {
            return DataProvider.Instance.ExcuteNonQuery("EXEC USP_DeleteCategory @idCategory = " + id) > 0;
        }
    }
}
