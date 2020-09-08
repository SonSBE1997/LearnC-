using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace DemoProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void GetProcesses()
        {
            try
            {
                Process[] processArr = Process.GetProcesses();
                foreach (Process process in processArr)
                {
                    textBox1.Text += process.ProcessName + "\r\n";
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe");
        }
    }
}
