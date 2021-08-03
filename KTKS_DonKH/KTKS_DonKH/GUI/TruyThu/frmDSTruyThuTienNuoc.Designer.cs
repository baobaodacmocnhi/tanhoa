namespace KTKS_DonKH.GUI.TruyThu
{
    partial class frmDSTruyThuTienNuoc
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
            this.txtNoiDungTimKiem2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_KhoangThoiGian = new System.Windows.Forms.Panel();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTimTheo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoiDungTimKiem = new System.Windows.Forms.TextBox();
            this.dgvDSTruyThuTienNuoc = new System.Windows.Forms.DataGridView();
            this.In = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCongVan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tongm3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongm3 = new System.Windows.Forms.TextBox();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnInNhan = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.radTruyThu = new System.Windows.Forms.RadioButton();
            this.radThuMoi = new System.Windows.Forms.RadioButton();
            this.panel_KhoangThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTruyThuTienNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDungTimKiem2
            // 
            this.txtNoiDungTimKiem2.Location = new System.Drawing.Point(514, 37);
            this.txtNoiDungTimKiem2.Name = "txtNoiDungTimKiem2";
            this.txtNoiDungTimKiem2.Size = new System.Drawing.Size(100, 26);
            this.txtNoiDungTimKiem2.TabIndex = 23;
            this.txtNoiDungTimKiem2.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Tìm Theo:";
            // 
            // panel_KhoangThoiGian
            // 
            this.panel_KhoangThoiGian.Controls.Add(this.dateTu);
            this.panel_KhoangThoiGian.Controls.Add(this.dateDen);
            this.panel_KhoangThoiGian.Controls.Add(this.label3);
            this.panel_KhoangThoiGian.Controls.Add(this.label4);
            this.panel_KhoangThoiGian.Location = new System.Drawing.Point(506, 0);
            this.panel_KhoangThoiGian.Name = "panel_KhoangThoiGian";
            this.panel_KhoangThoiGian.Size = new System.Drawing.Size(180, 60);
            this.panel_KhoangThoiGian.TabIndex = 24;
            this.panel_KhoangThoiGian.Visible = false;
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(83, 4);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(90, 26);
            this.dateTu.TabIndex = 13;
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(83, 33);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(90, 26);
            this.dateDen.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Từ Ngày:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
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
            "Số Tiền"});
            this.cmbTimTheo.Location = new System.Drawing.Point(334, 11);
            this.cmbTimTheo.Name = "cmbTimTheo";
            this.cmbTimTheo.Size = new System.Drawing.Size(100, 28);
            this.cmbTimTheo.TabIndex = 19;
            this.cmbTimTheo.SelectedIndexChanged += new System.EventHandler(this.cmbTimTheo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(440, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Nội Dung:";
            // 
            // txtNoiDungTimKiem
            // 
            this.txtNoiDungTimKiem.Location = new System.Drawing.Point(514, 10);
            this.txtNoiDungTimKiem.Name = "txtNoiDungTimKiem";
            this.txtNoiDungTimKiem.Size = new System.Drawing.Size(100, 26);
            this.txtNoiDungTimKiem.TabIndex = 21;
            this.txtNoiDungTimKiem.Visible = false;
            this.txtNoiDungTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoiDungTimKiem_KeyPress);
            // 
            // dgvDSTruyThuTienNuoc
            // 
            this.dgvDSTruyThuTienNuoc.AllowUserToAddRows = false;
            this.dgvDSTruyThuTienNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSTruyThuTienNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSTruyThuTienNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSTruyThuTienNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In,
            this.MaDon,
            this.IDCT,
            this.CreateDate,
            this.SoCongVan,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NoiDung,
            this.DienThoai,
            this.Tongm3,
            this.TongTien});
            this.dgvDSTruyThuTienNuoc.Location = new System.Drawing.Point(12, 66);
            this.dgvDSTruyThuTienNuoc.MultiSelect = false;
            this.dgvDSTruyThuTienNuoc.Name = "dgvDSTruyThuTienNuoc";
            this.dgvDSTruyThuTienNuoc.RowHeadersWidth = 60;
            this.dgvDSTruyThuTienNuoc.Size = new System.Drawing.Size(1174, 535);
            this.dgvDSTruyThuTienNuoc.TabIndex = 25;
            this.dgvDSTruyThuTienNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSTruyThuTienNuoc_CellFormatting);
            this.dgvDSTruyThuTienNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSTruyThuTienNuoc_RowPostPaint);
            this.dgvDSTruyThuTienNuoc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvDSTruyThuTienNuoc_KeyDown);
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
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "Số Phiếu";
            this.IDCT.Name = "IDCT";
            this.IDCT.Width = 70;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // SoCongVan
            // 
            this.SoCongVan.DataPropertyName = "SoCongVan";
            this.SoCongVan.HeaderText = "SoCongVan";
            this.SoCongVan.Name = "SoCongVan";
            this.SoCongVan.Visible = false;
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
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            // 
            // DienThoai
            // 
            this.DienThoai.DataPropertyName = "DienThoai";
            this.DienThoai.HeaderText = "Điện Thoại";
            this.DienThoai.Name = "DienThoai";
            // 
            // Tongm3
            // 
            this.Tongm3.DataPropertyName = "Tongm3BinhQuan";
            this.Tongm3.HeaderText = "Tổng m3";
            this.Tongm3.Name = "Tongm3";
            this.Tongm3.Width = 60;
            // 
            // TongTien
            // 
            this.TongTien.DataPropertyName = "TongTien";
            this.TongTien.HeaderText = "Tổng Tiền";
            this.TongTien.Name = "TongTien";
            this.TongTien.Width = 80;
            // 
            // txtTongm3
            // 
            this.txtTongm3.Location = new System.Drawing.Point(968, 601);
            this.txtTongm3.Name = "txtTongm3";
            this.txtTongm3.Size = new System.Drawing.Size(100, 26);
            this.txtTongm3.TabIndex = 26;
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(1068, 601);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(100, 26);
            this.txtTongTien.TabIndex = 27;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(692, 14);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 25);
            this.btnXem.TabIndex = 28;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(773, 14);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 29;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnInNhan
            // 
            this.btnInNhan.Location = new System.Drawing.Point(854, 14);
            this.btnInNhan.Name = "btnInNhan";
            this.btnInNhan.Size = new System.Drawing.Size(75, 25);
            this.btnInNhan.TabIndex = 30;
            this.btnInNhan.Text = "In Nhãn";
            this.btnInNhan.UseVisualStyleBackColor = true;
            this.btnInNhan.Click += new System.EventHandler(this.btnInNhan_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.ForeColor = System.Drawing.Color.Red;
            this.chkSelectAll.Location = new System.Drawing.Point(72, 40);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(99, 24);
            this.chkSelectAll.TabIndex = 31;
            this.chkSelectAll.Text = "In Tất Cả";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // radTruyThu
            // 
            this.radTruyThu.AutoSize = true;
            this.radTruyThu.Checked = true;
            this.radTruyThu.Location = new System.Drawing.Point(12, 7);
            this.radTruyThu.Name = "radTruyThu";
            this.radTruyThu.Size = new System.Drawing.Size(96, 24);
            this.radTruyThu.TabIndex = 32;
            this.radTruyThu.TabStop = true;
            this.radTruyThu.Text = "Truy Thu";
            this.radTruyThu.UseVisualStyleBackColor = true;
            // 
            // radThuMoi
            // 
            this.radThuMoi.AutoSize = true;
            this.radThuMoi.Location = new System.Drawing.Point(97, 7);
            this.radThuMoi.Name = "radThuMoi";
            this.radThuMoi.Size = new System.Drawing.Size(90, 24);
            this.radThuMoi.TabIndex = 33;
            this.radThuMoi.Text = "Thư Mời";
            this.radThuMoi.UseVisualStyleBackColor = true;
            // 
            // frmDSTruyThuTienNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1202, 644);
            this.Controls.Add(this.radThuMoi);
            this.Controls.Add(this.radTruyThu);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.btnInNhan);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.txtTongm3);
            this.Controls.Add(this.dgvDSTruyThuTienNuoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTimTheo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNoiDungTimKiem);
            this.Controls.Add(this.panel_KhoangThoiGian);
            this.Controls.Add(this.txtNoiDungTimKiem2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDSTruyThuTienNuoc";
            this.Text = "Danh Sách Truy Thu Tiền Nước";
            this.Load += new System.EventHandler(this.frmQLTruyThuTienNuoc_Load);
            this.panel_KhoangThoiGian.ResumeLayout(false);
            this.panel_KhoangThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSTruyThuTienNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNoiDungTimKiem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_KhoangThoiGian;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTimTheo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoiDungTimKiem;
        private System.Windows.Forms.DataGridView dgvDSTruyThuTienNuoc;
        private System.Windows.Forms.TextBox txtTongm3;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnInNhan;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCongVan;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn DienThoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tongm3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTien;
        private System.Windows.Forms.RadioButton radTruyThu;
        private System.Windows.Forms.RadioButton radThuMoi;
    }
}