using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai14
{
    public partial class Form1 : Form
    {
        bool hp = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hp)
            {
                if ((label1.Left + label1.Width) < this.Width - 10)
                    label1.Left += 10;
                else hp = false;
            }
            else
            {
                if (label1.Left > 0) label1.Left -= 10;
                else hp = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
