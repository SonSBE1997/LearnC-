using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.ColumnWidth = checkedListBox1.Width / 2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string notice = "Bạn đã chọn các món: ";
            foreach (string item in checkedListBox1.CheckedItems)
            {
                notice += item + ", ";
            }
            notice = notice.Remove(notice.Length - 2, 2);
            MessageBox.Show(notice);
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                MessageBox.Show("Bạn vừa thêm món " + checkedListBox1.SelectedItem, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
