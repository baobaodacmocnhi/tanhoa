namespace KTKS_DonKH.GUI.ToXuLy
{
    partial class frmQLDonTXL
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
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.dgvDSDonTXL = new System.Windows.Forms.DataGridView();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCongVan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaiQuyet = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GhiChuChuyenKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInDSDonTXL = new System.Windows.Forms.Button();
            this.chkChuaKT = new System.Windows.Forms.CheckBox();
            this.btnInChiTiet = new System.Windows.Forms.Button();
            this.btnInGiaoToKH = new System.Windows.Forms.Button();
            this.btnGiaoKhac = new System.Windows.Forms.Button();
            this.btnInBamChi = new System.Windows.Forms.Button();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonTXL)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(359, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 31;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(85, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(85, 35);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Địa Chỉ",
            "Số Công Văn",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(137, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(141, 25);
            this.cmbTimTheo.TabIndex = 23;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(359, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 25;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nội Dung:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(359, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 26;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // dgvDSDonTXL
            // 
            this.dgvDSDonTXL.AllowUserToAddRows = false;
            this.dgvDSDonTXL.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDonTXL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSDonTXL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDonTXL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuyen,
            this.LyDoChuyen,
            this.SoLuongDiaChi,
            this.MaDon,
            this.TenLD,
            this.SoCongVan,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.CreateBy,
            this.NguoiDi,
            this.GiaiQuyet,
            this.GhiChuChuyenKT});
            this.dgvDSDonTXL.Location = new System.Drawing.Point(0, 67);
            this.dgvDSDonTXL.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSDonTXL.MultiSelect = false;
            this.dgvDSDonTXL.Name = "dgvDSDonTXL";
            this.dgvDSDonTXL.RowHeadersWidth = 60;
            this.dgvDSDonTXL.Size = new System.Drawing.Size(1362, 470);
            this.dgvDSDonTXL.TabIndex = 27;
            this.dgvDSDonTXL.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDonTXL_CellEndEdit);
            this.dgvDSDonTXL.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSDonTXL_CellFormatting);
            this.dgvDSDonTXL.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonTXL_RowPostPaint);
            this.dgvDSDonTXL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSDonTXL_KeyDown);
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Visible = false;
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyen
            // 
            this.LyDoChuyen.DataPropertyName = "LyDoChuyen";
            this.LyDoChuyen.HeaderText = "Ly Do Chuyển";
            this.LyDoChuyen.Name = "LyDoChuyen";
            this.LyDoChuyen.Visible = false;
            this.LyDoChuyen.Width = 200;
            // 
            // SoLuongDiaChi
            // 
            this.SoLuongDiaChi.DataPropertyName = "SoLuongDiaChi";
            this.SoLuongDiaChi.HeaderText = "SL.Địa Chỉ";
            this.SoLuongDiaChi.Name = "SoLuongDiaChi";
            this.SoLuongDiaChi.Visible = false;
            this.SoLuongDiaChi.Width = 110;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            dataGridViewCellStyle2.NullValue = null;
            this.MaDon.DefaultCellStyle = dataGridViewCellStyle2;
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 90;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.ReadOnly = true;
            this.TenLD.Width = 130;
            // 
            // SoCongVan
            // 
            this.SoCongVan.DataPropertyName = "SoCongVan";
            this.SoCongVan.HeaderText = "Số Công Văn";
            this.SoCongVan.Name = "SoCongVan";
            this.SoCongVan.Width = 120;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 110;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 260;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 270;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 245;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Lập";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 200;
            // 
            // NguoiDi
            // 
            this.NguoiDi.DataPropertyName = "NguoiDi";
            this.NguoiDi.HeaderText = "Người Được Giao";
            this.NguoiDi.Name = "NguoiDi";
            this.NguoiDi.Width = 200;
            // 
            // GiaiQuyet
            // 
            this.GiaiQuyet.HeaderText = "Giải Quyết";
            this.GiaiQuyet.Name = "GiaiQuyet";
            // 
            // GhiChuChuyenKT
            // 
            this.GhiChuChuyenKT.DataPropertyName = "GhiChuChuyenKT";
            this.GhiChuChuyenKT.HeaderText = "GhiChuChuyenKT";
            this.GhiChuChuyenKT.Name = "GhiChuChuyenKT";
            this.GhiChuChuyenKT.Visible = false;
            // 
            // btnInDSDonTXL
            // 
            this.btnInDSDonTXL.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInDSDonTXL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDSDonTXL.Location = new System.Drawing.Point(557, 4);
            this.btnInDSDonTXL.Name = "btnInDSDonTXL";
            this.btnInDSDonTXL.Size = new System.Drawing.Size(132, 35);
            this.btnInDSDonTXL.TabIndex = 29;
            this.btnInDSDonTXL.Text = "In (Ngày Giao)";
            this.btnInDSDonTXL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDSDonTXL.UseVisualStyleBackColor = true;
            this.btnInDSDonTXL.Click += new System.EventHandler(this.btnInDSDonKH_Click);
            // 
            // chkChuaKT
            // 
            this.chkChuaKT.AutoSize = true;
            this.chkChuaKT.Location = new System.Drawing.Point(557, 43);
            this.chkChuaKT.Name = "chkChuaKT";
            this.chkChuaKT.Size = new System.Drawing.Size(83, 21);
            this.chkChuaKT.TabIndex = 32;
            this.chkChuaKT.Text = "Chưa KT";
            this.chkChuaKT.UseVisualStyleBackColor = true;
            // 
            // btnInChiTiet
            // 
            this.btnInChiTiet.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInChiTiet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInChiTiet.Location = new System.Drawing.Point(977, 4);
            this.btnInChiTiet.Name = "btnInChiTiet";
            this.btnInChiTiet.Size = new System.Drawing.Size(114, 35);
            this.btnInChiTiet.TabIndex = 33;
            this.btnInChiTiet.Text = "In (Chi Tiết)";
            this.btnInChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInChiTiet.UseVisualStyleBackColor = true;
            this.btnInChiTiet.Click += new System.EventHandler(this.btnInChiTiet_Click);
            // 
            // btnInGiaoToKH
            // 
            this.btnInGiaoToKH.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInGiaoToKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInGiaoToKH.Location = new System.Drawing.Point(695, 4);
            this.btnInGiaoToKH.Name = "btnInGiaoToKH";
            this.btnInGiaoToKH.Size = new System.Drawing.Size(140, 35);
            this.btnInGiaoToKH.TabIndex = 34;
            this.btnInGiaoToKH.Text = "In (Giao Tổ KH)";
            this.btnInGiaoToKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInGiaoToKH.UseVisualStyleBackColor = true;
            this.btnInGiaoToKH.Click += new System.EventHandler(this.btnInGiaoToKH_Click);
            // 
            // btnGiaoKhac
            // 
            this.btnGiaoKhac.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnGiaoKhac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGiaoKhac.Location = new System.Drawing.Point(841, 4);
            this.btnGiaoKhac.Name = "btnGiaoKhac";
            this.btnGiaoKhac.Size = new System.Drawing.Size(130, 35);
            this.btnGiaoKhac.TabIndex = 35;
            this.btnGiaoKhac.Text = "In (Giao Khác)";
            this.btnGiaoKhac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGiaoKhac.UseVisualStyleBackColor = true;
            this.btnGiaoKhac.Click += new System.EventHandler(this.btnGiaoKhac_Click);
            // 
            // btnInBamChi
            // 
            this.btnInBamChi.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInBamChi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBamChi.Location = new System.Drawing.Point(1097, 4);
            this.btnInBamChi.Name = "btnInBamChi";
            this.btnInBamChi.Size = new System.Drawing.Size(114, 35);
            this.btnInBamChi.TabIndex = 36;
            this.btnInBamChi.Text = "In (Bấm Chì)";
            this.btnInBamChi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInBamChi.UseVisualStyleBackColor = true;
            this.btnInBamChi.Click += new System.EventHandler(this.btnInBamChi_Click);
            // 
            // frmQLDonTXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1395, 562);
            this.Controls.Add(this.btnInBamChi);
            this.Controls.Add(this.btnGiaoKhac);
            this.Controls.Add(this.btnInGiaoToKH);
            this.Controls.Add(this.btnInChiTiet);
            this.Controls.Add(this.chkChuaKT);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnInDSDonTXL);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.dgvDSDonTXL);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLDonTXL";
            this.Text = "Danh Sách Đơn Tổ Xử Lý";
            this.Load += new System.EventHandler(this.frmQLDonTXL_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonTXL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInDSDonTXL;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.DataGridView dgvDSDonTXL;
        private System.Windows.Forms.CheckBox chkChuaKT;
        private System.Windows.Forms.Button btnInChiTiet;
        private System.Windows.Forms.Button btnInGiaoToKH;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCongVan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiDi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GiaiQuyet;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChuChuyenKT;
        private System.Windows.Forms.Button btnGiaoKhac;
        private System.Windows.Forms.Button btnInBamChi;
    }
}