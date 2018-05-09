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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCongVan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).BeginInit();
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
            this.dateTu.Location = new System.Drawing.Point(96, 168);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 18;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(96, 196);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 173);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 17;
            this.label10.Text = "Từ Ngày:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 202);
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
            this.DiaChi});
            this.dgvDSCongVan.Location = new System.Drawing.Point(14, 226);
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
            this.btnXoa.Location = new System.Drawing.Point(677, 226);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(513, 190);
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
            this.lstMa.Size = new System.Drawing.Size(79, 144);
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
            this.btnInDS.Location = new System.Drawing.Point(594, 190);
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
            this.cmbTuGio.Location = new System.Drawing.Point(202, 168);
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
            this.cmbDenGio.Location = new System.Drawing.Point(202, 196);
            this.cmbDenGio.Name = "cmbDenGio";
            this.cmbDenGio.Size = new System.Drawing.Size(41, 24);
            this.cmbDenGio.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(244, 173);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 16);
            this.label15.TabIndex = 94;
            this.label15.Text = "h";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(244, 200);
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
            "Mã Đơn/TB"});
            this.cmbTimKiem.Location = new System.Drawing.Point(300, 192);
            this.cmbTimKiem.Name = "cmbTimKiem";
            this.cmbTimKiem.Size = new System.Drawing.Size(100, 24);
            this.cmbTimKiem.TabIndex = 98;
            this.cmbTimKiem.SelectedIndexChanged += new System.EventHandler(this.cmbTimKiem_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(300, 173);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(37, 16);
            this.label18.TabIndex = 97;
            this.label18.Text = "Loại:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(406, 192);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 100;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(402, 173);
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
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Xử Lý"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Bấm Chì"),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(null, "Tổ Giao Dịch Khách Hàng")});
            this.chkcmbNoiNhan.Properties.PopupFormSize = new System.Drawing.Size(0, 500);
            this.chkcmbNoiNhan.Properties.SelectAllItemVisible = false;
            this.chkcmbNoiNhan.Size = new System.Drawing.Size(100, 22);
            this.chkcmbNoiNhan.TabIndex = 101;
            // 
            // frmCongVanDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1284, 594);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVanBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
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
    }
}