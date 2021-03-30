namespace KTKS_DonKH.GUI.ThuTraLoi
{
    partial class frmDSToTrinh2021
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label20 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvToTrinh = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ThuDuocKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TraTrinhKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhieuTong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnInDS = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaFile_dgvHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(156, 28);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 16);
            this.label20.TabIndex = 12;
            this.label20.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã TT",
            "Danh Bộ",
            "Ngày",
            "Về Việc"});
            this.cmbTimTheo.Location = new System.Drawing.Point(230, 25);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 13;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(410, 25);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 15;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(336, 28);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(67, 16);
            this.label22.TabIndex = 14;
            this.label22.Text = "Nội Dung:";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label26);
            this.panel_KhoangThoiGian.Controls.Add(this.label27);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(403, 12);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 59);
            this.panel_KhoangThoiGian.TabIndex = 16;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(82, 5);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(82, 32);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 5);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(63, 16);
            this.label26.TabIndex = 15;
            this.label26.Text = "Từ Ngày:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 32);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(71, 16);
            this.label27.TabIndex = 16;
            this.label27.Text = "Đến Ngày:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(586, 28);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 17;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvToTrinh
            // 
            this.dgvToTrinh.AllowUserToAddRows = false;
            this.dgvToTrinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToTrinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToTrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.ThuDuocKy,
            this.TraTrinhKy,
            this.IDCT,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.VeViec,
            this.NoiDung,
            this.SoPhieuTong});
            this.dgvToTrinh.Location = new System.Drawing.Point(1, 77);
            this.dgvToTrinh.Name = "dgvToTrinh";
            this.dgvToTrinh.Size = new System.Drawing.Size(1273, 531);
            this.dgvToTrinh.TabIndex = 19;
            this.dgvToTrinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToTrinh_CellContentClick);
            this.dgvToTrinh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToTrinh_CellFormatting);
            this.dgvToTrinh.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvToTrinh_CellValidating);
            this.dgvToTrinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvToTrinh_RowPostPaint);
            this.dgvToTrinh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvToTrinh_KeyDown);
            // 
            // In
            // 
            this.In.FalseValue = "false";
            this.In.HeaderText = "In";
            this.In.IndeterminateValue = "false";
            this.In.Name = "In";
            this.In.TrueValue = "true";
            this.In.Width = 30;
            // 
            // ThuDuocKy
            // 
            this.ThuDuocKy.DataPropertyName = "ThuDuocKy";
            this.ThuDuocKy.HeaderText = "Được Ký";
            this.ThuDuocKy.Name = "ThuDuocKy";
            this.ThuDuocKy.Width = 50;
            // 
            // TraTrinhKy
            // 
            this.TraTrinhKy.DataPropertyName = "TraTrinhKy";
            this.TraTrinhKy.HeaderText = "Trả Trình Ký";
            this.TraTrinhKy.Name = "TraTrinhKy";
            this.TraTrinhKy.Width = 50;
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "Mã TT";
            this.IDCT.Name = "IDCT";
            this.IDCT.Width = 80;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.Width = 200;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 200;
            // 
            // SoPhieuTong
            // 
            this.SoPhieuTong.DataPropertyName = "SoPhieuTong";
            this.SoPhieuTong.HeaderText = "Số Phiếu Tổng";
            this.SoPhieuTong.Name = "SoPhieuTong";
            this.SoPhieuTong.Width = 50;
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(667, 28);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 25);
            this.btnInDS.TabIndex = 18;
            this.btnInDS.Text = "In";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaFile_dgvHinh});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(68, 26);
            // 
            // xoaFile_dgvHinh
            // 
            this.xoaFile_dgvHinh.Name = "xoaFile_dgvHinh";
            this.xoaFile_dgvHinh.Size = new System.Drawing.Size(67, 22);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(54, 46);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(114, 20);
            this.chkSelectAll.TabIndex = 22;
            this.chkSelectAll.Text = "Chọn In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // frmDSToTrinh2021
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1368, 647);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dgvToTrinh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "frmDSToTrinh2021";
            this.Text = "Danh Sách Tờ Trình";
            this.Load += new System.EventHandler(this.frmToTrinh_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmToTrinh_KeyUp);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvToTrinh;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem xoaFile_dgvHinh;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ThuDuocKy;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TraTrinhKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhieuTong;
    }
}