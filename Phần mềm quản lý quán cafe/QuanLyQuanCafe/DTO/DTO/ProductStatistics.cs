using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.DTO
{
    public class ProductStatistics
    {
        public ProductStatistics() {}
        public ProductStatistics(string tenSanPham, int tongSoSanPham)
        {
            this.TenSanPham = tenSanPham;
            this.TongSoSanPham = tongSoSanPham;
        }

        public ProductStatistics(DataRow row)
        {
            this.TenSanPham = row["TenSanPham"].ToString();
            this.TongSoSanPham = (int)row["Total"];
        }

        private string tenSanPham;
        private int tongSoSanPham;
        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public int TongSoSanPham { get => tongSoSanPham; set => tongSoSanPham = value; }
    }
}
