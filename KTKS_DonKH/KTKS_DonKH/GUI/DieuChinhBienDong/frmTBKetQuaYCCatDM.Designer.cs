namespace KTKS_DonKH.GUI.DieuChinhBienDong
{
    partial class frmTBKetQuaYCCatDM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateNhan = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoPhieuNhan = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbChiNhanh_Nhan = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDiaChi_Nhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoTen_Nhan = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDanhBo_Nhan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPYC = new System.Windows.Forms.TextBox();
            this.cmbChiNhanh_Cat = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSoNK_Cat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaCT_Cat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi_Cat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen_Cat = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo_Cat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDSTBKetQuaYCCatDM = new System.Windows.Forms.DataGridView();
            this.btnInKhongDongY = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnInDongY = new System.Windows.Forms.Button();
            this.btnInCapDinhMuc = new System.Windows.Forms.Button();
            this.label63 = new System.Windows.Forms.Label();
            this.txtHoTens_Cat = new System.Windows.Forms.TextBox();
            this.SoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatNK_DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatNK_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatNK_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanNK_MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanNK_DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanNK_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NhanNK_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PYC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTenCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTBKetQuaYCCatDM)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(901, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateNhan);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSoPhieuNhan);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtGhiChu);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cmbChiNhanh_Nhan);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtDiaChi_Nhan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtHoTen_Nhan);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtDanhBo_Nhan);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(464, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(431, 265);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nơi Nhận";
            // 
            // dateNhan
            // 
            this.dateNhan.CustomFormat = "dd/MM/yyyy";
            this.dateNhan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNhan.Location = new System.Drawing.Point(127, 154);
            this.dateNhan.Name = "dateNhan";
            this.dateNhan.Size = new System.Drawing.Size(100, 22);
            this.dateNhan.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "Ngày Nhận:";
            // 
            // txtSoPhieuNhan
            // 
            this.txtSoPhieuNhan.Location = new System.Drawing.Point(127, 126);
            this.txtSoPhieuNhan.Name = "txtSoPhieuNhan";
            this.txtSoPhieuNhan.Size = new System.Drawing.Size(290, 22);
            this.txtSoPhieuNhan.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Số Phiếu Nhận:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(127, 182);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(290, 22);
            this.txtGhiChu.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 16);
            this.label8.TabIndex = 22;
            this.label8.Text = "Ghi Chú:";
            // 
            // cmbChiNhanh_Nhan
            // 
            this.cmbChiNhanh_Nhan.FormattingEnabled = true;
            this.cmbChiNhanh_Nhan.Location = new System.Drawing.Point(127, 13);
            this.cmbChiNhanh_Nhan.Name = "cmbChiNhanh_Nhan";
            this.cmbChiNhanh_Nhan.Size = new System.Drawing.Size(290, 24);
            this.cmbChiNhanh_Nhan.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nơi Nhận:";
            // 
            // txtDiaChi_Nhan
            // 
            this.txtDiaChi_Nhan.Location = new System.Drawing.Point(127, 98);
            this.txtDiaChi_Nhan.Name = "txtDiaChi_Nhan";
            this.txtDiaChi_Nhan.Size = new System.Drawing.Size(290, 22);
            this.txtDiaChi_Nhan.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 16);
            this.label10.TabIndex = 6;
            this.label10.Text = "Địa Chỉ:";
            // 
            // txtHoTen_Nhan
            // 
            this.txtHoTen_Nhan.Location = new System.Drawing.Point(127, 70);
            this.txtHoTen_Nhan.Name = "txtHoTen_Nhan";
            this.txtHoTen_Nhan.Size = new System.Drawing.Size(290, 22);
            this.txtHoTen_Nhan.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Khách Hàng:";
            // 
            // txtDanhBo_Nhan
            // 
            this.txtDanhBo_Nhan.Location = new System.Drawing.Point(127, 42);
            this.txtDanhBo_Nhan.Name = "txtDanhBo_Nhan";
            this.txtDanhBo_Nhan.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo_Nhan.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Danh Bộ:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label63);
            this.groupBox1.Controls.Add(this.txtHoTens_Cat);
            this.groupBox1.Controls.Add(this.txtPYC);
            this.groupBox1.Controls.Add(this.cmbChiNhanh_Cat);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtSoNK_Cat);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtMaCT_Cat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDiaChi_Cat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHoTen_Cat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo_Cat);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(446, 265);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nơi Cắt/Chuyển";
            // 
            // txtPYC
            // 
            this.txtPYC.Location = new System.Drawing.Point(143, 127);
            this.txtPYC.Name = "txtPYC";
            this.txtPYC.Size = new System.Drawing.Size(290, 22);
            this.txtPYC.TabIndex = 14;
            // 
            // cmbChiNhanh_Cat
            // 
            this.cmbChiNhanh_Cat.Enabled = false;
            this.cmbChiNhanh_Cat.FormattingEnabled = true;
            this.cmbChiNhanh_Cat.Location = new System.Drawing.Point(143, 13);
            this.cmbChiNhanh_Cat.Name = "cmbChiNhanh_Cat";
            this.cmbChiNhanh_Cat.Size = new System.Drawing.Size(290, 24);
            this.cmbChiNhanh_Cat.TabIndex = 1;
            this.cmbChiNhanh_Cat.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nơi Cắt/Chuyển:";
            this.label13.Visible = false;
            // 
            // txtSoNK_Cat
            // 
            this.txtSoNK_Cat.Location = new System.Drawing.Point(143, 183);
            this.txtSoNK_Cat.Name = "txtSoNK_Cat";
            this.txtSoNK_Cat.Size = new System.Drawing.Size(100, 22);
            this.txtSoNK_Cat.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Số NK Cắt/Chuyển:";
            // 
            // txtMaCT_Cat
            // 
            this.txtMaCT_Cat.Location = new System.Drawing.Point(143, 155);
            this.txtMaCT_Cat.Name = "txtMaCT_Cat";
            this.txtMaCT_Cat.Size = new System.Drawing.Size(150, 22);
            this.txtMaCT_Cat.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số Chứng Từ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số PYC-HL:";
            // 
            // txtDiaChi_Cat
            // 
            this.txtDiaChi_Cat.Location = new System.Drawing.Point(143, 99);
            this.txtDiaChi_Cat.Name = "txtDiaChi_Cat";
            this.txtDiaChi_Cat.Size = new System.Drawing.Size(290, 22);
            this.txtDiaChi_Cat.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa Chỉ:";
            // 
            // txtHoTen_Cat
            // 
            this.txtHoTen_Cat.Location = new System.Drawing.Point(143, 71);
            this.txtHoTen_Cat.Name = "txtHoTen_Cat";
            this.txtHoTen_Cat.Size = new System.Drawing.Size(290, 22);
            this.txtHoTen_Cat.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDanhBo_Cat
            // 
            this.txtDanhBo_Cat.Location = new System.Drawing.Point(143, 43);
            this.txtDanhBo_Cat.Name = "txtDanhBo_Cat";
            this.txtDanhBo_Cat.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo_Cat.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Bộ:";
            // 
            // dgvDSTBKetQuaYCCatDM
            // 
            this.dgvDSTBKetQuaYCCatDM.AllowUserToAddRows = false;
            this.dgvDSTBKetQuaYCCatDM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTBKetQuaYCCatDM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSTBKetQuaYCCatDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTBKetQuaYCCatDM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoPhieu,
            this.MaCT,
            this.SoNKCat,
            this.CatNK_DanhBo,
            this.CatNK_HoTen,
            this.CatNK_DiaChi,
            this.NhanNK_MaCN,
            this.NhanNK_DanhBo,
            this.NhanNK_HoTen,
            this.NhanNK_DiaChi,
            this.SoPhieuNhan,
            this.NgayNhan,
            this.GhiChu,
            this.PYC,
            this.HoTenCat});
            this.dgvDSTBKetQuaYCCatDM.Location = new System.Drawing.Point(10, 274);
            this.dgvDSTBKetQuaYCCatDM.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSTBKetQuaYCCatDM.MultiSelect = false;
            this.dgvDSTBKetQuaYCCatDM.Name = "dgvDSTBKetQuaYCCatDM";
            this.dgvDSTBKetQuaYCCatDM.RowHeadersWidth = 60;
            this.dgvDSTBKetQuaYCCatDM.Size = new System.Drawing.Size(1280, 335);
            this.dgvDSTBKetQuaYCCatDM.TabIndex = 17;
            this.dgvDSTBKetQuaYCCatDM.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSTBKetQuaYCCatDM_CellContentClick);
            this.dgvDSTBKetQuaYCCatDM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSTBKetQuaYCCatDM_CellFormatting);
            // 
            // btnInKhongDongY
            // 
            this.btnInKhongDongY.Location = new System.Drawing.Point(982, 210);
            this.btnInKhongDongY.Name = "btnInKhongDongY";
            this.btnInKhongDongY.Size = new System.Drawing.Size(126, 25);
            this.btnInKhongDongY.TabIndex = 39;
            this.btnInKhongDongY.Text = "In Không Đồng Ý";
            this.btnInKhongDongY.UseVisualStyleBackColor = true;
            this.btnInKhongDongY.Click += new System.EventHandler(this.btnInKhongDongY_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(899, 96);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 40;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(901, 134);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 41;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnInDongY
            // 
            this.btnInDongY.Location = new System.Drawing.Point(1114, 210);
            this.btnInDongY.Name = "btnInDongY";
            this.btnInDongY.Size = new System.Drawing.Size(86, 25);
            this.btnInDongY.TabIndex = 42;
            this.btnInDongY.Text = "In Đồng Ý";
            this.btnInDongY.UseVisualStyleBackColor = true;
            this.btnInDongY.Click += new System.EventHandler(this.btnInDongY_Click);
            // 
            // btnInCapDinhMuc
            // 
            this.btnInCapDinhMuc.Location = new System.Drawing.Point(1206, 210);
            this.btnInCapDinhMuc.Name = "btnInCapDinhMuc";
            this.btnInCapDinhMuc.Size = new System.Drawing.Size(86, 25);
            this.btnInCapDinhMuc.TabIndex = 43;
            this.btnInCapDinhMuc.Text = "In Cấp ĐM";
            this.btnInCapDinhMuc.UseVisualStyleBackColor = true;
            this.btnInCapDinhMuc.Click += new System.EventHandler(this.btnInCapDinhMuc_Click);
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(11, 214);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(101, 16);
            this.label63.TabIndex = 15;
            this.label63.Text = "DS Họ Tên Cắt:";
            // 
            // txtHoTens_Cat
            // 
            this.txtHoTens_Cat.Location = new System.Drawing.Point(143, 211);
            this.txtHoTens_Cat.Multiline = true;
            this.txtHoTens_Cat.Name = "txtHoTens_Cat";
            this.txtHoTens_Cat.Size = new System.Drawing.Size(290, 44);
            this.txtHoTens_Cat.TabIndex = 16;
            // 
            // SoPhieu
            // 
            this.SoPhieu.DataPropertyName = "SoPhieu";
            this.SoPhieu.HeaderText = "Số Phiếu";
            this.SoPhieu.Name = "SoPhieu";
            this.SoPhieu.Width = 70;
            // 
            // MaCT
            // 
            this.MaCT.DataPropertyName = "MaCT";
            this.MaCT.HeaderText = "Số Chứng Từ";
            this.MaCT.Name = "MaCT";
            // 
            // SoNKCat
            // 
            this.SoNKCat.DataPropertyName = "SoNKCat";
            this.SoNKCat.HeaderText = "Số NK Cắt";
            this.SoNKCat.Name = "SoNKCat";
            this.SoNKCat.Width = 80;
            // 
            // CatNK_DanhBo
            // 
            this.CatNK_DanhBo.DataPropertyName = "CatNK_DanhBo";
            this.CatNK_DanhBo.HeaderText = "Danh Bộ Cắt";
            this.CatNK_DanhBo.Name = "CatNK_DanhBo";
            // 
            // CatNK_HoTen
            // 
            this.CatNK_HoTen.DataPropertyName = "CatNK_HoTen";
            this.CatNK_HoTen.HeaderText = "Khách Hàng Cắt";
            this.CatNK_HoTen.Name = "CatNK_HoTen";
            this.CatNK_HoTen.Width = 150;
            // 
            // CatNK_DiaChi
            // 
            this.CatNK_DiaChi.DataPropertyName = "CatNK_DiaChi";
            this.CatNK_DiaChi.HeaderText = "Địa Chỉ Cắt";
            this.CatNK_DiaChi.Name = "CatNK_DiaChi";
            this.CatNK_DiaChi.Width = 150;
            // 
            // NhanNK_MaCN
            // 
            this.NhanNK_MaCN.DataPropertyName = "NhanNK_MaCN";
            this.NhanNK_MaCN.HeaderText = "Chi Nhánh Nhận";
            this.NhanNK_MaCN.Name = "NhanNK_MaCN";
            this.NhanNK_MaCN.Width = 150;
            // 
            // NhanNK_DanhBo
            // 
            this.NhanNK_DanhBo.DataPropertyName = "NhanNK_DanhBo";
            this.NhanNK_DanhBo.HeaderText = "Danh Bộ Nhận";
            this.NhanNK_DanhBo.Name = "NhanNK_DanhBo";
            // 
            // NhanNK_HoTen
            // 
            this.NhanNK_HoTen.DataPropertyName = "NhanNK_HoTen";
            this.NhanNK_HoTen.HeaderText = "Khách Hàng Nhận";
            this.NhanNK_HoTen.Name = "NhanNK_HoTen";
            this.NhanNK_HoTen.Width = 150;
            // 
            // NhanNK_DiaChi
            // 
            this.NhanNK_DiaChi.DataPropertyName = "NhanNK_DiaChi";
            this.NhanNK_DiaChi.HeaderText = "Địa Chỉ Nhận";
            this.NhanNK_DiaChi.Name = "NhanNK_DiaChi";
            this.NhanNK_DiaChi.Width = 150;
            // 
            // SoPhieuNhan
            // 
            this.SoPhieuNhan.DataPropertyName = "SoPhieuNhan";
            this.SoPhieuNhan.HeaderText = "SoPhieuNhan";
            this.SoPhieuNhan.Name = "SoPhieuNhan";
            this.SoPhieuNhan.Visible = false;
            this.SoPhieuNhan.Width = 113;
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            this.NgayNhan.HeaderText = "NgayNhan";
            this.NgayNhan.Name = "NgayNhan";
            this.NgayNhan.Visible = false;
            this.NgayNhan.Width = 97;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = false;
            this.GhiChu.Width = 77;
            // 
            // PYC
            // 
            this.PYC.DataPropertyName = "PYC";
            this.PYC.HeaderText = "PYC";
            this.PYC.Name = "PYC";
            this.PYC.Visible = false;
            // 
            // HoTenCat
            // 
            this.HoTenCat.DataPropertyName = "HoTenCat";
            this.HoTenCat.HeaderText = "HoTenCat";
            this.HoTenCat.Name = "HoTenCat";
            this.HoTenCat.Visible = false;
            // 
            // frmTBKetQuaYCCatDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1304, 619);
            this.Controls.Add(this.btnInCapDinhMuc);
            this.Controls.Add(this.btnInDongY);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnInKhongDongY);
            this.Controls.Add(this.dgvDSTBKetQuaYCCatDM);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmTBKetQuaYCCatDM";
            this.Text = "Thông Báo Kết Quả Yêu Cầu Cắt Định Mức";
            this.Load += new System.EventHandler(this.frmTBKetQuaYCCatDM_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTBKetQuaYCCatDM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbChiNhanh_Nhan;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtDiaChi_Nhan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoTen_Nhan;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDanhBo_Nhan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbChiNhanh_Cat;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSoNK_Cat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaCT_Cat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi_Cat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen_Cat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo_Cat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDSTBKetQuaYCCatDM;
        private System.Windows.Forms.Button btnInKhongDongY;
        private System.Windows.Forms.TextBox txtSoPhieuNhan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateNhan;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnInDongY;
        private System.Windows.Forms.TextBox txtPYC;
        private System.Windows.Forms.Button btnInCapDinhMuc;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox txtHoTens_Cat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatNK_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatNK_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CatNK_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanNK_MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanNK_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanNK_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NhanNK_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn PYC;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTenCat;
    }
}