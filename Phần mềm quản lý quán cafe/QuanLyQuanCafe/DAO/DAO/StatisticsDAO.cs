using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;

namespace DAO.DAO
{
    public class StatisticsDAO
    {
        private static StatisticsDAO instance;

        public static StatisticsDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new StatisticsDAO();
                return StatisticsDAO.instance;
            }
            private set { StatisticsDAO.instance = value; }
        }

        private StatisticsDAO() { }

        public List<RevenueStatistics> GetRevenueByYear(int year)
        {
            List<RevenueStatistics> list = new List<RevenueStatistics>();

            string query = string.Format("SELECT MONTH(DateCheckOut) as 'Month', SUM(totalPrice) as 'Doanh Thu' FROM dbo.HoaDon WHERE TrangThai = 1 AND YEAR(DateCheckOut) = {0} Group by MONTH(DateCheckOut)", year);

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                RevenueStatistics tk = new RevenueStatistics(item);
                list.Add(tk);
            }

            return list;
        }
    }
}
