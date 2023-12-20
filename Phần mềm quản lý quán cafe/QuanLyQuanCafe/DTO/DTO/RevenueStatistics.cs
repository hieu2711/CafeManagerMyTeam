using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class RevenueStatistics
    {
        public RevenueStatistics(string month, float totalPrice)
        {
            this.Month = month;
            this.TotalPrice = totalPrice;
        }

        public RevenueStatistics(DataRow row)
        {
            this.Month = row["month"].ToString();
            var TotalPriceTemp = row["Doanh Thu"];

            if (TotalPriceTemp.ToString() != "")
            {
                this.TotalPrice = (float)Convert.ToDouble(TotalPriceTemp.ToString());
            }
        }

        private string month;
        private float totalPrice;
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string Month { get => month; set => month = value; }
    }
}
