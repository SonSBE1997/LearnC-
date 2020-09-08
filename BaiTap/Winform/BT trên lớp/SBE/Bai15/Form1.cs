using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeDown();
        }

        private void timeDown()
        {
            int minute, second;
            Int32.TryParse(textBox1.Text, out minute);
            Int32.TryParse(textBox2.Text, out second);
            if (minute == 0 && second == 0)
            {
                timer1.Stop();
                return;
            }
            second--;
            if (second == -1)
            {
                minute--;
                second = 59;
            }
            textBox1.Text = minute.ToString();
            textBox2.Text = second.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int minute, second;
            if (!Int32.TryParse(textBox1.Text, out minute) || minute > 60 || minute < 0)
            {
                MessageBox.Show("Bạn phải nhập phút là một số trong đoạn [0,60]");
                return;
            }

            if (!Int32.TryParse(textBox2.Text, out second) || second > 60 || second < 0)
            {
                MessageBox.Show("Bạn phải nhập giây là một số trong đoạn [0,60]");
                return;
            }
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox1.Text = "00";
            textBox2.Text = "00";
        }
    }
}
