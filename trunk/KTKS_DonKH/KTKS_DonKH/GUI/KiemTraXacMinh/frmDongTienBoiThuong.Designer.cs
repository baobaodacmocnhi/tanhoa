﻿namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmDongTienBoiThuong
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
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungKiemTra = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label21 = new System.Windows.Forms.Label();
            this.dgvDSKetQuaKiemTra = new System.Windows.Forms.DataGridView();
            this.MaCTKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDungKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.chkDongTienBoiThuong = new System.Windows.Forms.CheckBox();
            this.groupDongTienBoiThuong = new System.Windows.Forms.GroupBox();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.dateDongTien = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).BeginInit();
            this.groupDongTienBoiThuong.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTheoYeuCau
            // 
            this.lbTheoYeuCau.AutoSize = true;
            this.lbTheoYeuCau.Location = new System.Drawing.Point(583, 138);
            this.lbTheoYeuCau.Name = "lbTheoYeuCau";
            this.lbTheoYeuCau.Size = new System.Drawing.Size(164, 17);
            this.lbTheoYeuCau.TabIndex = 30;
            this.lbTheoYeuCau.Text = "Thực Hiện Theo Yêu Cầu:";
            this.lbTheoYeuCau.Visible = false;
            // 
            // txtTheoYeuCau
            // 
            this.txtTheoYeuCau.Location = new System.Drawing.Point(753, 135);
            this.txtTheoYeuCau.Name = "txtTheoYeuCau";
            this.txtTheoYeuCau.Size = new System.Drawing.Size(281, 25);
            this.txtTheoYeuCau.TabIndex = 31;
            this.txtTheoYeuCau.Visible = false;
            // 
            // cmbTinhTrangDHN
            // 
            this.cmbTinhTrangDHN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbTinhTrangDHN.Location = new System.Drawing.Point(310, 41);
            this.cmbTinhTrangDHN.MaxDropDownItems = 50;
            this.cmbTinhTrangDHN.Name = "cmbTinhTrangDHN";
            this.cmbTinhTrangDHN.Size = new System.Drawing.Size(165, 25);
            this.cmbTinhTrangDHN.TabIndex = 5;
            this.cmbTinhTrangDHN.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(307, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 17);
            this.label20.TabIndex = 4;
            this.label20.Text = "ĐHN lúc Kiểm Tra";
            this.label20.Visible = false;
            // 
            // cmbChiKhoaGoc
            // 
            this.cmbChiKhoaGoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiKhoaGoc.FormattingEnabled = true;
            this.cmbChiKhoaGoc.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiKhoaGoc.Location = new System.Drawing.Point(308, 104);
            this.cmbChiKhoaGoc.MaxDropDownItems = 50;
            this.cmbChiKhoaGoc.Name = "cmbChiKhoaGoc";
            this.cmbChiKhoaGoc.Size = new System.Drawing.Size(70, 25);
            this.cmbChiKhoaGoc.TabIndex = 19;
            // 
            // cmbChiMatSo
            // 
            this.cmbChiMatSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiMatSo.FormattingEnabled = true;
            this.cmbChiMatSo.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiMatSo.Location = new System.Drawing.Point(308, 73);
            this.cmbChiMatSo.MaxDropDownItems = 50;
            this.cmbChiMatSo.Name = "cmbChiMatSo";
            this.cmbChiMatSo.Size = new System.Drawing.Size(70, 25);
            this.cmbChiMatSo.TabIndex = 17;
            // 
            // cmbHienTrangKiemTra
            // 
            this.cmbHienTrangKiemTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHienTrangKiemTra.FormattingEnabled = true;
            this.cmbHienTrangKiemTra.Location = new System.Drawing.Point(114, 42);
            this.cmbHienTrangKiemTra.MaxDropDownItems = 50;
            this.cmbHienTrangKiemTra.Name = "cmbHienTrangKiemTra";
            this.cmbHienTrangKiemTra.Size = new System.Drawing.Size(188, 25);
            this.cmbHienTrangKiemTra.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(111, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Hiện Trạng Kiểm Tra";
            // 
            // txtHoTenKHKy
            // 
            this.txtHoTenKHKy.Location = new System.Drawing.Point(540, 104);
            this.txtHoTenKHKy.Name = "txtHoTenKHKy";
            this.txtHoTenKHKy.Size = new System.Drawing.Size(178, 25);
            this.txtHoTenKHKy.TabIndex = 25;
            // 
            // cmbTinhTrangChiSo
            // 
            this.cmbTinhTrangChiSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.cmbTinhTrangChiSo.Location = new System.Drawing.Point(540, 42);
            this.cmbTinhTrangChiSo.MaxDropDownItems = 50;
            this.cmbTinhTrangChiSo.Name = "cmbTinhTrangChiSo";
            this.cmbTinhTrangChiSo.Size = new System.Drawing.Size(165, 25);
            this.cmbTinhTrangChiSo.TabIndex = 9;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(537, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 17);
            this.label19.TabIndex = 8;
            this.label19.Text = "Chỉ Số lúc Kiểm Tra";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 24;
            this.label17.Text = "Họ Tên KH Ký:";
            // 
            // dateKTXM
            // 
            this.dateKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKTXM.Location = new System.Drawing.Point(11, 42);
            this.dateKTXM.Name = "dateKTXM";
            this.dateKTXM.Size = new System.Drawing.Size(97, 25);
            this.dateKTXM.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Ngày Kiểm Tra";
            // 
            // txtSoThan
            // 
            this.txtSoThan.Location = new System.Drawing.Point(73, 135);
            this.txtSoThan.Name = "txtSoThan";
            this.txtSoThan.Size = new System.Drawing.Size(97, 25);
            this.txtSoThan.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Số Thân:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Chì Khóa Góc:";
            // 
            // txtMucDichSuDung
            // 
            this.txtMucDichSuDung.Location = new System.Drawing.Point(308, 135);
            this.txtMucDichSuDung.Name = "txtMucDichSuDung";
            this.txtMucDichSuDung.Size = new System.Drawing.Size(231, 25);
            this.txtMucDichSuDung.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Mục Đích Sử Dụng:";
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(73, 104);
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(97, 25);
            this.txtCo.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Cỡ:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 17);
            this.label13.TabIndex = 16;
            this.label13.Text = "Chì Mặt Số:";
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(481, 42);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(50, 25);
            this.txtChiSo.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(478, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 17);
            this.label14.TabIndex = 6;
            this.label14.Text = "Chỉ Số";
            // 
            // txtHieu
            // 
            this.txtHieu.Location = new System.Drawing.Point(73, 73);
            this.txtHieu.Name = "txtHieu";
            this.txtHieu.Size = new System.Drawing.Size(97, 25);
            this.txtHieu.TabIndex = 11;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 17);
            this.label15.TabIndex = 10;
            this.label15.Text = "Hiệu:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbTheoYeuCau);
            this.groupBox2.Controls.Add(this.txtTheoYeuCau);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 36);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 171);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(540, 73);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(89, 25);
            this.txtDienThoai.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nội Dung Kiểm Tra:";
            // 
            // txtNoiDungKiemTra
            // 
            this.txtNoiDungKiemTra.Location = new System.Drawing.Point(753, 42);
            this.txtNoiDungKiemTra.Multiline = true;
            this.txtNoiDungKiemTra.Name = "txtNoiDungKiemTra";
            this.txtNoiDungKiemTra.Size = new System.Drawing.Size(375, 87);
            this.txtNoiDungKiemTra.TabIndex = 27;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(430, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Điện Thoại:";
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Thực Hiện";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 200;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(296, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(64, 17);
            this.label21.TabIndex = 7;
            this.label21.Text = "Danh Bộ:";
            // 
            // dgvDSKetQuaKiemTra
            // 
            this.dgvDSKetQuaKiemTra.AllowUserToAddRows = false;
            this.dgvDSKetQuaKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKetQuaKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKetQuaKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTKTXM,
            this.ToXuLy,
            this.MaDon,
            this.DanhBo,
            this.NoiDungKiemTra,
            this.CreateBy});
            this.dgvDSKetQuaKiemTra.Location = new System.Drawing.Point(12, 213);
            this.dgvDSKetQuaKiemTra.Name = "dgvDSKetQuaKiemTra";
            this.dgvDSKetQuaKiemTra.Size = new System.Drawing.Size(760, 250);
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
            // ToXuLy
            // 
            this.ToXuLy.DataPropertyName = "ToXuLy";
            this.ToXuLy.HeaderText = "TXL";
            this.ToXuLy.Name = "ToXuLy";
            this.ToXuLy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ToXuLy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ToXuLy.Width = 50;
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
            // NoiDungKiemTra
            // 
            this.NoiDungKiemTra.DataPropertyName = "NoiDungKiemTra";
            this.NoiDungKiemTra.HeaderText = "Kết Qủa";
            this.NoiDungKiemTra.Name = "NoiDungKiemTra";
            this.NoiDungKiemTra.ReadOnly = true;
            this.NoiDungKiemTra.Width = 250;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(366, 5);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 25);
            this.txtDanhBo.TabIndex = 8;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(1023, 287);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(100, 35);
            this.btnSua.TabIndex = 12;
            this.btnSua.Text = "Cập Nhật";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // chkDongTienBoiThuong
            // 
            this.chkDongTienBoiThuong.AutoSize = true;
            this.chkDongTienBoiThuong.Location = new System.Drawing.Point(778, 213);
            this.chkDongTienBoiThuong.Name = "chkDongTienBoiThuong";
            this.chkDongTienBoiThuong.Size = new System.Drawing.Size(162, 21);
            this.chkDongTienBoiThuong.TabIndex = 42;
            this.chkDongTienBoiThuong.Text = "Đóng Tiền Bồi Thường";
            this.chkDongTienBoiThuong.UseVisualStyleBackColor = true;
            this.chkDongTienBoiThuong.CheckedChanged += new System.EventHandler(this.chkDongTienBoiThuong_CheckedChanged);
            // 
            // groupDongTienBoiThuong
            // 
            this.groupDongTienBoiThuong.Controls.Add(this.txtSoTien);
            this.groupDongTienBoiThuong.Controls.Add(this.label23);
            this.groupDongTienBoiThuong.Controls.Add(this.dateDongTien);
            this.groupDongTienBoiThuong.Controls.Add(this.label22);
            this.groupDongTienBoiThuong.Enabled = false;
            this.groupDongTienBoiThuong.Location = new System.Drawing.Point(778, 228);
            this.groupDongTienBoiThuong.Name = "groupDongTienBoiThuong";
            this.groupDongTienBoiThuong.Size = new System.Drawing.Size(239, 94);
            this.groupDongTienBoiThuong.TabIndex = 41;
            this.groupDongTienBoiThuong.TabStop = false;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(118, 45);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(97, 25);
            this.txtSoTien.TabIndex = 57;
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(117, 25);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(52, 17);
            this.label23.TabIndex = 56;
            this.label23.Text = "Số Tiền";
            // 
            // dateDongTien
            // 
            this.dateDongTien.CustomFormat = "dd/MM/yyyy";
            this.dateDongTien.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDongTien.Location = new System.Drawing.Point(9, 45);
            this.dateDongTien.Name = "dateDongTien";
            this.dateDongTien.Size = new System.Drawing.Size(97, 25);
            this.dateDongTien.TabIndex = 57;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(105, 17);
            this.label22.TabIndex = 56;
            this.label22.Text = "Ngày Đóng Tiền";
            // 
            // frmDongTienBoiThuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1154, 493);
            this.Controls.Add(this.chkDongTienBoiThuong);
            this.Controls.Add(this.groupDongTienBoiThuong);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.dgvDSKetQuaKiemTra);
            this.Controls.Add(this.txtDanhBo);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDongTienBoiThuong";
            this.Text = "Đóng Tiền Bồi Thường";
            this.Load += new System.EventHandler(this.frmDongTienBoiThuong_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).EndInit();
            this.groupDongTienBoiThuong.ResumeLayout(false);
            this.groupDongTienBoiThuong.PerformLayout();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.DataGridView dgvDSKetQuaKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTKTXM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDungKiemTra;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.CheckBox chkDongTienBoiThuong;
        private System.Windows.Forms.GroupBox groupDongTienBoiThuong;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DateTimePicker dateDongTien;
        private System.Windows.Forms.Label label22;
    }
}