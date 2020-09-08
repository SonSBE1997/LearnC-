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

        int[] arr;
        public Form1()
        {
            InitializeComponent();
            arr = new int[] { };
        }

        #region RandomNumber
        private void btnRandom_Click(object sender, EventArgs e)
        {
            if (txbNumber.Text.Trim() == "")
            {
                MessageBox.Show("Bạn phải nhập số phần tử");
                txbNumber.Focus();
                return;
            }
            int n;
            if (!Int32.TryParse(txbNumber.Text, out n))
            {
                MessageBox.Show("Bạn phải nhập vào một số nguyên");
                txbNumber.Focus();
                return;
            }
            RandomNumber(n);

        }

        void RandomNumber(int n)
        {
            arr = new int[n];
            Random rd = new Random();
            label2.Text = "Dãy ngẫu nhiên: ";
            for (int i = 0; i < n; i++)
            {
                arr[i] = rd.Next(1, 100);
                label2.Text += arr[i].ToString() + "; ";
            }
        }

        #endregion

        private void btnSum_Click(object sender, EventArgs e)
        {
            if (arr.Length == 0) return;
            label3.Text = "Tổng các phần tử: ";
            label3.Text += arr.Sum().ToString();
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (arr.Length == 0) return;
            label4.Text = "Dãy sau khi sắp xếp:";
            Array.Sort(arr);
            Array.Reverse(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                label4.Text += arr[i].ToString() + "; ";
            }
        }

        private void btnRework_Click(object sender, EventArgs e)
        {
            Array.Clear(arr, 0, arr.Length);
            txbNumber.Text = "";
            txbNumber.Focus();
            label2.Text = "Dãy ngẫu nhiên: ";
            label3.Text = "Tổng các phần tử: ";
            label4.Text = "Dãy sau khi sắp xếp:";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn thoát chương trình không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập vào số");
                e.Handled = true;
            }

        }
    }
}
