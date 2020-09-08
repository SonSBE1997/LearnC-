using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai11
{
    public partial class Form1 : Form
    {
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            count = 0;
            foreach (string item in listBox2.Items)
            {
                string[] result = item.Split('(');
                int i = listBox2.Items.IndexOf(item);
                if (result[0] == listBox1.SelectedItem.ToString())
                {
                    count = Int32.Parse(result[1].Substring(0, result[1].Length - 1));
                    count++;
                    listBox2.Items[i] = listBox1.SelectedItem.ToString() + "(" + count + ")";
                    return;
                }
            }
            count = 1;
            listBox2.Items.Add(listBox1.SelectedItem.ToString() + "(" + count + ")");
        }

        private void listBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa " + listBox2.SelectedItem.ToString() + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                listBox2.Items.Remove(listBox2.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Bạn phải nhập đầy đủ thông tin cá nhân!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string content = "Họ tên khách: " + textBox1.Text + "\r\nĐiện thoại: " + textBox2.Text;
            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("Bạn chưa chọn mặt hàng để mua!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            content += "\r\nDanh sách hàng đặt mua:";

            foreach (string item in listBox2.Items)
            {
                content += "\r\n- " + item;
            }

            if (Pay() == "") return;
            content += "\r\nPhương thức thanh toán: " + Pay();
            if (Contact() == "") return;
            content += "\r\nHình thức liên lạc: " + Contact();
            MessageBox.Show(content, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        string Pay()
        {
            if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn hình thức thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            if (radioButton1.Checked) return "Tiền mặt";
            if (radioButton2.Checked) return "Sec";
            return "Thẻ tín dụng";
        }

        string Contact()
        {
            string contact = "";
            if (checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                MessageBox.Show("Bạn chưa chọn hình thức liên lạc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return "";
            }
            if (checkBox1.Checked) contact += "Điện thoại";
            if (checkBox2.Checked) if (contact == "") contact += "Fax"; else contact += ", Fax";
            if (checkBox3.Checked) if (contact == "") contact += "Email"; else contact += ", Email";
            return contact;
        }
    }
}
