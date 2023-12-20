using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Customer
    {
        public Customer(int idKhachHang, string hoTen, string soDienThoai, int diemTichLuy)
        {
            this.IdKhachHang = idKhachHang;
            this.HoTen = hoTen;
            this.SoDienThoai = soDienThoai;
            this.DiemTichLuy = diemTichLuy;
        }

        public Customer(DataRow row)
        {
            this.IdKhachHang = (int)row["KhachHangID"];
            this.HoTen = row["HoVaTen"].ToString();
            this.SoDienThoai = row["SoDienThoai"].ToString();
            this.DiemTichLuy = (int)row["DiemTichLuy"];
        }

        private int idKhachHang;
        private string hoTen;
        private string soDienThoai;
        private int diemTichLuy;

        public int IdKhachHang { get => idKhachHang; set => idKhachHang = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public int DiemTichLuy { get => diemTichLuy; set => diemTichLuy = value; }
    }
}
