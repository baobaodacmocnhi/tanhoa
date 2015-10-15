namespace ThuTien.GUI.TongHop
{
    partial class frmDCHD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDCHD = new System.Windows.Forms.DataGridView();
            this.Ngay_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDCHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TangGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_DC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnInDSDangNgan = new System.Windows.Forms.Button();
            this.btnInDSTon = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDCHD)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "(Enter)";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(194, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 32;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Danh Bộ:";
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
            this.MaHD,
            this.NgayGiaiTrach,
            this.SoHoaDon,
            this.Ky,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.To,
            this.HanhThu});
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 38);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1284, 200);
            this.dgvHoaDon.TabIndex = 30;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            this.dgvHoaDon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvHoaDon_MouseDoubleClick);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = false;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.Width = 80;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 50;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.Width = 70;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT.HeaderText = "Thuế GTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            this.ThueGTGT.Width = 70;
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT.HeaderText = "Phí BVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            this.PhiBVMT.Width = 70;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.Width = 70;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 40;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.Width = 170;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(489, 242);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 39;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(383, 244);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 38;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(319, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Đến Ngày:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(213, 244);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(156, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Từ Ngày:";
            // 
            // dgvDCHD
            // 
            this.dgvDCHD.AllowUserToAddRows = false;
            this.dgvDCHD.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDCHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDCHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDCHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ngay_DC,
            this.MaDCHD,
            this.SoHoaDon_DC,
            this.Ky_DC,
            this.MLT_DC,
            this.DanhBo_DC,
            this.HoTen_DC,
            this.DiaChi_DC,
            this.TieuThu_DC,
            this.GiaBan_End,
            this.ThueGTGT_End,
            this.PhiBVMT_End,
            this.TongCong_End,
            this.TongCong_Start,
            this.TangGiam,
            this.TongCong_BD,
            this.To_DC,
            this.HanhThu_DC});
            this.dgvDCHD.Location = new System.Drawing.Point(12, 270);
            this.dgvDCHD.Name = "dgvDCHD";
            this.dgvDCHD.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDCHD.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDCHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDCHD.Size = new System.Drawing.Size(1284, 300);
            this.dgvDCHD.TabIndex = 34;
            this.dgvDCHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDCHD_CellFormatting);
            this.dgvDCHD.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDCHD_RowPostPaint);
            this.dgvDCHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDCHD_MouseDoubleClick);
            // 
            // Ngay_DC
            // 
            this.Ngay_DC.DataPropertyName = "NgayDC";
            this.Ngay_DC.HeaderText = "Ngày ĐC";
            this.Ngay_DC.Name = "Ngay_DC";
            this.Ngay_DC.ReadOnly = true;
            // 
            // MaDCHD
            // 
            this.MaDCHD.DataPropertyName = "MaDCHD";
            this.MaDCHD.HeaderText = "MaDCHD";
            this.MaDCHD.Name = "MaDCHD";
            this.MaDCHD.ReadOnly = true;
            this.MaDCHD.Visible = false;
            // 
            // SoHoaDon_DC
            // 
            this.SoHoaDon_DC.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_DC.HeaderText = "Số HĐ";
            this.SoHoaDon_DC.Name = "SoHoaDon_DC";
            this.SoHoaDon_DC.ReadOnly = true;
            // 
            // Ky_DC
            // 
            this.Ky_DC.DataPropertyName = "Ky";
            this.Ky_DC.HeaderText = "Kỳ";
            this.Ky_DC.Name = "Ky_DC";
            this.Ky_DC.ReadOnly = true;
            this.Ky_DC.Width = 50;
            // 
            // MLT_DC
            // 
            this.MLT_DC.DataPropertyName = "MLT";
            this.MLT_DC.HeaderText = "MLT";
            this.MLT_DC.Name = "MLT_DC";
            this.MLT_DC.ReadOnly = true;
            this.MLT_DC.Visible = false;
            this.MLT_DC.Width = 80;
            // 
            // DanhBo_DC
            // 
            this.DanhBo_DC.DataPropertyName = "DanhBo";
            this.DanhBo_DC.HeaderText = "Danh Bộ";
            this.DanhBo_DC.Name = "DanhBo_DC";
            this.DanhBo_DC.ReadOnly = true;
            // 
            // HoTen_DC
            // 
            this.HoTen_DC.DataPropertyName = "HoTen";
            this.HoTen_DC.HeaderText = "Họ Tên";
            this.HoTen_DC.Name = "HoTen_DC";
            this.HoTen_DC.ReadOnly = true;
            this.HoTen_DC.Width = 150;
            // 
            // DiaChi_DC
            // 
            this.DiaChi_DC.DataPropertyName = "DiaChi";
            this.DiaChi_DC.HeaderText = "Địa Chỉ";
            this.DiaChi_DC.Name = "DiaChi_DC";
            this.DiaChi_DC.ReadOnly = true;
            this.DiaChi_DC.Visible = false;
            this.DiaChi_DC.Width = 200;
            // 
            // TieuThu_DC
            // 
            this.TieuThu_DC.DataPropertyName = "TieuThu";
            this.TieuThu_DC.HeaderText = "Tiêu Thụ";
            this.TieuThu_DC.Name = "TieuThu_DC";
            this.TieuThu_DC.ReadOnly = true;
            this.TieuThu_DC.Visible = false;
            this.TieuThu_DC.Width = 50;
            // 
            // GiaBan_End
            // 
            this.GiaBan_End.DataPropertyName = "GiaBan_End";
            this.GiaBan_End.HeaderText = "Giá Bán";
            this.GiaBan_End.Name = "GiaBan_End";
            this.GiaBan_End.ReadOnly = true;
            this.GiaBan_End.Width = 70;
            // 
            // ThueGTGT_End
            // 
            this.ThueGTGT_End.DataPropertyName = "ThueGTGT_End";
            this.ThueGTGT_End.HeaderText = "Thuế GTGT";
            this.ThueGTGT_End.Name = "ThueGTGT_End";
            this.ThueGTGT_End.ReadOnly = true;
            this.ThueGTGT_End.Width = 70;
            // 
            // PhiBVMT_End
            // 
            this.PhiBVMT_End.DataPropertyName = "PhiBVMT_End";
            this.PhiBVMT_End.HeaderText = "Phí BVMT";
            this.PhiBVMT_End.Name = "PhiBVMT_End";
            this.PhiBVMT_End.ReadOnly = true;
            this.PhiBVMT_End.Width = 70;
            // 
            // TongCong_End
            // 
            this.TongCong_End.DataPropertyName = "TongCong_End";
            this.TongCong_End.HeaderText = "Tổng Cộng";
            this.TongCong_End.Name = "TongCong_End";
            this.TongCong_End.ReadOnly = true;
            this.TongCong_End.Width = 70;
            // 
            // TongCong_Start
            // 
            this.TongCong_Start.DataPropertyName = "TongCong_Start";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.TongCong_Start.DefaultCellStyle = dataGridViewCellStyle4;
            this.TongCong_Start.HeaderText = "Tổng Cộng Trước";
            this.TongCong_Start.Name = "TongCong_Start";
            this.TongCong_Start.ReadOnly = true;
            // 
            // TangGiam
            // 
            this.TangGiam.DataPropertyName = "TangGiam";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TangGiam.DefaultCellStyle = dataGridViewCellStyle5;
            this.TangGiam.HeaderText = "Biến Động";
            this.TangGiam.Name = "TangGiam";
            this.TangGiam.ReadOnly = true;
            this.TangGiam.Width = 50;
            // 
            // TongCong_BD
            // 
            this.TongCong_BD.DataPropertyName = "TongCong_BD";
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.TongCong_BD.DefaultCellStyle = dataGridViewCellStyle6;
            this.TongCong_BD.HeaderText = "Tổng Cộng BD";
            this.TongCong_BD.Name = "TongCong_BD";
            this.TongCong_BD.ReadOnly = true;
            this.TongCong_BD.Width = 80;
            // 
            // To_DC
            // 
            this.To_DC.DataPropertyName = "To";
            this.To_DC.HeaderText = "Tổ";
            this.To_DC.Name = "To_DC";
            this.To_DC.ReadOnly = true;
            this.To_DC.Width = 40;
            // 
            // HanhThu_DC
            // 
            this.HanhThu_DC.DataPropertyName = "HanhThu";
            this.HanhThu_DC.HeaderText = "Hành Thu";
            this.HanhThu_DC.Name = "HanhThu_DC";
            this.HanhThu_DC.ReadOnly = true;
            this.HanhThu_DC.Width = 170;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(570, 242);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnInDSDangNgan
            // 
            this.btnInDSDangNgan.Location = new System.Drawing.Point(651, 242);
            this.btnInDSDangNgan.Name = "btnInDSDangNgan";
            this.btnInDSDangNgan.Size = new System.Drawing.Size(103, 23);
            this.btnInDSDangNgan.TabIndex = 41;
            this.btnInDSDangNgan.Text = "In DS Đăng Ngân";
            this.btnInDSDangNgan.UseVisualStyleBackColor = true;
            this.btnInDSDangNgan.Click += new System.EventHandler(this.btnInDSDangNgan_Click);
            // 
            // btnInDSTon
            // 
            this.btnInDSTon.Location = new System.Drawing.Point(760, 242);
            this.btnInDSTon.Name = "btnInDSTon";
            this.btnInDSTon.Size = new System.Drawing.Size(75, 23);
            this.btnInDSTon.TabIndex = 42;
            this.btnInDSTon.Text = "In DS Tồn";
            this.btnInDSTon.UseVisualStyleBackColor = true;
            this.btnInDSTon.Click += new System.EventHandler(this.btnInDSTon_Click);
            // 
            // frmDCHD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 662);
            this.Controls.Add(this.btnInDSTon);
            this.Controls.Add(this.btnInDSDangNgan);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvDCHD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHoaDon);
            this.Name = "frmDCHD";
            this.Text = "Điều Chỉnh Hóa Đơn";
            this.Load += new System.EventHandler(this.frmDCHD_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDCHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDCHD;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnInDSDangNgan;
        private System.Windows.Forms.Button btnInDSTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngay_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDCHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn TangGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_DC;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_DC;
    }
}