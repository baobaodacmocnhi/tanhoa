namespace KTKS_DonKH.GUI.HeThong
{
    partial class frmTaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDSTaiKhoan = new System.Windows.Forms.DataGridView();
            this.btnThem = new System.Windows.Forms.Button();
            this.MaU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QTaiKhoan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QCapNhat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QNhanDonKH = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QQLDonKH = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QKTXM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QDCBD = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QCHDB = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTaiKhoan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Họ Tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(160, 14);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 1;
            // 
            // txtTaiKhoan
            // 
            this.txtTaiKhoan.Location = new System.Drawing.Point(161, 47);
            this.txtTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.txtTaiKhoan.Name = "txtTaiKhoan";
            this.txtTaiKhoan.Size = new System.Drawing.Size(200, 25);
            this.txtTaiKhoan.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tài Khoản:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(160, 80);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(200, 25);
            this.txtMatKhau.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 83);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật Khẩu:";
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::KTKS_DonKH.Properties.Resources.delete_24x24;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(369, 113);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(68, 35);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Visible = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(295, 113);
            this.btnSua.Margin = new System.Windows.Forms.Padding(4);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(66, 35);
            this.btnSua.TabIndex = 8;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // dgvDSTaiKhoan
            // 
            this.dgvDSTaiKhoan.AllowUserToAddRows = false;
            this.dgvDSTaiKhoan.AllowUserToDeleteRows = false;
            this.dgvDSTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaU,
            this.HoTen,
            this.TaiKhoan,
            this.MatKhau,
            this.QTaiKhoan,
            this.QCapNhat,
            this.QNhanDonKH,
            this.QQLDonKH,
            this.QKTXM,
            this.QDCBD,
            this.QCHDB});
            this.dgvDSTaiKhoan.Location = new System.Drawing.Point(0, 156);
            this.dgvDSTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSTaiKhoan.MultiSelect = false;
            this.dgvDSTaiKhoan.Name = "dgvDSTaiKhoan";
            this.dgvDSTaiKhoan.Size = new System.Drawing.Size(947, 384);
            this.dgvDSTaiKhoan.TabIndex = 9;
            this.dgvDSTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTaiKhoan_CellContentClick);
            this.dgvDSTaiKhoan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTaiKhoan_CellEndEdit);
            this.dgvDSTaiKhoan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSTaiKhoan_RowPostPaint);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(210, 113);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // MaU
            // 
            this.MaU.DataPropertyName = "MaU";
            this.MaU.HeaderText = "Mã Tài Khoản";
            this.MaU.Name = "MaU";
            this.MaU.Visible = false;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài Khoản";
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật Khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Visible = false;
            // 
            // QTaiKhoan
            // 
            this.QTaiKhoan.DataPropertyName = "QTaiKhoan";
            this.QTaiKhoan.HeaderText = "Q.Tài Khoản";
            this.QTaiKhoan.Name = "QTaiKhoan";
            // 
            // QCapNhat
            // 
            this.QCapNhat.DataPropertyName = "QCapNhat";
            this.QCapNhat.HeaderText = "Q.Cập Nhật";
            this.QCapNhat.Name = "QCapNhat";
            // 
            // QNhanDonKH
            // 
            this.QNhanDonKH.DataPropertyName = "QNhanDonKH";
            this.QNhanDonKH.HeaderText = "Q.Nhận Đơn KH";
            this.QNhanDonKH.Name = "QNhanDonKH";
            this.QNhanDonKH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QNhanDonKH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // QQLDonKH
            // 
            this.QQLDonKH.DataPropertyName = "QQLDonKH";
            this.QQLDonKH.HeaderText = "Q.Quản Lý Đơn KH";
            this.QQLDonKH.Name = "QQLDonKH";
            this.QQLDonKH.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.QQLDonKH.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // QKTXM
            // 
            this.QKTXM.DataPropertyName = "QKTXM";
            this.QKTXM.HeaderText = "Q.Kiểm Tra Xác Minh";
            this.QKTXM.Name = "QKTXM";
            // 
            // QDCBD
            // 
            this.QDCBD.DataPropertyName = "QDCBD";
            this.QDCBD.HeaderText = "Q.Điều Chỉnh Biến Động";
            this.QDCBD.Name = "QDCBD";
            // 
            // QCHDB
            // 
            this.QCHDB.DataPropertyName = "QCHDB";
            this.QCHDB.HeaderText = "Q.Cắt Hủy Danh Bộ";
            this.QCHDB.Name = "QCHDB";
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1246, 576);
            this.Controls.Add(this.dgvDSTaiKhoan);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTaiKhoan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTaiKhoan";
            this.Text = "frmTaiKhoan";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTaiKhoan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridView dgvDSTaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaU;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QTaiKhoan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QCapNhat;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QNhanDonKH;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QQLDonKH;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QKTXM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QDCBD;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QCHDB;
    }
}