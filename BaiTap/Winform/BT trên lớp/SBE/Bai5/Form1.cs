using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            libLanguage.Items.Add("Tiếng anh");
            libLanguage.Items.Add("Tiếng đức");
            libLanguage.Items.Add("Tiếng pháp");
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLanguage.Text.Trim()))
            {
                MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            libLanguage.Items.Add(txtLanguage.Text.Trim());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < libLanguage.SelectedItems.Count; i++)
            {
                libLanguage.Items.Remove(libLanguage.SelectedItems[i]);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLanguage.Text.Trim()))
            {
                MessageBox.Show("Bạn phải nhập từ khóa cần tìm kiếm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (libLanguage.Items.Contains(txtLanguage.Text.Trim()))
            {
                libLanguage.SelectedItem = txtLanguage.Text.Trim();
            }
            else
            {
                MessageBox.Show("Không thấy " + txtLanguage.Text.Trim()  + " trong danh sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }
    }
}
