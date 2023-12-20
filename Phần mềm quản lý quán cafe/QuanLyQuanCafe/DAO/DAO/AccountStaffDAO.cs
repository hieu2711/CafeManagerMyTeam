using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class AccountStaffDAO
    {
        private static AccountStaffDAO instance;

        public static AccountStaffDAO Instance 
        {
            get
            {
                if (instance == null)
                    instance = new AccountStaffDAO();
                return AccountStaffDAO.instance;
            }
            private set { AccountStaffDAO.instance = value; }
        }

        private AccountStaffDAO() { }

        public List<AccountStaff> GetListStaffAndAccountByTableStaffAccount()
        {
            List<AccountStaff> listStaffInfo = new List<AccountStaff>();

            string query = "Select n.NhanVienID, n.HoVaTen, n.NgaySinh, n.GioiTinh, n.SoDienThoai, n.NgayVaoLam, n.ChucVu, t.Username, t.PassWord From dbo.TaiKhoan as t, dbo.NhanVien as n WHERE n.NhanVienID = t.ID_NhanVien";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AccountStaff info = new AccountStaff(item);
                listStaffInfo.Add(info);
            }

            return listStaffInfo;
        }

        public List<AccountStaff> SearchStaffByName(string name)
        {
            List<AccountStaff> listStaff = new List<AccountStaff>();

            string query = string.Format("SELECT * FROM dbo.NhanVien as nv, dbo.TaiKhoan as t WHERE nv.NhanVienID = t.ID_NhanVien AND dbo.fuConvertToUnsign1(HoVaTen) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                AccountStaff staff = new AccountStaff(item);
                listStaff.Add(staff);
            }

            return listStaff;
        }
    }
}
