using DAO.DAO;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyQuanCafe
{
    public partial class fRevenueStatistics : Form
    {
        public fRevenueStatistics()
        {
            InitializeComponent();
            load_Chart();
        }

        //Hiển thị biểu đồ
        void load_Chart()
        {

            List<RevenueStatistics> list = BillDAO.Instance.getListDoanhThuThang();
            
            //=======================
            //Biểu đồ trong thống kê daonh thu theo năm
            DateTime year = DateTime.Now;
            chartRevenueYear.Titles.Add("Thống kê doanh thu năm " + year.Year.ToString());
            chartRevenueYear.Series[0].ChartType = SeriesChartType.Doughnut;
            chartRevenueYear.Series[0].IsValueShownAsLabel = true;
            chartRevenueYear.Series[0].Label = "#PERCENT{P0}";

            List<RevenueStatistics> listRevenueyear = StatisticsDAO.Instance.GetRevenueByYear(year.Year);
            // Thiết lập dữ liệu cho biểu đồ
            foreach (RevenueStatistics item in listRevenueyear)
            {
                chartRevenueYear.Series[0].Points.AddXY(item.Month, item.TotalPrice);
            }

            dgvTKN.DataSource = StatisticsDAO.Instance.GetRevenueByYear(year.Year);

            //=====================
            //Biểu đồ cột
            chartDoanhThu.Titles.Add("Thống kê doanh thu");
            chartDoanhThu.Series[0].ChartType = SeriesChartType.Bar;
            chartDoanhThu.Series[0].IsValueShownAsLabel = true;
            chartDoanhThu.Series[0].Label = "#PERCENT{P0}";

            // Thiết lập dữ liệu cho biểu đồ
            foreach (RevenueStatistics item in list)
            {
                chartDoanhThu.Series[0].Points.AddXY(item.Month, item.TotalPrice);

            }

            dgvView.DataSource = BillDAO.Instance.getListDoanhThuThang();
        }

        //Thống kê doanh thu theo tháng
        private void btnThongKeDoanhThu_Click(object sender, EventArgs e)
        {
            
            int month = (int)nupThang.Value;
            int year = (int)nupNam.Value;

            List<RevenueStatistics> list = BillDAO.Instance.getListDoanhThuTheoThang(month, year);
            if (list.Count > 0)
            {
                //Biểu đồ cột
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Series[0].Points.Clear();

                chartDoanhThu.Titles.Add("Thống kê doanh thu tháng");
                chartDoanhThu.Series[0].ChartType = SeriesChartType.Bar;
                chartDoanhThu.Series[0].IsValueShownAsLabel = true;
                chartDoanhThu.Series[0].Label = "#PERCENT{P0}";
                // Thiết lập dữ liệu cho biểu đồ
                foreach (RevenueStatistics item in list)
                {
                    chartDoanhThu.Series[0].Points.AddXY(item.Month, item.TotalPrice);

                }

                dgvView.DataSource = BillDAO.Instance.getListDoanhThuTheoThang(month, year);
                lbThongBao.Text = "";
            } 
            else
            {
                lbThongBao.Text = "Không có số liệu trong tháng này!!!!";
                chartDoanhThu.Titles.Clear();
                chartDoanhThu.Series[0].Points.Clear();
                dgvView.DataSource = null;
            }
       
        }

        //Thống kê doanh thu theo năm
        private void btnThongKeDoanhThu_Nam_Click(object sender, EventArgs e)
        {
            int year = (int)nupYear.Value;
            //Biểu đồ cột
            chartRevenueYear.Titles.Clear();
            chartRevenueYear.Series[0].Points.Clear();

            chartRevenueYear.Titles.Add("Thống kê doanh thu tháng");
            chartRevenueYear.Series[0].ChartType = SeriesChartType.Doughnut;
            chartRevenueYear.Series[0].IsValueShownAsLabel = true;
            chartRevenueYear.Series[0].Label = "#PERCENT{P0}";

            List<RevenueStatistics> list = StatisticsDAO.Instance.GetRevenueByYear(year);

            if (list.Count > 0)
            {
                // Thiết lập dữ liệu cho biểu đồ
                foreach (RevenueStatistics item in list)
                {
                    chartRevenueYear.Series[0].Points.AddXY(item.Month, item.TotalPrice);

                }

                dgvTKN.DataSource = StatisticsDAO.Instance.GetRevenueByYear(year);
                lbThongBao2.Text = "";
            } 
            else
            {
                lbThongBao2.Text = "Không có dữ liệu trong năm này!!!";
                chartRevenueYear.Titles.Clear();
                chartRevenueYear.Series[0].Points.Clear();
                dgvTKN.DataSource = null;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
