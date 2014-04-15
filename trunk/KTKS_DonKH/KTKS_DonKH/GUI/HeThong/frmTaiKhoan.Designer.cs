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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtTaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dgvDSTaiKhoan = new System.Windows.Forms.DataGridView();
            this.MaU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatKhau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKiemBamChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvPhanQuyen = new System.Windows.Forms.DataGridView();
            this.MaR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuyenXem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.QuyenCapNhat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtMaKiemBamChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTaiKhoan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).BeginInit();
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
            this.label3.Location = new System.Drawing.Point(80, 83);
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
            this.btnXoa.Location = new System.Drawing.Point(558, 113);
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
            this.btnSua.Location = new System.Drawing.Point(484, 113);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTaiKhoan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTaiKhoan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaU,
            this.HoTen,
            this.TaiKhoan,
            this.MatKhau,
            this.MaKiemBamChi});
            this.dgvDSTaiKhoan.Location = new System.Drawing.Point(13, 156);
            this.dgvDSTaiKhoan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSTaiKhoan.MultiSelect = false;
            this.dgvDSTaiKhoan.Name = "dgvDSTaiKhoan";
            this.dgvDSTaiKhoan.Size = new System.Drawing.Size(501, 378);
            this.dgvDSTaiKhoan.TabIndex = 9;
            this.dgvDSTaiKhoan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTaiKhoan_CellContentClick);
            this.dgvDSTaiKhoan.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTaiKhoan_CellEndEdit);
            this.dgvDSTaiKhoan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSTaiKhoan_RowPostPaint);
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
            this.HoTen.Width = 200;
            // 
            // TaiKhoan
            // 
            this.TaiKhoan.DataPropertyName = "TaiKhoan";
            this.TaiKhoan.HeaderText = "Tài Khoản";
            this.TaiKhoan.Name = "TaiKhoan";
            this.TaiKhoan.ReadOnly = true;
            this.TaiKhoan.Width = 110;
            // 
            // MatKhau
            // 
            this.MatKhau.DataPropertyName = "MatKhau";
            this.MatKhau.HeaderText = "Mật Khẩu";
            this.MatKhau.Name = "MatKhau";
            this.MatKhau.Visible = false;
            // 
            // MaKiemBamChi
            // 
            this.MaKiemBamChi.DataPropertyName = "MaKiemBamChi";
            this.MaKiemBamChi.HeaderText = "Mã Kiềm BC";
            this.MaKiemBamChi.Name = "MaKiemBamChi";
            this.MaKiemBamChi.Width = 120;
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(399, 113);
            this.btnThem.Margin = new System.Windows.Forms.Padding(4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvPhanQuyen
            // 
            this.dgvPhanQuyen.AllowUserToAddRows = false;
            this.dgvPhanQuyen.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhanQuyen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPhanQuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhanQuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaR,
            this.TenR,
            this.QuyenXem,
            this.QuyenCapNhat});
            this.dgvPhanQuyen.Location = new System.Drawing.Point(522, 156);
            this.dgvPhanQuyen.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhanQuyen.MultiSelect = false;
            this.dgvPhanQuyen.Name = "dgvPhanQuyen";
            this.dgvPhanQuyen.Size = new System.Drawing.Size(546, 378);
            this.dgvPhanQuyen.TabIndex = 10;
            this.dgvPhanQuyen.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhanQuyen_CellEndEdit);
            this.dgvPhanQuyen.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhanQuyen_RowPostPaint);
            // 
            // MaR
            // 
            this.MaR.DataPropertyName = "MaR";
            this.MaR.HeaderText = "Mã Quyền";
            this.MaR.Name = "MaR";
            this.MaR.Visible = false;
            // 
            // TenR
            // 
            this.TenR.DataPropertyName = "TenR";
            this.TenR.HeaderText = "Tên Quyền";
            this.TenR.Name = "TenR";
            this.TenR.ReadOnly = true;
            this.TenR.Width = 300;
            // 
            // QuyenXem
            // 
            this.QuyenXem.DataPropertyName = "QuyenXem";
            this.QuyenXem.HeaderText = "Q.Xem";
            this.QuyenXem.Name = "QuyenXem";
            // 
            // QuyenCapNhat
            // 
            this.QuyenCapNhat.DataPropertyName = "QuyenCapNhat";
            this.QuyenCapNhat.HeaderText = "Q.Cập Nhật";
            this.QuyenCapNhat.Name = "QuyenCapNhat";
            // 
            // txtMaKiemBamChi
            // 
            this.txtMaKiemBamChi.Location = new System.Drawing.Point(160, 113);
            this.txtMaKiemBamChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaKiemBamChi.Name = "txtMaKiemBamChi";
            this.txtMaKiemBamChi.Size = new System.Drawing.Size(200, 25);
            this.txtMaKiemBamChi.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Mã Kiềm BC:";
            // 
            // frmTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1276, 547);
            this.Controls.Add(this.txtMaKiemBamChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvPhanQuyen);
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
            this.Text = "Tài Khoản";
            this.Load += new System.EventHandler(this.frmTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTaiKhoan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhanQuyen)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvPhanQuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaR;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenR;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QuyenXem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn QuyenCapNhat;
        private System.Windows.Forms.TextBox txtMaKiemBamChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaU;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaiKhoan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatKhau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKiemBamChi;
    }
}