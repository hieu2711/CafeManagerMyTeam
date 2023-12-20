using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {  
        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int trangThai)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.TrangThai = trangThai;
        }

        public Bill(DataRow row)
        {
            this.Id = (int)row["HoaDonID"];
            this.DateCheckIn = (DateTime?)row["DateCheckIn"];

            var dataCheckOutTemp = row["DateCheckOut"];

            if (dataCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dataCheckOutTemp;
            this.TrangThai = (int)row["TrangThai"];
        }

        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int trangThai;
        
        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
       
    }
}
