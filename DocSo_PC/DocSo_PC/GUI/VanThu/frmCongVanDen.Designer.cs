namespace DocSo_PC.GUI.VanThu
{
    partial class frmCongVanDen
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDanhSach = new System.Windows.Forms.DataGridView();
            this.Them = new System.Windows.Forms.DataGridViewButtonColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToMaHoa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LoaiVB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XemHinh = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiVanBan = new System.Windows.Forms.ComboBox();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbNoiChuyen = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbLoaiVanBan_Nhap = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Đơn/Danh Bộ";
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(111, 34);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 20);
            this.txtMaDon.TabIndex = 1;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(enter)";
            // 
            // dgvDanhSach
            // 
            this.dgvDanhSach.AllowUserToAddRows = false;
            this.dgvDanhSach.AllowUserToDeleteRows = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvDanhSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Them,
            this.CreateDate,
            this.ToMaHoa,
            this.LoaiVB,
            this.MaDon,
            this.To,
            this.MLT,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.TableName,
            this.IDCT,
            this.NoiChuyen,
            this.ID,
            this.XemHinh});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSach.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvDanhSach.Location = new System.Drawing.Point(0, 59);
            this.dgvDanhSach.Name = "dgvDanhSach";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSach.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDanhSach.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dgvDanhSach.Size = new System.Drawing.Size(1360, 299);
            this.dgvDanhSach.TabIndex = 57;
            this.dgvDanhSach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellClick);
            this.dgvDanhSach.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSach_CellEndEdit);
            this.dgvDanhSach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDanhSach_RowPostPaint);
            this.dgvDanhSach.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDanhSach_MouseDoubleClick);
            // 
            // Them
            // 
            this.Them.HeaderText = "Xử Lý";
            this.Them.Name = "Them";
            this.Them.Text = "Thêm";
            this.Them.UseColumnTextForButtonValue = true;
            this.Them.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            // 
            // ToMaHoa
            // 
            this.ToMaHoa.DataPropertyName = "ToMaHoa";
            this.ToMaHoa.HeaderText = "Tổ Mã Hóa";
            this.ToMaHoa.Name = "ToMaHoa";
            this.ToMaHoa.Width = 50;
            // 
            // LoaiVB
            // 
            this.LoaiVB.DataPropertyName = "LoaiVB";
            this.LoaiVB.HeaderText = "Loại VB";
            this.LoaiVB.Name = "LoaiVB";
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.Width = 80;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 70;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 70;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.FillWeight = 90F;
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
            this.DiaChi.Width = 150;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 390;
            // 
            // TableName
            // 
            this.TableName.DataPropertyName = "TableName";
            this.TableName.HeaderText = "TableName";
            this.TableName.Name = "TableName";
            this.TableName.Visible = false;
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "IDCT";
            this.IDCT.Name = "IDCT";
            this.IDCT.Visible = false;
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "NoiChuyen";
            this.NoiChuyen.Name = "NoiChuyen";
            this.NoiChuyen.Visible = false;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // XemHinh
            // 
            this.XemHinh.HeaderText = "Hình";
            this.XemHinh.Name = "XemHinh";
            this.XemHinh.Text = "Xem";
            this.XemHinh.UseColumnTextForButtonValue = true;
            this.XemHinh.Width = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 58;
            this.label3.Text = "Loại Văn Bản";
            // 
            // cmbLoaiVanBan
            // 
            this.cmbLoaiVanBan.FormattingEnabled = true;
            this.cmbLoaiVanBan.Items.AddRange(new object[] {
            "Biên Bản Kiểm Tra",
            "TB Cắt Tạm/Cắt Hủy",
            "Tờ Trình",
            "Biên Bản Nghiệm Thu"});
            this.cmbLoaiVanBan.Location = new System.Drawing.Point(111, 7);
            this.cmbLoaiVanBan.Name = "cmbLoaiVanBan";
            this.cmbLoaiVanBan.Size = new System.Drawing.Size(130, 21);
            this.cmbLoaiVanBan.TabIndex = 59;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(422, 7);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(97, 20);
            this.dateTu.TabIndex = 61;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(368, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Từ Ngày";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(422, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(97, 20);
            this.dateDen.TabIndex = 63;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(361, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Đến Ngày";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(525, 6);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 64;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(606, 6);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 65;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbNoiChuyen);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cmbLoaiVanBan_Nhap);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtNoiDung);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 364);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 174);
            this.groupBox1.TabIndex = 66;
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(214, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 13);
            this.label11.TabIndex = 69;
            this.label11.Text = "Nơi Chuyển";
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 67;
            this.label10.Text = "Loại Văn Bản";
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
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(407, 96);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 65;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
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
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(82, 99);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(200, 20);
            this.txtDiaChi.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Địa Chỉ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(82, 73);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(150, 20);
            this.txtHoTen.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Khách Hàng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(82, 47);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Danh Bộ";
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.Location = new System.Drawing.Point(247, 9);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(118, 17);
            this.chkAuto.TabIndex = 67;
            this.chkAuto.Text = "Công Văn Tự Động";
            this.chkAuto.UseVisualStyleBackColor = true;
            // 
            // frmCongVanDen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 642);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbLoaiVanBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDanhSach);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label1);
            this.Name = "frmCongVanDen";
            this.Text = "Công Văn Đến";
            this.Load += new System.EventHandler(this.frmCongVanDen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSach)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDanhSach;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoaiVanBan;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewButtonColumn Them;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToMaHoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoaiVB;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn TableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewButtonColumn XemHinh;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbLoaiVanBan_Nhap;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbNoiChuyen;
        private System.Windows.Forms.CheckBox chkAuto;
    }
}