using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class MenuTable
    {
        public MenuTable(string foodName, string donViTinh, string size, float price, int foodTotal, float priceTotal)
        {
            this.FoodName = foodName;
            this.DonViTinh = donViTinh;
            this.Price = price;
            this.Size = size;
            this.FoodTotal = foodTotal;
            this.PriceTotal = priceTotal;
        }

        public MenuTable(DataRow row)
        {
            this.FoodName = row["TenSanPham"].ToString();
            this.DonViTinh = row["DonViTinh"].ToString();
            this.Size = row["Size"].ToString();
            this.Price = (float)Convert.ToDouble(row["DonGia"].ToString());
            this.FoodTotal = (int)row["TongSanPham"];
            this.PriceTotal = (float)Convert.ToDouble(row["priceTotal"].ToString());
        }

        private string foodName;
        private string donViTinh;
        private string size;
        private float price;
        private int foodTotal;
        private float priceTotal;

        public string FoodName { get => foodName; set => foodName = value; }
        public string DonViTinh { get => donViTinh; set => donViTinh = value; }
        public float Price { get => price; set => price = value; }
        public int FoodTotal { get => foodTotal; set => foodTotal = value; }
        public float PriceTotal { get => priceTotal; set => priceTotal = value; }
        public string Size { get => size; set => size = value; }
    }
}
