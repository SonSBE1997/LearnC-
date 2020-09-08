using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai17
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "abc.txt";
            save.InitialDirectory = @"D:\";
            if (save.ShowDialog() == DialogResult.OK)
            {
                using(StreamWriter writer = new StreamWriter(save.FileName))
                {
                    writer.Write(rtxtContent.Text);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rtxtContent.Text = "Mùa thu bước đi trên con phố cũ";
        }
    }
}