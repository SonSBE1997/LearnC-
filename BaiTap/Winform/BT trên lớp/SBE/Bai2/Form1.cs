using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNumber1.Text) || String.IsNullOrEmpty(txtNumber2.Text))
            {
                MessageBox.Show("Bạn phải nhập vào đủ 2 số a và b", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            label3.Text = Calculate();
        }

        private string Calculate()
        {
            int a = Int32.Parse(txtNumber1.Text);
            int b = Int32.Parse(txtNumber2.Text);
            int sum = 0;
            if (a < b)
            {
                for (int i = a; i <= b; i++)
                {
                    sum += i;
                }
                return string.Format("Tổng từ {0} đến {1} là: {2}", a, b, sum);
            }
            else
            {
                for (int i = b; i <= a; i++)
                {
                    sum += i;
                }
                return string.Format("Tổng từ {0} đến {1} là: {2}", b, a, sum);
            }
        }

        private void btnRework_Click(object sender, EventArgs e)
        {
            txtNumber1.Text = "";
            txtNumber2.Text = "";
            txtNumber1.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtNumber1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập a là một số");
                e.Handled = true;
            }
        }

        private void txtNumber2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập b là một số");
                e.Handled = true;
            }
        }
    }
}
