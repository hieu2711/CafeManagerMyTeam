using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new StaffDAO();
                return StaffDAO.instance;
            }
            private set { StaffDAO.instance = value; }
        }

        private StaffDAO() { }

        //Lấy thông tin nhân viên
        public List<Staff> GetListStaff()
        {
            List<Staff> listStaff = new List<Staff>();

            string query = "Select * from dbo.NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Staff nv = new Staff(item);
                listStaff.Add(nv);
            }

            return listStaff;
        }

        public int GetMaxStaffId()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScala("SELECT MAX(NhanVienID) FROM dbo.NhanVien");
            }
            catch
            {
                return 1;
            }
        }

        public bool InsertStaff(string HoVaTen, string NgaySinh, string GioiTinh, string SoDienThoai, string NgayVaoLam, string chucVu)
        {
            string query = string.Format("INSERT INTO dbo.NhanVien( HoVaTen, NgaySinh, GioiTinh, SoDienThoai, NgayVaoLam, ChucVu) Values ( N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", HoVaTen, NgaySinh, GioiTinh, SoDienThoai, NgayVaoLam, chucVu);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateStaff(string HoVaTen, string NgaySinh, string GioiTinh, string SoDienThoai, string NgayVaoLam, string chucVu, int id)
        {
            string query = string.Format("UPDATE dbo.NhanVien SET HoVaTen = N'{0}', NgaySinh = N'{1}', GioiTinh = N'{2}', SoDienThoai = N'{3}', NgayVaoLam = N'{4}', ChucVu = N'{5}' WHERE NhanVienID = {6}", HoVaTen, NgaySinh, GioiTinh, SoDienThoai, NgayVaoLam, chucVu, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteStaff(int idStaff)
        {
            AccountDAO.Instance.DeleteAccount(idStaff);

            string query = string.Format("DELETE dbo.NhanVien WHERE NhanVienID = " + idStaff);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        //Lấy không tin nhân viên theo username
        public Staff GetStaffByUsername(string username)
        {
            string query = "SELECT * FROM dbo.TaiKhoan as tk, dbo.NhanVien as nv WHERE tk.ID_NhanVien = nv.NhanVienID AND Username = N'" + username + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                return new Staff(item);
            }

            return null;
        }

       
    }
}
