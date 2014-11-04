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
            this.radAll = new System.Windows.Forms.RadioButton();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.radChuaChuyen = new System.Windows.Forms.RadioButton();
            this.radDaChuyen = new System.Windows.Forms.RadioButton();
            this.dgvDSDonTXL = new System.Windows.Forms.DataGridView();
            this.btnInDSDonKH = new System.Windows.Forms.Button();
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
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(594, 0);
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
            "Ngày Lập",
            "Khoảng Thời Gian",
            "Số Công Văn"});
            this.cmbTimTheo.Location = new System.Drawing.Point(372, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(141, 25);
            this.cmbTimTheo.TabIndex = 23;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(594, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 25;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Nội Dung:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 22;
            this.label2.Text = "Tìm Theo:";
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(121, 12);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(67, 21);
            this.radAll.TabIndex = 30;
            this.radAll.Text = "Tất Cả";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(594, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 26;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // radChuaChuyen
            // 
            this.radChuaChuyen.AutoSize = true;
            this.radChuaChuyen.Location = new System.Drawing.Point(12, 39);
            this.radChuaChuyen.Name = "radChuaChuyen";
            this.radChuaChuyen.Size = new System.Drawing.Size(107, 21);
            this.radChuaChuyen.TabIndex = 21;
            this.radChuaChuyen.Text = "Chưa Chuyển";
            this.radChuaChuyen.UseVisualStyleBackColor = true;
            this.radChuaChuyen.CheckedChanged += new System.EventHandler(this.radChuaDuyet_CheckedChanged);
            // 
            // radDaChuyen
            // 
            this.radDaChuyen.AutoSize = true;
            this.radDaChuyen.Location = new System.Drawing.Point(12, 12);
            this.radDaChuyen.Name = "radDaChuyen";
            this.radDaChuyen.Size = new System.Drawing.Size(93, 21);
            this.radDaChuyen.TabIndex = 20;
            this.radDaChuyen.Text = "Đã Chuyển";
            this.radDaChuyen.UseVisualStyleBackColor = true;
            this.radDaChuyen.CheckedChanged += new System.EventHandler(this.radDaDuyet_CheckedChanged);
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
            this.NguoiDi});
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
            // btnInDSDonKH
            // 
            this.btnInDSDonKH.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInDSDonKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDSDonKH.Location = new System.Drawing.Point(844, 12);
            this.btnInDSDonKH.Name = "btnInDSDonKH";
            this.btnInDSDonKH.Size = new System.Drawing.Size(202, 35);
            this.btnInDSDonKH.TabIndex = 29;
            this.btnInDSDonKH.Text = "In Danh Sách (Ngày Giao)";
            this.btnInDSDonKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDSDonKH.UseVisualStyleBackColor = true;
            this.btnInDSDonKH.Click += new System.EventHandler(this.btnInDSDonKH_Click);
            // 
            // MaChuyen
            // 
            this.MaChuyen.DataPropertyName = "MaChuyen";
            this.MaChuyen.HeaderText = "Chuyển Đi";
            this.MaChuyen.Name = "MaChuyen";
            this.MaChuyen.Width = 150;
            // 
            // LyDoChuyen
            // 
            this.LyDoChuyen.DataPropertyName = "LyDoChuyen";
            this.LyDoChuyen.HeaderText = "Ly Do Chuyển";
            this.LyDoChuyen.Name = "LyDoChuyen";
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
            this.CreateBy.HeaderText = "Người Nhận";
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
            // frmQLDonTXL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 562);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.btnInDSDonKH);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.radChuaChuyen);
            this.Controls.Add(this.radDaChuyen);
            this.Controls.Add(this.dgvDSDonTXL);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLDonTXL";
            this.Text = "frmQLDonTXL";
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
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.Button btnInDSDonKH;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.RadioButton radChuaChuyen;
        private System.Windows.Forms.RadioButton radDaChuyen;
        private System.Windows.Forms.DataGridView dgvDSDonTXL;
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
    }
}