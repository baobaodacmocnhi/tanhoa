namespace KTKS_DonKH.GUI.KhachHang
{
    partial class frmQLDonDienThoai
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
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvDonDT = new System.Windows.Forms.DataGridView();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnLapDon = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.dateTimKiem = new System.Windows.Forms.DateTimePicker();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInDaLapDon = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LapDon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaLD = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.MaDonDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiBao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonDT)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(564, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(192, 64);
            this.panel_KhoangThoiGian.TabIndex = 9;
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
            // dgvDonDT
            // 
            this.dgvDonDT.AllowUserToAddRows = false;
            this.dgvDonDT.AllowUserToDeleteRows = false;
            this.dgvDonDT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDonDT.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.LapDon,
            this.MaLD,
            this.MaDonDT,
            this.MaDon,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.GiaBieu,
            this.DinhMuc,
            this.NoiDung,
            this.GhiChu,
            this.NguoiBao,
            this.DienThoai});
            this.dgvDonDT.Location = new System.Drawing.Point(0, 67);
            this.dgvDonDT.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDonDT.Name = "dgvDonDT";
            this.dgvDonDT.Size = new System.Drawing.Size(1365, 465);
            this.dgvDonDT.TabIndex = 16;
            // 
            // btnIn
            // 
            this.btnIn.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Location = new System.Drawing.Point(799, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(54, 35);
            this.btnIn.TabIndex = 17;
            this.btnIn.Text = "In";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnLapDon
            // 
            this.btnLapDon.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLapDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLapDon.Location = new System.Drawing.Point(1124, 12);
            this.btnLapDon.Name = "btnLapDon";
            this.btnLapDon.Size = new System.Drawing.Size(97, 35);
            this.btnLapDon.TabIndex = 18;
            this.btnLapDon.Text = "Lập Đơn";
            this.btnLapDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLapDon.UseVisualStyleBackColor = true;
            this.btnLapDon.Click += new System.EventHandler(this.btnLapDon_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Danh Bộ",
            "Địa Chỉ",
            "Ngày",
            "Khoảng Thời Gian"});
            this.cmbTimTheo.Location = new System.Drawing.Point(353, 12);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(141, 25);
            this.cmbTimTheo.TabIndex = 20;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // dateTimKiem
            // 
            this.dateTimKiem.CustomFormat = "dd/MM/yyyy";
            this.dateTimKiem.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimKiem.Location = new System.Drawing.Point(574, 35);
            this.dateTimKiem.Name = "dateTimKiem";
            this.dateTimKiem.Size = new System.Drawing.Size(130, 25);
            this.dateTimKiem.TabIndex = 23;
            this.dateTimKiem.Visible = false;
            this.dateTimKiem.ValueChanged += new System.EventHandler(this.dateTimKiem_ValueChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(574, 12);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(130, 25);
            this.txtNoiDungTimKiem.TabIndex = 22;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.TextChanged += new System.EventHandler(this.txtNoiDungTimKiem_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(500, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nội Dung:";
            // 
            // btnInDaLapDon
            // 
            this.btnInDaLapDon.Image = global::KTKS_DonKH.Properties.Resources.print_24x24;
            this.btnInDaLapDon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInDaLapDon.Location = new System.Drawing.Point(883, 12);
            this.btnInDaLapDon.Name = "btnInDaLapDon";
            this.btnInDaLapDon.Size = new System.Drawing.Size(132, 35);
            this.btnInDaLapDon.TabIndex = 24;
            this.btnInDaLapDon.Text = "In Đã Lập Đơn";
            this.btnInDaLapDon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInDaLapDon.UseVisualStyleBackColor = true;
            this.btnInDaLapDon.Click += new System.EventHandler(this.btnInDaLapDon_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(12, 39);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(119, 21);
            this.chkSelectAll.TabIndex = 25;
            this.chkSelectAll.Text = "Chọn In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // In
            // 
            this.In.DataPropertyName = "In";
            this.In.HeaderText = "In";
            this.In.Name = "In";
            this.In.Width = 30;
            // 
            // LapDon
            // 
            this.LapDon.DataPropertyName = "LapDon";
            this.LapDon.HeaderText = "Lập Đơn";
            this.LapDon.Name = "LapDon";
            this.LapDon.Width = 70;
            // 
            // MaLD
            // 
            this.MaLD.DataPropertyName = "MaLD";
            this.MaLD.HeaderText = "Tên Loại Đơn";
            this.MaLD.Name = "MaLD";
            this.MaLD.Width = 150;
            // 
            // MaDonDT
            // 
            this.MaDonDT.DataPropertyName = "MaDonDT";
            this.MaDonDT.HeaderText = "MaDonDT";
            this.MaDonDT.Name = "MaDonDT";
            this.MaDonDT.ReadOnly = true;
            this.MaDonDT.Visible = false;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Nhận";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
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
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 200;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GB";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.ReadOnly = true;
            this.GiaBieu.Width = 50;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "ĐM";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.ReadOnly = true;
            this.DinhMuc.Width = 50;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 200;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            this.GhiChu.Width = 200;
            // 
            // NguoiBao
            // 
            this.NguoiBao.DataPropertyName = "NguoiBao";
            this.NguoiBao.HeaderText = "Người Báo";
            this.NguoiBao.Name = "NguoiBao";
            this.NguoiBao.ReadOnly = true;
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            this.DienThoai.ReadOnly = true;
            // 
            // frmQLDonDienThoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1376, 569);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnInDaLapDon);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.dateTimKiem);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.btnLapDon);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dgvDonDT);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmQLDonDienThoai";
            this.Text = "Quản Lý Đơn Điện Thoại";
            this.Load += new System.EventHandler(this.frmQLDonDienThoai_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDonDT)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvDonDT;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnLapDon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.DateTimePicker dateTimKiem;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInDaLapDon;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn LapDon;
        private System.Windows.Forms.DataGridViewComboBoxColumn MaLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDonDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
    }
}