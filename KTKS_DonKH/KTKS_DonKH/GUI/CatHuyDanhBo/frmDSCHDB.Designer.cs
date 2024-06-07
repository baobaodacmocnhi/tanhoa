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
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbQuan = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInDS = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTCHDB)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSYCCHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // radDSCatTamDanhBo
            // 
            this.radDSCatTamDanhBo.AutoSize = true;
            this.radDSCatTamDanhBo.Location = new System.Drawing.Point(113, 12);
            this.radDSCatTamDanhBo.Name = "radDSCatTamDanhBo";
            this.radDSCatTamDanhBo.Size = new System.Drawing.Size(99, 20);
            this.radDSCatTamDanhBo.TabIndex = 2;
            this.radDSCatTamDanhBo.Text = "DS Cắt Tạm";
            this.radDSCatTamDanhBo.UseVisualStyleBackColor = true;
            this.radDSCatTamDanhBo.CheckedChanged += new System.EventHandler(this.radDSCatTamDanhBo_CheckedChanged);
            // 
            // radDSCatHuyDanhBo
            // 
            this.radDSCatHuyDanhBo.AutoSize = true;
            this.radDSCatHuyDanhBo.Location = new System.Drawing.Point(113, 38);
            this.radDSCatHuyDanhBo.Name = "radDSCatHuyDanhBo";
            this.radDSCatHuyDanhBo.Size = new System.Drawing.Size(95, 20);
            this.radDSCatHuyDanhBo.TabIndex = 3;
            this.radDSCatHuyDanhBo.Text = "DS Cắt Hủy";
            this.radDSCatHuyDanhBo.UseVisualStyleBackColor = true;
            this.radDSCatHuyDanhBo.CheckedChanged += new System.EventHandler(this.radDSCatHuyDanhBo_CheckedChanged);
            // 
            // dgvDSCTCHDB
            // 
            this.dgvDSCTCHDB.AllowUserToAddRows = false;
            this.dgvDSCTCHDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.GhiChuLyDo});
            this.dgvDSCTCHDB.Location = new System.Drawing.Point(1, 68);
            this.dgvDSCTCHDB.Name = "dgvDSCTCHDB";
            this.dgvDSCTCHDB.RowHeadersWidth = 60;
            this.dgvDSCTCHDB.Size = new System.Drawing.Size(1350, 530);
            this.dgvDSCTCHDB.TabIndex = 11;
            this.dgvDSCTCHDB.Visible = false;
            this.dgvDSCTCHDB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSCTCHDB_CellEndEdit);
            this.dgvDSCTCHDB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSCTCHDB_CellFormatting);
            this.dgvDSCTCHDB.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDSCTCHDB_CellValidating);
            this.dgvDSCTCHDB.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSCTCHDB_RowPostPaint);
            this.dgvDSCTCHDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSCTCHDB_KeyDown);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.FalseValue = "False";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.TrueValue = "True";
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
            this.MaTB.DataPropertyName = "ID";
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
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "Lý Do";
            this.LyDo.Name = "LyDo";
            this.LyDo.ReadOnly = true;
            this.LyDo.Width = 200;
            // 
            // GhiChuLyDo
            // 
            this.GhiChuLyDo.DataPropertyName = "GhiChuLyDo";
            this.GhiChuLyDo.HeaderText = "Ghi Chú";
            this.GhiChuLyDo.Name = "GhiChuLyDo";
            this.GhiChuLyDo.ReadOnly = true;
            this.GhiChuLyDo.Width = 200;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(367, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
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
            "Số Thông Báo/Số Phiếu",
            "Ngày",
            "Lý Do",
            "Hết Hạn"});
            this.cmbTimTheo.Location = new System.Drawing.Point(441, 5);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 2;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(621, 15);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 4;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nội Dung:";
            // 
            // radDSDongNuoc
            // 
            this.radDSDongNuoc.AutoSize = true;
            this.radDSDongNuoc.Location = new System.Drawing.Point(218, 38);
            this.radDSDongNuoc.Name = "radDSDongNuoc";
            this.radDSDongNuoc.Size = new System.Drawing.Size(115, 20);
            this.radDSDongNuoc.TabIndex = 5;
            this.radDSDongNuoc.Text = "DS Đóng Nước";
            this.radDSDongNuoc.UseVisualStyleBackColor = true;
            this.radDSDongNuoc.CheckedChanged += new System.EventHandler(this.radDSDongNuoc_CheckedChanged);
            // 
            // radDSYCCHDB
            // 
            this.radDSYCCHDB.AutoSize = true;
            this.radDSYCCHDB.Location = new System.Drawing.Point(218, 12);
            this.radDSYCCHDB.Name = "radDSYCCHDB";
            this.radDSYCCHDB.Size = new System.Drawing.Size(131, 20);
            this.radDSYCCHDB.TabIndex = 4;
            this.radDSYCCHDB.Text = "DS Phiếu Hủy DB";
            this.radDSYCCHDB.UseVisualStyleBackColor = true;
            this.radDSYCCHDB.CheckedChanged += new System.EventHandler(this.radDSYCCHDB_CheckedChanged);
            // 
            // btnInNhan
            // 
            this.btnInNhan.Location = new System.Drawing.Point(989, 18);
            this.btnInNhan.Name = "btnInNhan";
            this.btnInNhan.Size = new System.Drawing.Size(75, 25);
            this.btnInNhan.TabIndex = 26;
            this.btnInNhan.Text = "In Nhãn";
            this.btnInNhan.UseVisualStyleBackColor = true;
            this.btnInNhan.Click += new System.EventHandler(this.btnInNhan_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 38);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(101, 20);
            this.chkSelectAll.TabIndex = 7;
            this.chkSelectAll.Text = "Chọn Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(880, 18);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(103, 25);
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
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(616, 2);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(177, 60);
            this.panel_KhoangThoiGian.TabIndex = 6;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(80, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(80, 32);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // dgvDSYCCHDB
            // 
            this.dgvDSYCCHDB.AllowUserToAddRows = false;
            this.dgvDSYCCHDB.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.YC_GhiChuLyDo});
            this.dgvDSYCCHDB.Location = new System.Drawing.Point(1, 113);
            this.dgvDSYCCHDB.Name = "dgvDSYCCHDB";
            this.dgvDSYCCHDB.RowHeadersWidth = 60;
            this.dgvDSYCCHDB.Size = new System.Drawing.Size(1350, 530);
            this.dgvDSYCCHDB.TabIndex = 25;
            this.dgvDSYCCHDB.Visible = false;
            this.dgvDSYCCHDB.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSYCCHDB_CellEndEdit);
            this.dgvDSYCCHDB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSYCCHDB_CellFormatting);
            this.dgvDSYCCHDB.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDSYCCHDB_CellValidating);
            this.dgvDSYCCHDB.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSYCCHDB_RowPostPaint);
            this.dgvDSYCCHDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSYCCHDB_KeyDown);
            // 
            // YC_In
            // 
            this.YC_In.DataPropertyName = "In";
            this.YC_In.FalseValue = "False";
            this.YC_In.HeaderText = "In";
            this.YC_In.Name = "YC_In";
            this.YC_In.TrueValue = "True";
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
            this.SoPhieu.DataPropertyName = "ID";
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
            this.YC_HoTen.Width = 150;
            // 
            // YC_DiaChi
            // 
            this.YC_DiaChi.DataPropertyName = "DiaChi";
            this.YC_DiaChi.HeaderText = "Địa Chỉ";
            this.YC_DiaChi.Name = "YC_DiaChi";
            this.YC_DiaChi.ReadOnly = true;
            this.YC_DiaChi.Width = 200;
            // 
            // YC_LyDo
            // 
            this.YC_LyDo.DataPropertyName = "LyDo";
            this.YC_LyDo.HeaderText = "Lý Do Xử Lý";
            this.YC_LyDo.Name = "YC_LyDo";
            this.YC_LyDo.ReadOnly = true;
            this.YC_LyDo.Width = 200;
            // 
            // YC_GhiChuLyDo
            // 
            this.YC_GhiChuLyDo.DataPropertyName = "GhiChuLyDo";
            this.YC_GhiChuLyDo.HeaderText = "Ghi Chú";
            this.YC_GhiChuLyDo.Name = "YC_GhiChuLyDo";
            this.YC_GhiChuLyDo.ReadOnly = true;
            this.YC_GhiChuLyDo.Width = 200;
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(621, 37);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem2.TabIndex = 5;
            this.txtNoiDungTimKiem2.Visible = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(799, 18);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 27;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbQuan
            // 
            this.cmbQuan.FormattingEnabled = true;
            this.cmbQuan.Location = new System.Drawing.Point(441, 35);
            this.cmbQuan.Name = "cmbQuan";
            this.cmbQuan.Size = new System.Drawing.Size(100, 24);
            this.cmbQuan.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(395, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Quận";
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(1070, 18);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 25);
            this.btnInDS.TabIndex = 33;
            this.btnInDS.Text = "In DS";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // frmDSCHDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1421, 619);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.cmbQuan);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.radDSCatTamDanhBo);
            this.Controls.Add(this.radDSYCCHDB);
            this.Controls.Add(this.radDSCatHuyDanhBo);
            this.Controls.Add(this.radDSDongNuoc);
            this.Controls.Add(this.btnInNhan);
            this.Controls.Add(this.dgvDSYCCHDB);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDSCTCHDB);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDSCHDB";
            this.Text = "Danh Sách Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmDSCHDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTCHDB)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Button btnInNhan;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Button btnXem;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn YC_In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn YC_PhieuDuocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn YC_GhiChuLyDo;
        private System.Windows.Forms.ComboBox cmbQuan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnInDS;
    }
}