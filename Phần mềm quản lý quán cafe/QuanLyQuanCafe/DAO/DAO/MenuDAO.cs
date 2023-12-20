using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MenuDAO();
                return MenuDAO.instance;
            }
            private set { MenuDAO.instance = value; }
        }

        private MenuDAO() { }

        public List<MenuTable> GetListMenuByTable(int id)
        {
            List<MenuTable> listMenuTable = new List<MenuTable>();

            string query = "Select TenSanPham, DonViTinh, sp.Size, sp.DonGia, cthd.TongSanPham, cthd.TongSanPham * sp.DonGia as N'PriceTotal' from dbo.ChiTietHoaDon as cthd, dbo.HoaDon as hd, dbo.SanPham as sp where cthd.ID_HoaDon = hd.HoaDonID AND cthd.ID_SanPham = sp.SanPhamID AND hd.SoBanDaDung = " + id + " AND hd.TrangThai = 0";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MenuTable menu = new MenuTable(item);
                listMenuTable.Add(menu);
            }

            return listMenuTable;
        } 
    }
}
