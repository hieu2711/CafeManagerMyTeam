using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return CategoryDAO.instance;
            }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> listDanhMuc = new List<Category>();

            string query = "Select * from dbo.LoaiSanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                listDanhMuc.Add(category);
            }

            return listDanhMuc;
        }

        public Category GetDanhMucById(int id)
        {
            Category categary = null;

            string query = "Select * from dbo.LoaiSanPham where LoaiSanPhamID = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                categary = new Category(item);
                return categary;
            }

            return categary;
        }

        public bool InsertCategary(string TenDanhMuc)
        {
            string query = string.Format("INSERT INTO dbo.LoaiSanPham (LoaiSanPham) Values(N'{0}')", TenDanhMuc);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateCategary(string TenDanhMuc, int id)
        {
            string query = string.Format("UPDATE dbo.LoaiSanPham SET LoaiSanPham = N'{0}' WHERE LoaiSanPhamID = {1}", TenDanhMuc, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteCategary(int idCategary)
        {
            ProductDAO.Instance.DeleteProductByCategaryId(idCategary);

            string query = string.Format("DELETE dbo.LoaiSanPham WHERE LoaiSanPhamID = " + idCategary);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

    }
}
