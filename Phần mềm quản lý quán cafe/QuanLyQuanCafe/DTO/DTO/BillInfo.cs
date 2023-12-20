using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int hoaDonId, int sanPhamId, int count)
        {
            this.Id = id;
            this.HoaDonId = hoaDonId;
            this.SanPhamId = sanPhamId;
            this.Count = count;
        }

        public BillInfo(DataRow row)
        {
            this.Id = (int)row["ChiTietHoaDonID"];
            this.HoaDonId = (int)row["ID_HoaDon"];
            this.SanPhamId = (int)row["ID_SanPham"];
            this.Count = (int)row["TongSanPham"];
        }

        private int id;
        private int hoaDonId;
        private int sanPhamId;
        private int count;

        public int Id { get => id; set => id = value; }
        public int HoaDonId { get => hoaDonId; set => hoaDonId = value; }
        public int SanPhamId { get => sanPhamId; set => sanPhamId = value; }
        public int Count { get => count; set => count = value; }
    }
}
