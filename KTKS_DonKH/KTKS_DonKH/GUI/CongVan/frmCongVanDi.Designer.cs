namespace KTKS_DonKH.GUI.CongVan
{
    partial class frmCongVanDi
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoaiVanBan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTuMa = new System.Windows.Forms.TextBox();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNoiChuyen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDenMa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvDSCongVan = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiVanBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.lstMa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnInDS = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbTuGio = new System.Windows.Forms.ComboBox();
            this.cmbDenGio = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbTimKiem = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.chkcmbNoiNhan = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.chkCreateBy = new System.Windows.Forms.CheckBox();
            this.chkNgayLap = new System.Windows.Forms.CheckBox();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.chkKTXM = new System.Windows.Forms.CheckBox();
            this.chkToTrinh = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnXem_Moi = new System.Windows.Forms.Button();
            this.panelTo = new System.Windows.Forms.Panel();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnIn_Moi = new System.Windows.Forms.Button();
            this.cmbNoiNhan_Moi = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbNoiChuyen_Moi = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dateTu_Moi = new System.Windows.Forms.DateTimePicker();
            this.dateDen_Moi = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCongVan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panelTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Văn Bản:";
            // 
            // cmbLoaiVanBan
            // 
            this.cmbLoaiVanBan.FormattingEnabled = true;
            this.cmbLoaiVanBan.Items.AddRange(new object[] {
            "Đơn Từ Mới",
            "Đơn Tổ Khách Hàng",
            "Đơn Tổ Xử Lý",
            "Đơn Tổ Bấm Chì",
            "Tổ Giao Dịch Khách Hàng",
            "Kiểm Tra Xác Minh",
            "Bấm Chì",
            "Điều Chỉnh Biến Động",
            "Điều Chỉnh Hóa Đơn",
            "Cắt Tạm Danh Bộ",
            "Cắt Hủy Danh Bộ",
            "Phiếu Hủy Danh Bộ",
            "Thư Trả Lời",
            "Khác"});
            this.cmbLoaiVanBan.Location = new System.Drawing.Point(11, 28);
            this.cmbLoaiVanBan.Name = "cmbLoaiVanBan";
            this.cmbLoaiVanBan.Size = new System.Drawing.Size(150, 24);
            this.cmbLoaiVanBan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ Mã:";
            // 
            // txtTuMa
            // 
            this.txtTuMa.Location = new System.Drawing.Point(168, 28);
            this.txtTuMa.Name = "txtTuMa";
            this.txtTuMa.Size = new System.Drawing.Size(70, 22);
            this.txtTuMa.TabIndex = 3;
            this.txtTuMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuMa_KeyPress);
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(385, 28);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 7;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(383, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Danh Bộ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(545, 28);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(201, 22);
            this.txtHoTen.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(541, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Khách Hàng:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung.Location = new System.Drawing.Point(752, 74);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(201, 22);
            this.txtNoiDung.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(746, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nội Dung:";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Items.AddRange(new object[] {
            "Đội TCTB",
            "Tổ Thay",
            "Đội QLĐHN",
            "Đội Thu Tiền",
            "P. KHĐT",
            "P. GNKDT",
            "Ban QLDA",
            "P. Kế Toán",
            "P. TCHC",
            "P. KTCN",
            "Đội TCXL",
            "Tổ Xử Lý",
            "Tổ Bấm Chì",
            "Tổ Giao Dịch Khách Hàng"});
            this.cmbNoiChuyen.Location = new System.Drawing.Point(959, 102);
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(100, 24);
            this.cmbNoiChuyen.TabIndex = 15;
            this.cmbNoiChuyen.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(954, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nơi Chuyển:";
            // 
            // txtDenMa
            // 
            this.txtDenMa.Location = new System.Drawing.Point(168, 74);
            this.txtDenMa.Name = "txtDenMa";
            this.txtDenMa.Size = new System.Drawing.Size(70, 22);
            this.txtDenMa.TabIndex = 5;
            this.txtDenMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenMa_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Đến Mã:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Danh Sách:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(96, 125);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 18;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(96, 153);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Từ Ngày:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 159);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Đến Ngày:";
            // 
            // dgvDSCongVan
            // 
            this.dgvDSCongVan.AllowUserToAddRows = false;
            this.dgvDSCongVan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCongVan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCongVan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCongVan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.LoaiVanBan,
            this.Ma,
            this.NoiDung,
            this.CreateDate,
            this.NoiChuyen,
            this.DanhBo,
            this.DiaChi,
            this.HoTen});
            this.dgvDSCongVan.Location = new System.Drawing.Point(11, 208);
            this.dgvDSCongVan.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSCongVan.Name = "dgvDSCongVan";
            this.dgvDSCongVan.RowHeadersWidth = 60;
            this.dgvDSCongVan.Size = new System.Drawing.Size(655, 346);
            this.dgvDSCongVan.TabIndex = 22;
            this.dgvDSCongVan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSCongVan_CellFormatting);
            this.dgvDSCongVan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSCongVan_RowPostPaint);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // LoaiVanBan
            // 
            this.LoaiVanBan.DataPropertyName = "LoaiVanBan";
            this.LoaiVanBan.HeaderText = "Loại Văn Bản";
            this.LoaiVanBan.Name = "LoaiVanBan";
            this.LoaiVanBan.Width = 150;
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "Ma";
            this.Ma.HeaderText = "Số CV";
            this.Ma.Name = "Ma";
            this.Ma.Width = 80;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Chuyển";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 120;
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "Nơi Chuyển";
            this.NoiChuyen.Name = "NoiChuyen";
            this.NoiChuyen.Width = 120;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "DanhBo";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Visible = false;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "DiaChi";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Visible = false;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "HoTen";
            this.HoTen.Name = "HoTen";
            this.HoTen.Visible = false;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(752, 28);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(406, 22);
            this.txtDiaChi.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(746, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Địa Chỉ:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(675, 178);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(513, 147);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 21;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(1064, 73);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 25);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lstMa
            // 
            this.lstMa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstMa.Location = new System.Drawing.Point(298, 26);
            this.lstMa.Name = "lstMa";
            this.lstMa.Size = new System.Drawing.Size(79, 100);
            this.lstMa.TabIndex = 87;
            this.lstMa.UseCompatibleStateImageBehavior = false;
            this.lstMa.View = System.Windows.Forms.View.Details;
            this.lstMa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMa_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(594, 147);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 25);
            this.btnInDS.TabIndex = 88;
            this.btnInDS.Text = "In DS";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 89;
            this.label12.Text = "(enter)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(245, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 16);
            this.label13.TabIndex = 90;
            this.label13.Text = "(enter)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(385, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 16);
            this.label14.TabIndex = 91;
            this.label14.Text = "(double-click để xóa)";
            // 
            // cmbTuGio
            // 
            this.cmbTuGio.FormattingEnabled = true;
            this.cmbTuGio.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbTuGio.Location = new System.Drawing.Point(192, 125);
            this.cmbTuGio.Name = "cmbTuGio";
            this.cmbTuGio.Size = new System.Drawing.Size(41, 24);
            this.cmbTuGio.TabIndex = 92;
            // 
            // cmbDenGio
            // 
            this.cmbDenGio.FormattingEnabled = true;
            this.cmbDenGio.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cmbDenGio.Location = new System.Drawing.Point(192, 153);
            this.cmbDenGio.Name = "cmbDenGio";
            this.cmbDenGio.Size = new System.Drawing.Size(41, 24);
            this.cmbDenGio.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(234, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 94;
            this.label15.Text = "h";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(234, 157);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 16);
            this.label16.TabIndex = 95;
            this.label16.Text = "h";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(491, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 16);
            this.label17.TabIndex = 96;
            this.label17.Text = "(enter)";
            // 
            // cmbTimKiem
            // 
            this.cmbTimKiem.FormattingEnabled = true;
            this.cmbTimKiem.Items.AddRange(new object[] {
            "",
            "Danh Bộ",
            "Mã Đơn/TB",
            "Phòng Đội"});
            this.cmbTimKiem.Location = new System.Drawing.Point(300, 149);
            this.cmbTimKiem.Name = "cmbTimKiem";
            this.cmbTimKiem.Size = new System.Drawing.Size(100, 24);
            this.cmbTimKiem.TabIndex = 98;
            this.cmbTimKiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimKiem_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(300, 130);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 16);
            this.label18.TabIndex = 97;
            this.label18.Text = "Loại:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(406, 149);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 100;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(402, 130);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 16);
            this.label19.TabIndex = 99;
            this.label19.Text = "Nội Dung:";
            // 
            // chkcmbNoiNhan
            // 
            this.chkcmbNoiNhan.EditValue = "";
            this.chkcmbNoiNhan.Location = new System.Drawing.Point(959, 74);
            this.chkcmbNoiNhan.Name = "chkcmbNoiNhan";
            this.chkcmbNoiNhan.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkcmbNoiNhan.Properties.Appearance.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbNoiNhan.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Đội TCTB"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Thay"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Đội QLĐHN"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Đội Thu Tiền"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. KHĐT"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. GNKDT"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Ban QLDA"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. Kế Toán"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. TCHC"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. KTCN"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Đội TCXL"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Khách Hàng"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Xử Lý"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Bấm Chì"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Tổng Hợp"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "c.Trân (Điều Chỉnh)"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "P. Khách Hàng")});
            this.chkcmbNoiNhan.Properties.PopupFormSize = new System.Drawing.Size(0, 500);
            this.chkcmbNoiNhan.Properties.SelectAllItemVisible = false;
            this.chkcmbNoiNhan.Size = new System.Drawing.Size(100, 22);
            this.chkcmbNoiNhan.TabIndex = 101;
            // 
            // chkCreateBy
            // 
            this.chkCreateBy.AutoSize = true;
            this.chkCreateBy.Location = new System.Drawing.Point(96, 181);
            this.chkCreateBy.Name = "chkCreateBy";
            this.chkCreateBy.Size = new System.Drawing.Size(124, 20);
            this.chkCreateBy.TabIndex = 102;
            this.chkCreateBy.Text = "Theo Người Lập";
            this.chkCreateBy.UseVisualStyleBackColor = true;
            // 
            // chkNgayLap
            // 
            this.chkNgayLap.AutoSize = true;
            this.chkNgayLap.Location = new System.Drawing.Point(867, 132);
            this.chkNgayLap.Name = "chkNgayLap";
            this.chkNgayLap.Size = new System.Drawing.Size(86, 20);
            this.chkNgayLap.TabIndex = 103;
            this.chkNgayLap.Text = "Ngày Lập";
            this.chkNgayLap.UseVisualStyleBackColor = true;
            this.chkNgayLap.CheckedChanged += new System.EventHandler(this.chkNgayLap_CheckedChanged);
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Enabled = false;
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(959, 132);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(90, 22);
            this.dateNgayLap.TabIndex = 104;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(675, 147);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(85, 25);
            this.btnXuatExcel.TabIndex = 105;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // chkKTXM
            // 
            this.chkKTXM.AutoSize = true;
            this.chkKTXM.Location = new System.Drawing.Point(807, 102);
            this.chkKTXM.Name = "chkKTXM";
            this.chkKTXM.Size = new System.Drawing.Size(63, 20);
            this.chkKTXM.TabIndex = 106;
            this.chkKTXM.Text = "KTXM";
            this.chkKTXM.UseVisualStyleBackColor = true;
            // 
            // chkToTrinh
            // 
            this.chkToTrinh.AutoSize = true;
            this.chkToTrinh.Location = new System.Drawing.Point(876, 102);
            this.chkToTrinh.Name = "chkToTrinh";
            this.chkToTrinh.Size = new System.Drawing.Size(77, 20);
            this.chkToTrinh.TabIndex = 107;
            this.chkToTrinh.Text = "Tờ Trình";
            this.chkToTrinh.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXem_Moi);
            this.groupBox1.Controls.Add(this.panelTo);
            this.groupBox1.Controls.Add(this.btnIn_Moi);
            this.groupBox1.Controls.Add(this.cmbNoiNhan_Moi);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.cmbNoiChuyen_Moi);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.dateTu_Moi);
            this.groupBox1.Controls.Add(this.dateDen_Moi);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Location = new System.Drawing.Point(674, 209);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 189);
            this.groupBox1.TabIndex = 108;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Công Văn Đi Mới 2023";
            // 
            // btnXem_Moi
            // 
            this.btnXem_Moi.Location = new System.Drawing.Point(357, 91);
            this.btnXem_Moi.Name = "btnXem_Moi";
            this.btnXem_Moi.Size = new System.Drawing.Size(75, 25);
            this.btnXem_Moi.TabIndex = 94;
            this.btnXem_Moi.Text = "Xem";
            this.btnXem_Moi.UseVisualStyleBackColor = true;
            this.btnXem_Moi.Click += new System.EventHandler(this.btnXem_Moi_Click);
            // 
            // panelTo
            // 
            this.panelTo.Controls.Add(this.cmbTo);
            this.panelTo.Controls.Add(this.label23);
            this.panelTo.Location = new System.Drawing.Point(139, 121);
            this.panelTo.Name = "panelTo";
            this.panelTo.Size = new System.Drawing.Size(212, 56);
            this.panelTo.TabIndex = 93;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(3, 25);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(206, 24);
            this.cmbTo.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(3, 6);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(28, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "Tổ:";
            // 
            // btnIn_Moi
            // 
            this.btnIn_Moi.Location = new System.Drawing.Point(357, 122);
            this.btnIn_Moi.Name = "btnIn_Moi";
            this.btnIn_Moi.Size = new System.Drawing.Size(75, 25);
            this.btnIn_Moi.TabIndex = 92;
            this.btnIn_Moi.Text = "In DS";
            this.btnIn_Moi.UseVisualStyleBackColor = true;
            this.btnIn_Moi.Click += new System.EventHandler(this.btnIn_Moi_Click);
            // 
            // cmbNoiNhan_Moi
            // 
            this.cmbNoiNhan_Moi.FormattingEnabled = true;
            this.cmbNoiNhan_Moi.Location = new System.Drawing.Point(151, 92);
            this.cmbNoiNhan_Moi.MaxDropDownItems = 10;
            this.cmbNoiNhan_Moi.Name = "cmbNoiNhan_Moi";
            this.cmbNoiNhan_Moi.Size = new System.Drawing.Size(200, 24);
            this.cmbNoiNhan_Moi.TabIndex = 91;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(151, 73);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(64, 16);
            this.label22.TabIndex = 90;
            this.label22.Text = "Nơi Nhận";
            // 
            // cmbNoiChuyen_Moi
            // 
            this.cmbNoiChuyen_Moi.FormattingEnabled = true;
            this.cmbNoiChuyen_Moi.Location = new System.Drawing.Point(151, 40);
            this.cmbNoiChuyen_Moi.MaxDropDownItems = 10;
            this.cmbNoiChuyen_Moi.Name = "cmbNoiChuyen_Moi";
            this.cmbNoiChuyen_Moi.Size = new System.Drawing.Size(200, 24);
            this.cmbNoiChuyen_Moi.TabIndex = 89;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(151, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 16);
            this.label32.TabIndex = 88;
            this.label32.Text = "Nơi Chuyển";
            // 
            // dateTu_Moi
            // 
            this.dateTu_Moi.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTu_Moi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu_Moi.Location = new System.Drawing.Point(9, 41);
            this.dateTu_Moi.Name = "dateTu_Moi";
            this.dateTu_Moi.Size = new System.Drawing.Size(136, 22);
            this.dateTu_Moi.TabIndex = 22;
            // 
            // dateDen_Moi
            // 
            this.dateDen_Moi.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateDen_Moi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen_Moi.Location = new System.Drawing.Point(9, 93);
            this.dateDen_Moi.Name = "dateDen_Moi";
            this.dateDen_Moi.Size = new System.Drawing.Size(136, 22);
            this.dateDen_Moi.TabIndex = 24;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(60, 16);
            this.label20.TabIndex = 21;
            this.label20.Text = "Từ Ngày";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 74);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(68, 16);
            this.label21.TabIndex = 23;
            this.label21.Text = "Đến Ngày";
            // 
            // frmCongVanDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 609);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkToTrinh);
            this.Controls.Add(this.chkKTXM);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.chkNgayLap);
            this.Controls.Add(this.chkCreateBy);
            this.Controls.Add(this.chkcmbNoiNhan);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbTimKiem);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbDenGio);
            this.Controls.Add(this.cmbTuGio);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.lstMa);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDSCongVan);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDenMa);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cmbNoiChuyen);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTuMa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLoaiVanBan);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmCongVanDi";
            this.Text = "Công Văn Đi";
            this.Load += new System.EventHandler(this.frmCongVanDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCongVan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelTo.ResumeLayout(false);
            this.panelTo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoaiVanBan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTuMa;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNoiChuyen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.TextBox txtDenMa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvDSCongVan;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.ListView lstMa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmbTuGio;
        private System.Windows.Forms.ComboBox cmbDenGio;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cmbTimKiem;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label19;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbNoiNhan;
        private System.Windows.Forms.CheckBox chkCreateBy;
        private System.Windows.Forms.CheckBox chkNgayLap;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVanBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.CheckBox chkKTXM;
        private System.Windows.Forms.CheckBox chkToTrinh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTu_Moi;
        private System.Windows.Forms.DateTimePicker dateDen_Moi;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmbNoiNhan_Moi;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.ComboBox cmbNoiChuyen_Moi;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnIn_Moi;
        private System.Windows.Forms.Panel panelTo;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnXem_Moi;
    }
}