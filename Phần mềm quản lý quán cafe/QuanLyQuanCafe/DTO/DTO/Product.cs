using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Product
    {
        public Product(int productId, string productName, string  donViTinh, string size, float donGia, int danhMucId)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.DonViTinh = donViTinh;
            this.Size = size;
            this.DonGia = donGia;
            this.DanhMucId = danhMucId;
        }

        public Product(DataRow row)
        {
            this.ProductId = (int)row["SanPhamID"];
            this.ProductName = row["TenSanPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.Size = row["Size"].ToString();
            this.DonGia = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.DanhMucId = (int)row["ID_LoaiSanPham"];
        }

        private int productId;
        private string productName;
        private string donViTinh;
        private string size;
        private float donGia;
        private int danhMucId;

        public int ProductId { get => productId; set => productId = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public string Size { get => size; set => size = value; }
        public float DonGia { get => donGia; set => donGia = value; }
        public int DanhMucId { get => danhMucId; set => danhMucId = value; }
    }
}
