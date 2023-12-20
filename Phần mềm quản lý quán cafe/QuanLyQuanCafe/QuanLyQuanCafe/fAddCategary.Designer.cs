
namespace QuanLyQuanCafe
{
    partial class fAddCategary
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnInfoDanhMuc = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddcategary = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.lbTenDanhMuc = new System.Windows.Forms.Label();
            this.pnNameShop = new System.Windows.Forms.Panel();
            this.lbTenQuan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnInfoDanhMuc.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnNameShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnInfoDanhMuc
            // 
            this.pnInfoDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnInfoDanhMuc.Controls.Add(this.btnExit);
            this.pnInfoDanhMuc.Controls.Add(this.btnAddcategary);
            this.pnInfoDanhMuc.Controls.Add(this.panel2);
            this.pnInfoDanhMuc.Location = new System.Drawing.Point(12, 103);
            this.pnInfoDanhMuc.Name = "pnInfoDanhMuc";
            this.pnInfoDanhMuc.Size = new System.Drawing.Size(505, 174);
            this.pnInfoDanhMuc.TabIndex = 4;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(271, 111);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(142, 51);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddcategary
            // 
            this.btnAddcategary.Location = new System.Drawing.Point(75, 111);
            this.btnAddcategary.Name = "btnAddcategary";
            this.btnAddcategary.Size = new System.Drawing.Size(142, 51);
            this.btnAddcategary.TabIndex = 3;
            this.btnAddcategary.Text = "Thêm danh mục";
            this.btnAddcategary.UseVisualStyleBackColor = true;
            this.btnAddcategary.Click += new System.EventHandler(this.btnAddcategary_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.txtTenDanhMuc);
            this.panel2.Controls.Add(this.lbTenDanhMuc);
            this.panel2.Location = new System.Drawing.Point(6, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(499, 62);
            this.panel2.TabIndex = 2;
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenDanhMuc.Location = new System.Drawing.Point(192, 10);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(304, 34);
            this.txtTenDanhMuc.TabIndex = 1;
            // 
            // lbTenDanhMuc
            // 
            this.lbTenDanhMuc.AutoSize = true;
            this.lbTenDanhMuc.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenDanhMuc.Location = new System.Drawing.Point(4, 14);
            this.lbTenDanhMuc.Name = "lbTenDanhMuc";
            this.lbTenDanhMuc.Size = new System.Drawing.Size(184, 29);
            this.lbTenDanhMuc.TabIndex = 0;
            this.lbTenDanhMuc.Text = "Tên danh mục:";
            // 
            // pnNameShop
            // 
            this.pnNameShop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnNameShop.Controls.Add(this.lbTenQuan);
            this.pnNameShop.Controls.Add(this.pictureBox1);
            this.pnNameShop.Location = new System.Drawing.Point(12, 12);
            this.pnNameShop.Name = "pnNameShop";
            this.pnNameShop.Size = new System.Drawing.Size(505, 76);
            this.pnNameShop.TabIndex = 5;
            // 
            // lbTenQuan
            // 
            this.lbTenQuan.AutoSize = true;
            this.lbTenQuan.Font = new System.Drawing.Font("Brush Script MT", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenQuan.Location = new System.Drawing.Point(141, 17);
            this.lbTenQuan.Name = "lbTenQuan";
            this.lbTenQuan.Size = new System.Drawing.Size(240, 34);
            this.lbTenQuan.TabIndex = 1;
            this.lbTenQuan.Text = "SP TEAM COFFEE";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QuanLyQuanCafe.Properties.Resources.Sp_Team;
            this.pictureBox1.Location = new System.Drawing.Point(15, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // fAddCategary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 289);
            this.Controls.Add(this.pnNameShop);
            this.Controls.Add(this.pnInfoDanhMuc);
            this.Name = "fAddCategary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAddCategary";
            this.pnInfoDanhMuc.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnNameShop.ResumeLayout(false);
            this.pnNameShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnInfoDanhMuc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Label lbTenDanhMuc;
        private System.Windows.Forms.Button btnAddcategary;
        private System.Windows.Forms.Panel pnNameShop;
        private System.Windows.Forms.Label lbTenQuan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExit;
    }
}