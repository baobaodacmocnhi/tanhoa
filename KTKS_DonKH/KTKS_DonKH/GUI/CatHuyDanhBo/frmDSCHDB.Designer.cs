namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmDSCHDB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.radDSCatTamDanhBo = new System.Windows.Forms.RadioButton();
            this.radDSCatHuyDanhBo = new System.Windows.Forms.RadioButton();
            this.dgvDSCTCHDB = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PhieuDuocKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DaLapPhieu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoPhieuYCCHDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThongBaoDuocKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChuLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radDSDongNuoc = new System.Windows.Forms.RadioButton();
            this.radDSYCCHDB = new System.Windows.Forms.RadioButton();
            this.btnInNhan = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnIn = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDSYCCHDB = new System.Windows.Forms.DataGridView();
            this.YC_In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.YC_PhieuDuocKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_GhiChuLyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YC_NgayCatTamNutBit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCongVan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayCongVan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTCHDB)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSYCCHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // radDSCatTamDanhBo
            // 
            this.radDSCatTamDanhBo.AutoSize = true;
            this.radDSCatTamDanhBo.Location = new System.Drawing.Point(94, 16);
            this.radDSCatTamDanhBo.Name = "radDSCatTamDanhBo";
            this.radDSCatTamDanhBo.Size = new System.Drawing.Size(135, 19);
            this.radDSCatTamDanhBo.TabIndex = 2;
            this.radDSCatTamDanhBo.Text = "Danh Sách Cắt Tạm";
            this.radDSCatTamDanhBo.UseVisualStyleBackColor = true;
            this.radDSCatTamDanhBo.CheckedChanged += new System.EventHandler(this.radDSCatTamDanhBo_CheckedChanged);
            // 
            // radDSCatHuyDanhBo
            // 
            this.radDSCatHuyDanhBo.AutoSize = true;
            this.radDSCatHuyDanhBo.Location = new System.Drawing.Point(94, 41);
            this.radDSCatHuyDanhBo.Name = "radDSCatHuyDanhBo";
            this.radDSCatHuyDanhBo.Size = new System.Drawing.Size(131, 19);
            this.radDSCatHuyDanhBo.TabIndex = 3;
            this.radDSCatHuyDanhBo.Text = "Danh Sách Cắt Hủy";
            this.radDSCatHuyDanhBo.UseVisualStyleBackColor = true;
            this.radDSCatHuyDanhBo.CheckedChanged += new System.EventHandler(this.radDSCatHuyDanhBo_CheckedChanged);
            // 
            // dgvDSCTCHDB
            // 
            this.dgvDSCTCHDB.AllowUserToAddRows = false;
            this.dgvDSCTCHDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCTCHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCTCHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCTCHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.PhieuDuocKy,
            this.DaLapPhieu,
            this.SoPhieuYCCHDB,
            this.ThongBaoDuocKy,
            this.MaTB,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.LyDo,
            this.GhiChuLyDo,
            this.SoTien});
            this.dgvDSCTCHDB.Location = new System.Drawing.Point(1, 64);
            this.dgvDSCTCHDB.Name = "dgvDSCTCHDB";
            this.dgvDSCTCHDB.RowHeadersWidth = 60;
            this.dgvDSCTCHDB.Size = new System.Drawing.Size(1192, 415);
            this.dgvDSCTCHDB.TabIndex = 11;
            this.dgvDSCTCHDB.Visible = false;
            this.dgvDSCTCHDB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSCTCHDB_CellEndEdit);
            this.dgvDSCTCHDB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSCTCHDB_CellFormatting);
            this.dgvDSCTCHDB.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSCTCHDB_RowPostPaint);
            this.dgvDSCTCHDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSCTCHDB_KeyDown);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.Width = 30;
            // 
            // PhieuDuocKy
            // 
            this.PhieuDuocKy.DataPropertyName = "PhieuDuocKy";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.NullValue = false;
            this.PhieuDuocKy.DefaultCellStyle = dataGridViewCellStyle2;
            this.PhieuDuocKy.HeaderText = "Phiếu Được Ký";
            this.PhieuDuocKy.Name = "PhieuDuocKy";
            this.PhieuDuocKy.Width = 80;
            // 
            // DaLapPhieu
            // 
            this.DaLapPhieu.DataPropertyName = "DaLapPhieu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.NullValue = false;
            this.DaLapPhieu.DefaultCellStyle = dataGridViewCellStyle3;
            this.DaLapPhieu.HeaderText = "Đã Lập Phiếu";
            this.DaLapPhieu.Name = "DaLapPhieu";
            this.DaLapPhieu.ReadOnly = true;
            this.DaLapPhieu.Width = 70;
            // 
            // SoPhieuYCCHDB
            // 
            this.SoPhieuYCCHDB.DataPropertyName = "SoPhieu";
            this.SoPhieuYCCHDB.HeaderText = "Số Phiếu";
            this.SoPhieuYCCHDB.Name = "SoPhieuYCCHDB";
            this.SoPhieuYCCHDB.Width = 90;
            // 
            // ThongBaoDuocKy
            // 
            this.ThongBaoDuocKy.DataPropertyName = "ThongBaoDuocKy";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.NullValue = false;
            this.ThongBaoDuocKy.DefaultCellStyle = dataGridViewCellStyle4;
            this.ThongBaoDuocKy.HeaderText = "TB Được Ký";
            this.ThongBaoDuocKy.Name = "ThongBaoDuocKy";
            this.ThongBaoDuocKy.Width = 80;
            // 
            // MaTB
            // 
            this.MaTB.DataPropertyName = "MaTB";
            this.MaTB.HeaderText = "Mã Thông Báo";
            this.MaTB.Name = "MaTB";
            this.MaTB.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 90;
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
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 180;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 300;
            // 
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "Lý Do Xử Lý";
            this.LyDo.Name = "LyDo";
            this.LyDo.ReadOnly = true;
            this.LyDo.Width = 230;
            // 
            // GhiChuLyDo
            // 
            this.GhiChuLyDo.DataPropertyName = "GhiChuLyDo";
            this.GhiChuLyDo.HeaderText = "Ghi Chú";
            this.GhiChuLyDo.Name = "GhiChuLyDo";
            this.GhiChuLyDo.ReadOnly = true;
            this.GhiChuLyDo.Width = 253;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            this.SoTien.Width = 90;
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(730, 34);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(114, 21);
            this.dateTimKiem.TabIndex = 6;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(490, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Số Thông Báo",
            "Số Phiếu",
            "Ngày",
            "Khoảng Thời Gian",
            "Lý Do"});
            this.cmbTimTheo.Location = new System.Drawing.Point(555, 14);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(106, 23);
            this.cmbTimTheo.TabIndex = 2;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(730, 14);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(114, 21);
            this.txtNoiDungTimKiem.TabIndex = 4;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nội Dung:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radDSDongNuoc);
            this.groupBox1.Controls.Add(this.radDSYCCHDB);
            this.groupBox1.Controls.Add(this.radDSCatTamDanhBo);
            this.groupBox1.Controls.Add(this.radDSCatHuyDanhBo);
            this.groupBox1.Location = new System.Drawing.Point(116, -8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 66);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // radDSDongNuoc
            // 
            this.radDSDongNuoc.AutoSize = true;
            this.radDSDongNuoc.Location = new System.Drawing.Point(226, 40);
            this.radDSDongNuoc.Name = "radDSDongNuoc";
            this.radDSDongNuoc.Size = new System.Drawing.Size(151, 19);
            this.radDSDongNuoc.TabIndex = 5;
            this.radDSDongNuoc.Text = "Danh Sách Đóng Nước";
            this.radDSDongNuoc.UseVisualStyleBackColor = true;
            this.radDSDongNuoc.CheckedChanged += new System.EventHandler(this.radDSDongNuoc_CheckedChanged);
            // 
            // radDSYCCHDB
            // 
            this.radDSYCCHDB.AutoSize = true;
            this.radDSYCCHDB.Location = new System.Drawing.Point(228, 16);
            this.radDSYCCHDB.Name = "radDSYCCHDB";
            this.radDSYCCHDB.Size = new System.Drawing.Size(121, 19);
            this.radDSYCCHDB.TabIndex = 4;
            this.radDSYCCHDB.Text = "Danh Sách YCCH";
            this.radDSYCCHDB.UseVisualStyleBackColor = true;
            this.radDSYCCHDB.CheckedChanged += new System.EventHandler(this.radDSYCCHDB_CheckedChanged);
            // 
            // btnInNhan
            // 
            this.btnInNhan.Location = new System.Drawing.Point(1015, 5);
            this.btnInNhan.Name = "btnInNhan";
            this.btnInNhan.Size = new System.Drawing.Size(75, 23);
            this.btnInNhan.TabIndex = 26;
            this.btnInNhan.Text = "In Nhãn";
            this.btnInNhan.UseVisualStyleBackColor = true;
            this.btnInNhan.Click += new System.EventHandler(this.btnInNhan_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(10, 34);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(106, 19);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.Text = "Chọn In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(902, 5);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(90, 23);
            this.btnIn.TabIndex = 8;
            this.btnIn.Text = "In Thông Báo";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(725, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(168, 56);
            this.panel_KhoangThoiGian.TabIndex = 6;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(74, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(88, 21);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(74, 31);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(88, 21);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // dgvDSYCCHDB
            // 
            this.dgvDSYCCHDB.AllowUserToAddRows = false;
            this.dgvDSYCCHDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSYCCHDB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDSYCCHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSYCCHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YC_In,
            this.YC_PhieuDuocKy,
            this.SoPhieu,
            this.YC_CreateDate,
            this.YC_DanhBo,
            this.YC_HoTen,
            this.YC_DiaChi,
            this.YC_LyDo,
            this.YC_GhiChuLyDo,
            this.YC_SoTien,
            this.YC_NgayCatTamNutBit,
            this.NgayXuLy,
            this.SoCongVan,
            this.NgayCongVan});
            this.dgvDSYCCHDB.Location = new System.Drawing.Point(1, 106);
            this.dgvDSYCCHDB.Name = "dgvDSYCCHDB";
            this.dgvDSYCCHDB.RowHeadersWidth = 60;
            this.dgvDSYCCHDB.Size = new System.Drawing.Size(1192, 415);
            this.dgvDSYCCHDB.TabIndex = 25;
            this.dgvDSYCCHDB.Visible = false;
            this.dgvDSYCCHDB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSYCCHDB_CellEndEdit);
            this.dgvDSYCCHDB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSYCCHDB_CellFormatting);
            this.dgvDSYCCHDB.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSYCCHDB_RowPostPaint);
            this.dgvDSYCCHDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSYCCHDB_KeyDown);
            // 
            // YC_In
            // 
            this.YC_In.DataPropertyName = "In";
            this.YC_In.HeaderText = "In";
            this.YC_In.Name = "YC_In";
            this.YC_In.Width = 30;
            // 
            // YC_PhieuDuocKy
            // 
            this.YC_PhieuDuocKy.DataPropertyName = "PhieuDuocKy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.NullValue = false;
            this.YC_PhieuDuocKy.DefaultCellStyle = dataGridViewCellStyle6;
            this.YC_PhieuDuocKy.HeaderText = "Phiếu Được Ký";
            this.YC_PhieuDuocKy.Name = "YC_PhieuDuocKy";
            this.YC_PhieuDuocKy.Width = 80;
            // 
            // SoPhieu
            // 
            this.SoPhieu.DataPropertyName = "SoPhieu";
            this.SoPhieu.HeaderText = "Số Phiếu";
            this.SoPhieu.Name = "SoPhieu";
            this.SoPhieu.ReadOnly = true;
            // 
            // YC_CreateDate
            // 
            this.YC_CreateDate.DataPropertyName = "CreateDate";
            this.YC_CreateDate.HeaderText = "Ngày Lập";
            this.YC_CreateDate.Name = "YC_CreateDate";
            this.YC_CreateDate.ReadOnly = true;
            this.YC_CreateDate.Width = 90;
            // 
            // YC_DanhBo
            // 
            this.YC_DanhBo.DataPropertyName = "DanhBo";
            this.YC_DanhBo.HeaderText = "Danh Bộ";
            this.YC_DanhBo.Name = "YC_DanhBo";
            this.YC_DanhBo.ReadOnly = true;
            // 
            // YC_HoTen
            // 
            this.YC_HoTen.DataPropertyName = "HoTen";
            this.YC_HoTen.HeaderText = "Khách Hàng";
            this.YC_HoTen.Name = "YC_HoTen";
            this.YC_HoTen.ReadOnly = true;
            this.YC_HoTen.Width = 180;
            // 
            // YC_DiaChi
            // 
            this.YC_DiaChi.DataPropertyName = "DiaChi";
            this.YC_DiaChi.HeaderText = "Địa Chỉ";
            this.YC_DiaChi.Name = "YC_DiaChi";
            this.YC_DiaChi.ReadOnly = true;
            this.YC_DiaChi.Width = 300;
            // 
            // YC_LyDo
            // 
            this.YC_LyDo.DataPropertyName = "LyDo";
            this.YC_LyDo.HeaderText = "Lý Do Xử Lý";
            this.YC_LyDo.Name = "YC_LyDo";
            this.YC_LyDo.ReadOnly = true;
            this.YC_LyDo.Width = 230;
            // 
            // YC_GhiChuLyDo
            // 
            this.YC_GhiChuLyDo.DataPropertyName = "GhiChuLyDo";
            this.YC_GhiChuLyDo.HeaderText = "Ghi Chú";
            this.YC_GhiChuLyDo.Name = "YC_GhiChuLyDo";
            this.YC_GhiChuLyDo.ReadOnly = true;
            this.YC_GhiChuLyDo.Width = 253;
            // 
            // YC_SoTien
            // 
            this.YC_SoTien.DataPropertyName = "SoTien";
            this.YC_SoTien.HeaderText = "Số Tiền";
            this.YC_SoTien.Name = "YC_SoTien";
            this.YC_SoTien.ReadOnly = true;
            this.YC_SoTien.Width = 90;
            // 
            // YC_NgayCatTamNutBit
            // 
            this.YC_NgayCatTamNutBit.DataPropertyName = "YC_NgayCatTamNutBit";
            this.YC_NgayCatTamNutBit.HeaderText = "Ngày CTNBit";
            this.YC_NgayCatTamNutBit.Name = "YC_NgayCatTamNutBit";
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.Width = 90;
            // 
            // SoCongVan
            // 
            this.SoCongVan.DataPropertyName = "SoCongVan";
            this.SoCongVan.HeaderText = "Số CV";
            this.SoCongVan.Name = "SoCongVan";
            // 
            // NgayCongVan
            // 
            this.NgayCongVan.DataPropertyName = "NgayCongVan";
            this.NgayCongVan.HeaderText = "Ngày CV";
            this.NgayCongVan.Name = "NgayCongVan";
            this.NgayCongVan.Width = 90;
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(730, 35);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(114, 21);
            this.txtNoiDungTimKiem2.TabIndex = 5;
            this.txtNoiDungTimKiem2.Visible = false;
            this.txtNoiDungTimKiem2.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem2_TextChanged);
            // 
            // frmDSCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1192, 564);
            this.Controls.Add(this.btnInNhan);
            this.Controls.Add(this.dgvDSYCCHDB);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSCTCHDB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSCHDB";
            this.Text = "Danh Sách Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmDSCHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTCHDB)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSYCCHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       

        #endregion

        private System.Windows.Forms.RadioButton radDSCatTamDanhBo;
        private System.Windows.Forms.RadioButton radDSCatHuyDanhBo;
        private System.Windows.Forms.DataGridView dgvDSCTCHDB;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radDSYCCHDB;
        private System.Windows.Forms.DataGridView dgvDSYCCHDB;
        private System.Windows.Forms.RadioButton radDSDongNuoc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PhieuDuocKy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaLapPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuYCCHDB;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ThongBaoDuocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChuLyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewCheckBoxColumn YC_In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn YC_PhieuDuocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_GhiChuLyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_NgayCatTamNutBit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCongVan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayCongVan;
        private System.Windows.Forms.Button btnInNhan;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
    }
}