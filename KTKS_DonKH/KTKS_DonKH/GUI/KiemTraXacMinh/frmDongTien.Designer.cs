﻿namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmDongTien
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
            this.lbTheoYeuCau = new System.Windows.Forms.Label();
            this.txtTheoYeuCau = new System.Windows.Forms.TextBox();
            this.cmbTinhTrangDHN = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbChiKhoaGoc = new System.Windows.Forms.ComboBox();
            this.cmbChiMatSo = new System.Windows.Forms.ComboBox();
            this.cmbHienTrangKiemTra = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtHoTenKHKy = new System.Windows.Forms.TextBox();
            this.cmbTinhTrangChiSo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dateKTXM = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoThan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMucDichSuDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChiSo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHieu = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkMoNuoc = new System.Windows.Forms.CheckBox();
            this.chkDutChiGoc = new System.Windows.Forms.CheckBox();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungKiemTra = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.dgvDSKetQuaKiemTra = new System.Windows.Forms.DataGridView();
            this.MaCTKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDungKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.chkDongTien = new System.Windows.Forms.CheckBox();
            this.groupBoxDongTien = new System.Windows.Forms.GroupBox();
            this.txtSoTienDongTien = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dateDongTien = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbNoiDungXuLy = new System.Windows.Forms.ComboBox();
            this.chkChuyenLapTBCat = new System.Windows.Forms.CheckBox();
            this.groupBoxChuyenCatHuy = new System.Windows.Forms.GroupBox();
            this.dateChuyenCatHuy = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.chkLapBangGia = new System.Windows.Forms.CheckBox();
            this.groupBoxLapBangGia = new System.Windows.Forms.GroupBox();
            this.dateLapBangGia = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGhiChuNoiDungXuLy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).BeginInit();
            this.groupBoxDongTien.SuspendLayout();
            this.groupBoxChuyenCatHuy.SuspendLayout();
            this.groupBoxLapBangGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTheoYeuCau
            // 
            this.lbTheoYeuCau.AutoSize = true;
            this.lbTheoYeuCau.Location = new System.Drawing.Point(747, 12);
            this.lbTheoYeuCau.Name = "lbTheoYeuCau";
            this.lbTheoYeuCau.Size = new System.Drawing.Size(161, 16);
            this.lbTheoYeuCau.TabIndex = 30;
            this.lbTheoYeuCau.Text = "Thực Hiện Theo Yêu Cầu:";
            this.lbTheoYeuCau.Visible = false;
            // 
            // txtTheoYeuCau
            // 
            this.txtTheoYeuCau.Location = new System.Drawing.Point(917, 9);
            this.txtTheoYeuCau.Name = "txtTheoYeuCau";
            this.txtTheoYeuCau.Size = new System.Drawing.Size(123, 22);
            this.txtTheoYeuCau.TabIndex = 31;
            this.txtTheoYeuCau.Visible = false;
            // 
            // cmbTinhTrangDHN
            // 
            this.cmbTinhTrangDHN.FormattingEnabled = true;
            this.cmbTinhTrangDHN.Items.AddRange(new object[] {
            "",
            "Còn",
            "Mất",
            "Không ĐHN",
            "Lấp mất",
            "Bể kiếng",
            "Mất mặt số",
            "Chủ gỡ",
            "Hầm sâu",
            "Chất đồ",
            "Gắn ngược",
            "Đóng nước",
            "Cắt ống bên ngoài",
            "Kẹt khóa"});
            this.cmbTinhTrangDHN.Location = new System.Drawing.Point(310, 38);
            this.cmbTinhTrangDHN.MaxDropDownItems = 50;
            this.cmbTinhTrangDHN.Name = "cmbTinhTrangDHN";
            this.cmbTinhTrangDHN.Size = new System.Drawing.Size(165, 24);
            this.cmbTinhTrangDHN.TabIndex = 5;
            this.cmbTinhTrangDHN.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(307, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(114, 16);
            this.label20.TabIndex = 4;
            this.label20.Text = "ĐHN lúc Kiểm Tra";
            this.label20.Visible = false;
            // 
            // cmbChiKhoaGoc
            // 
            this.cmbChiKhoaGoc.FormattingEnabled = true;
            this.cmbChiKhoaGoc.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiKhoaGoc.Location = new System.Drawing.Point(309, 98);
            this.cmbChiKhoaGoc.MaxDropDownItems = 50;
            this.cmbChiKhoaGoc.Name = "cmbChiKhoaGoc";
            this.cmbChiKhoaGoc.Size = new System.Drawing.Size(70, 24);
            this.cmbChiKhoaGoc.TabIndex = 19;
            // 
            // cmbChiMatSo
            // 
            this.cmbChiMatSo.FormattingEnabled = true;
            this.cmbChiMatSo.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiMatSo.Location = new System.Drawing.Point(309, 68);
            this.cmbChiMatSo.MaxDropDownItems = 50;
            this.cmbChiMatSo.Name = "cmbChiMatSo";
            this.cmbChiMatSo.Size = new System.Drawing.Size(70, 24);
            this.cmbChiMatSo.TabIndex = 17;
            // 
            // cmbHienTrangKiemTra
            // 
            this.cmbHienTrangKiemTra.FormattingEnabled = true;
            this.cmbHienTrangKiemTra.Location = new System.Drawing.Point(114, 39);
            this.cmbHienTrangKiemTra.MaxDropDownItems = 50;
            this.cmbHienTrangKiemTra.Name = "cmbHienTrangKiemTra";
            this.cmbHienTrangKiemTra.Size = new System.Drawing.Size(188, 24);
            this.cmbHienTrangKiemTra.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(111, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 16);
            this.label18.TabIndex = 2;
            this.label18.Text = "Hiện Trạng Kiểm Tra";
            // 
            // txtHoTenKHKy
            // 
            this.txtHoTenKHKy.Location = new System.Drawing.Point(539, 98);
            this.txtHoTenKHKy.Name = "txtHoTenKHKy";
            this.txtHoTenKHKy.Size = new System.Drawing.Size(178, 22);
            this.txtHoTenKHKy.TabIndex = 25;
            // 
            // cmbTinhTrangChiSo
            // 
            this.cmbTinhTrangChiSo.FormattingEnabled = true;
            this.cmbTinhTrangChiSo.Items.AddRange(new object[] {
            "",
            "Chạy",
            "NCN",
            "Chạy lết",
            "Chạy ngược",
            "Kẹt số",
            "Tuôn số",
            "Không nước",
            "Kiếng mờ",
            "Mất ĐHN",
            "Không ĐHN",
            "Lấp mất",
            "Bể kiếng",
            "Mất mặt số",
            "Chủ gỡ",
            "Hầm sâu",
            "Chất đồ",
            "Gắn ngược",
            "Đóng nước",
            "Cắt ống bên ngoài",
            "Kẹt khóa"});
            this.cmbTinhTrangChiSo.Location = new System.Drawing.Point(539, 39);
            this.cmbTinhTrangChiSo.MaxDropDownItems = 50;
            this.cmbTinhTrangChiSo.Name = "cmbTinhTrangChiSo";
            this.cmbTinhTrangChiSo.Size = new System.Drawing.Size(165, 24);
            this.cmbTinhTrangChiSo.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(537, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(124, 16);
            this.label19.TabIndex = 8;
            this.label19.Text = "Chỉ Số lúc Kiểm Tra";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(95, 16);
            this.label17.TabIndex = 24;
            this.label17.Text = "Họ Tên KH Ký:";
            // 
            // dateKTXM
            // 
            this.dateKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKTXM.Location = new System.Drawing.Point(11, 39);
            this.dateKTXM.Name = "dateKTXM";
            this.dateKTXM.Size = new System.Drawing.Size(97, 22);
            this.dateKTXM.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 20);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Ngày Kiểm Tra";
            // 
            // txtSoThan
            // 
            this.txtSoThan.Location = new System.Drawing.Point(73, 127);
            this.txtSoThan.Name = "txtSoThan";
            this.txtSoThan.Size = new System.Drawing.Size(97, 22);
            this.txtSoThan.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số Thân:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Chì Khóa Góc:";
            // 
            // txtMucDichSuDung
            // 
            this.txtMucDichSuDung.Location = new System.Drawing.Point(309, 127);
            this.txtMucDichSuDung.Name = "txtMucDichSuDung";
            this.txtMucDichSuDung.Size = new System.Drawing.Size(231, 22);
            this.txtMucDichSuDung.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mục Đích Sử Dụng:";
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(73, 98);
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(97, 22);
            this.txtCo.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 16);
            this.label12.TabIndex = 12;
            this.label12.Text = "Cỡ:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 16);
            this.label13.TabIndex = 16;
            this.label13.Text = "Chì Mặt Số:";
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(481, 39);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(50, 22);
            this.txtChiSo.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(478, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 16);
            this.label14.TabIndex = 6;
            this.label14.Text = "Chỉ Số";
            // 
            // txtHieu
            // 
            this.txtHieu.Location = new System.Drawing.Point(73, 68);
            this.txtHieu.Name = "txtHieu";
            this.txtHieu.Size = new System.Drawing.Size(97, 22);
            this.txtHieu.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 71);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 16);
            this.label15.TabIndex = 10;
            this.label15.Text = "Hiệu:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkMoNuoc);
            this.groupBox2.Controls.Add(this.chkDutChiGoc);
            this.groupBox2.Controls.Add(this.cmbTinhTrangDHN);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.cmbChiKhoaGoc);
            this.groupBox2.Controls.Add(this.cmbChiMatSo);
            this.groupBox2.Controls.Add(this.cmbTinhTrangChiSo);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cmbHienTrangKiemTra);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtHoTenKHKy);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtDienThoai);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNoiDungKiemTra);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dateKTXM);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtSoThan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMucDichSuDung);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtChiSo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtHieu);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 161);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả";
            // 
            // chkMoNuoc
            // 
            this.chkMoNuoc.AutoSize = true;
            this.chkMoNuoc.Location = new System.Drawing.Point(869, 135);
            this.chkMoNuoc.Name = "chkMoNuoc";
            this.chkMoNuoc.Size = new System.Drawing.Size(81, 20);
            this.chkMoNuoc.TabIndex = 48;
            this.chkMoNuoc.Text = "Mở Nước";
            this.chkMoNuoc.UseVisualStyleBackColor = true;
            this.chkMoNuoc.Visible = false;
            // 
            // chkDutChiGoc
            // 
            this.chkDutChiGoc.AutoSize = true;
            this.chkDutChiGoc.Location = new System.Drawing.Point(767, 135);
            this.chkDutChiGoc.Name = "chkDutChiGoc";
            this.chkDutChiGoc.Size = new System.Drawing.Size(96, 20);
            this.chkDutChiGoc.TabIndex = 47;
            this.chkDutChiGoc.Text = "Đứt Chì Góc";
            this.chkDutChiGoc.UseVisualStyleBackColor = true;
            this.chkDutChiGoc.Visible = false;
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(539, 68);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(89, 22);
            this.txtDienThoai.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nội Dung Kiểm Tra:";
            // 
            // txtNoiDungKiemTra
            // 
            this.txtNoiDungKiemTra.Location = new System.Drawing.Point(753, 39);
            this.txtNoiDungKiemTra.Multiline = true;
            this.txtNoiDungKiemTra.Name = "txtNoiDungKiemTra";
            this.txtNoiDungKiemTra.Size = new System.Drawing.Size(375, 82);
            this.txtNoiDungKiemTra.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(430, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Điện Thoại:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(307, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 16);
            this.label21.TabIndex = 7;
            this.label21.Text = "Danh Bộ:";
            // 
            // dgvDSKetQuaKiemTra
            // 
            this.dgvDSKetQuaKiemTra.AllowUserToAddRows = false;
            this.dgvDSKetQuaKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKetQuaKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKetQuaKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTKTXM,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.NoiDungKiemTra,
            this.CreateBy});
            this.dgvDSKetQuaKiemTra.Location = new System.Drawing.Point(12, 207);
            this.dgvDSKetQuaKiemTra.Name = "dgvDSKetQuaKiemTra";
            this.dgvDSKetQuaKiemTra.Size = new System.Drawing.Size(760, 174);
            this.dgvDSKetQuaKiemTra.TabIndex = 13;
            this.dgvDSKetQuaKiemTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSKetQuaKiemTra_CellContentClick);
            this.dgvDSKetQuaKiemTra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSKetQuaKiemTra_CellFormatting);
            this.dgvDSKetQuaKiemTra.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSKetQuaKiemTra_RowPostPaint);
            // 
            // MaCTKTXM
            // 
            this.MaCTKTXM.DataPropertyName = "MaCTKTXM";
            this.MaCTKTXM.HeaderText = "MaCTKTXM";
            this.MaCTKTXM.Name = "MaCTKTXM";
            this.MaCTKTXM.Visible = false;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
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
            this.HoTen.Width = 150;
            // 
            // NoiDungKiemTra
            // 
            this.NoiDungKiemTra.DataPropertyName = "NoiDungKiemTra";
            this.NoiDungKiemTra.HeaderText = "Nội Dung Kiểm Tra";
            this.NoiDungKiemTra.Name = "NoiDungKiemTra";
            this.NoiDungKiemTra.ReadOnly = true;
            this.NoiDungKiemTra.Width = 200;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Thực Hiện";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 150;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(377, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 8;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(779, 428);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(86, 25);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // chkDongTien
            // 
            this.chkDongTien.AutoSize = true;
            this.chkDongTien.Location = new System.Drawing.Point(779, 341);
            this.chkDongTien.Name = "chkDongTien";
            this.chkDongTien.Size = new System.Drawing.Size(89, 20);
            this.chkDongTien.TabIndex = 42;
            this.chkDongTien.Text = "Đóng Tiền";
            this.chkDongTien.UseVisualStyleBackColor = true;
            this.chkDongTien.CheckedChanged += new System.EventHandler(this.chkDongTienBoiThuong_CheckedChanged);
            // 
            // groupBoxDongTien
            // 
            this.groupBoxDongTien.Controls.Add(this.txtSoTienDongTien);
            this.groupBoxDongTien.Controls.Add(this.label23);
            this.groupBoxDongTien.Controls.Add(this.dateDongTien);
            this.groupBoxDongTien.Controls.Add(this.label22);
            this.groupBoxDongTien.Enabled = false;
            this.groupBoxDongTien.Location = new System.Drawing.Point(779, 356);
            this.groupBoxDongTien.Name = "groupBoxDongTien";
            this.groupBoxDongTien.Size = new System.Drawing.Size(370, 66);
            this.groupBoxDongTien.TabIndex = 41;
            this.groupBoxDongTien.TabStop = false;
            // 
            // txtSoTienDongTien
            // 
            this.txtSoTienDongTien.Location = new System.Drawing.Point(119, 37);
            this.txtSoTienDongTien.Name = "txtSoTienDongTien";
            this.txtSoTienDongTien.Size = new System.Drawing.Size(245, 22);
            this.txtSoTienDongTien.TabIndex = 57;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(118, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(55, 16);
            this.label23.TabIndex = 56;
            this.label23.Text = "Số Tiền";
            // 
            // dateDongTien
            // 
            this.dateDongTien.CustomFormat = "dd/MM/yyyy";
            this.dateDongTien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDongTien.Location = new System.Drawing.Point(10, 37);
            this.dateDongTien.Name = "dateDongTien";
            this.dateDongTien.Size = new System.Drawing.Size(97, 22);
            this.dateDongTien.TabIndex = 57;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 16);
            this.label22.TabIndex = 56;
            this.label22.Text = "Ngày";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(778, 207);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 58;
            this.label7.Text = "Nội Dung Xử Lý";
            // 
            // cmbNoiDungXuLy
            // 
            this.cmbNoiDungXuLy.FormattingEnabled = true;
            this.cmbNoiDungXuLy.Items.AddRange(new object[] {
            "Đóng Tiền Bồi Thường",
            "Trình Thay Miễn Phí",
            "Trình Bấm Lại Mặt Số"});
            this.cmbNoiDungXuLy.Location = new System.Drawing.Point(781, 226);
            this.cmbNoiDungXuLy.MaxDropDownItems = 50;
            this.cmbNoiDungXuLy.Name = "cmbNoiDungXuLy";
            this.cmbNoiDungXuLy.Size = new System.Drawing.Size(150, 24);
            this.cmbNoiDungXuLy.TabIndex = 32;
            this.cmbNoiDungXuLy.SelectedIndexChanged += new System.EventHandler(this.cmbNoiDungDongTien_SelectedIndexChanged);
            // 
            // chkChuyenLapTBCat
            // 
            this.chkChuyenLapTBCat.AutoSize = true;
            this.chkChuyenLapTBCat.Location = new System.Drawing.Point(998, 256);
            this.chkChuyenLapTBCat.Name = "chkChuyenLapTBCat";
            this.chkChuyenLapTBCat.Size = new System.Drawing.Size(142, 20);
            this.chkChuyenLapTBCat.TabIndex = 44;
            this.chkChuyenLapTBCat.Text = "Chuyển Lập TB Cắt";
            this.chkChuyenLapTBCat.UseVisualStyleBackColor = true;
            this.chkChuyenLapTBCat.CheckedChanged += new System.EventHandler(this.chkChuyenCatHuy_CheckedChanged);
            // 
            // groupBoxChuyenCatHuy
            // 
            this.groupBoxChuyenCatHuy.Controls.Add(this.dateChuyenCatHuy);
            this.groupBoxChuyenCatHuy.Controls.Add(this.label6);
            this.groupBoxChuyenCatHuy.Enabled = false;
            this.groupBoxChuyenCatHuy.Location = new System.Drawing.Point(998, 269);
            this.groupBoxChuyenCatHuy.Name = "groupBoxChuyenCatHuy";
            this.groupBoxChuyenCatHuy.Size = new System.Drawing.Size(151, 66);
            this.groupBoxChuyenCatHuy.TabIndex = 43;
            this.groupBoxChuyenCatHuy.TabStop = false;
            // 
            // dateChuyenCatHuy
            // 
            this.dateChuyenCatHuy.CustomFormat = "dd/MM/yyyy";
            this.dateChuyenCatHuy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateChuyenCatHuy.Location = new System.Drawing.Point(9, 37);
            this.dateChuyenCatHuy.Name = "dateChuyenCatHuy";
            this.dateChuyenCatHuy.Size = new System.Drawing.Size(97, 22);
            this.dateChuyenCatHuy.TabIndex = 57;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 16);
            this.label6.TabIndex = 56;
            this.label6.Text = "Ngày Chuyển";
            // 
            // chkLapBangGia
            // 
            this.chkLapBangGia.AutoSize = true;
            this.chkLapBangGia.Location = new System.Drawing.Point(779, 256);
            this.chkLapBangGia.Name = "chkLapBangGia";
            this.chkLapBangGia.Size = new System.Drawing.Size(109, 20);
            this.chkLapBangGia.TabIndex = 46;
            this.chkLapBangGia.Text = "Lập Bảng Giá";
            this.chkLapBangGia.UseVisualStyleBackColor = true;
            this.chkLapBangGia.CheckedChanged += new System.EventHandler(this.chkLapBangGia_CheckedChanged);
            // 
            // groupBoxLapBangGia
            // 
            this.groupBoxLapBangGia.Controls.Add(this.dateLapBangGia);
            this.groupBoxLapBangGia.Controls.Add(this.label2);
            this.groupBoxLapBangGia.Enabled = false;
            this.groupBoxLapBangGia.Location = new System.Drawing.Point(779, 269);
            this.groupBoxLapBangGia.Name = "groupBoxLapBangGia";
            this.groupBoxLapBangGia.Size = new System.Drawing.Size(153, 66);
            this.groupBoxLapBangGia.TabIndex = 45;
            this.groupBoxLapBangGia.TabStop = false;
            // 
            // dateLapBangGia
            // 
            this.dateLapBangGia.CustomFormat = "dd/MM/yyyy";
            this.dateLapBangGia.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLapBangGia.Location = new System.Drawing.Point(10, 37);
            this.dateLapBangGia.Name = "dateLapBangGia";
            this.dateLapBangGia.Size = new System.Drawing.Size(97, 22);
            this.dateLapBangGia.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 56;
            this.label2.Text = "Ngày Lập";
            // 
            // txtGhiChuNoiDungXuLy
            // 
            this.txtGhiChuNoiDungXuLy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtGhiChuNoiDungXuLy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtGhiChuNoiDungXuLy.Location = new System.Drawing.Point(937, 228);
            this.txtGhiChuNoiDungXuLy.Name = "txtGhiChuNoiDungXuLy";
            this.txtGhiChuNoiDungXuLy.Size = new System.Drawing.Size(174, 22);
            this.txtGhiChuNoiDungXuLy.TabIndex = 60;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(936, 209);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 16);
            this.label8.TabIndex = 59;
            this.label8.Text = "Ghi Chú Nội Dung Xử Lý";
            // 
            // frmDongTien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1167, 463);
            this.Controls.Add(this.txtGhiChuNoiDungXuLy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbTheoYeuCau);
            this.Controls.Add(this.txtTheoYeuCau);
            this.Controls.Add(this.cmbNoiDungXuLy);
            this.Controls.Add(this.chkLapBangGia);
            this.Controls.Add(this.groupBoxLapBangGia);
            this.Controls.Add(this.chkChuyenLapTBCat);
            this.Controls.Add(this.groupBoxChuyenCatHuy);
            this.Controls.Add(this.chkDongTien);
            this.Controls.Add(this.groupBoxDongTien);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dgvDSKetQuaKiemTra);
            this.Controls.Add(this.txtDanhBo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDongTien";
            this.Text = "Đóng Tiền";
            this.Load += new System.EventHandler(this.frmDongTien_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).EndInit();
            this.groupBoxDongTien.ResumeLayout(false);
            this.groupBoxDongTien.PerformLayout();
            this.groupBoxChuyenCatHuy.ResumeLayout(false);
            this.groupBoxChuyenCatHuy.PerformLayout();
            this.groupBoxLapBangGia.ResumeLayout(false);
            this.groupBoxLapBangGia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTheoYeuCau;
        private System.Windows.Forms.TextBox txtTheoYeuCau;
        private System.Windows.Forms.ComboBox cmbTinhTrangDHN;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbChiKhoaGoc;
        private System.Windows.Forms.ComboBox cmbChiMatSo;
        private System.Windows.Forms.ComboBox cmbHienTrangKiemTra;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtHoTenKHKy;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ComboBox cmbTinhTrangChiSo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateKTXM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoThan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMucDichSuDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChiSo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHieu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungKiemTra;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgvDSKetQuaKiemTra;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.CheckBox chkDongTien;
        private System.Windows.Forms.GroupBox groupBoxDongTien;
        private System.Windows.Forms.TextBox txtSoTienDongTien;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dateDongTien;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkChuyenLapTBCat;
        private System.Windows.Forms.GroupBox groupBoxChuyenCatHuy;
        private System.Windows.Forms.DateTimePicker dateChuyenCatHuy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkLapBangGia;
        private System.Windows.Forms.GroupBox groupBoxLapBangGia;
        private System.Windows.Forms.DateTimePicker dateLapBangGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbNoiDungXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDungKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.CheckBox chkDutChiGoc;
        private System.Windows.Forms.CheckBox chkMoNuoc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGhiChuNoiDungXuLy;
        private System.Windows.Forms.Label label8;
    }
}