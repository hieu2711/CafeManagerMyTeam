using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fManager : Form
    {
        BindingSource productList = new BindingSource();
        BindingSource categaryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        BindingSource accountStaffList = new BindingSource();
        BindingSource customerList = new BindingSource();
        public fManager()
        {
            InitializeComponent();

            LoadAllTable();
        }

        #region Method


        List<Product> SearchProductByName(string name)
        {
            List<Product> listProduct = ProductDAO.Instance.SearchProductByName(name);

            return listProduct;
        }

        List<AccountStaff> SearchStaffByName(string name)
        {
            List<AccountStaff> listStaff = AccountStaffDAO.Instance.SearchStaffByName(name);

            return listStaff;
        }
        
        void LoadAllTable()
        {
            dgvProduct.DataSource = productList;
            dgvCategory.DataSource = categaryList;
            dgvTable.DataSource = tableList;
            dgvStaff.DataSource = accountStaffList;
            dgvCustomer.DataSource = customerList;

            LoadListProduct();
            LoadDanhMuc();
            Loadtable();
            AddProductBinding();
            AddcategaryBinding();
            AddTableBinding();
            AddTableAccountStaff();
            LoadStaffAndAccount();
            LoadDanhMucComboBox(cbDanhMuc);
            LoadListCustomer();
            AddCustomerBinding();
        }

        //Hiện thị thông tin khách hàng
        void LoadListCustomer()
        {
            customerList.DataSource = CustomerDAO.Instance.GetListCustomer();
            dgvCustomer.Columns[0].HeaderText = "ID khách hàng";
            dgvCustomer.Columns[1].HeaderText = "Tên khách hàng";
            dgvCustomer.Columns[2].HeaderText = "Số điện thoại";
            dgvCustomer.Columns[3].HeaderText = "Điểm tích lũy";

        }

        //Hiển thị thông tin sản phẩm
        void LoadListProduct()
        {
            productList.DataSource = ProductDAO.Instance.GetlistProduct();
            dgvProduct.Columns[0].HeaderText = "ID sản phẩm";
            dgvProduct.Columns[1].HeaderText = "Tên sản phẩm";
            dgvProduct.Columns[2].HeaderText = "Đơn vị tính";
            dgvProduct.Columns[3].HeaderText = "Size";
            dgvProduct.Columns[4].HeaderText = "Giá sản phẩm";
            dgvProduct.Columns[5].HeaderText = "ID danh mục";
        }

        //Hiển thị thông tin danh mục
        void LoadDanhMuc()
        {
            categaryList.DataSource = CategoryDAO.Instance.GetListCategory();
            dgvCategory.Columns[0].HeaderText = "ID danh mục";
            dgvCategory.Columns[1].HeaderText = "Tên danh mục";
        }

        //Hiển thị thông tin bàn
        void Loadtable()
        {
            tableList.DataSource = TableDAO.Instance.LoadTableList();
            dgvTable.Columns[0].HeaderText = "ID bàn";
            dgvTable.Columns[1].HeaderText = "Số bàn";
            dgvTable.Columns[2].HeaderText = "Trạng thái";
        }

        //Hiển thị thông tin nhân viên và tài khoản
        void LoadStaffAndAccount()
        {
            accountStaffList.DataSource = AccountStaffDAO.Instance.GetListStaffAndAccountByTableStaffAccount();
            dgvStaff.Columns[0].HeaderText = "ID nhân viên";
            dgvStaff.Columns[1].HeaderText = "Tên nhân viên";
            dgvStaff.Columns[2].HeaderText = "Ngày sinh";
            dgvStaff.Columns[3].HeaderText = "Giới tính";
            dgvStaff.Columns[4].HeaderText = "Số điện thoại";
            dgvStaff.Columns[5].HeaderText = "Ngày vào làm";
            dgvStaff.Columns[6].HeaderText = "Chức vụ";
        }

        //Hiển thị danh mục sản phẩm trong comboBox
        void LoadDanhMucComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "tenCategory";
        }

        void AddProductBinding()
        {
            txtSanPhamID.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "ProductId"));
            txtTenSanPham.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "ProductName"));
            txtDonViTinh.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "donViTinh"));
            nudGia.DataBindings.Add(new Binding("Value", dgvProduct.DataSource, "donGia"));
            txtSize.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "size"));
        }

        void AddcategaryBinding()
        {
            txtDanhMucID.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "loaiSanPhamId"));
            txtTenDanhMuc.DataBindings.Add(new Binding("Text", dgvCategory.DataSource, "tenCategory"));
        }

        void AddTableBinding()
        {
            txtBanID.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "id"));
            txtBan.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "name"));
            txtTrangThaiBan.DataBindings.Add(new Binding("Text", dgvTable.DataSource, "trangThai"));
        }

        void AddTableAccountStaff()
        {
            txtNVTK_ID.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "nhanVienID"));
            txtNVTK_HoVaTen.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "hoVaTen"));
            txtNVTK_GioiTinh.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "gioiTinh"));
            txtNVTK_NgaySinh.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "ngaySinh")); ;
            txtNVTK_NgayVaoLam.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "ngayVaoLam"));
            txtNVTK_ChucVu.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "chucVu"));
            txtNVTK_SoDienThoai.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "soDienThoai"));
            txtNVTK_Username.DataBindings.Add(new Binding("Text", dgvStaff.DataSource, "username"));
        }

        void AddCustomerBinding()
        {
            txtIdCus.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "idKhachHang"));
            txtNameCus.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "hoTen"));
            txtPhoneCus.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "soDienThoai"));
            txtPointCus.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "diemTichLuy"));
        }
        #endregion


        #region Event
        private void btnXemDanhMuc_Click(object sender, EventArgs e)
        {
            LoadDanhMuc();
        }

        private void btnXemSanPham_Click(object sender, EventArgs e)
        {
            LoadListProduct();
        }

        private void btnXemBan_Click(object sender, EventArgs e)
        {
            Loadtable();
        }

        private void btnXemNV_TK_Click(object sender, EventArgs e)
        {
            LoadStaffAndAccount();
        }

        private void txtSanPhamID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProduct.SelectedCells.Count > 1)
                {

                    int id = (int)dgvProduct.SelectedCells[0].OwningRow.Cells["danhMucId"].Value;

                    Category categary = CategoryDAO.Instance.GetDanhMucById(id);

                    cbDanhMuc.SelectedItem = categary;

                    int index = -1;
                    int i = 0;

                    foreach (Category item in cbDanhMuc.Items)
                    {
                        if (item.LoaiSanPhamId == categary.LoaiSanPhamId)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }

                    cbDanhMuc.SelectedIndex = index;
                }
            } catch { }
        }

        //Thêm sửa xóa sản phẩm
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            fAddProduct f = new fAddProduct();
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadListProduct();
        }

        private void btnSuaSanPham_Click(object sender, EventArgs e)
        {
            int categogyID = (cbDanhMuc.SelectedItem as Category).LoaiSanPhamId;
            string tenSanPham = txtTenSanPham.Text;
            string donViTinh = txtDonViTinh.Text;
            float price = (float)nudGia.Value;
            string size = txtSize.Text;
            int idProduct = Convert.ToInt32(txtSanPhamID.Text);

            if (ProductDAO.Instance.UpdateProduct(tenSanPham, donViTinh, price, categogyID, size, idProduct))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListProduct();
                if(updateProduct != null)
                {
                    updateProduct(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa món thất bại");
            }
        }

        private void btnXoaSanPham_Click(object sender, EventArgs e)
        {
            int idProduct = Convert.ToInt32(txtSanPhamID.Text);

            if (ProductDAO.Instance.DeleteProduct(idProduct))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListProduct();
                if (deleteProduct != null)
                {
                    deleteProduct(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Xóa món thất bại");
            }
        }

        private event EventHandler updateProduct;
        public event EventHandler UpdateProduct
        {
            add { updateProduct += value; }
            remove { updateProduct -= value; }
        }

        private event EventHandler deleteProduct;
        public event EventHandler DeleteProduct
        {
            add { deleteProduct += value; }
            remove { deleteProduct -= value; }
        }

        //Thêm sửa xóa danh mục
        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            fAddCategary f = new fAddCategary();
            f.ShowDialog();
            LoadDanhMuc();
        }
        private void btnSuaDanhMuc_Click(object sender, EventArgs e)
        {
            int idCategary = Convert.ToInt32(txtDanhMucID.Text);
            string tenDanhMuc = txtTenDanhMuc.Text;

            if (CategoryDAO.Instance.UpdateCategary(tenDanhMuc, idCategary))
            {
                MessageBox.Show("Sửa danh mục thành công");
                LoadDanhMuc();
                if (updateCategary != null)
                {
                    updateCategary(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Sửa danh mục thất bại");
            }
        }

        private void btnXoaDanhMuc_Click(object sender, EventArgs e)
        {
            int idCategary = Convert.ToInt32(txtDanhMucID.Text);
            if (ProductDAO.Instance.DeleteProductByCategaryId(idCategary))
            {
                if (CategoryDAO.Instance.DeleteCategary(idCategary))
                {
                    MessageBox.Show("Xóa danh mục thành công");
                    LoadDanhMuc();
                    if (deleteCategary != null)
                    {
                        deleteCategary(this, new EventArgs());
                    }
                }
            }
            else
            {
                MessageBox.Show("Xóa danh mục thất bại");
            }
        }

        private event EventHandler updateCategary;
        public event EventHandler UpdateCategary
        {
            add { updateCategary += value; }
            remove { updateCategary -= value; }
        }

        private event EventHandler deleteCategary;
        public event EventHandler DeleteCategary
        {
            add { deleteCategary += value; }
            remove { deleteCategary -= value; }
        }

        //Thêm sửa xóa thông tin bàn
        private void btnThemBan_Click(object sender, EventArgs e)
        {
            fAddTable f = new fAddTable();
            f.ShowDialog();
            Loadtable();
        }

        private void btnSuaBan_Click(object sender, EventArgs e)
        {
            int idBan = Convert.ToInt32(txtBanID.Text);
            string tenban = txtBan.Text;
            string trangThai = txtTrangThaiBan.Text;

            if (TableDAO.Instance.UpdateTable(tenban, trangThai, idBan))
            {
                MessageBox.Show("Sửa thông tin bàn thành công");
                Loadtable();
            }
            else
            {
                MessageBox.Show("Sửa thông tin bàn thất bại");
            }
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            int idBan = Convert.ToInt32(txtBanID.Text);
            if (TableDAO.Instance.DeleteTable(idBan))
            {
                MessageBox.Show("Xóa bàn thành công");
                Loadtable();
                
            }
            else
            {
                MessageBox.Show("Xóa bàn thất bại");
            }
        }

        // Thêm sửa xóa nhân viên và tài khoản
        private void btnThemNV_TK_Click(object sender, EventArgs e)
        {
            fAddStaff f = new fAddStaff();
            f.ShowDialog();
            LoadStaffAndAccount();
        }

        private void btnSuaNVTK_Click(object sender, EventArgs e)
        {
            int idNV = Convert.ToInt32(txtNVTK_ID.Text);
            string hoVaTen = txtNVTK_HoVaTen.Text;
            string ngaySinh = txtNVTK_NgaySinh.Text;
            string ngayVaoLam = txtNVTK_NgayVaoLam.Text;
            string gioiTinh = txtNVTK_GioiTinh.Text;
            string soDienThoai = txtNVTK_SoDienThoai.Text;
            string chucVu = txtNVTK_ChucVu.Text;

            if (StaffDAO.Instance.UpdateStaff(hoVaTen, ngaySinh, gioiTinh, soDienThoai, ngayVaoLam, chucVu, idNV))
            {
                MessageBox.Show("Sửa thông tin thành công");
                LoadStaffAndAccount();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }

        private void btnXoaNVTK_Click(object sender, EventArgs e)
        {
            int idStaff = Convert.ToInt32(txtNVTK_ID.Text);

            if (StaffDAO.Instance.DeleteStaff(idStaff))
            {
                MessageBox.Show("Xóa thành công");
                LoadStaffAndAccount();

            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnTimSanPham_Click(object sender, EventArgs e)
        {
          productList.DataSource = SearchProductByName(txtTimKiemFood.Text);
        }

        private void btnTimKiemNV_TK_Click(object sender, EventArgs e)
        {
            accountStaffList.DataSource = SearchStaffByName(txtNVTK_tìmKiem.Text);
        }

        //Sửa, xóa khách hàng
        private void btnUpdateCus_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdCus.Text);
            string name = txtNameCus.Text;
            string phone = txtPhoneCus.Text;

            if (CustomerDAO.Instance.UpdateCustomerById(id, name, phone))
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công!");
                LoadListCustomer();
            } else
            {
                MessageBox.Show("Sửa thông tin khách hàng thát bại!");
            }
        }

        private void btnDeleteCus_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdCus.Text);

            if (CustomerDAO.Instance.DeleteCustomerById(id))
            {
                MessageBox.Show("Xóa thông tin khách hàng thành công!");
                LoadListCustomer();
            }
            else
            {
                MessageBox.Show("Xóa thông tin khách hàng thát bại!");
            }
        }


        //Thống kê
        private void btnThongKe_DoanhThu_Click(object sender, EventArgs e)
        {
            fRevenueStatistics frmDoanhThu = new fRevenueStatistics();

            this.Hide();

            frmDoanhThu.ShowDialog();

            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThongKe_SanPham_Click(object sender, EventArgs e)
        {
            fProductStatistics frmThongKeSanPham = new fProductStatistics();

            this.Hide();
            frmThongKeSanPham.ShowDialog();
            this.Show();
        }

        #endregion
    }

}
