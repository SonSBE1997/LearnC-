using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoWinform1
{
    public partial class Form1 : Form
    {
        private List<CBClass> danhSach;

        public Form1()
        {
            InitializeComponent();
            addData();
        }

        void addData()
        {
            danhSach = new List<CBClass>();
            danhSach.Add(new CBClass()
            {
                ClassName = "CNTT1",
                ListStudent = new List<string>() { "Vũ Xuân Long ", "Nguyễn Đức Hạnh" }
            });

            danhSach.Add(new CBClass()
            {
                ClassName = "CNTT2",
                ListStudent = new List<string>() { "Nguyễn Hữu Hưng ", "Bùi Văn Vinh" }
            });

            cbClass.DataSource = danhSach;
            cbClass.DisplayMember = "ClassName";

            cbListStudent.DataBindings.Add(new Binding("DataSource",cbClass.DataSource,"ListStudent"));
        }

        
    }

    public class CBClass
    {
        public string ClassName { get; set; }
        public List<string> ListStudent { get; set; }
    }
}
