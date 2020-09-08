using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Bai7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> list = Directory.GetDirectories(@"D:\hoc tap\C#").ToList();
            list.AddRange(Directory.GetFiles(@"D:\hoc tap\C#"));
            comboBox1.DataSource = list;
        }
    }
}
