using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai16
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bntOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "JPG (*.jpg)|*.jpg| PNG (*.png) |*.png| Bitmap (*.bmp) |*.bmp| All Files (*.*) |*.*";
            //open.FilterIndex = 4;
            open.InitialDirectory = @"I:\";
            open.Title = "Hiển thị hình ảnh";
            if (open.ShowDialog() == DialogResult.OK)
            {
                //pic.SizeMode =
                pic.Image = Image.FromFile(open.FileName);
            }
            else
            {
                MessageBox.Show("You clicked Cancel!", "OpenDialog", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}  