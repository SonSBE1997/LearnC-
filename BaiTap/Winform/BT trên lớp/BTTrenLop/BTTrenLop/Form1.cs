using CinemaManagement.BLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTrenLop
{
    public partial class Form1 : Form
    {
        BindingSource source = new BindingSource();
        public Form1()
        {
            InitializeComponent();
            dtgvTable.DataSource = source;
            DoDuLieuLenCB();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("Bạn có chắc chắn thoát không?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }



        void DoDuLieuLenCB()
        {
            List<Employee> lsEmployee = new List<Employee>();
            foreach (DataRow row in (DataProvider.Instance.ExcuteQuery("SELECT Manhanvien, Tennhanvien FROM  dbo.tblNhanVien")).Rows)
            {
                lsEmployee.Add(new Employee(row));
            }
            cbEmployeeID.DataSource = lsEmployee;
            cbEmployeeID.DisplayMember = "ID";
            cbEmployeeID.ValueMember = "ID";
            cbEmployeeID.SelectedIndex = -1;

            List<Customer> lsCustomer = new List<Customer>();
            foreach (DataRow row in DataProvider.Instance.ExcuteQuery("SELECT * FROM  dbo.tblKhach ").Rows)
            {
                lsCustomer.Add(new Customer(row));
            }

            cbCustomerID.DataSource = lsCustomer;
            cbCustomerID.DisplayMember = "ID";
            cbCustomerID.ValueMember = "ID";
            cbCustomerID.SelectedIndex = -1;

            cboBillIDSearch.DataSource = DataProvider.Instance.ExcuteQuery("SELECT MaHDBan FROM  dbo.tblHDBan ");
            cboBillIDSearch.DisplayMember = "MaHDBan";
            cboBillIDSearch.ValueMember = "MaHDBan";


            cbMaHang.DataSource = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblHang");
            cbMaHang.ValueMember = "Mahang";
            cbMaHang.DisplayMember = "Mahang";

            cbMaHang.SelectedIndex = -1;
        }

        void DoDuLieuVaobang()
        {
            txtBillID.Text = cboBillIDSearch.SelectedValue.ToString();
            source.DataSource = DataProvider.Instance.ExcuteQuery("SELECT ct.MaHang,TenHang,ct.SoLuong,GiamGia,h.DonGiaBan AS DonGia,ThanhTien FROM dbo.tblChiTietHDBan ct JOIN dbo.tblHang h ON h.Mahang = ct.MaHang  WHERE MaHDBan= N'" + txtBillID.Text + "'");

            txtTongTien1.Text = DataProvider.Instance.ExcuteScalar("SELECT SUM(CONVERT(INT,ThanhTien)) FROM dbo.tblChiTietHDBan  WHERE MaHDBan= N'" + txtBillID.Text + "'").ToString();

            try
            {
                txtTongTien.Text = "Bằng chữ: " + ReadNumber.ByWords(Int32.Parse(txtTongTien1.Text));
            }
            catch
            {
                txtTongTien.Text = "Bằng chữ: ";
            }
           
        }

        void LoadDataBinding()
        {
            txtTenHang.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "TenHang", true, DataSourceUpdateMode.Never));
            txtSL.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "SoLuong", true, DataSourceUpdateMode.Never));
            txtGiamGia.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "GiamGia", true, DataSourceUpdateMode.Never));
            txtDonGia.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "DonGia", true, DataSourceUpdateMode.Never));
            txtTotalPrice.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ThanhTien", true, DataSourceUpdateMode.Never));
        }


        void BillInfoID()
        {
            DataTable hdBan = DataProvider.Instance.ExcuteQuery("select *  from  tblHDBan  WHERE MaHDBan= N'" + txtBillID.Text + "'");

            mtxbDate.Text = DateTime.Parse(hdBan.Rows[0]["NgayBan"].ToString()).ToString("dd/MM/yyyy");
            foreach (var item in cbEmployeeID.Items)
            {
                if ((item as Employee).ID == hdBan.Rows[0]["NhanVien"].ToString().Trim())
                {
                    cbEmployeeID.SelectedItem = item;
                    break;
                }
            }

            foreach (var item in cbCustomerID.Items)
            {
                if ((item as Customer).ID == hdBan.Rows[0]["MaKhach"].ToString().Trim())
                {
                    cbCustomerID.SelectedItem = item;
                    break;
                }
            };
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txtBillID.Text = cboBillIDSearch.SelectedValue.ToString();
            BillInfoID();
            DoDuLieuVaobang();
            LoadDataBinding();
        }

        private void cbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable customer = DataProvider.Instance.ExcuteQuery("SELECT * FROM dbo.tblKhach WHERE Makhach = N'" + cbCustomerID.SelectedValue + "'");
            try
            {
                txtCustomerName.Text = customer.Rows[0]["TenKhach"].ToString();
                txtAddress.Text = customer.Rows[0]["DiaChi"].ToString();
                txtPhoneNumber.Text = customer.Rows[0]["DienThoai"].ToString();
            }
            catch
            {
                txtCustomerName.Text = "";
                txtAddress.Text = "";
                txtPhoneNumber.Text = "";
            }
        }

        private void cbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtEmployeeName.Text = DataProvider.Instance.ExcuteScalar("SELECT Tennhanvien FROM dbo.tblNhanVien WHERE Manhanvien = N'" + cbEmployeeID.SelectedValue + "'").ToString();
            }
            catch
            {
                txtEmployeeName.Text = "";
            }
        }

        private void txtTenHang_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    string hang = dtgvTable.SelectedRows[0].Cells["MaHang"].Value.ToString();
            //    foreach (string item in cbMaHang.Items)
            //    {
            //        if (item == hang)
            //        {
            //            cbMaHang.SelectedItem = item;
            //            break;
            //        }
            //    }
            //}
            //catch { }
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void dtgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string hang = dtgvTable.SelectedRows[0].Cells["MaHang"].Value.ToString();
            if (hang != "")
            {
                if (MessageBox.Show("Ban co chac muon xoa chi tiet hoa don nay chu?", "xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProvider.Instance.ExcuteNonQuery("DELETE dbo.tblChiTietHDBan WHERE MaHang = N'" + hang + "'");
                    DoDuLieuVaobang();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            DateTime time = DateTime.Now;
            mtxbDate.Text = time.ToString("dd/MM/yyyy");
            txtBillID.Text = "HD" + time.Day + time.Month + time.Year;
            string temp = "";
            try
            {
                temp = DataProvider.Instance.ExcuteScalar("SELECT TOP 1 MaHDBan FROM  dbo.tblHDBan WHERE MaHDBan LIKE N'" + txtBillID.Text + "%' ORDER BY MaHDBan DESC").ToString();
            }
            catch { }

            if (temp != "")
            {
                txtBillID.Text += (Convert.ToInt32(temp.Substring(temp.Length - 1)) + 1).ToString();
            }
            else txtBillID.Text += "0";
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double dongia, giamgia, soluong, thanhtien;
                dongia = Convert.ToDouble(txtDonGia.Text);
                if (txtSL.Text == "")
                    soluong = 0;
                else
                    soluong = Convert.ToDouble(txtSL.Text);
                if (txtGiamGia.Text == "")
                    giamgia = 0;
                else
                    giamgia = Convert.ToDouble(txtGiamGia.Text) / 100;
                thanhtien = dongia * soluong * (1 - giamgia);
                txtTotalPrice.Text = thanhtien.ToString();
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int TongTien, slCu, slMoi;
            DataTable dtHoaDon = DataProvider.Instance.ExcuteQuery("Select * from tblHDBan where MaHDBan='" + txtBillID.Text + "'");
            DateTime dtNgayBan = Convert.ToDateTime(mtxbDate.Text);
            if (dtHoaDon.Rows.Count == 0)
            {
                TongTien = Convert.ToInt32(txtTotalPrice.Text);
                DataProvider.Instance.ExcuteNonQuery("insert into tblHDBan values('" + txtBillID.Text + "','" + cbEmployeeID.SelectedValue.ToString() + "','" + String.Format("{0:MM/dd/yyyy}", dtNgayBan) +
                    "','" + cbCustomerID.SelectedValue.ToString() + "'," + TongTien + ")");
            }
            else
            {
                TongTien = Convert.ToInt32(dtHoaDon.Rows[0]["TongTien"].ToString()) + Convert.ToInt32(txtTotalPrice.Text);
                DataProvider.Instance.ExcuteNonQuery("update tblHDBan set TongTien=" + TongTien + " where MaHDBan='" + txtBillID.Text + "'");
            }

            //Trừ số lượng của hàng
            DataTable dtSLHang = DataProvider.Instance.ExcuteQuery("Select SoLuong from tblHang where MaHang = '" + cbMaHang.SelectedValue.ToString() + "'");
            slCu = Convert.ToInt32(dtSLHang.Rows[0]["SoLuong"].ToString());
            if (slCu < Convert.ToInt32(txtSL.Text))
                MessageBox.Show("Số lượng chỉ còn " + slCu.ToString());
            else
            {
                slMoi = slCu - Convert.ToInt32(txtSL.Text);
                DataProvider.Instance.ExcuteNonQuery("update tblHang set SoLuong= " + slMoi + "where MaHang = '" + cbMaHang.SelectedValue.ToString() + "'");
                //GV chưa ktr trùng khóa trung chi tiết 

                DataProvider.Instance.ExcuteNonQuery("insert into tblChiTietHDBan values('" + txtBillID.Text + "','" + cbMaHang.SelectedValue.ToString() + "'," +
                   Convert.ToInt32(txtSL.Text) + "," + Convert.ToInt32(txtGiamGia.Text) + "," + Convert.ToInt32(txtTotalPrice.Text) + ")");
                DoDuLieuVaobang();
                txtTongTien1.Text = TongTien.ToString();
            }
        }
    }
}
