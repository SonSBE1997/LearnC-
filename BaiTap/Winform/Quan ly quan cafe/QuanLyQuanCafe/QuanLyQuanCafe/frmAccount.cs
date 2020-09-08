using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class frmAccount : Form
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
                LoadInfoAccount(loginAccount);
            }
        }

        private void LoadInfoAccount(Account loginAccount)
        {
            txbUserName.Text = loginAccount.UserName;
            txbDisplayName.Text = loginAccount.DisplayName;
        }

        public frmAccount(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }

        private void UpdateAccount()
        {
            string userName = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            string password = AccountDAO.Instance.PasswordEncoding(txbPassword.Text);
            string newPass = txbNewPassword.Text;
            string reEnterPass = txbReEnterPassword.Text;

            if (!checkPass(password, newPass, reEnterPass)) return;

            if (AccountDAO.Instance.UpdateAccount(userName, displayName, password, newPass))
            {
                MessageBox.Show("Cập nhật thành công!");
                LoginAccount.DisplayName = txbDisplayName.Text;
                txbDisplayName.Text = LoginAccount.DisplayName;
                this.Close();
                if (_onUpdatedAccount != null)
                {
                    if (newPass.Equals(""))
                        _onUpdatedAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName), 0));
                    else _onUpdatedAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(userName), 1));
                }
            }

        }

        private bool checkPass(string password, string newPass, string reEnterPass)
        {
            if (!password.Equals(LoginAccount.Password))
            {
                MessageBox.Show("Mật khẩu không đúng!");
                return false;
            }

            if (!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Mật khẩu mới không khớp");
                return false;
            }

            if (txbPassword.Text.Equals(newPass))
            {
                MessageBox.Show("Bạn không thể đặt mật khẩu mới trùng với mật khẩu hiện tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private event EventHandler<AccountEvent> _onUpdatedAccount;
        public event EventHandler<AccountEvent> OnUpdatedAccount
        {
            add { _onUpdatedAccount += value; }
            remove { _onUpdatedAccount -= value; }
        }
    }

    public class AccountEvent : EventArgs
    {
        private Account acc;
        private int typeUpdate;

        public Account Acc
        {
            get
            {
                return acc;
            }

            set
            {
                acc = value;
            }
        }

        public int TypeUpdate
        {
            get
            {
                return typeUpdate;
            }

            set
            {
                typeUpdate = value;
            }
        }

        public AccountEvent(Account account)
        {
            this.Acc = account;
        }

        public AccountEvent(Account account, int type)
        {
            this.Acc = account;
            this.TypeUpdate = type;
        }
    }
}