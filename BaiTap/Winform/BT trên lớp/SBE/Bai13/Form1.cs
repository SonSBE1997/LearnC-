using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiai_Click(object sender, EventArgs e)
        {
            int a, b;
            a = (int)numA.Value;
            b = (int)numB.Value;
            string content = "A = " + a + ", B = " + b + ". ";
            if (a == 0)
            {
                if (b == 0) content += "Phương trình vô số nghiệm.";
                else content += "Phương trình vô nghiệm.";
            }
            else
            {
                float result = (float)-b / a;
                content += "Phương trình có nghiệm là x = " + result;
            }
            txtResult.Text = content;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không!", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
