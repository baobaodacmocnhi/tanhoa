namespace DocSo_PC.GUI.ToTruong
{
    partial class frmPhieuChuyen
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
            this.lbTo = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.dateTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateDenNgay = new System.Windows.Forms.DateTimePicker();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XemHinh = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNoiChuyen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLoaiVanBan_Nhap = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTo
            // 
            this.lbTo.AutoSize = true;
            this.lbTo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTo.Location = new System.Drawing.Point(12, 12);
            this.lbTo.Name = "lbTo";
            this.lbTo.Size = new System.Drawing.Size(32, 19);
            this.lbTo.TabIndex = 53;
            this.lbTo.Text = "Tổ:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cmbTo.Location = new System.Drawing.Point(50, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(100, 21);
            this.cmbTo.TabIndex = 52;
            this.cmbTo.Visible = false;
            // 
            // dateTuNgay
            // 
            this.dateTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dateTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTuNgay.Location = new System.Drawing.Point(210, 13);
            this.dateTuNgay.Name = "dateTuNgay";
            this.dateTuNgay.Size = new System.Drawing.Size(95, 20);
            this.dateTuNgay.TabIndex = 63;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(612, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 66;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(156, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 62;
            this.label10.Text = "Từ Ngày";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(311, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 64;
            this.label11.Text = "Đến Ngày";
            // 
            // dateDenNgay
            // 
            this.dateDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dateDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDenNgay.Location = new System.Drawing.Point(372, 13);
            this.dateDenNgay.Name = "dateDenNgay";
            this.dateDenNgay.Size = new System.Drawing.Size(95, 20);
            this.dateDenNgay.TabIndex = 65;
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CreateDate,
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.XemHinh,
            this.GhiChu,
            this.TinhTrang,
            this.ID,
            this.Folder,
            this.SoPhieu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSach.Location = new System.Drawing.Point(12, 39);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDanhSach.Size = new System.Drawing.Size(958, 274);
            this.dgvDanhSach.TabIndex = 67;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellEndEdit);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // XemHinh
            // 
            this.XemHinh.HeaderText = "Hình";
            this.XemHinh.Name = "XemHinh";
            this.XemHinh.Text = "Xem";
            this.XemHinh.UseColumnTextForButtonValue = true;
            this.XemHinh.Width = 50;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 80;
            // 
            // TinhTrang
            // 
            this.TinhTrang.DataPropertyName = "TinhTrang";
            this.TinhTrang.HeaderText = "Tình Trạng";
            this.TinhTrang.Name = "TinhTrang";
            this.TinhTrang.Width = 80;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Mã";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // Folder
            // 
            this.Folder.DataPropertyName = "Folder";
            this.Folder.HeaderText = "Folder";
            this.Folder.Name = "Folder";
            this.Folder.Visible = false;
            // 
            // SoPhieu
            // 
            this.SoPhieu.DataPropertyName = "SoPhieu";
            this.SoPhieu.HeaderText = "Số Phiếu";
            this.SoPhieu.Name = "SoPhieu";
            this.SoPhieu.Width = 80;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(693, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 68;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(473, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 69;
            this.label1.Text = "Loại";
            // 
            // cmbLoai
            // 
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Tất Cả",
            "Âm Sâu",
            "Xây Dựng",
            "Đứt Chì Góc",
            "Đứt Chì Thân",
            "Ngập Nước",
            "Kẹt Tường",
            "Lấp Khóa Góc",
            "Bể HBV",
            "Bể Nấp, Mất Nấp HBV",
            "Gãy Tay Van",
            "Nhập Thủ Công"});
            this.cmbLoai.Location = new System.Drawing.Point(506, 12);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(100, 21);
            this.cmbLoai.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(976, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 71;
            this.label2.Text = "Danh Bộ";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(1031, 39);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 72;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(1031, 65);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(100, 20);
            this.txtHoTen.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(976, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 73;
            this.label3.Text = "Họ Tên";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(1031, 91);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(100, 20);
            this.txtDiaChi.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(976, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 75;
            this.label4.Text = "Địa Chỉ";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(1056, 117);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 77;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(1056, 146);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 78;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(774, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 13);
            this.label5.TabIndex = 134;
            this.label5.Text = "Cập nhật trực tiếp TÌNH TRẠNG";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNoiChuyen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbLoaiVanBan_Nhap);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Location = new System.Drawing.Point(12, 319);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 174);
            this.groupBox1.TabIndex = 135;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Thủ Công";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Items.AddRange(new object[] {
            "P. Thương Vụ",
            "Đ. TCTB"});
            this.cmbNoiChuyen.Location = new System.Drawing.Point(282, 20);
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(100, 21);
            this.cmbNoiChuyen.TabIndex = 70;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 69;
            this.label6.Text = "Nơi Chuyển";
            // 
            // cmbLoaiVanBan_Nhap
            // 
            this.cmbLoaiVanBan_Nhap.FormattingEnabled = true;
            this.cmbLoaiVanBan_Nhap.Items.AddRange(new object[] {
            "Biên Bản Kiểm Tra",
            "TB Cắt Tạm/Cắt Hủy",
            "Tờ Trình",
            "Biên Bản Nghiệm Thu"});
            this.cmbLoaiVanBan_Nhap.Location = new System.Drawing.Point(82, 20);
            this.cmbLoaiVanBan_Nhap.Name = "cmbLoaiVanBan_Nhap";
            this.cmbLoaiVanBan_Nhap.Size = new System.Drawing.Size(130, 21);
            this.cmbLoaiVanBan_Nhap.TabIndex = 68;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 67;
            this.label7.Text = "Loại Văn Bản";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "(enter)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(407, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 65;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(82, 125);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(400, 40);
            this.txtNoiDung.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Nội Dung";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 99);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 102);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Địa Chỉ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(150, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Khách Hàng";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 47);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Danh Bộ";
            // 
            // frmPhieuChuyen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 636);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLoai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.dateTuNgay);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dateDenNgay);
            this.Controls.Add(this.lbTo);
            this.Controls.Add(this.cmbTo);
            this.Name = "frmPhieuChuyen";
            this.Text = "Phiếu Chuyển";
            this.Load += new System.EventHandler(this.frmPhieuChuyen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTo;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.DateTimePicker dateTuNgay;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateDenNgay;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewButtonColumn XemHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folder;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbNoiChuyen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLoaiVanBan_Nhap;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label14;
    }
}