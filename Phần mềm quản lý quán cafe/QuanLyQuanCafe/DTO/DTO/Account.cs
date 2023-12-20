using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Account
    {
        public Account(string username, string password, int nhanVienId, int chucVu)
        {
            this.Username = username;
            this.Password = password;
            this.NhanVienId = nhanVienId;
            this.ChucVu = chucVu;
        }

        public Account(DataRow row)
        {
            this.Username = row["Username"].ToString();
            this.Password = row["PassWord"].ToString();
            this.NhanVienId = (int)row["ID_NhanVien"];
            this.ChucVu = (int)row["ChucVu"];
        }

        private string username;
        private string password;
        private int nhanVienId;
        private int chucVu;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int NhanVienId { get => nhanVienId; set => nhanVienId = value; }
        public int ChucVu { get => chucVu; set => chucVu = value; }
    }
}
