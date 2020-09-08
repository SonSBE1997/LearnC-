using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTrenLop
{
    class Employee
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public Employee(DataRow row)
        {
            ID = row["Manhanvien"].ToString();
            Name = row["Tennhanvien"].ToString();
        }
    }
}
