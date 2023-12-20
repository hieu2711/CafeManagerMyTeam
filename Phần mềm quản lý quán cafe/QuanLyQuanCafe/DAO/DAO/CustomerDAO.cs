using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;

        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerDAO();
                return CustomerDAO.instance;
            }
            private set { CustomerDAO.instance = value; }
        }

        private CustomerDAO() { }

        public List<Customer> GetListCustomer()
        {
            List<Customer> listCus = new List<Customer>();

            string query = "Select * from dbo.KhachHang";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Customer c = new Customer(item);
                listCus.Add(c);
            }

            return listCus;
        }

        public int GetCustomerIdByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer id = new Customer(data.Rows[0]);
                return id.IdKhachHang;
            }

            return -1;
        }

        public int GetDTLByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer diemTichLuy = new Customer(data.Rows[0]);
                return diemTichLuy.DiemTichLuy;
            }

            return -1;
        }

        public string GetNameCustomerByNumberPhone(string str)
        {
            string query = "SELECT * FROM dbo.KhachHang WHERE SoDienThoai = N'" + str + "'";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Customer name = new Customer(data.Rows[0]);
                return name.HoTen;
            }

            return null;
        }

        public bool InsertKhachHang(string tenKhachHang, string soDienThoai, int diemTichLuy)
        {
            string query = string.Format("INSERT INTO dbo.KhachHang(HoVaTen, SoDienThoai, DiemTichLuy) VALUES (N'{0}', N'{1}', {2})", tenKhachHang, soDienThoai, diemTichLuy);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateKhachHang(int id)
        {
            string query = string.Format("UPDATE dbo.KhachHang SET DiemTichLuy += 5 WHERE KhachHangID = {0}", id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateCustomerById(int id, string name, string phone)
        {
            string query = string.Format("UPDATE dbo.KhachHang SET HoVaTen = N'{0}' , SoDienThoai = {1} WHERE KhachHangID = {2}", name, phone, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteCustomerById(int id)
        {
            string query = string.Format("DELETE dbo.KhachHang WHERE KhachHangID = {0}",  id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }
    }
}
