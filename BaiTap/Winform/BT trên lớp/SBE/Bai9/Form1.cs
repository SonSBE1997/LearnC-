using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox3.Font = new Font(checkBox3.Font, FontStyle.Strikeout);
            checkBox4.Font = new Font(checkBox4.Font, FontStyle.Underline);
            radioButton1.Font = new Font("VnTime", 12);
            radioButton2.Font = new Font("VnUniverse", 12);
            radioButton3.Font = new Font("VnVgogue", 12);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            textBox1.ForeColor = Color.Black;
            textBox1.Font = new Font("Arial", 12, FontStyle.Regular);
        }

        #region Color
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true) textBox1.ForeColor = Color.Blue;
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true) textBox1.ForeColor = Color.Red;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true) textBox1.ForeColor = Color.Green;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true) textBox1.ForeColor = Color.Purple;
        }
        #endregion
        #region Font Style

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) textBox1.Font = new Font(textBox1.Font, FontStyle.Bold);
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true) textBox1.Font = new Font(textBox1.Font, FontStyle.Strikeout);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true) textBox1.Font = new Font(textBox1.Font, FontStyle.Underline);
        }
        #endregion

        #region Font
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true) textBox1.Font = new Font("Tahoma", 12);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) textBox1.Font = new Font("Tahoma", 12);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true) textBox1.Font = new Font("Tahoma", 12);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true) textBox1.Font = new Font("Tahoma", 12);
        }
        #endregion
    }
}
