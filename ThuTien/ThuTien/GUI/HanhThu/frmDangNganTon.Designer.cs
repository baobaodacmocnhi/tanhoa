namespace ThuTien.GUI.HanhThu
{
    partial class frmDangNganTon
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
            this.label5 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.txtTongGiaBan_TG = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT_TG = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_TG = new System.Windows.Forms.TextBox();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.MaHD_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.txtTongGiaBan_CQ = new System.Windows.Forms.TextBox();
            this.txtTongThueGTGT_CQ = new System.Windows.Forms.TextBox();
            this.txtTongPhiBVMT_CQ = new System.Windows.Forms.TextBox();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.MaHD_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            this.dateGiaiTrach = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 29;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(87, 12);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 25;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 28;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 27;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 26;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(565, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 36;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(161, 226);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(75, 23);
            this.btnInPhieu.TabIndex = 37;
            this.btnInPhieu.Text = "In Phiếu";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(85, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "(Enter)";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(268, 38);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(945, 597);
            this.tabControl.TabIndex = 41;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.txtTongGiaBan_TG);
            this.tabTuGia.Controls.Add(this.txtTongThueGTGT_TG);
            this.tabTuGia.Controls.Add(this.txtTongPhiBVMT_TG);
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(937, 571);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(6, 546);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_TG.TabIndex = 5;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongGiaBan_TG
            // 
            this.txtTongGiaBan_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_TG.Location = new System.Drawing.Point(409, 546);
            this.txtTongGiaBan_TG.Name = "txtTongGiaBan_TG";
            this.txtTongGiaBan_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_TG.TabIndex = 4;
            this.txtTongGiaBan_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT_TG
            // 
            this.txtTongThueGTGT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_TG.Location = new System.Drawing.Point(509, 546);
            this.txtTongThueGTGT_TG.Name = "txtTongThueGTGT_TG";
            this.txtTongThueGTGT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_TG.TabIndex = 3;
            this.txtTongThueGTGT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_TG
            // 
            this.txtTongPhiBVMT_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_TG.Location = new System.Drawing.Point(609, 546);
            this.txtTongPhiBVMT_TG.Name = "txtTongPhiBVMT_TG";
            this.txtTongPhiBVMT_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_TG.TabIndex = 2;
            this.txtTongPhiBVMT_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongCong_TG
            // 
            this.txtTongCong_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_TG.Location = new System.Drawing.Point(709, 546);
            this.txtTongCong_TG.Name = "txtTongCong_TG";
            this.txtTongCong_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_TG.TabIndex = 1;
            this.txtTongCong_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_TG,
            this.NgayGiaiTrach_TG,
            this.SoHoaDon_TG,
            this.Ky_TG,
            this.MLT_TG,
            this.SoPhatHanh_TG,
            this.DanhBo_TG,
            this.TieuThu_TG,
            this.GiaBan_TG,
            this.ThueGTGT_TG,
            this.PhiBVMT_TG,
            this.TongCong_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDTuGia.Size = new System.Drawing.Size(925, 540);
            this.dgvHDTuGia.TabIndex = 0;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // MaHD_TG
            // 
            this.MaHD_TG.DataPropertyName = "MaHD";
            this.MaHD_TG.HeaderText = "MaHD";
            this.MaHD_TG.Name = "MaHD_TG";
            this.MaHD_TG.ReadOnly = true;
            this.MaHD_TG.Visible = false;
            // 
            // NgayGiaiTrach_TG
            // 
            this.NgayGiaiTrach_TG.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_TG.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_TG.Name = "NgayGiaiTrach_TG";
            this.NgayGiaiTrach_TG.ReadOnly = true;
            this.NgayGiaiTrach_TG.Width = 80;
            // 
            // SoHoaDon_TG
            // 
            this.SoHoaDon_TG.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TG.HeaderText = "Số HĐ";
            this.SoHoaDon_TG.Name = "SoHoaDon_TG";
            this.SoHoaDon_TG.ReadOnly = true;
            // 
            // Ky_TG
            // 
            this.Ky_TG.DataPropertyName = "Ky";
            this.Ky_TG.HeaderText = "Kỳ";
            this.Ky_TG.Name = "Ky_TG";
            this.Ky_TG.ReadOnly = true;
            this.Ky_TG.Visible = false;
            // 
            // MLT_TG
            // 
            this.MLT_TG.DataPropertyName = "MLT";
            this.MLT_TG.HeaderText = "MLT";
            this.MLT_TG.Name = "MLT_TG";
            this.MLT_TG.ReadOnly = true;
            // 
            // SoPhatHanh_TG
            // 
            this.SoPhatHanh_TG.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_TG.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_TG.Name = "SoPhatHanh_TG";
            this.SoPhatHanh_TG.ReadOnly = true;
            this.SoPhatHanh_TG.Visible = false;
            // 
            // DanhBo_TG
            // 
            this.DanhBo_TG.DataPropertyName = "DanhBo";
            this.DanhBo_TG.HeaderText = "Danh Bộ";
            this.DanhBo_TG.Name = "DanhBo_TG";
            this.DanhBo_TG.ReadOnly = true;
            // 
            // TieuThu_TG
            // 
            this.TieuThu_TG.DataPropertyName = "TieuThu";
            this.TieuThu_TG.HeaderText = "Tiêu Thụ";
            this.TieuThu_TG.Name = "TieuThu_TG";
            this.TieuThu_TG.ReadOnly = true;
            this.TieuThu_TG.Width = 80;
            // 
            // GiaBan_TG
            // 
            this.GiaBan_TG.DataPropertyName = "GiaBan";
            this.GiaBan_TG.HeaderText = "Giá Bán";
            this.GiaBan_TG.Name = "GiaBan_TG";
            this.GiaBan_TG.ReadOnly = true;
            // 
            // ThueGTGT_TG
            // 
            this.ThueGTGT_TG.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_TG.HeaderText = "Thuế GTGT";
            this.ThueGTGT_TG.Name = "ThueGTGT_TG";
            this.ThueGTGT_TG.ReadOnly = true;
            // 
            // PhiBVMT_TG
            // 
            this.PhiBVMT_TG.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_TG.HeaderText = "Phí BVMT";
            this.PhiBVMT_TG.Name = "PhiBVMT_TG";
            this.PhiBVMT_TG.ReadOnly = true;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongGiaBan_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongThueGTGT_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongPhiBVMT_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(937, 571);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // txtTongHD_CQ
            // 
            this.txtTongHD_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_CQ.Location = new System.Drawing.Point(6, 546);
            this.txtTongHD_CQ.Name = "txtTongHD_CQ";
            this.txtTongHD_CQ.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_CQ.TabIndex = 33;
            this.txtTongHD_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongGiaBan_CQ
            // 
            this.txtTongGiaBan_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongGiaBan_CQ.Location = new System.Drawing.Point(409, 546);
            this.txtTongGiaBan_CQ.Name = "txtTongGiaBan_CQ";
            this.txtTongGiaBan_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongGiaBan_CQ.TabIndex = 13;
            this.txtTongGiaBan_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongThueGTGT_CQ
            // 
            this.txtTongThueGTGT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongThueGTGT_CQ.Location = new System.Drawing.Point(509, 546);
            this.txtTongThueGTGT_CQ.Name = "txtTongThueGTGT_CQ";
            this.txtTongThueGTGT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongThueGTGT_CQ.TabIndex = 12;
            this.txtTongThueGTGT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhiBVMT_CQ
            // 
            this.txtTongPhiBVMT_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhiBVMT_CQ.Location = new System.Drawing.Point(609, 546);
            this.txtTongPhiBVMT_CQ.Name = "txtTongPhiBVMT_CQ";
            this.txtTongPhiBVMT_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongPhiBVMT_CQ.TabIndex = 11;
            this.txtTongPhiBVMT_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD_CQ,
            this.NgayGiaiTrach_CQ,
            this.SoHoaDon_CQ,
            this.Ky_CQ,
            this.MLT_CQ,
            this.SoPhatHanh_CQ,
            this.DanhBo_CQ,
            this.TieuThu_CQ,
            this.GiaBan_CQ,
            this.ThueGTGT_CQ,
            this.PhiBVMT_CQ,
            this.TongCong_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(925, 540);
            this.dgvHDCoQuan.TabIndex = 10;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // MaHD_CQ
            // 
            this.MaHD_CQ.DataPropertyName = "MaHD";
            this.MaHD_CQ.HeaderText = "MaHD";
            this.MaHD_CQ.Name = "MaHD_CQ";
            this.MaHD_CQ.ReadOnly = true;
            this.MaHD_CQ.Visible = false;
            // 
            // NgayGiaiTrach_CQ
            // 
            this.NgayGiaiTrach_CQ.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_CQ.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_CQ.Name = "NgayGiaiTrach_CQ";
            this.NgayGiaiTrach_CQ.ReadOnly = true;
            this.NgayGiaiTrach_CQ.Width = 80;
            // 
            // SoHoaDon_CQ
            // 
            this.SoHoaDon_CQ.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CQ.HeaderText = "Số HĐ";
            this.SoHoaDon_CQ.Name = "SoHoaDon_CQ";
            this.SoHoaDon_CQ.ReadOnly = true;
            // 
            // Ky_CQ
            // 
            this.Ky_CQ.DataPropertyName = "Ky";
            this.Ky_CQ.HeaderText = "Kỳ";
            this.Ky_CQ.Name = "Ky_CQ";
            this.Ky_CQ.ReadOnly = true;
            this.Ky_CQ.Visible = false;
            // 
            // MLT_CQ
            // 
            this.MLT_CQ.DataPropertyName = "MLT";
            this.MLT_CQ.HeaderText = "MLT";
            this.MLT_CQ.Name = "MLT_CQ";
            this.MLT_CQ.ReadOnly = true;
            // 
            // SoPhatHanh_CQ
            // 
            this.SoPhatHanh_CQ.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_CQ.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_CQ.Name = "SoPhatHanh_CQ";
            this.SoPhatHanh_CQ.ReadOnly = true;
            this.SoPhatHanh_CQ.Visible = false;
            // 
            // DanhBo_CQ
            // 
            this.DanhBo_CQ.DataPropertyName = "DanhBo";
            this.DanhBo_CQ.HeaderText = "Danh Bộ";
            this.DanhBo_CQ.Name = "DanhBo_CQ";
            this.DanhBo_CQ.ReadOnly = true;
            // 
            // TieuThu_CQ
            // 
            this.TieuThu_CQ.DataPropertyName = "TieuThu";
            this.TieuThu_CQ.HeaderText = "Tiêu Thụ";
            this.TieuThu_CQ.Name = "TieuThu_CQ";
            this.TieuThu_CQ.ReadOnly = true;
            this.TieuThu_CQ.Width = 80;
            // 
            // GiaBan_CQ
            // 
            this.GiaBan_CQ.DataPropertyName = "GiaBan";
            this.GiaBan_CQ.HeaderText = "Giá Bán";
            this.GiaBan_CQ.Name = "GiaBan_CQ";
            this.GiaBan_CQ.ReadOnly = true;
            // 
            // ThueGTGT_CQ
            // 
            this.ThueGTGT_CQ.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_CQ.HeaderText = "Thuế GTGT";
            this.ThueGTGT_CQ.Name = "ThueGTGT_CQ";
            this.ThueGTGT_CQ.ReadOnly = true;
            // 
            // PhiBVMT_CQ
            // 
            this.PhiBVMT_CQ.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_CQ.HeaderText = "Phí BVMT";
            this.PhiBVMT_CQ.Name = "PhiBVMT_CQ";
            this.PhiBVMT_CQ.ReadOnly = true;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(709, 546);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 9;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dateGiaiTrach
            // 
            this.dateGiaiTrach.CustomFormat = "dd/MM/yyyy";
            this.dateGiaiTrach.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGiaiTrach.Location = new System.Drawing.Point(459, 12);
            this.dateGiaiTrach.Name = "dateGiaiTrach";
            this.dateGiaiTrach.Size = new System.Drawing.Size(100, 20);
            this.dateGiaiTrach.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Ngày Giải Trách:";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(161, 181);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(81, 23);
            this.btnIn.TabIndex = 44;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // frmDangNganTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 706);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dateGiaiTrach);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnInPhieu);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label4);
            this.Name = "frmDangNganTon";
            this.Text = "Đăng Ngân Tồn";
            this.Load += new System.EventHandler(this.frmDangNganTon_Load);
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.TextBox txtTongGiaBan_TG;
        private System.Windows.Forms.TextBox txtTongThueGTGT_TG;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_TG;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.TextBox txtTongGiaBan_CQ;
        private System.Windows.Forms.TextBox txtTongThueGTGT_CQ;
        private System.Windows.Forms.TextBox txtTongPhiBVMT_CQ;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.TextBox txtTongCong_CQ;
        private System.Windows.Forms.DateTimePicker dateGiaiTrach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
    }
}