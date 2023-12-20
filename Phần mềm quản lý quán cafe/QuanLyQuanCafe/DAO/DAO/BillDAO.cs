using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillDAO();
                return BillDAO.instance;
            }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }

        public int GetIdByTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.HoaDon where SoBanDaDung =" + id + " AND TrangThai = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }

            return -1;
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBill @idTable", new object[] { id });
        } 

        public int GetMaxBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScala(" SELECT MAX(HoaDonID) FROM dbo.HoaDon");
            }
            catch
            {
                return 1;
            }
        }

        public void checkOutBill(int id, float totalPrice)
        {
            string query = "UPDATE dbo.HoaDon SET DateCheckout = GETDATE() , TrangThai = 1 , totalPrice = " + totalPrice + " WHERE HoaDonID = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public int GetidBillBytableId(int idTable)
        {
            string query = "SELECT * FROM dbo.HoaDon WHERE SoBanDaDung = " + idTable;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Bill id = new Bill(data.Rows[0]);
                return id.Id;
            }

            return -1;
        }


        public bool DeleteBillBytableID(int id)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIdBill(GetidBillBytableId(id));

            string query = string.Format("DELETE dbo.HoaDon WHERE SoBanDaDung = " + id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;

        }

        public List<RevenueStatistics> getListDoanhThuThang()
        {
            List<RevenueStatistics> list = new List<RevenueStatistics>();

            string query = "SELECT MONTH(DateCheckOut) as N'Month',  SUM(totalPrice) as N'Doanh Thu' FROM dbo.HoaDon Where TrangThai = 1 Group by MONTH(DateCheckOut)";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                RevenueStatistics tk = new RevenueStatistics(item);
                list.Add(tk);
            }

            return list;
        }

        public List<RevenueStatistics> getListDoanhThuTheoThang(int month, int year)
        {
            List<RevenueStatistics> list = new List<RevenueStatistics>();

            string query = string.Format("SELECT MONTH(DateCheckOut) as N'Month',  SUM(totalPrice) as N'Doanh Thu' FROM dbo.HoaDon Where MONTH(DateCheckOut) = {0} AND YEAR(DateCheckOut) = {1} AND TrangThai = 1 Group by MONTH(DateCheckOut)", month, year);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                RevenueStatistics tk = new RevenueStatistics(item);
                list.Add(tk);
            }

            return list;
        }
    }
}
