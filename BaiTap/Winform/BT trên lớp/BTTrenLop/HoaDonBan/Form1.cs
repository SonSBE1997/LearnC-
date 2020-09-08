using HoaDonBan.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace HoaDonBan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DoDuLieuLenComboBox();
        }

        #region  dodulieu
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaNV.SelectedIndex != -1)
            {
                txtTenNV.Text = (cbMaNV.DataSource as DataTable).Rows[cbMaNV.SelectedIndex]["Tennhanvien"].ToString();
            }
            else txtTenNV.Text = "";
        }

        private void cbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaKH.SelectedIndex != -1)
            {
                txtTenKH.Text = (cbMaKH.DataSource as DataTable).Rows[cbMaKH.SelectedIndex]["TenKhach"].ToString();
                txtDienThoai.Text = (cbMaKH.DataSource as DataTable).Rows[cbMaKH.SelectedIndex]["DienThoai"].ToString();
                txtDiaChi.Text = (cbMaKH.DataSource as DataTable).Rows[cbMaKH.SelectedIndex]["DiaChi"].ToString();
            }
            else txtTenKH.Text = "";
        }

        private void cbMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaHang.SelectedIndex != -1)
            {
                txtTenHang.Text = (cbMaHang.DataSource as DataTable).Rows[cbMaHang.SelectedIndex]["Tenhang"].ToString();
                txtDonGia.Text = (cbMaHang.DataSource as DataTable).Rows[cbMaHang.SelectedIndex]["DonGiaBan"].ToString();
            }
            else
            {
                txtTenHang.Text = "";
                txtDonGia.Text = "";
            }
        }

        #region DO DL Len ComboBox
        void DoDuLieuLenComboBox()
        {
            DoLenCBMaHD();
            DoLeCBMaHang();
            DoLenCBMaKH();
            DoLenCBMaNV();
        }

        void DoLenCBMaHD()
        {
            cbMaHD.DataSource = HoaDonBLL.Instance.GetAllBill();
            cbMaHD.DisplayMember = "MaHDBan";
            cbMaHD.ValueMember = "MaHDBan";
            cbMaHD.SelectedIndex = -1;

        }

        void DoLenCBMaNV()
        {
            cbMaNV.DataSource = NhanVienBLL.Instance.LayTatCaNV();
            cbMaNV.DisplayMember = "Manhanvien";
            cbMaNV.ValueMember = "Manhanvien";
            cbMaNV.SelectedIndex = -1;
        }

        void DoLenCBMaKH()
        {
            cbMaKH.DataSource = KhachHangBLL.Instance.LayTatCaKH();
            cbMaKH.DisplayMember = "Makhach";
            cbMaKH.ValueMember = "Makhach";
            cbMaKH.SelectedIndex = -1;
        }

        void DoLeCBMaHang()
        {
            cbMaHang.DataSource = HangBLL.Instance.LayTatCaHang();
            cbMaHang.DisplayMember = "Mahang";
            cbMaHang.ValueMember = "Mahang";
            cbMaHang.SelectedIndex = -1;
        }

        #endregion

        void DoDLLenDtgv()
        {
            dtgvTable.DataSource = ChiTietHDBLL.Instance.GetAllBillInfoByBillID(txtMaHD.Text);
        }

        private void dtgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((dtgvTable.DataSource as DataTable).Rows.Count <= 0) return;
            string mahang = dtgvTable.SelectedRows[0].Cells["MaHang"].Value.ToString();
            foreach (DataRow row in (cbMaHang.DataSource as DataTable).Rows)
            {
                if (row["Mahang"].ToString() == mahang)
                {
                    cbMaHang.SelectedValue = mahang;
                    break;
                }
                else
                    cbMaHang.SelectedIndex = -1;
            }
            txtTenHang.Text = dtgvTable.SelectedRows[0].Cells["TenHang"].Value.ToString();
            txtSL.Text = dtgvTable.SelectedRows[0].Cells["SoLuong"].Value.ToString();
            txtGiamGia.Text = dtgvTable.SelectedRows[0].Cells["GiamGia"].Value.ToString();
            txtDonGia.Text = dtgvTable.SelectedRows[0].Cells["DonGia"].Value.ToString();
            txtThanhTien.Text = dtgvTable.SelectedRows[0].Cells["ThanhTien"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbMaHD.SelectedIndex != -1)
            {
                DataRow row = (cbMaHD.DataSource as DataTable).Rows[cbMaHD.SelectedIndex];
                txtMaHD.Text = row["MaHDBan"].ToString();
                mtxbNgayBan.Text = DateTime.Parse(row["NgayBan"].ToString()).ToString("dd/MM/yyyy");
                string manv = row["NhanVien"].ToString();
                string makh = row["MaKhach"].ToString();
                foreach (DataRow item in (cbMaNV.DataSource as DataTable).Rows)
                {
                    if (item["Manhanvien"].ToString() == manv)
                    {
                        cbMaNV.SelectedValue = manv;
                        break;
                    }
                    else { cbMaNV.SelectedIndex = -1; }
                }

                foreach (DataRow item in (cbMaKH.DataSource as DataTable).Rows)
                {
                    if (item["Makhach"].ToString() == makh)
                    {
                        cbMaKH.SelectedValue = makh;
                        break;
                    }
                    else { cbMaKH.SelectedIndex = -1; }
                }

                DoDLLenDtgv();

                txtTongTienSo.Text = DataProvider.Instance.ExcuteScalar("SELECT SUM(CONVERT(INT,ThanhTien)) FROM dbo.tblChiTietHDBan  WHERE MaHDBan= N'" + txtMaHD.Text + "'").ToString();

                try
                {
                    txtTongTienChu.Text = "Bằng chữ: " + ReadNumber.ByWords(Int32.Parse(txtTongTienSo.Text));
                }
                catch
                {
                    txtTongTienChu.Text = "Bằng chữ: ";
                }
            }
        }


        #endregion

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            DateTime time = DateTime.Now;
            mtxbNgayBan.Text = time.ToString("dd/MM/yyyy");
            txtMaHD.Text = "HD" + time.Day + time.Month + time.Year;
            string temp = "";
            try
            {
                temp = DataProvider.Instance.ExcuteScalar("SELECT TOP 1 MaHDBan FROM  dbo.tblHDBan WHERE MaHDBan LIKE N'" + txtMaHD.Text + "%' ORDER BY MaHDBan DESC").ToString();
            }
            catch { }

            if (temp != "")
            {
                txtMaHD.Text += (Convert.ToInt32(temp.Substring(temp.Length - 1)) + 1).ToString();
            }
            else txtMaHD.Text += "0";
            string manv = cbMaNV.SelectedIndex < 0 ? "" : cbMaNV.SelectedValue.ToString();
            string makh = cbMaKH.SelectedIndex < 0 ? "" : cbMaKH.SelectedValue.ToString();
            string query = string.Format("INSERT INTO dbo.tblHDBan ( MaHDBan , NhanVien , NgayBan ,MaKhach ,TongTien) VALUES  ( N'{0}' ,  N'{1}' , '{2}' ,N'{3}' , 0 )", txtMaHD.Text, manv, time, makh);
            DataProvider.Instance.ExcuteNonQuery(query);
            DoLenCBMaHD();
        }

        private void dtgvTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string hang = dtgvTable.SelectedRows[0].Cells["MaHang"].Value.ToString();
            if (hang != "")
            {
                if (MessageBox.Show("Ban co chac muon xoa chi tiet hoa don nay chu?", "xoa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataProvider.Instance.ExcuteNonQuery("DELETE dbo.tblChiTietHDBan WHERE MaHang = N'" + hang + "'");
                    DoDLLenDtgv();
                }
            }
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Double dongia, giamgia, soluong, thanhtien;
                if (txtDonGia.Text == "") dongia = 0;
                else dongia = Convert.ToDouble(txtDonGia.Text);
                if (txtSL.Text == "")
                    soluong = 0;
                else
                    soluong = Convert.ToDouble(txtSL.Text);
                if (txtGiamGia.Text == "")
                    giamgia = 0;
                else
                    giamgia = Convert.ToDouble(txtGiamGia.Text) / 100;
                thanhtien = dongia * soluong * (1 - giamgia);
                txtThanhTien.Text = thanhtien.ToString();
            }
            catch { }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            string maH = cbMaHang.SelectedValue.ToString();
            string maHD = txtMaHD.Text;
            string giamgia = txtGiamGia.Text == "" ? "0" : txtGiamGia.Text;
            DataTable dataTable = DataProvider.Instance.ExcuteQuery("Select * from tblHang where Mahang = '" + maH + "'");
            int soluonghangconlai = Convert.ToInt32(dataTable.Rows[0]["SoLuong"].ToString());
            int soluongmoi = Convert.ToInt32(txtSL.Text);

            DataTable data1 = DataProvider.Instance.ExcuteQuery("select * from tblChiTietHDBan where MaHDBan = '" + maHD + "' ");
            if (data1.Rows.Count > 0)
            {

                DataTable data = DataProvider.Instance.ExcuteQuery("select * from tblChiTietHDBan where MaHDBan = '" + maHD + "' and Mahang = '" + maH + "' ");
                if (data.Rows.Count > 0)
                {
                    int soluongcu = Convert.ToInt32(data.Rows[0]["SoLuong"].ToString());
                    if (soluongmoi < soluongcu)
                    {
                        soluonghangconlai = soluonghangconlai + (soluongcu - soluongmoi);
                        DataProvider.Instance.ExcuteNonQuery("update tblHang set SoLuong = '" + soluonghangconlai + "' where Mahang ='" + cbMaHang.SelectedValue.ToString() + "'");
                        DataProvider.Instance.ExcuteNonQuery("update tblChiTietHDBan set SoLuong = '" + soluongmoi + "', GiamGia = '" + giamgia + "',ThanhTien = '" + txtThanhTien.Text + "' where MaHDBan = '" + txtMaHD.Text + "' and MaHang = '" + cbMaHang.SelectedValue.ToString() + "' ");
                    }
                    else
                    {
                        int kiemtra = soluongmoi - soluongcu;
                        if (soluonghangconlai > kiemtra)
                        {
                            soluonghangconlai = soluonghangconlai - (soluongmoi - soluongcu);
                            DataProvider.Instance.ExcuteNonQuery("update tblHang set SoLuong = '" + soluonghangconlai + "' where Mahang ='" + cbMaHang.SelectedValue.ToString() + "'");
                            DataProvider.Instance.ExcuteNonQuery("update tblChiTietHDBan set SoLuong = '" + txtSL.Text + "', ThanhTien = '" + txtThanhTien.Text + "' where MaHDBan = '" + txtMaHD.Text + "' and MaHang = '" + cbMaHang.SelectedValue.ToString() + "' ");
                        }
                        else
                        {
                            MessageBox.Show("so luong san pham k đủ . Chỉ còn lại " + soluonghangconlai + " san pham");
                        }
                    }
                }
                else
                {
                    if (soluonghangconlai > soluongmoi)
                    {
                        soluonghangconlai = soluonghangconlai - soluongmoi;
                        DataProvider.Instance.ExcuteNonQuery("update tblHang set SoLuong = '" + soluonghangconlai + "' where Mahang ='" + cbMaHang.SelectedValue.ToString() + "'");
                        DataProvider.Instance.ExcuteNonQuery("insert into tblChiTietHdBan values('" + txtMaHD.Text + "','" + cbMaHang.SelectedValue.ToString() + "','" + txtSL.Text + "','" + giamgia + "','" + txtThanhTien.Text + "')");
                    }
                    else
                    {
                        MessageBox.Show("so luong san pham k đủ . Chỉ còn lại " + soluonghangconlai + " san pham");
                    }

                }
            }
            else
            {
                if (soluonghangconlai > soluongmoi)
                {
                    DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.tblHDBan SET TongTien = " + txtThanhTien.Text + " WHERE MaHDBan = N'" + maHD + "'");
                    DataProvider.Instance.ExcuteNonQuery("insert into tblChiTietHDBan values ('" + txtMaHD.Text + "','" + cbMaHang.SelectedValue.ToString() + "','" + txtSL.Text + "','" + txtGiamGia.Text + "','" + txtThanhTien.Text + "')");
                }
                else
                {
                    MessageBox.Show("so luong san pham k đủ . Chỉ còn lại " + soluonghangconlai + " san pham");
                }
            }
            DoDLLenDtgv();
            try
            {
                txtTongTienSo.Text = DataProvider.Instance.ExcuteScalar("SELECT SUM(CONVERT(INT,ThanhTien)) FROM dbo.tblChiTietHDBan  WHERE MaHDBan= N'" + txtMaHD.Text + "'").ToString();
                txtTongTienChu.Text = "Bằng chữ: " + ReadNumber.ByWords(Int32.Parse(txtTongTienSo.Text));
            }
            catch
            {
                txtTongTienChu.Text = "Bằng chữ: ";
            }
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text;
            DialogResult re = MessageBox.Show("Bạn có chắc muốn hủy hóa đơn " + maHD + " không?");
            if (re == DialogResult.No) return;
            for (int i = 0; i < dtgvTable.RowCount - 1; i++)
            {
                String mahang = dtgvTable.Rows[i].Cells[0].Value.ToString();
                int soluong = Convert.ToUInt16(dtgvTable.Rows[i].Cells[2].Value.ToString());
                DataTable dataTable = DataProvider.Instance.ExcuteQuery("Select * from tblHang where Mahang = '" + mahang + "'");
                int soluonghangconlai = Convert.ToInt32(dataTable.Rows[0]["SoLuong"].ToString());
                soluonghangconlai = soluonghangconlai + soluong;
                DataProvider.Instance.ExcuteNonQuery("update tblHang set SoLuong = '" + soluonghangconlai + "' where Mahang ='" + mahang + "'");
            }
            DataProvider.Instance.ExcuteNonQuery("delete tblChiTietHDBan where MaHDBan = '" + txtMaHD.Text + "' ");
            DataProvider.Instance.ExcuteNonQuery("delete tblHDBan where MaHDBan = '" + txtMaHD.Text + "' ");
            txtMaHD.Text = "";
            DoDLLenDtgv();
            DoLenCBMaHD();
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            DataTable dtHang = DataProvider.Instance.ExcuteQuery("SELECT h.Mahang,h.TenHang,ct.SoLuong,h.DonGiaBan,ct.GiamGia,ct.ThanhTien FROM dbo.tblHang h JOIN dbo.tblChiTietHDBan ct ON ct.MaHang = h.Mahang where MaHDBan = N'" + txtMaHD.Text + "' ");
            if (dtHang.Rows.Count > 0)
            {
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //
                Excel.Range tenCuaHang = (Excel.Range)exSheet.Cells[1, 1]; tenCuaHang.Font.Size = 12; tenCuaHang.Font.Bold = true;
                tenCuaHang.Font.Color = Color.Blue; tenCuaHang.Value = "CỬA HÀNG ABC - XYZ";

                Excel.Range dcCuaHang = (Excel.Range)exSheet.Cells[2, 1]; dcCuaHang.Font.Size = 12; dcCuaHang.Font.Bold = true; dcCuaHang.Font.Color = Color.Blue; dcCuaHang.Value = "Địa chỉ: Cầu giấy - Hà Nội";

                Excel.Range dtCuaHang = (Excel.Range)exSheet.Cells[3, 1]; dtCuaHang.Font.Size = 12; dtCuaHang.Font.Bold = true; dtCuaHang.Font.Color = Color.Blue; dtCuaHang.Value = "Điện thoại: 0969696969";


                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH CÁC MẶT HÀNG";
                //
                exSheet.get_Range("A7:G7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã hàng";
                exSheet.get_Range("C7").Value = "Tên hàng";
                exSheet.get_Range("C7").ColumnWidth = 20;
                exSheet.get_Range("D7").Value = "Số lượng";
                exSheet.get_Range("E7").Value = "Đơn giá";
                exSheet.get_Range("F7").Value = "Giảm giá";
                exSheet.get_Range("G7").Value = "Thành tiền";
                int d = 0;
                for (int i = 0; i < dtHang.Rows.Count; i++, ++d)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":G" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dtHang.Rows[i]["Mahang"].ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dtHang.Rows[i]["TenHang"].ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dtHang.Rows[i]["SoLuong"].ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dtHang.Rows[i]["DonGiaBan"].ToString();
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = dtHang.Rows[i]["GiamGia"].ToString();
                    exSheet.get_Range("G" + (i + 8).ToString()).Value = dtHang.Rows[i]["ThanhTien"].ToString();
                }
                string tong = DataProvider.Instance.ExcuteScalar("SELECT SUM(CONVERT(INT,ThanhTien)) FROM dbo.tblChiTietHDBan  WHERE MaHDBan= N'" + txtMaHD.Text + "'").ToString();

                exSheet.get_Range("F" + (d + 10).ToString()).Font.Bold = false;
                exSheet.get_Range("G" + (d + 10).ToString()).Font.Bold = false;
                exSheet.get_Range("F" + (d + 10).ToString()).Value = "Tổng tiền:";
                exSheet.get_Range("G" + (d + 10).ToString()).Value = tong.ToString();

                exSheet.Name = "HoaDonHang";
                exBook.Activate();
                SaveFileDialog dlgSave = new SaveFileDialog();
                dlgSave.Filter = "Excel Document(*.xlsx)|*.xlsx  |Word Document(*.docx) |*.docx|All files(*.*)|*.*";
                dlgSave.FilterIndex = 1;
                dlgSave.AddExtension = true;
                dlgSave.DefaultExt = ".xlsx";
                if (dlgSave.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    exBook.SaveAs(dlgSave.FileName.ToString());//Lưu file Excel         
                exApp.Quit();//Thoát khỏi ứng dụng            
            }
            else MessageBox.Show("Không có danh sách hàng để in");
        }
    }
}