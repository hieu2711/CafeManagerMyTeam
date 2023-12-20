
namespace QuanLyQuanCafe
{
    partial class fAddTable
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
            this.pnNameShop = new System.Windows.Forms.Panel();
            this.lbTenQuan = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.cbTrangThaiBan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel16 = new System.Windows.Forms.Panel();
            this.txtBan = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnNameShop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnNameShop
            // 
            this.pnNameShop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnNameShop.Controls.Add(this.lbTenQuan);
            this.pnNameShop.Controls.Add(this.pictureBox1);
            this.pnNameShop.Location = new System.Drawing.Point(12, 12);
            this.pnNameShop.Name = "pnNameShop";
            this.pnNameShop.Size = new System.Drawing.Size(550, 76);
            this.pnNameShop.TabIndex = 8;
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
            // panel13
            // 
            this.panel13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel13.Controls.Add(this.btnExit);
            this.panel13.Controls.Add(this.btnAddTable);
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Controls.Add(this.panel16);
            this.panel13.Location = new System.Drawing.Point(12, 94);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(550, 215);
            this.panel13.TabIndex = 10;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(311, 147);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 53);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(88, 147);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(119, 53);
            this.btnAddTable.TabIndex = 3;
            this.btnAddTable.Text = "Thêm bàn";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // panel15
            // 
            this.panel15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel15.Controls.Add(this.cbTrangThaiBan);
            this.panel15.Controls.Add(this.label4);
            this.panel15.Location = new System.Drawing.Point(3, 65);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(544, 46);
            this.panel15.TabIndex = 2;
            // 
            // cbTrangThaiBan
            // 
            this.cbTrangThaiBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrangThaiBan.FormattingEnabled = true;
            this.cbTrangThaiBan.Items.AddRange(new object[] {
            "Trống"});
            this.cbTrangThaiBan.Location = new System.Drawing.Point(156, 6);
            this.cbTrangThaiBan.Name = "cbTrangThaiBan";
            this.cbTrangThaiBan.Size = new System.Drawing.Size(91, 37);
            this.cbTrangThaiBan.TabIndex = 1;
            this.cbTrangThaiBan.Text = "Trống";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "Trạng thái:";
            // 
            // panel16
            // 
            this.panel16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel16.Controls.Add(this.txtBan);
            this.panel16.Controls.Add(this.label5);
            this.panel16.Location = new System.Drawing.Point(3, 13);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(544, 46);
            this.panel16.TabIndex = 2;
            // 
            // txtBan
            // 
            this.txtBan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBan.Location = new System.Drawing.Point(156, 7);
            this.txtBan.Name = "txtBan";
            this.txtBan.Size = new System.Drawing.Size(385, 34);
            this.txtBan.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 29);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số bàn:";
            // 
            // fAddTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 321);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.pnNameShop);
            this.Name = "fAddTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fAddTable";
            this.pnNameShop.ResumeLayout(false);
            this.pnNameShop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnNameShop;
        private System.Windows.Forms.Label lbTenQuan;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.ComboBox cbTrangThaiBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.TextBox txtBan;
        private System.Windows.Forms.Label label5;
    }
}