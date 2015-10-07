namespace ThuTien.GUI.ToTruong
{
    partial class frmGiaoHDTon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvHDTon = new System.Windows.Forms.DataGridView();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaoTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_HanhThuTruoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lbTo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTon)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(5, 25);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 18;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 20;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 19;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(141, 228);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nhân Viên:";
            // 
            // dgvHDTon
            // 
            this.dgvHDTon.AllowUserToAddRows = false;
            this.dgvHDTon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvHDTon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayGiaiTrach,
            this.NgayGiaoTon,
            this.MaHD,
            this.SoHoaDon,
            this.SoPhatHanh,
            this.DanhBo,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.MaNV_HanhThu,
            this.MaNV_HanhThuTruoc});
            this.dgvHDTon.Location = new System.Drawing.Point(265, 38);
            this.dgvHDTon.Name = "dgvHDTon";
            this.dgvHDTon.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTon.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHDTon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDTon.Size = new System.Drawing.Size(1092, 590);
            this.dgvHDTon.TabIndex = 26;
            this.dgvHDTon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTon_CellFormatting);
            this.dgvHDTon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTon_RowPostPaint);
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.ReadOnly = true;
            this.NgayGiaiTrach.Visible = false;
            // 
            // NgayGiaoTon
            // 
            this.NgayGiaoTon.DataPropertyName = "NgayGiaoTon";
            this.NgayGiaoTon.HeaderText = "Ngày Giao Tồn";
            this.NgayGiaoTon.Name = "NgayGiaoTon";
            this.NgayGiaoTon.ReadOnly = true;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Visible = false;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.ReadOnly = true;
            // 
            // SoPhatHanh
            // 
            this.SoPhatHanh.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh.HeaderText = "Số Phát Hành";
            this.SoPhatHanh.Name = "SoPhatHanh";
            this.SoPhatHanh.ReadOnly = true;
            this.SoPhatHanh.Visible = false;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.ReadOnly = true;
            this.TieuThu.Width = 50;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Width = 80;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT.HeaderText = "Thuế GTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            this.ThueGTGT.ReadOnly = true;
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT.HeaderText = "Phí BVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            this.PhiBVMT.ReadOnly = true;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            // 
            // MaNV_HanhThu
            // 
            this.MaNV_HanhThu.DataPropertyName = "MaNV_HanhThu";
            this.MaNV_HanhThu.HeaderText = "Hành Thu";
            this.MaNV_HanhThu.Name = "MaNV_HanhThu";
            this.MaNV_HanhThu.ReadOnly = true;
            this.MaNV_HanhThu.Width = 150;
            // 
            // MaNV_HanhThuTruoc
            // 
            this.MaNV_HanhThuTruoc.DataPropertyName = "MaNV_HanhThuTruoc";
            this.MaNV_HanhThuTruoc.HeaderText = "Hành Thu Trước";
            this.MaNV_HanhThuTruoc.Name = "MaNV_HanhThuTruoc";
            this.MaNV_HanhThuTruoc.ReadOnly = true;
            this.MaNV_HanhThuTruoc.Width = 150;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(742, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 31;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(636, 12);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(572, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(466, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(409, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Từ Ngày:";
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(261, 9);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 32;
            this.lbTo.Text = "Tổ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 258);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(80, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(111, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "(Enter)";
            // 
            // lstHD
            // 
            this.lstHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstHD.Location = new System.Drawing.Point(5, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(125, 173);
            this.lstHD.TabIndex = 48;
            this.lstHD.UseCompatibleStateImageBehavior = false;
            this.lstHD.View = System.Windows.Forms.View.Details;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh Sách Hóa Đơn";
            this.columnHeader1.Width = 120;
            // 
            // frmGiaoHDTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 666);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvHDTon);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Name = "frmGiaoHDTon";
            this.Text = "Giao Hóa Đơn Tồn";
            this.Load += new System.EventHandler(this.frmGiaoHDTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvHDTon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaoTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_HanhThuTruoc;
        private System.Windows.Forms.ListView lstHD;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}