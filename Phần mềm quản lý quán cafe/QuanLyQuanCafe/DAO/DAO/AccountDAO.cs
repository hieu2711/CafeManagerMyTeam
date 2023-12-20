using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                if (instance == null)
                    instance = new AccountDAO();
                return AccountDAO.instance;
            }
            private set { AccountDAO.instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = "USP_Login @username , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {username, password});

            return result.Rows.Count > 0;
        }

        public bool CheckUsername(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.TaiKhoan WHERE Username = N' " + username + " '");

            if (data.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }

        public int GetIdByUsername(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from dbo.TaiKhoan Where Username = '" + username + "' AND ChucVu = 0");

            if (data.Rows.Count > 0)
            {
                Account account = new Account(data.Rows[0]);
                return account.NhanVienId;
            }

            return -1;
        }

        //Lấy thông tin tài khoản
        public List<Account> GetListAccount()
        {
            List<Account> listAccount = new List<Account>();

            string query = "Select * from dbo.TaiKhoan";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Account accountItem = new Account(item);
                listAccount.Add(accountItem);
            }

            return listAccount;
        }

        //Thêm tài khoản
        public bool InsertAccount(string username, string password, int idNV, int chucVu)
        {
            string query = string.Format("INSERT INTO dbo.TaiKhoan( Username, PassWord, ID_NhanVien, ChucVu) Values (N'{0}', N'{1}', {2}, {3})", username, password, idNV, chucVu);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        //Xóa tài khoản
        public bool DeleteAccount(int idStaff)
        {
            string query = string.Format("DELETE dbo.TaiKhoan WHERE ID_NhanVien = " + idStaff);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        //Lấy tài khoản bởi tên đăng nhập
        public AccountLogin GetAccountByUsername(string username)
        {
            string query = "SELECT * FROM dbo.TaiKhoan WHERE Username = N'" + username + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new AccountLogin(item);
            }

            return null;
        }

        public bool Update_Account(string username, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC Update_PasswordAccountStaff @username , @password , @newPassword", new object[] { username, pass, newPass });
            
            return result > 0;
        }
    }
}
