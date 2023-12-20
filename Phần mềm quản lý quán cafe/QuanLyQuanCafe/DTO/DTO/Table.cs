using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        public Table(int id, string name, string trangThai)
        {
            this.Id = id;
            this.Name = name;
            this.TrangThai = trangThai;
        }

        public Table(DataRow row)
        {
            this.Id = (int)row["BanID"];
            this.Name = row["SoBan"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }

        private string trangThai;

        private int id;

        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }
}
