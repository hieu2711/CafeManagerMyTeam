using QuanLyQuanCafe.DAO;
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
    public partial class fAddStaff : Form
    {
        public fAddStaff()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        private void btnThemNVTK_Click(object sender, EventArgs e)
        {
            int cv = 0;
            string hoVaTen = txtNVTK_HoVaTen.Text;
            string ngaySinh = (dtpNVTK_NgaySinh.Value).ToString();
            string ngayVaoLam = (dtpNVTK_NgayVaoLam.Value).ToString();
            string gioiTinh = cbGioiTinh.Text;
            string soDienThoai = txtNVTK_SoDienThoai.Text;
            string username = txtNVTK_Username.Text;
            string password = txtNVTK_PassWord.Text;
            string chucVu = cbChucVu.Text;

            string pass = HashPassword(password);

            if (chucVu == "Nhân viên")
            {
                cv = 1;
            }
            else
            {
                cv = 0;
            }

            if (AccountDAO.Instance.CheckUsername(username) == false)
            {
                DateTime year = DateTime.Now;
                DateTime y = dtpNVTK_NgaySinh.Value;
               
                string[] a;
                a = ngaySinh.Split('-');


                if (year.Year - y.Year > 16)
                {

                    if (StaffDAO.Instance.InsertStaff(hoVaTen, ngaySinh, gioiTinh, soDienThoai, ngayVaoLam, chucVu))
                    {
                        if (AccountDAO.Instance.InsertAccount(username, pass, StaffDAO.Instance.GetMaxStaffId(), cv))
                        {
                            MessageBox.Show("Thêm thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại");
                        }
                    }
                }
                else

                {
                    MessageBox.Show("Thêm thất bại");
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã có vui lòng sửa lại");
            }
        }
    }
}
