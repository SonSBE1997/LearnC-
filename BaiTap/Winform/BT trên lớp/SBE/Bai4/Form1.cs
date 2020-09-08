using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai4
{
    public partial class Form1 : Form
    {
        int a, b;
        public Form1()
        {
            InitializeComponent();
        }

        #region Compare
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbMin.Checked) ckbMin.Text = "Min";
            else
            {
                if (!CheckData()) return;
                GetDataFromTextBox();
                ckbMin.Text = "Min = " + Math.Min(a, b);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckbMax.Checked) ckbMax.Text = "Max";
            else
            {
                if (!CheckData()) return;
                GetDataFromTextBox();
                ckbMax.Text = "Max = " + Math.Max(a, b);
            }
        }
        #endregion

        #region Calculate

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDevide.Checked)
            {
                if (!CheckData()) return;
                GetDataFromTextBox();
                txtResult.Text = ((float)a / b).ToString();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnMul.Checked)
            {
                if (!CheckData()) return;
                GetDataFromTextBox();
                txtResult.Text = (a * b).ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSub.Checked)
            {
                if (!CheckData()) return;
                GetDataFromTextBox();
                txtResult.Text = (a - b).ToString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnAdd.Checked)
            {
                txtResult.Text = (a + b).ToString();
                if (!CheckData()) return;
                GetDataFromTextBox();
            }
        }
        #endregion

        bool CheckData()
        {
            if (string.IsNullOrEmpty(txtA.Text) || string.IsNullOrEmpty(txtA.Text))
            {
                MessageBox.Show("Bạn phải nhập vào đủ 2 số a và b", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        void GetDataFromTextBox()
        {
            a = Int32.Parse(txtA.Text);
            b = Int32.Parse(txtB.Text);
        }

        private void btnRework_Click(object sender, EventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtResult.Text = "";
            txtA.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập a là một số");
                e.Handled = true;
            }
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8)
            {
                MessageBox.Show("Bạn phải nhập b là một số");
                e.Handled = true;
            }
        }
    }
}
