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

namespace QuanLyQuanCafe
{
    public partial class fAddCategary : Form
    {
        public fAddCategary()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddcategary_Click(object sender, EventArgs e)
        {
            string tenDM = txtTenDanhMuc.Text;

            if (CategoryDAO.Instance.InsertCategary(tenDM))
            {
                MessageBox.Show("Thêm danh mục thành công");
                if (insertCategary != null)
                {
                    insertCategary(this, new EventArgs());
                }
            } else
            {
                MessageBox.Show("Thêm danh mục thất bại");
            }
        }

        private event EventHandler insertCategary;
        public event EventHandler InsertCategary
        {
            add { insertCategary += value; }
            remove { insertCategary -= value; }
        }
    }
}
