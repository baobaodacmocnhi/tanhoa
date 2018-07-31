namespace KTKS_DonKH.GUI.DonTu
{
    partial class frmCapNhatDonTu
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
            this.components = new System.ComponentModel.Container();
            this.label16 = new System.Windows.Forms.Label();
            this.txtTongDB = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateCreateDate = new System.Windows.Forms.DateTimePicker();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSoCongVan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtVanDeKhac = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkcmbNoiNhan = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.cmbNoiChuyen = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dateChuyen = new System.Windows.Forms.DateTimePicker();
            this.label30 = new System.Windows.Forms.Label();
            this.dgvLichSuDonTu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayChuyenA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoanLenh = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayHoanLenh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label28 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabNhapCongVan = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonTu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(264, 48);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(27, 16);
            this.label16.TabIndex = 11;
            this.label16.Text = "DB";
            // 
            // txtTongDB
            // 
            this.txtTongDB.Location = new System.Drawing.Point(214, 45);
            this.txtTongDB.Name = "txtTongDB";
            this.txtTongDB.Size = new System.Drawing.Size(44, 22);
            this.txtTongDB.TabIndex = 10;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(320, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(79, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Ngày Nhận:";
            // 
            // dateCreateDate
            // 
            this.dateCreateDate.CustomFormat = "dd/MM/yyyy";
            this.dateCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCreateDate.Location = new System.Drawing.Point(402, 12);
            this.dateCreateDate.Name = "dateCreateDate";
            this.dateCreateDate.Size = new System.Drawing.Size(90, 22);
            this.dateCreateDate.TabIndex = 15;
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(214, 12);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 22);
            this.txtMaDon.TabIndex = 13;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(153, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Mã Đơn:";
            // 
            // txtSoCongVan
            // 
            this.txtSoCongVan.Location = new System.Drawing.Point(108, 45);
            this.txtSoCongVan.Name = "txtSoCongVan";
            this.txtSoCongVan.Size = new System.Drawing.Size(100, 22);
            this.txtSoCongVan.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(90, 16);
            this.label12.TabIndex = 8;
            this.label12.Text = "Số Công Văn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 19;
            this.label5.Text = "Nội Dung:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(108, 73);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(493, 66);
            this.txtNoiDung.TabIndex = 20;
            // 
            // txtVanDeKhac
            // 
            this.txtVanDeKhac.Location = new System.Drawing.Point(107, 145);
            this.txtVanDeKhac.Name = "txtVanDeKhac";
            this.txtVanDeKhac.Size = new System.Drawing.Size(494, 22);
            this.txtVanDeKhac.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "Vấn Đề Khác:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabNhapCongVan);
            this.tabControl.Location = new System.Drawing.Point(15, 173);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(585, 120);
            this.tabControl.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtDienThoai);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.txtDinhMuc);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtDiaChi);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtHopDong);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtGiaBieu);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtHoTen);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtDanhBo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(577, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Thông Tin Khách Hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(470, 5);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(100, 22);
            this.txtDienThoai.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(388, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 4;
            this.label11.Text = "Điện Thoại:";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(519, 61);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(50, 22);
            this.txtDinhMuc.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(448, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Định Mức:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(98, 61);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(344, 22);
            this.txtDiaChi.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Địa Chỉ:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(282, 5);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(204, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Hợp Đồng:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(519, 33);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(50, 22);
            this.txtGiaBieu.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(448, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Giá Biểu:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 33);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(344, 22);
            this.txtHoTen.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(98, 5);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Danh Bộ:";
            // 
            // chkcmbNoiNhan
            // 
            this.chkcmbNoiNhan.Location = new System.Drawing.Point(266, 315);
            this.chkcmbNoiNhan.Name = "chkcmbNoiNhan";
            this.chkcmbNoiNhan.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkcmbNoiNhan.Properties.Appearance.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkcmbNoiNhan.Properties.AppearanceDropDown.Options.UseFont = true;
            this.chkcmbNoiNhan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.chkcmbNoiNhan.Properties.PopupFormSize = new System.Drawing.Size(0, 250);
            this.chkcmbNoiNhan.Properties.SelectAllItemVisible = false;
            this.chkcmbNoiNhan.Size = new System.Drawing.Size(201, 22);
            this.chkcmbNoiNhan.TabIndex = 78;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(629, 314);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 25);
            this.btnCapNhat.TabIndex = 77;
            this.btnCapNhat.Text = "Cập Nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(473, 315);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(150, 22);
            this.txtGhiChu.TabIndex = 76;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(469, 296);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(57, 16);
            this.label34.TabIndex = 75;
            this.label34.Text = "Ghi Chú:";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(265, 296);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(67, 16);
            this.label33.TabIndex = 74;
            this.label33.Text = "Nơi Nhận:";
            // 
            // cmbNoiChuyen
            // 
            this.cmbNoiChuyen.FormattingEnabled = true;
            this.cmbNoiChuyen.Location = new System.Drawing.Point(110, 315);
            this.cmbNoiChuyen.MaxDropDownItems = 10;
            this.cmbNoiChuyen.Name = "cmbNoiChuyen";
            this.cmbNoiChuyen.Size = new System.Drawing.Size(150, 24);
            this.cmbNoiChuyen.TabIndex = 73;
            this.cmbNoiChuyen.SelectedIndexChanged += new System.EventHandler(this.cmbNoiChuyen_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(110, 296);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(80, 16);
            this.label32.TabIndex = 72;
            this.label32.Text = "Nơi Chuyển:";
            // 
            // dateChuyen
            // 
            this.dateChuyen.CustomFormat = "dd/MM/yyyy";
            this.dateChuyen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChuyen.Location = new System.Drawing.Point(15, 315);
            this.dateChuyen.Name = "dateChuyen";
            this.dateChuyen.Size = new System.Drawing.Size(90, 22);
            this.dateChuyen.TabIndex = 71;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(12, 296);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 16);
            this.label30.TabIndex = 70;
            this.label30.Text = "Ngày Chuyển:";
            // 
            // dgvLichSuDonTu
            // 
            this.dgvLichSuDonTu.AllowUserToAddRows = false;
            this.dgvLichSuDonTu.AllowUserToDeleteRows = false;
            this.dgvLichSuDonTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuDonTu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayChuyenA,
            this.NoiChuyen,
            this.NoiNhan,
            this.GhiChu,
            this.HoanLenh,
            this.NgayHoanLenh});
            this.dgvLichSuDonTu.Location = new System.Drawing.Point(15, 361);
            this.dgvLichSuDonTu.Name = "dgvLichSuDonTu";
            this.dgvLichSuDonTu.ReadOnly = true;
            this.dgvLichSuDonTu.Size = new System.Drawing.Size(862, 200);
            this.dgvLichSuDonTu.TabIndex = 80;
            this.dgvLichSuDonTu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichSuDonTu_CellMouseClick);
            this.dgvLichSuDonTu.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvLichSuDonTu_CellValidating);
            this.dgvLichSuDonTu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvLichSuDonTu_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NgayChuyenA
            // 
            this.NgayChuyenA.DataPropertyName = "NgayChuyen";
            this.NgayChuyenA.HeaderText = "Ngày Chuyển";
            this.NgayChuyenA.Name = "NgayChuyenA";
            this.NgayChuyenA.ReadOnly = true;
            this.NgayChuyenA.Width = 150;
            // 
            // NoiChuyen
            // 
            this.NoiChuyen.DataPropertyName = "NoiChuyen";
            this.NoiChuyen.HeaderText = "Nơi Chuyển";
            this.NoiChuyen.Name = "NoiChuyen";
            this.NoiChuyen.ReadOnly = true;
            this.NoiChuyen.Width = 150;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.ReadOnly = true;
            this.NoiNhan.Width = 250;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // HoanLenh
            // 
            this.HoanLenh.DataPropertyName = "HoanLenh";
            this.HoanLenh.HeaderText = "Hoàn Lệnh";
            this.HoanLenh.Name = "HoanLenh";
            this.HoanLenh.ReadOnly = true;
            this.HoanLenh.Width = 50;
            // 
            // NgayHoanLenh
            // 
            this.NgayHoanLenh.DataPropertyName = "NgayHoanLenh";
            this.NgayHoanLenh.HeaderText = "Ngày Hoàn Lệnh";
            this.NgayHoanLenh.Name = "NgayHoanLenh";
            this.NgayHoanLenh.ReadOnly = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(12, 342);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(242, 16);
            this.label28.TabIndex = 79;
            this.label28.Text = "Chuột Phải để XÓA Lịch Sử Chuyển Đơn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // tabNhapCongVan
            // 
            this.tabNhapCongVan.Location = new System.Drawing.Point(4, 25);
            this.tabNhapCongVan.Name = "tabNhapCongVan";
            this.tabNhapCongVan.Size = new System.Drawing.Size(577, 91);
            this.tabNhapCongVan.TabIndex = 1;
            this.tabNhapCongVan.Text = "Nhập Công Văn";
            this.tabNhapCongVan.UseVisualStyleBackColor = true;
            // 
            // frmCapNhatDonTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(891, 572);
            this.Controls.Add(this.dgvLichSuDonTu);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.chkcmbNoiNhan);
            this.Controls.Add(this.btnCapNhat);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.cmbNoiChuyen);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.dateChuyen);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtVanDeKhac);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtTongDB);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dateCreateDate);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtSoCongVan);
            this.Controls.Add(this.label12);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCapNhatDonTu";
            this.Text = "Cập Nhật Đơn Từ";
            this.Load += new System.EventHandler(this.frmCapNhatDonTu_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkcmbNoiNhan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuDonTu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtTongDB;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateCreateDate;
        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSoCongVan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtVanDeKhac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chkcmbNoiNhan;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox cmbNoiChuyen;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DateTimePicker dateChuyen;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.DataGridView dgvLichSuDonTu;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChuyenA;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HoanLenh;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayHoanLenh;
        private System.Windows.Forms.TabPage tabNhapCongVan;

    }
}