namespace ThuTien.GUI.Quay
{
    partial class frmTamThu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabThongTin = new System.Windows.Forms.TabPage();
            this.tabTamThu = new System.Windows.Forms.TabPage();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTamThu = new System.Windows.Forms.DataGridView();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabTamThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(189, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(247, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon,
            this.MaHD,
            this.SoHoaDon,
            this.Ky,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong});
            this.dgvHoaDon.Location = new System.Drawing.Point(6, 6);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1211, 575);
            this.dgvHoaDon.TabIndex = 13;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            // 
            // Chon
            // 
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.ReadOnly = true;
            this.Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Chon.Width = 50;
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
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.ReadOnly = true;
            this.TieuThu.Width = 80;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabThongTin);
            this.tabControl.Controls.Add(this.tabTamThu);
            this.tabControl.Location = new System.Drawing.Point(12, 41);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1335, 613);
            this.tabControl.TabIndex = 14;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabThongTin
            // 
            this.tabThongTin.Controls.Add(this.dgvHoaDon);
            this.tabThongTin.Location = new System.Drawing.Point(4, 22);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongTin.Size = new System.Drawing.Size(1327, 587);
            this.tabThongTin.TabIndex = 0;
            this.tabThongTin.Text = "Thông Tin";
            this.tabThongTin.UseVisualStyleBackColor = true;
            // 
            // tabTamThu
            // 
            this.tabTamThu.Controls.Add(this.btnXem);
            this.tabTamThu.Controls.Add(this.dateDen);
            this.tabTamThu.Controls.Add(this.label3);
            this.tabTamThu.Controls.Add(this.dateTu);
            this.tabTamThu.Controls.Add(this.label2);
            this.tabTamThu.Controls.Add(this.dgvTamThu);
            this.tabTamThu.Location = new System.Drawing.Point(4, 22);
            this.tabTamThu.Name = "tabTamThu";
            this.tabTamThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabTamThu.Size = new System.Drawing.Size(1327, 587);
            this.tabTamThu.TabIndex = 1;
            this.tabTamThu.Text = "Danh Sách Tạm Thu";
            this.tabTamThu.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(483, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 19;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(377, 9);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(313, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(207, 9);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(150, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Từ Ngày:";
            // 
            // dgvTamThu
            // 
            this.dgvTamThu.AllowUserToAddRows = false;
            this.dgvTamThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTamThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTamThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTamThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTT,
            this.NgayGiaiTrach_TT,
            this.CreateDate_TT,
            this.SoHoaDon_TT,
            this.Ky_TT,
            this.DanhBo_TT,
            this.HoTen_TT,
            this.DiaChi_TT,
            this.TieuThu_TT,
            this.GiaBan_TT,
            this.ThueGTGT_TT,
            this.PhiBVMT_TT,
            this.TongCong_TT});
            this.dgvTamThu.Location = new System.Drawing.Point(6, 35);
            this.dgvTamThu.Name = "dgvTamThu";
            this.dgvTamThu.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTamThu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTamThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTamThu.Size = new System.Drawing.Size(1315, 546);
            this.dgvTamThu.TabIndex = 14;
            this.dgvTamThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTamThu_CellFormatting);
            // 
            // btnXoa
            // 
            this.btnXoa.Enabled = false;
            this.btnXoa.Location = new System.Drawing.Point(515, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 17;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(434, 12);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 16;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(353, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 15;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // MaTT
            // 
            this.MaTT.DataPropertyName = "MaTT";
            this.MaTT.HeaderText = "MaHD";
            this.MaTT.Name = "MaTT";
            this.MaTT.ReadOnly = true;
            this.MaTT.Visible = false;
            // 
            // NgayGiaiTrach_TT
            // 
            this.NgayGiaiTrach_TT.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_TT.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_TT.Name = "NgayGiaiTrach_TT";
            this.NgayGiaiTrach_TT.ReadOnly = true;
            // 
            // CreateDate_TT
            // 
            this.CreateDate_TT.DataPropertyName = "CreateDate";
            this.CreateDate_TT.HeaderText = "Ngày Thu";
            this.CreateDate_TT.Name = "CreateDate_TT";
            this.CreateDate_TT.ReadOnly = true;
            // 
            // SoHoaDon_TT
            // 
            this.SoHoaDon_TT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TT.HeaderText = "Số HĐ";
            this.SoHoaDon_TT.Name = "SoHoaDon_TT";
            this.SoHoaDon_TT.ReadOnly = true;
            // 
            // Ky_TT
            // 
            this.Ky_TT.DataPropertyName = "Ky";
            this.Ky_TT.HeaderText = "Kỳ";
            this.Ky_TT.Name = "Ky_TT";
            this.Ky_TT.ReadOnly = true;
            this.Ky_TT.Width = 50;
            // 
            // DanhBo_TT
            // 
            this.DanhBo_TT.DataPropertyName = "DanhBo";
            this.DanhBo_TT.HeaderText = "Danh Bộ";
            this.DanhBo_TT.Name = "DanhBo_TT";
            this.DanhBo_TT.ReadOnly = true;
            // 
            // HoTen_TT
            // 
            this.HoTen_TT.DataPropertyName = "HoTen";
            this.HoTen_TT.HeaderText = "Họ Tên";
            this.HoTen_TT.Name = "HoTen_TT";
            this.HoTen_TT.ReadOnly = true;
            this.HoTen_TT.Width = 150;
            // 
            // DiaChi_TT
            // 
            this.DiaChi_TT.DataPropertyName = "DiaChi";
            this.DiaChi_TT.HeaderText = "Địa Chỉ";
            this.DiaChi_TT.Name = "DiaChi_TT";
            this.DiaChi_TT.ReadOnly = true;
            this.DiaChi_TT.Width = 200;
            // 
            // TieuThu_TT
            // 
            this.TieuThu_TT.DataPropertyName = "TieuThu";
            this.TieuThu_TT.HeaderText = "Tiêu Thụ";
            this.TieuThu_TT.Name = "TieuThu_TT";
            this.TieuThu_TT.ReadOnly = true;
            this.TieuThu_TT.Width = 80;
            // 
            // GiaBan_TT
            // 
            this.GiaBan_TT.DataPropertyName = "GiaBan";
            this.GiaBan_TT.HeaderText = "Giá Bán";
            this.GiaBan_TT.Name = "GiaBan_TT";
            this.GiaBan_TT.ReadOnly = true;
            this.GiaBan_TT.Width = 80;
            // 
            // ThueGTGT_TT
            // 
            this.ThueGTGT_TT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_TT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_TT.Name = "ThueGTGT_TT";
            this.ThueGTGT_TT.ReadOnly = true;
            // 
            // PhiBVMT_TT
            // 
            this.PhiBVMT_TT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_TT.HeaderText = "Phí BVMT";
            this.PhiBVMT_TT.Name = "PhiBVMT_TT";
            this.PhiBVMT_TT.ReadOnly = true;
            // 
            // TongCong_TT
            // 
            this.TongCong_TT.DataPropertyName = "TongCong";
            this.TongCong_TT.HeaderText = "Tổng Cộng";
            this.TongCong_TT.Name = "TongCong_TT";
            this.TongCong_TT.ReadOnly = true;
            // 
            // frmTamThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 666);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Name = "frmTamThu";
            this.Text = "Tạm Thu";
            this.Load += new System.EventHandler(this.frmTamThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabTamThu.ResumeLayout(false);
            this.tabTamThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTamThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabThongTin;
        private System.Windows.Forms.TabPage tabTamThu;
        private System.Windows.Forms.DataGridView dgvTamThu;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_TT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TT;
    }
}