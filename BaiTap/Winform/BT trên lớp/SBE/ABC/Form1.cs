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

namespace ABC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = "Rich Text|*rtf|all file(*.*)|*.*";
            dlgOpen.InitialDirectory = "E:\\";
            dlgOpen.FilterIndex = 2;
            dlgOpen.Title = "mo file.rtf";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                rbtbai1.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.RichText);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgsave = new SaveFileDialog();
            dlgsave.Filter = "text file(*.txt)|*.txt|word document(*.doc)|*.doc|all file(files(*.*)|*.*";
            dlgsave.InitialDirectory = "E:\\";
            dlgsave.FilterIndex = 2;
            dlgsave.Title = "chon file de lưu";
            dlgsave.AddExtension = true;
            dlgsave.DefaultExt = ".doc";
            if (dlgsave.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(dlgsave.FileName))
                {
                    try
                    {
                        writer.Write(rbtbai1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Loi ghi file");
                    }
                    writer.Close();

                }
            }
            else
                MessageBox.Show("you clicked cancel");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
