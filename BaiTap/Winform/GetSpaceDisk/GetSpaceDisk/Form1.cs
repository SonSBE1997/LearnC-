using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace GetSpaceDisk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", EntryPoint = "GetDiskFreeSpaceExA")]
        private static extern long GetDiskFreeSpaceEx(string lpDirectoryName, out long lpFreeBytesAvailableToCaller, out long lpTotalNumberOfBytes, out long lpTotalNumberOfFreeBytes);

        private void Form1_Load(object sender, EventArgs e)
        {
            long result, total, free, available;
            result = GetDiskFreeSpaceEx("E:", out available, out total, out free);

            if (result != 0)
            {
                long totalGB = total / (1024 * 1024 * 1024);
                long freeGB = free / (1024 * 1024 * 1024);
                long availableGB = available / (1024 * 1024 * 1024);
                string mess = "Tổng số GB: " + totalGB + "\r\n";
                mess += "Tổng số GB trống: " + freeGB + "\r\n";
                mess += "Tổng số GB trống xài được: " + availableGB;
                textBox1.Text = mess;
            }
        }
    }
}
