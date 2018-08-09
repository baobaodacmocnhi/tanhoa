namespace KTKS_DonKH.GUI.ThuTraLoi
{
    partial class frmToTrinh
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
            this.txtMaCTTT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaDonCu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtKinhTrinh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvToTrinh = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.cmbVeViec = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaCTTT
            // 
            this.txtMaCTTT.Location = new System.Drawing.Point(418, 12);
            this.txtMaCTTT.Name = "txtMaCTTT";
            this.txtMaCTTT.Size = new System.Drawing.Size(60, 22);
            this.txtMaCTTT.TabIndex = 20;
            this.txtMaCTTT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCTTT_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(329, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Mã Tờ Trình:";
            // 
            // txtMaDonCu
            // 
            this.txtMaDonCu.Location = new System.Drawing.Point(248, 12);
            this.txtMaDonCu.Name = "txtMaDonCu";
            this.txtMaDonCu.Size = new System.Drawing.Size(75, 22);
            this.txtMaDonCu.TabIndex = 18;
            this.txtMaDonCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonCu_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 17;
            this.label21.Text = "Mã Đơn Cũ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtKinhTrinh);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtNoiNhan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtVeViec);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(778, 248);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội Dung Tờ Trình";
            // 
            // txtKinhTrinh
            // 
            this.txtKinhTrinh.Location = new System.Drawing.Point(473, 21);
            this.txtKinhTrinh.Multiline = true;
            this.txtKinhTrinh.Name = "txtKinhTrinh";
            this.txtKinhTrinh.Size = new System.Drawing.Size(287, 44);
            this.txtKinhTrinh.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(398, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kính Trình:";
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(623, 93);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(149, 150);
            this.txtNoiNhan.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(620, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nơi Nhận:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(7, 93);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(610, 150);
            this.txtNoiDung.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Nội Dung:";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(105, 21);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(287, 22);
            this.txtVeViec.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(41, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Về Việc:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGiaBieu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(778, 87);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(720, 24);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(35, 22);
            this.txtDinhMuc.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(649, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Định Mức:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(608, 24);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(35, 22);
            this.txtGiaBieu.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Giá Biểu:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(422, 52);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(333, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 52);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(98, 24);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(796, 288);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 62;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(796, 257);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 61;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(796, 226);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 60;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(88, 403);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 16);
            this.label20.TabIndex = 97;
            this.label20.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã TT",
            "Danh Bộ",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(162, 400);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 98;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(342, 400);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 100;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(268, 403);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 99;
            this.label22.Text = "Nội Dung:";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label26);
            this.panel_KhoangThoiGian.Controls.Add(this.label27);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(335, 387);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 59);
            this.panel_KhoangThoiGian.TabIndex = 101;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(82, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(82, 32);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 16);
            this.label26.TabIndex = 15;
            this.label26.Text = "Từ Ngày:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 16);
            this.label27.TabIndex = 16;
            this.label27.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(518, 403);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 96;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvToTrinh
            // 
            this.dgvToTrinh.AllowUserToAddRows = false;
            this.dgvToTrinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToTrinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToTrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCT,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.VeViec,
            this.NoiDung});
            this.dgvToTrinh.Location = new System.Drawing.Point(5, 452);
            this.dgvToTrinh.Name = "dgvToTrinh";
            this.dgvToTrinh.Size = new System.Drawing.Size(1090, 235);
            this.dgvToTrinh.TabIndex = 95;
            this.dgvToTrinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToTrinh_CellContentClick);
            this.dgvToTrinh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToTrinh_CellFormatting);
            this.dgvToTrinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvToTrinh_RowPostPaint);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(796, 319);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 102;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cmbVeViec
            // 
            this.cmbVeViec.FormattingEnabled = true;
            this.cmbVeViec.Location = new System.Drawing.Point(796, 149);
            this.cmbVeViec.Name = "cmbVeViec";
            this.cmbVeViec.Size = new System.Drawing.Size(300, 24);
            this.cmbVeViec.TabIndex = 104;
            this.cmbVeViec.SelectedIndexChanged += new System.EventHandler(this.cmbVeViec_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(796, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 16);
            this.label8.TabIndex = 103;
            this.label8.Text = "Về Việc:";
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "Mã TT";
            this.IDCT.Name = "IDCT";
            this.IDCT.Width = 80;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
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
            this.HoTen.HeaderText = "Khách Hàng";
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
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.Width = 200;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 200;
            // 
            // frmToTrinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1101, 692);
            this.Controls.Add(this.cmbVeViec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvToTrinh);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaCTTT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMaDonCu);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmToTrinh";
            this.Text = "Tờ Trình";
            this.Load += new System.EventHandler(this.frmToTrinh_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaCTTT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaDonCu;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtKinhTrinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvToTrinh;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ComboBox cmbVeViec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
    }
}