namespace KTKS_DonKH.GUI.BamChi
{
    partial class frmDSBamChi
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
            this.dgvDSCTBamChi = new System.Windows.Forms.DataGridView();
            this.MaCTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VienChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaSoBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TheoYeuCau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInQuetToanVatTu = new System.Windows.Forms.Button();
            this.chkInBamChiThan_BBDCMS = new System.Windows.Forms.CheckBox();
            this.chkLoaiDon = new System.Windows.Forms.CheckBox();
            this.btnXem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTBamChi)).BeginInit();
            this.panel_KhoangThoiGian.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSCTBamChi
            // 
            this.dgvDSCTBamChi.AllowUserToAddRows = false;
            this.dgvDSCTBamChi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSCTBamChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSCTBamChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSCTBamChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTBC,
            this.ToXuLy,
            this.MaDon,
            this.TenLD,
            this.NgayBC,
            this.DanhBo,
            this.HopDong,
            this.HoTen,
            this.DiaChi,
            this.Hieu,
            this.Co,
            this.ChiSo,
            this.TrangThaiBC,
            this.VienChi,
            this.DayChi,
            this.MaSoBC,
            this.TheoYeuCau,
            this.CreateBy});
            this.dgvDSCTBamChi.Location = new System.Drawing.Point(0, 65);
            this.dgvDSCTBamChi.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgvDSCTBamChi.MultiSelect = false;
            this.dgvDSCTBamChi.Name = "dgvDSCTBamChi";
            this.dgvDSCTBamChi.RowHeadersWidth = 60;
            this.dgvDSCTBamChi.Size = new System.Drawing.Size(1432, 544);
            this.dgvDSCTBamChi.TabIndex = 21;
            this.dgvDSCTBamChi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSCTBamChi_CellFormatting);
            this.dgvDSCTBamChi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSCTBamChi_RowPostPaint);
            this.dgvDSCTBamChi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSCTBamChi_KeyDown);
            // 
            // MaCTBC
            // 
            this.MaCTBC.DataPropertyName = "MaCTBC";
            this.MaCTBC.HeaderText = "MaCTBC";
            this.MaCTBC.Name = "MaCTBC";
            this.MaCTBC.Visible = false;
            // 
            // ToXuLy
            // 
            this.ToXuLy.DataPropertyName = "ToXuLy";
            this.ToXuLy.HeaderText = "TXL";
            this.ToXuLy.Name = "ToXuLy";
            this.ToXuLy.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ToXuLy.Width = 50;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            this.MaDon.Width = 70;
            // 
            // TenLD
            // 
            this.TenLD.DataPropertyName = "TenLD";
            this.TenLD.HeaderText = "Tên Loại Đơn";
            this.TenLD.Name = "TenLD";
            this.TenLD.Width = 130;
            // 
            // NgayBC
            // 
            this.NgayBC.DataPropertyName = "NgayBC";
            this.NgayBC.HeaderText = "Ngày BC";
            this.NgayBC.Name = "NgayBC";
            this.NgayBC.ReadOnly = true;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HopDong
            // 
            this.HopDong.DataPropertyName = "HopDong";
            this.HopDong.HeaderText = "Hợp Đồng";
            this.HopDong.Name = "HopDong";
            this.HopDong.Visible = false;
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
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hiệu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Width = 50;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Cỡ";
            this.Co.Name = "Co";
            this.Co.Width = 50;
            // 
            // ChiSo
            // 
            this.ChiSo.DataPropertyName = "ChiSo";
            this.ChiSo.HeaderText = "Chỉ Số";
            this.ChiSo.Name = "ChiSo";
            this.ChiSo.Width = 50;
            // 
            // TrangThaiBC
            // 
            this.TrangThaiBC.DataPropertyName = "TrangThaiBC";
            this.TrangThaiBC.HeaderText = "Trạng Thái";
            this.TrangThaiBC.Name = "TrangThaiBC";
            // 
            // VienChi
            // 
            this.VienChi.DataPropertyName = "VienChi";
            this.VienChi.HeaderText = "Viên Chì";
            this.VienChi.Name = "VienChi";
            this.VienChi.Width = 50;
            // 
            // DayChi
            // 
            this.DayChi.DataPropertyName = "DayChi";
            this.DayChi.HeaderText = "Dây Chì";
            this.DayChi.Name = "DayChi";
            this.DayChi.Width = 50;
            // 
            // MaSoBC
            // 
            this.MaSoBC.DataPropertyName = "MaSoBC";
            this.MaSoBC.HeaderText = "Mã Số BC";
            this.MaSoBC.Name = "MaSoBC";
            this.MaSoBC.Visible = false;
            this.MaSoBC.Width = 50;
            // 
            // TheoYeuCau
            // 
            this.TheoYeuCau.DataPropertyName = "TheoYeuCau";
            this.TheoYeuCau.HeaderText = "Theo Yêu Cầu";
            this.TheoYeuCau.Name = "TheoYeuCau";
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Thực Hiện";
            this.CreateBy.Name = "CreateBy";
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(84, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 22);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(84, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 22);
            this.dateDen.TabIndex = 14;
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(503, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(181, 60);
            this.panel_KhoangThoiGian.TabIndex = 23;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(771, 15);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 25);
            this.btnIn.TabIndex = 22;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tìm Theo:";
            // 
            // cmbTimTheo
            // 
            this.cmbTimTheo.FormattingEnabled = true;
            this.cmbTimTheo.Items.AddRange(new object[] {
            "",
            "Mã Đơn",
            "Danh Bộ",
            "Ngày"});
            this.cmbTimTheo.Location = new System.Drawing.Point(331, 15);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 24);
            this.cmbTimTheo.TabIndex = 15;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(511, 13);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDungTimKiem.TabIndex = 17;
            this.txtNoiDungTimKiem.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(437, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nội Dung:";
            // 
            // btnInQuetToanVatTu
            // 
            this.btnInQuetToanVatTu.Location = new System.Drawing.Point(877, 15);
            this.btnInQuetToanVatTu.Name = "btnInQuetToanVatTu";
            this.btnInQuetToanVatTu.Size = new System.Drawing.Size(100, 25);
            this.btnInQuetToanVatTu.TabIndex = 24;
            this.btnInQuetToanVatTu.Text = "In Quyết Toán";
            this.btnInQuetToanVatTu.UseVisualStyleBackColor = true;
            this.btnInQuetToanVatTu.Click += new System.EventHandler(this.btnInQuetToanVatTu_Click);
            // 
            // chkInBamChiThan_BBDCMS
            // 
            this.chkInBamChiThan_BBDCMS.AutoSize = true;
            this.chkInBamChiThan_BBDCMS.Location = new System.Drawing.Point(1248, 38);
            this.chkInBamChiThan_BBDCMS.Name = "chkInBamChiThan_BBDCMS";
            this.chkInBamChiThan_BBDCMS.Size = new System.Drawing.Size(198, 20);
            this.chkInBamChiThan_BBDCMS.TabIndex = 25;
            this.chkInBamChiThan_BBDCMS.Text = "In Bấm Chì Thân && BB ĐCMS";
            this.chkInBamChiThan_BBDCMS.UseVisualStyleBackColor = true;
            this.chkInBamChiThan_BBDCMS.Visible = false;
            // 
            // chkLoaiDon
            // 
            this.chkLoaiDon.AutoSize = true;
            this.chkLoaiDon.Location = new System.Drawing.Point(1248, 12);
            this.chkLoaiDon.Name = "chkLoaiDon";
            this.chkLoaiDon.Size = new System.Drawing.Size(115, 20);
            this.chkLoaiDon.TabIndex = 26;
            this.chkLoaiDon.Text = "Theo Loại Đơn";
            this.chkLoaiDon.UseVisualStyleBackColor = true;
            this.chkLoaiDon.Visible = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(690, 15);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 27;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // frmDSBamChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1460, 658);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.chkLoaiDon);
            this.Controls.Add(this.chkInBamChiThan_BBDCMS);
            this.Controls.Add(this.btnInQuetToanVatTu);
            this.Controls.Add(this.dgvDSCTBamChi);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDSBamChi";
            this.Text = "Danh Sách Bấm Chì";
            this.Load += new System.EventHandler(this.frmDSBamChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSCTBamChi)).EndInit();
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSCTBamChi;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInQuetToanVatTu;
        private System.Windows.Forms.CheckBox chkInBamChiThan_BBDCMS;
        private System.Windows.Forms.CheckBox chkLoaiDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTBC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThaiBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn VienChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSoBC;
        private System.Windows.Forms.DataGridViewTextBoxColumn TheoYeuCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.Button btnXem;
    }
}