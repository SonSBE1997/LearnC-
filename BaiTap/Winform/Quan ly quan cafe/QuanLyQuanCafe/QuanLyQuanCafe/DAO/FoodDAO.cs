using QuanLyQuanCafe.DTO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null) instance = new FoodDAO();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        private FoodDAO() { }

        public List<Food> GetListFoodByCategoryID(int categoryID)
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("USP_GetListFoodByCategoryID @CategoryID = " + categoryID);

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public List<Food> GetListFood()
        {
            List<Food> listFood = new List<Food>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select *  from Food");

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public DataTable GetListFood2()
        {
            return DataProvider.Instance.ExcuteQuery("select f.ID , f.name as [tên thức ăn], fc.name as [danh mục], f.price as [đơn giá] from Food as f , FoodCategory as fc where f.idCategory = fc.id");
        }

        public bool InsertFood(string foodName, int idCategory, int price)
        {
            string query = string.Format("INSERT INTO dbo.Food( name, idCategory, price ) VALUES ( N'{0}', {1}, {2})", foodName, idCategory, price);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public bool UpdateFood(int id, string foodName, int idCategory, int price)
        {
            string query = string.Format("UPDATE dbo.Food SET name = N'{0}',idCategory = {1},price = {2} WHERE id = {3}", foodName, idCategory, price, id);
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public void DeleteFood(int id)
        {
            string query = "DELETE FROM dbo.Food WHERE id = " + id;
            DataProvider.Instance.ExcuteNonQuery(query);
        }

        public DataTable SearchFoodByName(string name)
        {
            return DataProvider.Instance.ExcuteQuery(string.Format("select f.ID , f.name as [tên thức ăn], fc.name as [danh mục], f.price as [đơn giá] from Food as f , FoodCategory as fc where f.idCategory = fc.id AND dbo.fucConvertUnicodeToUnsign(f.name) like N'%' + dbo.fucConvertUnicodeToUnsign(N'{0}') + '%'", name));
        }
    }
}
