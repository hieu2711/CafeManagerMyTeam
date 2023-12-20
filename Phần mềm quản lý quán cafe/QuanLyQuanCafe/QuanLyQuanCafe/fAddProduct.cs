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

namespace QuanLyQuanCafe
{
    public partial class fAddProduct : Form
    {
        public fAddProduct()
        {
            InitializeComponent();
            LoadCategory();
        }

        void LoadCategory()
        {
            List<Category> listDanhMuc = CategoryDAO.Instance.GetListCategory();
            cbDanhMuc.DataSource = listDanhMuc;
            cbDanhMuc.DisplayMember = "tenCategory";
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            int categogyID = (cbDanhMuc.SelectedItem as Category).LoaiSanPhamId;
            string tenSanPham = txtTenSanPham.Text;
            string donViTinh = cbDonVi.Text;
            float price = (float)nudGia.Value;
            string size = cbSize.Text;

            if (ProductDAO.Instance.InsertProduct(tenSanPham, donViTinh, price, categogyID, size))
            {
                MessageBox.Show("Thêm món thành công");
                if (insertProduct != null)
                {
                    insertProduct(this, new EventArgs());
                    txtTenSanPham.Text = "";
                    nudGia.Value = 0;
                }
            } else
            {
                MessageBox.Show("Thêm món thất bại");
            }

        }

        private event EventHandler insertProduct;
        public event EventHandler InsertProduct
        {
            add { insertProduct += value; }
            remove { insertProduct -= value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
