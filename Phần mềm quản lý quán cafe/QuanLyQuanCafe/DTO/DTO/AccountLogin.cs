using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class AccountLogin
    {
        public AccountLogin(string username, string password = null)
        {
            this.Username = username;
            this.Password = password;
        }

        public AccountLogin(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.Password = row["PassWord"].ToString();
        }

        private string username;
        private string password;
        

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        

    }
}
