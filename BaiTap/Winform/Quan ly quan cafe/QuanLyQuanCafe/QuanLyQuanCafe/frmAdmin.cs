using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class frmAdmin : Form
    {

        private Account loginAccount;
        public Account LoginAccount
        {
            get
            {
                return loginAccount;
            }

            set
            {
                loginAccount = value;
            }
        }
        int page = 1;
        #region BindingSource

        BindingSource listFood = new BindingSource();
        BindingSource listFoodCategory = new BindingSource();
        BindingSource listTable = new BindingSource();
        BindingSource listAccount = new BindingSource();
        #endregion

        #region createEvent
        private event EventHandler _onInsertedFood;
        public event EventHandler OnInsertedFood
        {
            add { _onInsertedFood += value; }
            remove { _onInsertedFood -= value; }
        }

        private event EventHandler _onUpdatedFood;
        public event EventHandler OnUpdatedFood
        {
            add { _onUpdatedFood += value; }
            remove { _onUpdatedFood -= value; }
        }

        private event EventHandler _onDeletedFood;
        public event EventHandler OnDeletedFood
        {
            add { _onDeletedFood += value; }
            remove { _onDeletedFood -= value; }
        }

        private event EventHandler _onInsertedCategory;
        public event EventHandler OnInsertedCategory
        {
            add { _onInsertedCategory += value; }
            remove { _onInsertedCategory -= value; }
        }

        private event EventHandler _onUpdatedCategory;
        public event EventHandler OnUpdatedCategory
        {
            add { _onUpdatedCategory += value; }
            remove { _onUpdatedCategory -= value; }
        }

        private event EventHandler _onDeletedCategory;
        public event EventHandler OnDeletedCategory
        {
            add { _onDeletedCategory += value; }
            remove { _onDeletedCategory -= value; }
        }

        private event EventHandler _onInsertedTable;
        public event EventHandler OnInsertedTable
        {
            add { _onInsertedTable += value; }
            remove { _onInsertedTable -= value; }
        }

        private event EventHandler _onUpdatedTable;
        public event EventHandler OnUpdatedTable
        {
            add { _onUpdatedTable += value; }
            remove { _onUpdatedTable -= value; }
        }

        private event EventHandler _onDeletedTable;
        public event EventHandler OnDeletedTable
        {
            add { _onDeletedTable += value; }
            remove { _onDeletedTable -= value; }
        }

        private event EventHandler _onUpdatedAccount;
        public event EventHandler OnUpdatedAccount
        {
            add { _onUpdatedAccount += value; }
            remove { _onUpdatedAccount -= value; }
        }

        private event EventHandler _onRepasswordAccount;
        public event EventHandler OnRePasswordAccount
        {
            add { _onRepasswordAccount += value; }
            remove { _onRepasswordAccount -= value; }
        }

        #endregion

        public frmAdmin(Account account)
        {
            InitializeComponent();
            LoginAccount = account;
            LoadAll();
            AddBinding();
        }

        #region Method
        private void LoadAll()
        {
            dtgvFood.DataSource = listFood;
            dtgvCategory.DataSource = listFoodCategory;
            dtgvTable.DataSource = listTable;
            dtgvAccount.DataSource = listAccount;

            LoadDateTimePicker();
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value);
            LoadListFood();
            LoadListCategory();
            LoadListTable();
            LoadListAccount();
            LoadTableStatus();
            LoadAccountType();
        }

        private void LoadAccountType()
        {
            List<string> type = new List<string>() { "Admin", "Nhân viên" };
            cbAccountType.DataSource = type;
        }

        private void LoadTableStatus()
        {
            List<string> status = new List<string>() { "Có người", "Trống" };
            cbTableStatus.DataSource = status;
        }

        private void AddBinding()
        {
            AddFoodBinding();
            AddFoodCategoryBinding();
            AddTableBinding();
            AddAccountBinding();
        }

        private void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "tên thức ăn", true, DataSourceUpdateMode.Never));
            txbID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            numFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "đơn giá", true, DataSourceUpdateMode.Never));
        }

        void AddFoodCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "tên danh mục", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "tên bàn", true, DataSourceUpdateMode.Never));
        }

        void AddAccountBinding()
        {
            txbAccountUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "tên đăng nhập", true, DataSourceUpdateMode.Never));
            txbAccountDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "tên hiển thị", true, DataSourceUpdateMode.Never));
        }

        void LoadDateTimePicker()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void LoadListBillByDateAndPage(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetListBillByDateAndPage(checkIn, checkOut, int.Parse(lblPage.Text), (int)PageRows.THIRD);
        }

        private void LoadListFood()
        {
            listFood.DataSource = FoodDAO.Instance.GetListFood2();
        }

        private void LoadListCategory()
        {
            cbFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbFoodCategory.DisplayMember = "Name";
            listFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory2();
        }

        private void LoadListTable()
        {
            listTable.DataSource = TableDAO.Instance.GetListTable();
        }


        private void LoadListAccount()
        {
            listAccount.DataSource = AccountDAO.Instance.GetListAccount2();
        }
        #endregion

        #region Events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnShowFood_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            listFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory2();
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTable();
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadListAccount();
        }

        private void txbID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string categoryName = dtgvFood.SelectedRows[0].Cells["danh mục"].Value.ToString();
                int index = 0;
                foreach (Category item in cbFoodCategory.Items)
                {
                    if (item.Name.Equals(categoryName))
                    {
                        break;
                    }
                    index++;
                }
                cbFoodCategory.SelectedIndex = index;
            }
            catch
            {
            }
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string foodName = txbFoodName.Text;
            int idCategory = (cbFoodCategory.SelectedItem as Category).Id;
            int price = (int)numFoodPrice.Value;
            if (FoodDAO.Instance.InsertFood(foodName, idCategory, price))
            {
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFood();
                if (_onInsertedFood != null)
                {
                    _onInsertedFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm thức ăn thất bại");
            }
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int idFood = int.Parse(txbID.Text);
            string foodName = txbFoodName.Text;
            int idCategory = (cbFoodCategory.SelectedItem as Category).Id;
            int price = (int)numFoodPrice.Value;
            if (FoodDAO.Instance.UpdateFood(idFood, foodName, idCategory, price))
            {
                MessageBox.Show("Sửa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadListFood();
                if (_onUpdatedFood != null)
                {
                    _onUpdatedFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa thông tin thức ăn thất bại!");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbID.Text);
            DialogResult result = MessageBox.Show("Bạn có muốn xóa thức ăn có ID = " + id + " không !", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                BillInfoDAO.Instance.DeleteBillInfoByIdFood(id);
                FoodDAO.Instance.DeleteFood(id);
                MessageBox.Show("Xoá thành công!");
                LoadListFood();
                if (_onDeletedFood != null)
                {
                    _onDeletedFood(this, new EventArgs());
                }
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadListCategory();
                LoadListFood();
                if (_onInsertedCategory != null)
                {
                    _onInsertedCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Thêm danh mục thất bại!");
            }
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbCategoryID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa danh mục  có ID " + txbCategoryID.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (CategoryDAO.Instance.DeleteCategory(id))
                {
                    MessageBox.Show("Xoá danh mục thành công!");
                    LoadListCategory();
                    LoadListFood();
                    if (_onDeletedCategory != null)
                    {
                        _onDeletedCategory(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Xoá danh mục thất bại!");
                }
            }
        }

        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbCategoryID.Text);
            string name = txbCategoryName.Text;
            if (CategoryDAO.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa thông tin danh mục thành công!");
                LoadListCategory();
                LoadListFood();
                if (_onUpdatedCategory != null)
                {
                    _onUpdatedCategory(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa thông tin danh mục thất bại!");
            }
        }

        private void txbTableID_TextChanged(object sender, EventArgs e)
        {
            string status = dtgvTable.SelectedRows[0].Cells["trạng thái"].Value.ToString();
            if (status.Equals("Có người"))
                cbTableStatus.SelectedIndex = 0;
            else
                cbTableStatus.SelectedIndex = 1;
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string name = txbTableName.Text;
            if (TableDAO.Instance.InsertTable(name))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadListTable();
                if (_onInsertedTable != null)
                    _onInsertedTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!");
            }
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbTableID.Text);
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa bàn có ID " + txbTableID.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (TableDAO.Instance.DeleteTable(id))
                {
                    MessageBox.Show("Xoá bàn ăn thành công!");
                    LoadListTable();
                    if (_onDeletedTable != null)
                        _onDeletedTable(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Xoá bàn ăn thất bại!");
                }
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txbTableID.Text);
            string name = txbTableName.Text;
            if (TableDAO.Instance.UpdateTable(id, name))
            {
                MessageBox.Show("Sửa thông tin bàn thành công!");
                LoadListTable();
                if (_onUpdatedTable != null)
                    _onUpdatedTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa thông tin bàn thất bại!");
            }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            listFood.DataSource = FoodDAO.Instance.SearchFoodByName(txbSearchFoodName.Text);
        }

        private void txbAccountUserName_TextChanged(object sender, EventArgs e)
        {
            string type = dtgvAccount.SelectedRows[0].Cells["loại tài khoản"].Value.ToString();
            if (type.Equals("Admin"))
                cbAccountType.SelectedIndex = 0;
            else
                cbAccountType.SelectedIndex = 1;
        }

        private void btnAddAcount_Click(object sender, EventArgs e)
        {
            int type = cbAccountType.SelectedItem.Equals("Admin") ? 1 : 0;
            string userName = txbAccountUserName.Text;
            string displayName = txbAccountDisplayName.Text;

            foreach (string item in AccountDAO.Instance.GetListUserName())
            {
                if (item.Equals(userName))
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (AccountDAO.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                LoadListAccount();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = dtgvAccount.SelectedRows[0].Cells["tên đăng nhập"].Value.ToString();
            if (loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Bạn không thể tự xóa tài khoản của mình");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản có tên đăng nhập là " + userName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (AccountDAO.Instance.DeleteAccount(userName))
                {
                    MessageBox.Show("Xoá tài khoản thành công!");
                    LoadListAccount();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string oldUserName = dtgvAccount.SelectedRows[0].Cells["tên đăng nhập"].Value.ToString();
            int type = cbAccountType.SelectedItem.Equals("Admin") ? 1 : 0;
            string userName = txbAccountUserName.Text;
            string displayName = txbAccountDisplayName.Text;

            if (AccountDAO.Instance.UpdateAccountByAdmin(oldUserName, userName, displayName, type))
            {
                MessageBox.Show("Sửa tài khoản thành công!");
                LoadListAccount();
                if (_onUpdatedAccount != null)
                    _onUpdatedAccount(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa tài khoản thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = dtgvAccount.SelectedRows[0].Cells["tên đăng nhập"].Value.ToString();
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đặt lại mật khẩu tài khoản có tên đăng nhập là " + userName + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (AccountDAO.Instance.ResetPassword(userName))
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!");
                    LoadListAccount();
                    if (userName.Equals(LoginAccount.UserName))
                        if (_onRepasswordAccount != null)
                            _onRepasswordAccount(this, new EventArgs());
                }
                else
                {
                    MessageBox.Show("Đặt lại mật khẩu thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            page = 1;
            lblPage.Text = "1";
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            page = PageMax();
            lblPage.Text = page.ToString();
        }

        private int PageMax()
        {
            int pageRows = (int)PageRows.THIRD;
            int pageMax;
            int billCount = BillDAO.Instance.GetCountBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            if (billCount % pageRows == 0) pageMax = billCount / pageRows;
            else pageMax = billCount / pageRows + 1;
            return pageMax;
        }

        private void btnPrivious_Click(object sender, EventArgs e)
        {
            if (page == 1) return;
            page -= 1;
            lblPage.Text = page.ToString();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (page == PageMax()) return;
            page += 1;
            lblPage.Text = page.ToString();
        }

        private void btnGoPage_Click(object sender, EventArgs e)
        {
            if ((int)numGoPage.Value > PageMax())
            {
                MessageBox.Show("Trang không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            page = (int)numGoPage.Value;
            lblPage.Text = page.ToString();
        }

        private void lblPage_TextChanged(object sender, EventArgs e)
        {
            LoadListBillByDateAndPage(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion
    }

    enum PageRows
    {
        THIRD = 3,
        FIVE = 5,
        TEN = 10,
        TWENTY = 20
    }
}