using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;

namespace QuanLyQuanCafe
{
    public partial class frmTableManager : Form
    {
        private Account account;
        public Account Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
                ChangeAccount(account);
            }
        }

        public frmTableManager(Account acc)
        {
            InitializeComponent();
            this.Account = acc;
            LoadTable();
            LoadFoodCategory();
            LoadComboBoxTable();
        }

        #region Methods
        void ChangeAccount(Account acc)
        {
            adminToolStripMenuItem.Enabled = acc.Type == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text = " Thông tin tài khoản (" + acc.DisplayName + ")";
        }
        void ReLoadOnFoodEvent()
        {
            LoadTable();
            LoadFoodListByCategoryID((cbFoodCategory.SelectedItem as Category).Id);
            if (liVBill.Tag != null) ShowBill(GetTableByListViewTag().ID);
        }

        private void Admin_OnUpdatedFood(object sender, EventArgs e)
        {
            ReLoadOnFoodEvent();
        }

        private void Admin_OnInsertedFood(object sender, EventArgs e)
        {
            ReLoadOnFoodEvent();
        }

        private void Admin_OnDeletedFood(object sender, EventArgs e)
        {
            ReLoadOnFoodEvent();
        }

        void ReloadOnCategoryEvent()
        {
            LoadFoodCategory();
            ReLoadOnFoodEvent();
        }

        private void Admin_OnUpdatedCategory(object sender, EventArgs e)
        {
            ReloadOnCategoryEvent();
        }

        private void Admin_OnInsertedCategory(object sender, EventArgs e)
        {
            ReloadOnCategoryEvent();
        }

        private void Admin_OnDeletedCategory(object sender, EventArgs e)
        {
            ReloadOnCategoryEvent();
        }

        public void ReloadOnTableEvent()
        {
            LoadTable();
            liVBill.Items.Clear();
        }

        private void Admin_OnDeletedTable(object sender, EventArgs e)
        {
            ReloadOnTableEvent();
        }

        private void Admin_OnUpdatedTable(object sender, EventArgs e)
        {
            ReloadOnTableEvent();
        }

        private void Admin_OnInsertedTable(object sender, EventArgs e)
        {
            ReloadOnTableEvent();
        }

        private void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tablesList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tablesList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.BlueViolet;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        private void ShowBill(int tableID)
        {
            liVBill.Items.Clear();
            List<DTO.Menu> listMenu = MenuDAO.Instance.GetListMenuByTable(tableID);
            float totalPrice = 0;
            foreach (DTO.Menu item in listMenu)
            {
                ListViewItem lvItem = new ListViewItem(item.FoodName.ToString());
                lvItem.SubItems.Add(item.Count.ToString());
                lvItem.SubItems.Add(item.Price.ToString());
                lvItem.SubItems.Add(item.TotalPrice.ToString());
                liVBill.Items.Add(lvItem);
                totalPrice += item.TotalPrice;
            }

            CultureInfo culture = new CultureInfo("vi-VN");
            // Cach 2 : Format ://Thread.CurrentThread.CurrentCulture = culture;
            txbTotalPrice.Text = totalPrice.ToString("c", culture);
        }

        private void LoadFoodCategory()
        {
            cbFoodCategory.DataSource = CategoryDAO.Instance.GetListCategory();
            cbFoodCategory.DisplayMember = "name";
        }

        private void LoadFoodListByCategoryID(int categoryID)
        {
            cbFood.DataSource = FoodDAO.Instance.GetListFoodByCategoryID(categoryID);
            cbFood.DisplayMember = "name";
        }

        private Table GetTableByListViewTag()
        {
            return liVBill.Tag as Table;
        }

        private int GetBillIDByTable(Table table, string service)
        {
            if (table == null)
            {
                MessageBox.Show("Bạn chưa chọn bàn để " + service + "!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -2;
            }
            return BillDAO.Instance.GetUncheckOutBillIDByTableID(table.ID);
        }

        private void LoadComboBoxTable()
        {
            cbSwitchTable.DataSource = TableDAO.Instance.LoadTableList();
            cbSwitchTable.DisplayMember = "Name";
        }
        #endregion

        #region Events
        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowBill(tableID);
            liVBill.Tag = (sender as Button).Tag;
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccount account = new frmAccount(Account);
            account.OnUpdatedAccount += Account_OnUpdatedAccount;

            account.ShowDialog();
        }

        private void Account_OnUpdatedAccount(object sender, AccountEvent e)
        {
            if (e.TypeUpdate == 0)
            {
                thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ")";
            }
            else
            {
                MessageBox.Show("Bạn phải đăng nhập lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAdmin admin = new frmAdmin(Account);
            admin.OnDeletedFood += Admin_OnDeletedFood;
            admin.OnInsertedFood += Admin_OnInsertedFood;
            admin.OnUpdatedFood += Admin_OnUpdatedFood;

            admin.OnDeletedCategory += Admin_OnDeletedCategory;
            admin.OnInsertedCategory += Admin_OnInsertedCategory;
            admin.OnUpdatedCategory += Admin_OnUpdatedCategory;

            admin.OnInsertedTable += Admin_OnInsertedTable;
            admin.OnUpdatedTable += Admin_OnUpdatedTable;
            admin.OnDeletedTable += Admin_OnDeletedTable;

            admin.OnUpdatedAccount += Admin_OnUpdatedAccount;
            admin.OnRePasswordAccount += Admin_OnRePasswordAccount;
            admin.ShowDialog();
        }

        private void Admin_OnRePasswordAccount(object sender, EventArgs e)
        {
            Form frm = sender as Form;
            RePasswordEvent(frm);
        }

        private void RePasswordEvent(Form frm)
        {
            frm.Close();
            this.Close();
            MessageBox.Show("Bạn phải đăng nhập lại ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Admin_OnUpdatedAccount(object sender, EventArgs e)
        {
            string userName = Account.UserName;
            Account = AccountDAO.Instance.GetAccountByUserName(userName);
        }

        private void cbFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox.SelectedItem == null) return;
            int categoryID = (comboBox.SelectedItem as Category).Id;
            LoadFoodListByCategoryID(categoryID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = GetTableByListViewTag();
            int iDBill = GetBillIDByTable(table, "thêm món");
            if (iDBill == -2) return;

            int foodID = (cbFood.SelectedItem as Food).ID;
            int count = (int)numFoodCount.Value;
            if (count == 0) return;
            if (iDBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBillID(), foodID, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(iDBill, foodID, count);
            }
            ShowBill(table.ID);
            LoadTable();
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = GetTableByListViewTag();
            int iDBill = GetBillIDByTable(table, "thanh toán");
            if (iDBill == -2) return;

            int discount = (int)numDiscount.Value;
            double totalPrice;
            if (txbTotalPrice.Text.Split(',')[0].Contains("."))
            {
                string[] priceSplit = txbTotalPrice.Text.Split(',')[0].Split('.');
                string temp = "";
                for (int i = 0; i < priceSplit.Length; i++)
                {
                    temp += priceSplit[i];
                }
                totalPrice = Convert.ToDouble(temp);
            }
            else
            {
                totalPrice = float.Parse(txbTotalPrice.Text.Split(',')[0]);
            }
            double finalTotalPrice = totalPrice - totalPrice * discount / 100;

            if (iDBill != -1)
            {
                DialogResult result = MessageBox.Show(String.Format("Bạn có muốn thanh toán hóa đơn cho {0} \nThanh toán tiền = tổng tiền - tổng tiền * giảm giá / 100  \n=>  {1} - {1} * {2} / 100 = {3}", table.Name, totalPrice, discount, finalTotalPrice), "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    BillDAO.Instance.CheckOut(iDBill, discount, (float)finalTotalPrice);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            Table table1 = GetTableByListViewTag();
            Table table2 = cbSwitchTable.SelectedItem as Table;
            if (table1 == null || table1.Equals(table2)) return;
            DialogResult result = MessageBox.Show(String.Format("Bạn có thật sự muốn chuyển bàn từ {0} sang {1}", table1.Name, table2.Name), "Chuyển bàn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                TableDAO.Instance.SwitchTale(table1.ID, table2.ID);
            }
            LoadTable();
        }
        #endregion

    }
}
