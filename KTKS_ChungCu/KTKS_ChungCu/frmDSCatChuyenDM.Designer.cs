namespace KTKS_ChungCu
{
    partial class frmDSCatChuyenDM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.dgvDSCatChuyenDM = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.btnInDS = new System.Windows.Forms.Button();
            this.MaLSCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InCatChuyen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CT_SoPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_MaCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_NhanNK_DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_NhanNK_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_NhanNK_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_CatNK_MaCN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_CatNK_DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_CatNK_HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CT_CatNK_DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CatDM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NhanDM = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.YeuCauCat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SoNKNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoNKCat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy_CC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCatChuyenDM)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(441, 38);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem2.TabIndex = 31;
            this.txtNoiDungTimKiem2.Visible = false;
            this.txtNoiDungTimKiem2.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem2_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(171, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(441, 39);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 30;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(432, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(189, 64);
            this.panel_KhoangThoiGian.TabIndex = 32;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(83, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 25);
            this.dateTu.TabIndex = 13;
            this.dateTu.ValueChanged += new System.EventHandler(this.dateTu_ValueChanged);
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(83, 35);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 25);
            this.dateDen.TabIndex = 14;
            this.dateDen.ValueChanged += new System.EventHandler(this.dateDen_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 41);
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
            "Số Phiếu",
            "Danh Bộ",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(245, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(120, 25);
            this.cmbTimTheo.TabIndex = 27;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(367, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(441, 11);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 29;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // dgvDSCatChuyenDM
            // 
            this.dgvDSCatChuyenDM.AllowUserToAddRows = false;
            this.dgvDSCatChuyenDM.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCatChuyenDM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCatChuyenDM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCatChuyenDM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLSCT,
            this.STT,
            this.Lo,
            this.Phong,
            this.InCatChuyen,
            this.CT_SoPhieu,
            this.Column1,
            this.CT_MaCT,
            this.CT_NhanNK_DanhBo,
            this.CT_NhanNK_HoTen,
            this.CT_NhanNK_DiaChi,
            this.CT_CatNK_MaCN,
            this.CT_CatNK_DanhBo,
            this.CT_CatNK_HoTen,
            this.CT_CatNK_DiaChi,
            this.MaDon,
            this.CatDM,
            this.NhanDM,
            this.YeuCauCat,
            this.SoNKNhan,
            this.SoNKCat,
            this.CreateBy_CC,
            this.GhiChu});
            this.dgvDSCatChuyenDM.Location = new System.Drawing.Point(0, 71);
            this.dgvDSCatChuyenDM.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSCatChuyenDM.MultiSelect = false;
            this.dgvDSCatChuyenDM.Name = "dgvDSCatChuyenDM";
            this.dgvDSCatChuyenDM.RowHeadersWidth = 60;
            this.dgvDSCatChuyenDM.Size = new System.Drawing.Size(1275, 470);
            this.dgvDSCatChuyenDM.TabIndex = 33;
            this.dgvDSCatChuyenDM.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSCatChuyenDM_CellFormatting);
            // 
            // btnIn
            // 
            this.btnIn.Image = global::KTKS_ChungCu.Properties.Resources.print_24x24;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(1076, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(92, 35);
            this.btnIn.TabIndex = 34;
            this.btnIn.Text = "In Phiếu";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Visible = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 44);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(119, 21);
            this.chkSelectAll.TabIndex = 35;
            this.chkSelectAll.Text = "Chọn In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.Visible = false;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // btnInDS
            // 
            this.btnInDS.Image = global::KTKS_ChungCu.Properties.Resources.print_24x24;
            this.btnInDS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDS.Location = new System.Drawing.Point(627, 12);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(80, 35);
            this.btnInDS.TabIndex = 36;
            this.btnInDS.Text = "In DS";
            this.btnInDS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // MaLSCT
            // 
            this.MaLSCT.DataPropertyName = "MaLSCT";
            this.MaLSCT.HeaderText = "Mã LSCT";
            this.MaLSCT.Name = "MaLSCT";
            this.MaLSCT.Visible = false;
            // 
            // STT
            // 
            this.STT.DataPropertyName = "STT";
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Visible = false;
            // 
            // Lo
            // 
            this.Lo.DataPropertyName = "Lo";
            this.Lo.HeaderText = "Lo";
            this.Lo.Name = "Lo";
            this.Lo.Visible = false;
            // 
            // Phong
            // 
            this.Phong.DataPropertyName = "Phong";
            this.Phong.HeaderText = "Phong";
            this.Phong.Name = "Phong";
            this.Phong.Visible = false;
            // 
            // InCatChuyen
            // 
            this.InCatChuyen.DataPropertyName = "In";
            this.InCatChuyen.HeaderText = "In";
            this.InCatChuyen.Name = "InCatChuyen";
            this.InCatChuyen.Width = 30;
            // 
            // CT_SoPhieu
            // 
            this.CT_SoPhieu.DataPropertyName = "SoPhieu";
            this.CT_SoPhieu.HeaderText = "Số Phiếu";
            this.CT_SoPhieu.Name = "CT_SoPhieu";
            this.CT_SoPhieu.ReadOnly = true;
            this.CT_SoPhieu.Width = 90;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CreateDate";
            this.Column1.HeaderText = "Ngày Lập";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // CT_MaCT
            // 
            this.CT_MaCT.DataPropertyName = "MaCT";
            this.CT_MaCT.HeaderText = "Số Chứng Từ";
            this.CT_MaCT.Name = "CT_MaCT";
            this.CT_MaCT.ReadOnly = true;
            // 
            // CT_NhanNK_DanhBo
            // 
            this.CT_NhanNK_DanhBo.DataPropertyName = "NhanNK_DanhBo";
            this.CT_NhanNK_DanhBo.HeaderText = "Danh Bộ Nhận";
            this.CT_NhanNK_DanhBo.Name = "CT_NhanNK_DanhBo";
            this.CT_NhanNK_DanhBo.ReadOnly = true;
            this.CT_NhanNK_DanhBo.Width = 90;
            // 
            // CT_NhanNK_HoTen
            // 
            this.CT_NhanNK_HoTen.DataPropertyName = "NhanNK_HoTen";
            this.CT_NhanNK_HoTen.HeaderText = "Khách Hàng Nhận";
            this.CT_NhanNK_HoTen.Name = "CT_NhanNK_HoTen";
            this.CT_NhanNK_HoTen.ReadOnly = true;
            this.CT_NhanNK_HoTen.Width = 200;
            // 
            // CT_NhanNK_DiaChi
            // 
            this.CT_NhanNK_DiaChi.DataPropertyName = "NhanNK_DiaChi";
            this.CT_NhanNK_DiaChi.HeaderText = "Địa Chỉ Nhận";
            this.CT_NhanNK_DiaChi.Name = "CT_NhanNK_DiaChi";
            this.CT_NhanNK_DiaChi.ReadOnly = true;
            this.CT_NhanNK_DiaChi.Width = 250;
            // 
            // CT_CatNK_MaCN
            // 
            this.CT_CatNK_MaCN.DataPropertyName = "CatNK_MaCN";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CT_CatNK_MaCN.DefaultCellStyle = dataGridViewCellStyle2;
            this.CT_CatNK_MaCN.HeaderText = "Chi Nhánh Cắt";
            this.CT_CatNK_MaCN.Name = "CT_CatNK_MaCN";
            this.CT_CatNK_MaCN.ReadOnly = true;
            this.CT_CatNK_MaCN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CT_CatNK_MaCN.Width = 250;
            // 
            // CT_CatNK_DanhBo
            // 
            this.CT_CatNK_DanhBo.DataPropertyName = "CatNK_DanhBo";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CT_CatNK_DanhBo.DefaultCellStyle = dataGridViewCellStyle3;
            this.CT_CatNK_DanhBo.HeaderText = "Danh Bộ Cắt";
            this.CT_CatNK_DanhBo.Name = "CT_CatNK_DanhBo";
            this.CT_CatNK_DanhBo.ReadOnly = true;
            this.CT_CatNK_DanhBo.Width = 90;
            // 
            // CT_CatNK_HoTen
            // 
            this.CT_CatNK_HoTen.DataPropertyName = "CatNK_HoTen";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CT_CatNK_HoTen.DefaultCellStyle = dataGridViewCellStyle4;
            this.CT_CatNK_HoTen.HeaderText = "Khách Hàng Cắt";
            this.CT_CatNK_HoTen.Name = "CT_CatNK_HoTen";
            this.CT_CatNK_HoTen.ReadOnly = true;
            this.CT_CatNK_HoTen.Width = 200;
            // 
            // CT_CatNK_DiaChi
            // 
            this.CT_CatNK_DiaChi.DataPropertyName = "CatNK_DiaChi";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.CT_CatNK_DiaChi.DefaultCellStyle = dataGridViewCellStyle5;
            this.CT_CatNK_DiaChi.HeaderText = "Địa Chỉ Cắt";
            this.CT_CatNK_DiaChi.Name = "CT_CatNK_DiaChi";
            this.CT_CatNK_DiaChi.ReadOnly = true;
            this.CT_CatNK_DiaChi.Width = 250;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.Visible = false;
            // 
            // CatDM
            // 
            this.CatDM.DataPropertyName = "CatDM";
            this.CatDM.HeaderText = "Cắt DM";
            this.CatDM.Name = "CatDM";
            this.CatDM.Visible = false;
            // 
            // NhanDM
            // 
            this.NhanDM.DataPropertyName = "NhanDM";
            this.NhanDM.HeaderText = "Nhận ĐM";
            this.NhanDM.Name = "NhanDM";
            this.NhanDM.Visible = false;
            // 
            // YeuCauCat
            // 
            this.YeuCauCat.DataPropertyName = "YeuCauCat";
            this.YeuCauCat.HeaderText = "YC Cắt";
            this.YeuCauCat.Name = "YeuCauCat";
            this.YeuCauCat.Visible = false;
            // 
            // SoNKNhan
            // 
            this.SoNKNhan.DataPropertyName = "SoNKNhan";
            this.SoNKNhan.HeaderText = "Số Nhân Khẩu";
            this.SoNKNhan.Name = "SoNKNhan";
            // 
            // SoNKCat
            // 
            this.SoNKCat.DataPropertyName = "SoNKCat";
            this.SoNKCat.HeaderText = "Số Nhân Khẩu Cắt";
            this.SoNKCat.Name = "SoNKCat";
            this.SoNKCat.Visible = false;
            // 
            // CreateBy_CC
            // 
            this.CreateBy_CC.DataPropertyName = "CreateBy";
            this.CreateBy_CC.HeaderText = "CreateBy";
            this.CreateBy_CC.Name = "CreateBy_CC";
            this.CreateBy_CC.Visible = false;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "GhiChu";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Visible = false;
            // 
            // frmDSCatChuyenDM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1276, 593);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvDSCatChuyenDM);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSCatChuyenDM";
            this.Text = "Danh Sách Cắt Chuyển ĐM";
            this.Load += new System.EventHandler(this.frmDSCatChuyenDM_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCatChuyenDM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.DataGridView dgvDSCatChuyenDM;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLSCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn InCatChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_SoPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_MaCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_NhanNK_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_NhanNK_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_NhanNK_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_CatNK_MaCN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_CatNK_DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_CatNK_HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CT_CatNK_DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CatDM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NhanDM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn YeuCauCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoNKCat;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy_CC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;

    }
}