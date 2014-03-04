namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmQLDonKH
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSDonKH = new System.Windows.Forms.DataGridView();
            this.MaChuyen = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.LyDoChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongDiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NVKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuu = new System.Windows.Forms.Button();
            this.radDaDuyet = new System.Windows.Forms.RadioButton();
            this.radChuaDuyet = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.btnInDSDonKH = new System.Windows.Forms.Button();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSDonKH
            // 
            this.dgvDSDonKH.AllowUserToAddRows = false;
            this.dgvDSDonKH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSDonKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDSDonKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSDonKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChuyen,
            this.LyDoChuyen,
            this.SoLuongDiaChi,
            this.NVKiemTra,
            this.MaDon,
            this.TenLD,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung});
            this.dgvDSDonKH.Location = new System.Drawing.Point(0, 67);
            this.dgvDSDonKH.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDSDonKH.MultiSelect = false;
            this.dgvDSDonKH.Name = "dgvDSDonKH";
            this.dgvDSDonKH.Size = new System.Drawing.Size(1605, 470);
            this.dgvDSDonKH.TabIndex = 7;
            this.dgvDSDonKH.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDSDonKH_CellBeginEdit);
            this.dgvDSDonKH.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSDonKH_CellEndEdit);
            this.dgvDSDonKH.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSDonKH_CellFormatting);
            this.dgvDSDonKH.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDSDonKH_EditingControlShowing);
            this.dgvDSDonKH.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSDonKH_RowPostPaint);
            this.dgvDSDonKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSDonKH_KeyDown);
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
            this.SoLuongDiaChi.Width = 110;
            // 
            // NVKiemTra
            // 
            this.NVKiemTra.DataPropertyName = "NVKiemTra";
            this.NVKiemTra.HeaderText = "NV Kiểm Tra";
            this.NVKiemTra.Name = "NVKiemTra";
            this.NVKiemTra.Width = 120;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            dataGridViewCellStyle4.NullValue = null;
            this.MaDon.DefaultCellStyle = dataGridViewCellStyle4;
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
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1180, 12);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // radDaDuyet
            // 
            this.radDaDuyet.AutoSize = true;
            this.radDaDuyet.Location = new System.Drawing.Point(12, 12);
            this.radDaDuyet.Name = "radDaDuyet";
            this.radDaDuyet.Size = new System.Drawing.Size(84, 21);
            this.radDaDuyet.TabIndex = 0;
            this.radDaDuyet.Text = "Đã Duyệt";
            this.radDaDuyet.UseVisualStyleBackColor = true;
            this.radDaDuyet.CheckedChanged += new System.EventHandler(this.radDaDuyet_CheckedChanged);
            // 
            // radChuaDuyet
            // 
            this.radChuaDuyet.AutoSize = true;
            this.radChuaDuyet.Location = new System.Drawing.Point(12, 39);
            this.radChuaDuyet.Name = "radChuaDuyet";
            this.radChuaDuyet.Size = new System.Drawing.Size(98, 21);
            this.radChuaDuyet.TabIndex = 1;
            this.radChuaDuyet.Text = "Chưa Duyệt";
            this.radChuaDuyet.UseVisualStyleBackColor = true;
            this.radChuaDuyet.CheckedChanged += new System.EventHandler(this.radChuaDuyet_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(520, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(594, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 5;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Ngày Lập",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(372, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(141, 25);
            this.cmbTimTheo.TabIndex = 3;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm Theo:";
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(594, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 6;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
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
            // btnInDSDonKH
            // 
            this.btnInDSDonKH.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInDSDonKH.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDSDonKH.Location = new System.Drawing.Point(844, 12);
            this.btnInDSDonKH.Name = "btnInDSDonKH";
            this.btnInDSDonKH.Size = new System.Drawing.Size(125, 35);
            this.btnInDSDonKH.TabIndex = 17;
            this.btnInDSDonKH.Text = "In Danh Sách";
            this.btnInDSDonKH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDSDonKH.UseVisualStyleBackColor = true;
            this.btnInDSDonKH.Click += new System.EventHandler(this.btnInDSDonKH_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Location = new System.Drawing.Point(121, 12);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(67, 21);
            this.radAll.TabIndex = 18;
            this.radAll.Text = "Tất Cả";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(595, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 19;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // frmQLDonKH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1370, 562);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.radAll);
            this.Controls.Add(this.btnInDSDonKH);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radChuaDuyet);
            this.Controls.Add(this.radDaDuyet);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.dgvDSDonKH);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLDonKH";
            this.Text = "Danh Sách Đơn Khách Hàng";
            this.Load += new System.EventHandler(this.frmQLDonKH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSDonKH)).EndInit();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSDonKH;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.RadioButton radDaDuyet;
        private System.Windows.Forms.RadioButton radChuaDuyet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Button btnInDSDonKH;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongDiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NVKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;


    }
}