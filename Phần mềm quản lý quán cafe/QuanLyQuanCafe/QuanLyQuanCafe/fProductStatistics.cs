using DTO.DTO;
using QuanLyQuanCafe.DAO;
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
    public partial class fProductStatistics : Form
    {
        public fProductStatistics()
        {
            InitializeComponent();
        }

        //Thống kê sản phẩm hiện tại
        private void fThongKeSanPham_Load(object sender, EventArgs e)
        {
            chartControl1.Titles.Add("Thống kê tổng sản phẩm");
            chartControl1.Series[0].ChartType = SeriesChartType.Pie;
            chartControl1.Series[0].IsValueShownAsLabel = true;
            chartControl1.Series[0].Label = "#PERCENT{P0}";

            List<ProductStatistics> list = ProductDAO.Instance.getListCountProduct();
            // Thiết lập dữ liệu cho biểu đồ
            foreach (ProductStatistics item in list)
            {
                chartControl1.Series[0].Points.AddXY(item.TenSanPham, item.TongSoSanPham);

            }

            dgvThongKeSanPham.DataSource = ProductDAO.Instance.getListCountProduct();
        }

        //Thống kê sản phẩm theo năm
        private void btnThongKeTheoThang_Click(object sender, EventArgs e)
        {
            int month = (int)nudMonth.Value;
            int year = (int)nudYear.Value;

            List<ProductStatistics> list = ProductDAO.Instance.GetListCountProductByMonth(month, year);
            if (list.Count > 0)
            {
                chart2.Titles.Clear();
                chart2.Series[0].Points.Clear();

                string title = "Thức uống bán chạy";
                chart2.Titles.Add(title);
                chart2.Series[0].ChartType = SeriesChartType.Pie;
                chart2.Series[0].IsValueShownAsLabel = true;
                chart2.Series[0].Label = "#PERCENT{P0}";

                // Thiết lập dữ liệu cho biểu đồ
                foreach (ProductStatistics item in list)
                {
                    chart2.Series[0].Points.AddXY(item.TenSanPham, item.TongSoSanPham);
                }

                dgvThongKeSanPhamTheoThang.DataSource = ProductDAO.Instance.GetListCountProductByMonth(month, year);

                lbThongBao.Text = "";
            }
            else
            {
                lbThongBao.Text = "Không có dữ liệu thời gian này";
                chart2.Titles.Clear();
                chart2.Series[0].Points.Clear();
                dgvThongKeSanPhamTheoThang.DataSource = null;
            }
         }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
