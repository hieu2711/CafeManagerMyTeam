using DTO.DTO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class ProductDAO
    {
        private static ProductDAO instance;

        public static ProductDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProductDAO();
                return ProductDAO.instance;
            }
            private set { ProductDAO.instance = value; }
        }

        private ProductDAO() { }

        public List<Product> GetProductBycategoryId(int id)
        {
            List<Product> listProduct = new List<Product>();

            string query = "SELECT * FROM dbo.SanPham WHERE ID_LoaiSanPham = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                listProduct.Add(product);
            }

            return listProduct;
        }

        public List<Product> GetlistProduct()
        {
            List<Product> list = new List<Product>();

            string query = "Select * from dbo.SanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product product = new Product(item);
                list.Add(product);
            }

            return list;
        }

        public bool InsertProduct(string TenSanPham, string DonViTinh, float DonGia, int categaryId, string size)
        {
            string query = string.Format("INSERT INTO dbo.SanPham (TenSanPham, DonViTinh, DonGia, ID_LoaiSanPham, Size) VALUES (N'{0}', N'{1}', {2}, {3}, N'{4}')", TenSanPham, DonViTinh, DonGia, categaryId, size);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool UpdateProduct(string TenSanPham, string DonViTinh, float DonGia, int categaryId, string size, int idProduct)
        {
            string query = string.Format("UPDATE dbo.SanPham SET TenSanPham = N'{0}', DonViTinh = N'{1}',DonGia = {2}, ID_LoaiSanPham = {3}, Size = N'{4}' WHERE SanPhamID = {5}", TenSanPham, DonViTinh, DonGia, categaryId, size, idProduct);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public bool DeleteProduct(int idProduct)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIdProduct(idProduct);

            string query = string.Format("DELETE dbo.SanPham WHERE SanPhamID = " + idProduct);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        public int GetProductIdByCategaryId(int idCategary)
        {
            string query = "SELECT * FROM dbo.SanPham WHERE ID_LoaiSanPham = " + idCategary;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Product id = new Product(data.Rows[0]);
                return id.ProductId;
            }

            return -1;

        }

        public bool DeleteProductByCategaryId(int idcategary)
        {
            BillInfoDAO.Instance.DeleteBillInfoByIdProduct(GetIdProductByIdCategory(idcategary));

            DeleteProduct(GetProductIdByCategaryId(idcategary));

            string query = string.Format("DELETE dbo.SanPham WHERE ID_LoaiSanPham = " + idcategary);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result >= 0;
        }

        
        public List<Product> SearchProductByName(string name)
        {
            List<Product> listProduct = new List<Product>();

            string query = string.Format("SELECT * FROM dbo.SanPham WHERE dbo.fuConvertToUnsign1(TenSanPham) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", name);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Product Product = new Product(item);
                listProduct.Add(Product);
            }

            return listProduct;
        }

        public List<ProductStatistics> getListCountProduct()
        {
            List<ProductStatistics> list = new List<ProductStatistics>();

            string query = "SELECT sp.TenSanPham, COUNT(*) as N'Total' FROM ChiTietHoaDon as ct , SanPham as sp WHERE ct.ID_SanPham = sp.SanPhamID GROUP BY sp.TenSanPham";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProductStatistics tk = new ProductStatistics(item);
                list.Add(tk);
            }

            return list;
        }

        public List<ProductStatistics> GetListCountProductByMonth(int month, int year)
        {
            List<ProductStatistics> list = new List<ProductStatistics>();

            string query = string.Format("SELECT sp.TenSanPham, COUNT(*) as N'Total' FROM ChiTietHoaDon as ct, SanPham as sp, HoaDon as h WHERE ct.ID_SanPham = sp.SanPhamID AND h.HoaDonID = ct.ID_HoaDon AND MONTH(DateCheckOut) = {0} AND YEAR(DateCheckOut) = {1} GROUP BY sp.TenSanPham", month, year);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                ProductStatistics tk = new ProductStatistics(item);
                list.Add(tk);
            }

            return list;
        }

        public int GetIdProductByIdCategory(int idCategory)
        {
            string query = "SELECT * FROM dbo.SanPham WHERE ID_LoaiSanPham = " + idCategory;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            if (data.Rows.Count > 0)
            {
                Product id = new Product(data.Rows[0]);
                return id.ProductId;
            }

            return -1;
        }
    }
}
