using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        #region Properties
        private int iD;
        private string name;
        private int iDCategory;
        private float price;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public int IDCategory
        {
            get
            {
                return iDCategory;
            }

            set
            {
                iDCategory = value;
            }
        }

        public float Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        #endregion

        public Food(int id, string name, int idCategory, float price)
        {
            this.ID = id;
            this.Name = name;
            this.IDCategory = idCategory;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.IDCategory = (int)row["idCategory"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
    }
}
