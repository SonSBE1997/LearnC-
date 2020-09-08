using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTrenLop
{
    class Customer
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Customer(DataRow row)
        {
            ID = row["Makhach"].ToString();
            Name = row["TenKhach"].ToString();
            Address = row["DiaChi"].ToString();
            PhoneNumber = row["DienThoai"].ToString();
        }
    }
}
