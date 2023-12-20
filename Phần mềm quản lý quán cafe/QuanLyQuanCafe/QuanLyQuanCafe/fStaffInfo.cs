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
using System.Security.Cryptography;

namespace QuanLyQuanCafe
{
    
    public partial class fStaffInfo : Form
    {
        private AccountLogin loginAccount;

        public AccountLogin LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changceAccount(loginAccount); }
        }

        public fStaffInfo(AccountLogin acc)
        {
            InitializeComponent();

            LoginAccount = acc;
            loadStaffInfo();
        }

        void changceAccount(AccountLogin acc)
        {
            txtTenDangNhap.Text = LoginAccount.Username;
            
        }

        //Mã hóa mật khẩu
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        //Hiển thị thông tin nhân viên đăng nhập
        void loadStaffInfo()
        {
            txtHovaTenNV.Text = StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).HoVaTen;
            txtNgaySinh.Text = (StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).NgaySinh).ToString();
            txtGioiTinh.Text = StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).GioiTinh;
            txtSDT.Text = StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).SoDienThoai;
            if (StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).ChucVu == "1")
            {
                txtChucVu.Text = "Nhân viên";
            } else
            {
                txtChucVu.Text = "Admin";
            }
            
            txtNgayVaoLam.Text = (StaffDAO.Instance.GetStaffByUsername(txtTenDangNhap.Text).NgayVaoLam).ToString();
        }

        //Thay đổi mật khẩu 
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text;
            string password = HashPassword(txtOldPassword.Text);
            string newPassword = HashPassword(txtNewPassword.Text);
            string newPasswordAgain = txtNewPasswordAgain.Text;

            if(!newPassword.Equals(newPasswordAgain))
            {
                MessageBox.Show("Mật khẩu mới chưa trùng khớp");
            } 
            else
            {
                if (AccountDAO.Instance.Update_Account(username, password, newPassword))
                {
                    MessageBox.Show("Cập nhật mật khẩu thành công");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu cũ");
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
