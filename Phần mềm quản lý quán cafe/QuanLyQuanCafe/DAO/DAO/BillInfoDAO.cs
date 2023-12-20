using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new BillInfoDAO();
                return BillInfoDAO.instance;
            }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> billList = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * From dbo.ChiTietHoaDon where ID_HoaDon = " + id);

            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                billList.Add(info);
            }

            return billList;
        }

        public void InsertBillInfo(int idBill, int idProduct, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @idBill , @idProduct , @count ", new object[] { idBill, idProduct, count });
        }

        public void DeleteBillInfoByIdProduct(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.ChiTietHoaDon WHERE ID_SanPham = " + id);
        }

        public void DeleteBillInfoByIdBill(int id)
        {
            DataProvider.Instance.ExecuteQuery("DELETE dbo.ChiTietHoaDon WHERE ID_HoaDon = " + id);
        }

        public int GetBillInfoByBillId (int idBill)
        {
            string query = "SELECT * FROM dbo.ChiTietHoaDon WHERE ID_HoaDon = " + idBill;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                BillInfo id = new BillInfo(data.Rows[0]);
                return id.Id;
            }

            return -1;
        }

   
    }
}
