namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmPhiMoNuocChuyenKhoan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvTienDu = new System.Windows.Forms.DataGridView();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvPhiMoNuoc = new System.Windows.Forms.DataGridView();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.chkChotTatCa = new System.Windows.Forms.CheckBox();
            this.radPhiMoNuocChung = new System.Windows.Forms.RadioButton();
            this.radPhiMoNuocRieng = new System.Windows.Forms.RadioButton();
            this.MaPMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chot_PMN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayChot_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayBK_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiMoNuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK_PMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoThan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSoDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaKQDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Danh Sách Danh Bộ Đóng Phí Mở Nước";
            // 
            // dgvTienDu
            // 
            this.dgvTienDu.AllowUserToAddRows = false;
            this.dgvTienDu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTienDu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTienDu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DanhBo,
            this.Phi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTienDu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTienDu.Location = new System.Drawing.Point(12, 51);
            this.dgvTienDu.Name = "dgvTienDu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTienDu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTienDu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTienDu.Size = new System.Drawing.Size(237, 570);
            this.dgvTienDu.TabIndex = 6;
            this.dgvTienDu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTienDu_CellContentClick);
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.HeaderText = "Phí";
            this.Phi.Name = "Phi";
            this.Phi.Width = 70;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(725, 22);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvPhiMoNuoc
            // 
            this.dgvPhiMoNuoc.AllowUserToAddRows = false;
            this.dgvPhiMoNuoc.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPhiMoNuoc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhiMoNuoc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPMN,
            this.CreateDate,
            this.DanhBo_PMN,
            this.HoTen_PMN,
            this.DiaChi_PMN,
            this.GhiChu_PMN,
            this.Chot_PMN,
            this.NgayChot_PMN,
            this.NgayBK_PMN,
            this.SoTien_PMN,
            this.TongCong_PMN,
            this.PhiMoNuoc,
            this.SoTK_PMN,
            this.CoDHN,
            this.Co,
            this.Hieu,
            this.SoThan,
            this.ChiSoDN,
            this.NgayDN,
            this.CreateBy,
            this.LyDo,
            this.MaKQDN});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPhiMoNuoc.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPhiMoNuoc.Location = new System.Drawing.Point(255, 51);
            this.dgvPhiMoNuoc.Name = "dgvPhiMoNuoc";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhiMoNuoc.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvPhiMoNuoc.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPhiMoNuoc.Size = new System.Drawing.Size(952, 570);
            this.dgvPhiMoNuoc.TabIndex = 8;
            this.dgvPhiMoNuoc.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhiMoNuoc_CellFormatting);
            this.dgvPhiMoNuoc.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvPhiMoNuoc_CellValidating);
            this.dgvPhiMoNuoc.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhiMoNuoc_RowPostPaint);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(449, 24);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(619, 24);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(555, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Đến Ngày:";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(806, 22);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 32;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(887, 22);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(968, 22);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 34;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // chkChotTatCa
            // 
            this.chkChotTatCa.AutoSize = true;
            this.chkChotTatCa.Location = new System.Drawing.Point(1127, 28);
            this.chkChotTatCa.Name = "chkChotTatCa";
            this.chkChotTatCa.Size = new System.Drawing.Size(83, 17);
            this.chkChotTatCa.TabIndex = 35;
            this.chkChotTatCa.Text = "Chốt Tất Cả";
            this.chkChotTatCa.UseVisualStyleBackColor = true;
            this.chkChotTatCa.CheckedChanged += new System.EventHandler(this.chkChotTatCa_CheckedChanged);
            // 
            // radPhiMoNuocChung
            // 
            this.radPhiMoNuocChung.AutoSize = true;
            this.radPhiMoNuocChung.Checked = true;
            this.radPhiMoNuocChung.Location = new System.Drawing.Point(255, 2);
            this.radPhiMoNuocChung.Name = "radPhiMoNuocChung";
            this.radPhiMoNuocChung.Size = new System.Drawing.Size(123, 17);
            this.radPhiMoNuocChung.TabIndex = 36;
            this.radPhiMoNuocChung.TabStop = true;
            this.radPhiMoNuocChung.Text = "Phí Mở Nước Chung";
            this.radPhiMoNuocChung.UseVisualStyleBackColor = true;
            // 
            // radPhiMoNuocRieng
            // 
            this.radPhiMoNuocRieng.AutoSize = true;
            this.radPhiMoNuocRieng.Location = new System.Drawing.Point(255, 25);
            this.radPhiMoNuocRieng.Name = "radPhiMoNuocRieng";
            this.radPhiMoNuocRieng.Size = new System.Drawing.Size(120, 17);
            this.radPhiMoNuocRieng.TabIndex = 37;
            this.radPhiMoNuocRieng.Text = "Phí Mở Nước Riêng";
            this.radPhiMoNuocRieng.UseVisualStyleBackColor = true;
            // 
            // MaPMN
            // 
            this.MaPMN.DataPropertyName = "MaPMN";
            this.MaPMN.HeaderText = "Số Phiếu";
            this.MaPMN.Name = "MaPMN";
            this.MaPMN.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // DanhBo_PMN
            // 
            this.DanhBo_PMN.DataPropertyName = "DanhBo";
            this.DanhBo_PMN.HeaderText = "Danh Bộ";
            this.DanhBo_PMN.Name = "DanhBo_PMN";
            // 
            // HoTen_PMN
            // 
            this.HoTen_PMN.DataPropertyName = "HoTen";
            this.HoTen_PMN.HeaderText = "Khách Hàng";
            this.HoTen_PMN.Name = "HoTen_PMN";
            this.HoTen_PMN.Width = 150;
            // 
            // DiaChi_PMN
            // 
            this.DiaChi_PMN.DataPropertyName = "DiaChi";
            this.DiaChi_PMN.HeaderText = "Địa Chỉ";
            this.DiaChi_PMN.Name = "DiaChi_PMN";
            this.DiaChi_PMN.Width = 200;
            // 
            // GhiChu_PMN
            // 
            this.GhiChu_PMN.DataPropertyName = "GhiChu";
            this.GhiChu_PMN.HeaderText = "Ghi Chú";
            this.GhiChu_PMN.Name = "GhiChu_PMN";
            this.GhiChu_PMN.Width = 150;
            // 
            // Chot_PMN
            // 
            this.Chot_PMN.DataPropertyName = "Chot";
            this.Chot_PMN.HeaderText = "Chốt";
            this.Chot_PMN.Name = "Chot_PMN";
            this.Chot_PMN.Width = 50;
            // 
            // NgayChot_PMN
            // 
            this.NgayChot_PMN.DataPropertyName = "NgayChot";
            this.NgayChot_PMN.HeaderText = "Ngày Chốt";
            this.NgayChot_PMN.Name = "NgayChot_PMN";
            this.NgayChot_PMN.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NgayChot_PMN.Width = 80;
            // 
            // NgayBK_PMN
            // 
            this.NgayBK_PMN.DataPropertyName = "NgayBK";
            this.NgayBK_PMN.HeaderText = "NgayBK";
            this.NgayBK_PMN.Name = "NgayBK_PMN";
            this.NgayBK_PMN.Visible = false;
            // 
            // SoTien_PMN
            // 
            this.SoTien_PMN.DataPropertyName = "SoTien";
            this.SoTien_PMN.HeaderText = "SoTien";
            this.SoTien_PMN.Name = "SoTien_PMN";
            this.SoTien_PMN.Visible = false;
            // 
            // TongCong_PMN
            // 
            this.TongCong_PMN.DataPropertyName = "TongCong";
            this.TongCong_PMN.HeaderText = "TongCong";
            this.TongCong_PMN.Name = "TongCong_PMN";
            this.TongCong_PMN.Visible = false;
            // 
            // PhiMoNuoc
            // 
            this.PhiMoNuoc.DataPropertyName = "PhiMoNuoc";
            this.PhiMoNuoc.HeaderText = "PhiMoNuoc";
            this.PhiMoNuoc.Name = "PhiMoNuoc";
            this.PhiMoNuoc.Visible = false;
            // 
            // SoTK_PMN
            // 
            this.SoTK_PMN.DataPropertyName = "SoTK";
            this.SoTK_PMN.HeaderText = "SoTK";
            this.SoTK_PMN.Name = "SoTK_PMN";
            this.SoTK_PMN.Visible = false;
            // 
            // CoDHN
            // 
            this.CoDHN.DataPropertyName = "CoDHN";
            this.CoDHN.HeaderText = "CoDHN";
            this.CoDHN.Name = "CoDHN";
            this.CoDHN.Visible = false;
            // 
            // Co
            // 
            this.Co.DataPropertyName = "Co";
            this.Co.HeaderText = "Co";
            this.Co.Name = "Co";
            this.Co.Visible = false;
            // 
            // Hieu
            // 
            this.Hieu.DataPropertyName = "Hieu";
            this.Hieu.HeaderText = "Hieu";
            this.Hieu.Name = "Hieu";
            this.Hieu.Visible = false;
            // 
            // SoThan
            // 
            this.SoThan.DataPropertyName = "SoThan";
            this.SoThan.HeaderText = "SoThan";
            this.SoThan.Name = "SoThan";
            this.SoThan.Visible = false;
            // 
            // ChiSoDN
            // 
            this.ChiSoDN.DataPropertyName = "ChiSoDN";
            this.ChiSoDN.HeaderText = "ChiSo";
            this.ChiSoDN.Name = "ChiSoDN";
            this.ChiSoDN.Visible = false;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "NgayDN";
            this.NgayDN.Name = "NgayDN";
            this.NgayDN.Visible = false;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "CreateBy";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.Visible = false;
            // 
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "LyDo";
            this.LyDo.Name = "LyDo";
            this.LyDo.Visible = false;
            // 
            // MaKQDN
            // 
            this.MaKQDN.DataPropertyName = "MaKQDN";
            this.MaKQDN.HeaderText = "MaKQDN";
            this.MaKQDN.Name = "MaKQDN";
            this.MaKQDN.Visible = false;
            // 
            // frmPhiMoNuocChuyenKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 657);
            this.Controls.Add(this.radPhiMoNuocRieng);
            this.Controls.Add(this.radPhiMoNuocChung);
            this.Controls.Add(this.chkChotTatCa);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvPhiMoNuoc);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvTienDu);
            this.Name = "frmPhiMoNuocChuyenKhoan";
            this.Text = "Phí Mở Nước Chuyển Khoản";
            this.Load += new System.EventHandler(this.frmPhiMoNuocChuyenKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTienDu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhiMoNuoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvTienDu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvPhiMoNuoc;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.CheckBox chkChotTatCa;
        private System.Windows.Forms.RadioButton radPhiMoNuocChung;
        private System.Windows.Forms.RadioButton radPhiMoNuocRieng;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu_PMN;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chot_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayChot_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayBK_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiMoNuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK_PMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoThan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSoDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKQDN;
    }
}