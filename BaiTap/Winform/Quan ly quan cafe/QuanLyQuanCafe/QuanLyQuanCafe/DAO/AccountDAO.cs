using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null) instance = new AccountDAO();
                return instance;
            }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public bool Login(string userName, string password)
        {
            string hashPass = PasswordEncoding(password);

            string query = "EXEC USP_Login @userName , @password";
            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, hashPass });
            return result.Rows.Count > 0;
        }

        public string PasswordEncoding(string password)
        {

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hashPass = "";
            foreach (byte item in hashData)
            {
                hashPass += item;
            }
            return hashPass;
        }

        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from Account where UserName = N'" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool UpdateAccount(string userName, string displayName, string password, string newPass)
        {
            string encodePass = PasswordEncoding(newPass);
            int result = DataProvider.Instance.ExcuteNonQuery("Exec USP_UpdateAccount @userName , @displayName , @password , @newPassword ", new object[] { userName, displayName, password, encodePass });
            return result > 0;
        }

        public List<Account> GetListAccount()
        {
            List<Account> listAccount = new List<Account>();
            DataTable data = DataProvider.Instance.ExcuteQuery("Select * from Account");
            foreach (DataRow item in data.Rows)
            {
                listAccount.Add(new Account(item));
            }
            return listAccount;
        }

        public DataTable GetListAccount2()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT UserName AS [tên đăng nhập], DisplayName AS [tên hiển thị] , IIF(Type = 1,N'Admin',N'Nhân viên') AS [loại tài khoản] FROM dbo.Account");
        }

        public List<String> GetListUserName()
        {
            List<String> listUserName = new List<string>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT UserName FROM dbo.Account");
            foreach (DataRow item in data.Rows)
            {
                listUserName.Add(item["UserName"].ToString());
            }
            return listUserName;
        }

        public bool InsertAccount(string userName, string displayName, int type)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("INSERT dbo.Account (UserName ,DisplayName  ,Type , PassWord) VALUES( N'{0}' , N'{1}', {2} , N'{3}')", userName, displayName, type, "20720532132149213101239102231223249249135100218")) > 0;
        }

        public bool UpdateAccountByAdmin(string oldUserName, string userName, string displayName, int type)
        {
            return DataProvider.Instance.ExcuteNonQuery(string.Format("UPDATE dbo.Account  Set UserName = N'{0}', DisplayName = N'{1}', Type ={2} where UserName = N'{3}'", userName, displayName, type, oldUserName)) > 0;
        }

        public bool DeleteAccount(string userName)
        {
            string query = "DELETE FROM dbo.Account WHERE UserName = N'" + userName + "'";
            return DataProvider.Instance.ExcuteNonQuery(query) > 0;
        }

        public bool ResetPassword(string userName)
        {
            return DataProvider.Instance.ExcuteNonQuery("UPDATE dbo.Account set PassWord = N'20720532132149213101239102231223249249135100218' where userName = N'" + userName + "'") > 0;
        }
    }
}
