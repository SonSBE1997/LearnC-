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

namespace FilePDFDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            saveFile.Filter = "PDF File |*.pdf|Text file (*.txt)|*.txt|XML file (*.xml)|*.xml|All files (*.*)|*.*";
            saveFile.AddExtension = false;
            saveFile.RestoreDirectory = true;
            saveFile.InitialDirectory = @"D:\";
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                CreatePdfFile.Instance.Create(saveFile.FileName);
            }
            saveFile.Dispose();
        }
    }
}
