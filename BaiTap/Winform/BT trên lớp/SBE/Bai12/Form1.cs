using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai12
{
    public partial class Form1 : Form
    {
        int red, blue, green;
        public Form1()
        {
            InitializeComponent();
        }

        private void hScrollBar2_ValueChanged(object sender, EventArgs e)
        {
            green = hScrollBar2.Value;
            label5.Text = green.ToString();
            textBox1.BackColor = Color.FromArgb(red, green, blue);
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            blue = hScrollBar1.Value;
            label3.Text = blue.ToString();
            textBox1.BackColor = Color.FromArgb(red, green, blue);
        }

        private void hsbRed_ValueChanged(object sender, EventArgs e)
        {
            red = hsbRed.Value;
            label2.Text = red.ToString();
            textBox1.BackColor = Color.FromArgb(red, green, blue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            red = 0;
            blue = 0;
            green = 0;
            hScrollBar1.Maximum = 255;
            textBox1.BackColor = Color.Black;
        }
    }
}
