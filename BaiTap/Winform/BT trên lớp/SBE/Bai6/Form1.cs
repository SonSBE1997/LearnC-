using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.ColumnWidth = listBox1.Width / 4;

            for (int i = 1; i <= 100; i++) listBox1.Items.Add("Item " + i);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string notice = "Bạn đã chọn các phần tử: ";
            foreach (string item in listBox1.SelectedItems)
            {
                notice += item + ", ";
            }

            notice = notice.Remove(notice.Length - 2, 2);
            MessageBox.Show(notice, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
