using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void btnRework_Click(object sender, EventArgs e)
        {
            txtMonth.Text = "";
            txtYear.Text = "";
            lblResult.Text = "";
            txtMonth.Focus();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtMonth.Text) || String.IsNullOrEmpty(txtMonth.Text))
            {
                MessageBox.Show("Bạn phải nhập đủ tháng và năm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int month = Int32.Parse(txtMonth.Text);
            if (month > 12 || month < 1)
            {
                MessageBox.Show("Bạn phải nhập tháng trong đoạn [1-12]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int year = Int32.Parse(txtYear.Text);
            if (year.ToString().Length != 4)
            {
                MessageBox.Show("Bạn phải nhập năm gồm 4 chữ số", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblResult.Text = string.Format("Tháng {0} năm {1} có {2} ngày", month, year, GetDay(year, month));
        }

        int GetDay(int year, int month)
        {
            month = month == 12 ? 0 : month;
            DateTime date = new DateTime(year, month + 1, 1);
            return date.AddDays(-1).Day;
        }

        private void txtMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập tháng là một số");
                e.Handled = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập năm là một số");
                e.Handled = true;
            }
        }
    }
}
