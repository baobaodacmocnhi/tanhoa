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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCongVan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại Văn Bản:";
            // 
            // cmbLoaiVanBan
            // 
            this.cmbLoaiVanBan.FormattingEnabled = true;
            this.cmbLoaiVanBan.Items.AddRange(new object[] {
            "Đơn Tổ Khách Hàng",
            "Đơn Tổ Xử Lý",
            "Kiểm Tra Xác Minh",
            "Bấm Chì",
            "Điều Chỉnh Biến Động",
            "Điều Chỉnh Hóa Đơn",
            "Cắt Tạm Danh Bộ",
            "Cắt Hủy Danh Bộ",
            "Phiếu Hủy Danh Bộ",
            "Thư Trả Lời",
            "Khác"});
            this.cmbLoaiVanBan.Location = new System.Drawing.Point(12, 30);
            this.cmbLoaiVanBan.Name = "cmbLoaiVanBan";
            this.cmbLoaiVanBan.Size = new System.Drawing.Size(150, 25);
            this.cmbLoaiVanBan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ Mã:";
            // 
            // txtTuMa
            // 
            this.txtTuMa.Location = new System.Drawing.Point(168, 30);
            this.txtTuMa.Name = "txtTuMa";
            this.txtTuMa.Size = new System.Drawing.Size(70, 25);
            this.txtTuMa.TabIndex = 3;
            this.txtTuMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuMa_KeyPress);
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(374, 30);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 7;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Danh Bộ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(534, 30);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 25);
            this.txtHoTen.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(529, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Khách Hàng:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDung.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDung.Location = new System.Drawing.Point(740, 78);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(200, 25);
            this.txtNoiDung.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(735, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Nội Dung:";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Items.AddRange(new object[] {
            "Đội TCTB",
            "Đội QLĐHN",
            "Đội Thu Tiền",
            "P. KHĐT",
            "P. GNKDT",
            "Ban QLDA",
            "P. Kế Toán",
            "P. TCHC",
            "P. KTCN",
            "Đội TCXL"});
            this.cmbNoiChuyen.Location = new System.Drawing.Point(946, 78);
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(100, 25);
            this.cmbNoiChuyen.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(943, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Nơi Chuyển:";
            // 
            // txtDenMa
            // 
            this.txtDenMa.Location = new System.Drawing.Point(168, 78);
            this.txtDenMa.Name = "txtDenMa";
            this.txtDenMa.Size = new System.Drawing.Size(70, 25);
            this.txtDenMa.TabIndex = 5;
            this.txtDenMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenMa_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(165, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Đến Mã:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(295, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Danh Sách:";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(95, 130);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 18;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(341, 130);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 17);
            this.label10.TabIndex = 17;
            this.label10.Text = "Từ Ngày:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(263, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 19;
            this.label11.Text = "Đến Ngày:";
            // 
            // dgvDSCongVan
            // 
            this.dgvDSCongVan.AllowUserToAddRows = false;
            this.dgvDSCongVan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCongVan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.dgvDSCongVan.Location = new System.Drawing.Point(14, 169);
            this.dgvDSCongVan.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSCongVan.Name = "dgvDSCongVan";
            this.dgvDSCongVan.RowHeadersWidth = 60;
            this.dgvDSCongVan.Size = new System.Drawing.Size(671, 380);
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
            this.txtDiaChi.Location = new System.Drawing.Point(740, 30);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(406, 25);
            this.txtDiaChi.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(735, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Địa Chỉ:";
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::KTKS_DonKH.Properties.Resources.delete_24x24;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(705, 169);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(67, 35);
            this.btnXoa.TabIndex = 23;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXem
            // 
            this.btnXem.Image = global::KTKS_DonKH.Properties.Resources.find_24x24;
            this.btnXem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXem.Location = new System.Drawing.Point(534, 127);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(70, 35);
            this.btnXem.TabIndex = 21;
            this.btnXem.Text = "Xem";
            this.btnXem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1052, 68);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 16;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lstMa
            // 
            this.lstMa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstMa.Location = new System.Drawing.Point(298, 27);
            this.lstMa.Name = "lstMa";
            this.lstMa.Size = new System.Drawing.Size(70, 97);
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
            this.btnInDS.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDS.Location = new System.Drawing.Point(610, 127);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 35);
            this.btnInDS.TabIndex = 88;
            this.btnInDS.Text = "In DS";
            this.btnInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(244, 33);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 17);
            this.label12.TabIndex = 89;
            this.label12.Text = "(enter)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(244, 81);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 90;
            this.label13.Text = "(enter)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(374, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(132, 17);
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
            this.cmbTuGio.Location = new System.Drawing.Point(201, 130);
            this.cmbTuGio.Name = "cmbTuGio";
            this.cmbTuGio.Size = new System.Drawing.Size(40, 25);
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
            this.cmbDenGio.Location = new System.Drawing.Point(447, 130);
            this.cmbDenGio.Name = "cmbDenGio";
            this.cmbDenGio.Size = new System.Drawing.Size(40, 25);
            this.cmbDenGio.TabIndex = 93;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(242, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(15, 17);
            this.label15.TabIndex = 94;
            this.label15.Text = "h";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(488, 133);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 17);
            this.label16.TabIndex = 95;
            this.label16.Text = "h";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(480, 33);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(48, 17);
            this.label17.TabIndex = 96;
            this.label17.Text = "(enter)";
            // 
            // frmCongVanDi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1293, 631);
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
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCongVanDi";
            this.Text = "Công Văn Đi";
            this.Load += new System.EventHandler(this.frmCongVanDi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCongVan)).EndInit();
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
    }
}