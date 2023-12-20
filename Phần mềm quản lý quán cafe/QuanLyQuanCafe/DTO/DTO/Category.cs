using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        public Category(int loaiSanPhamId, string tenCategory)
        {
            this.LoaiSanPhamId = loaiSanPhamId;
            this.TenCategory = tenCategory;
        }

        public Category(DataRow row)
        {
            this.LoaiSanPhamId = (int)row["LoaiSanPhamID"];
            this.TenCategory = row["LoaiSanPham"].ToString();
        }

        private int loaiSanPhamId;
        private string tenCategory;

        public int LoaiSanPhamId { get => loaiSanPhamId; set => loaiSanPhamId = value; }
        public string TenCategory { get => tenCategory; set => tenCategory = value; }
    }
}
