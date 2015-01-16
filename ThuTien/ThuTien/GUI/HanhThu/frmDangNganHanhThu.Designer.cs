namespace ThuTien.GUI.HanhThu
{
    partial class frmDangNganHanhThu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radChuaThu = new System.Windows.Forms.RadioButton();
            this.radDaThu = new System.Windows.Forms.RadioButton();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvTongHD = new System.Windows.Forms.DataGridView();
            this.Dot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongPhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDaThu = new System.Windows.Forms.TabPage();
            this.txtTongCong_DT = new System.Windows.Forms.TextBox();
            this.dgvHDDaThu = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabChuaThu = new System.Windows.Forms.TabPage();
            this.txtTongCong_CT = new System.Windows.Forms.TextBox();
            this.dgvHDChuaThu = new System.Windows.Forms.DataGridView();
            this.SoHoaDon_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHD)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabDaThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDDaThu)).BeginInit();
            this.tabChuaThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDChuaThu)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radChuaThu);
            this.groupBox1.Controls.Add(this.radDaThu);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Loại Quét";
            // 
            // radChuaThu
            // 
            this.radChuaThu.AutoSize = true;
            this.radChuaThu.Location = new System.Drawing.Point(6, 42);
            this.radChuaThu.Name = "radChuaThu";
            this.radChuaThu.Size = new System.Drawing.Size(72, 17);
            this.radChuaThu.TabIndex = 1;
            this.radChuaThu.TabStop = true;
            this.radChuaThu.Text = "Chưa Thu";
            this.radChuaThu.UseVisualStyleBackColor = true;
            // 
            // radDaThu
            // 
            this.radDaThu.AutoSize = true;
            this.radDaThu.Location = new System.Drawing.Point(6, 19);
            this.radDaThu.Name = "radDaThu";
            this.radDaThu.Size = new System.Drawing.Size(61, 17);
            this.radDaThu.TabIndex = 0;
            this.radDaThu.TabStop = true;
            this.radDaThu.Text = "Đã Thu";
            this.radDaThu.UseVisualStyleBackColor = true;
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbDot.Location = new System.Drawing.Point(361, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(50, 21);
            this.cmbDot.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(328, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Đợt:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(417, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(272, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(178, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Năm:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(754, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvTongHD);
            this.groupBox2.Location = new System.Drawing.Point(12, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(739, 93);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tổng Hóa Đơn Được Giao";
            // 
            // dgvTongHD
            // 
            this.dgvTongHD.AllowUserToAddRows = false;
            this.dgvTongHD.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTongHD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTongHD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTongHD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dot,
            this.Loai,
            this.TongHD,
            this.TongTieuThu,
            this.TongGiaBan,
            this.TongThueGTGT,
            this.TongPhiBVMT,
            this.TongCong});
            this.dgvTongHD.Location = new System.Drawing.Point(6, 19);
            this.dgvTongHD.MultiSelect = false;
            this.dgvTongHD.Name = "dgvTongHD";
            this.dgvTongHD.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvTongHD.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTongHD.Size = new System.Drawing.Size(726, 67);
            this.dgvTongHD.TabIndex = 0;
            this.dgvTongHD.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTongHoaDon_CellFormatting);
            // 
            // Dot
            // 
            this.Dot.DataPropertyName = "Dot";
            this.Dot.HeaderText = "Đợt";
            this.Dot.Name = "Dot";
            this.Dot.ReadOnly = true;
            this.Dot.Width = 50;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            this.Loai.Width = 50;
            // 
            // TongHD
            // 
            this.TongHD.DataPropertyName = "TongHD";
            this.TongHD.HeaderText = "Tổng HĐ";
            this.TongHD.Name = "TongHD";
            this.TongHD.ReadOnly = true;
            this.TongHD.Width = 80;
            // 
            // TongTieuThu
            // 
            this.TongTieuThu.DataPropertyName = "TongTieuThu";
            this.TongTieuThu.HeaderText = "Tiêu Thụ";
            this.TongTieuThu.Name = "TongTieuThu";
            this.TongTieuThu.ReadOnly = true;
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            this.TongGiaBan.HeaderText = "Giá Bán";
            this.TongGiaBan.Name = "TongGiaBan";
            this.TongGiaBan.ReadOnly = true;
            // 
            // TongThueGTGT
            // 
            this.TongThueGTGT.DataPropertyName = "TongThueGTGT";
            this.TongThueGTGT.HeaderText = "Thuế GTGT";
            this.TongThueGTGT.Name = "TongThueGTGT";
            this.TongThueGTGT.ReadOnly = true;
            // 
            // TongPhiBVMT
            // 
            this.TongPhiBVMT.DataPropertyName = "TongPhiBVMT";
            this.TongPhiBVMT.HeaderText = "Phí BVMT";
            this.TongPhiBVMT.Name = "TongPhiBVMT";
            this.TongPhiBVMT.ReadOnly = true;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDaThu);
            this.tabControl.Controls.Add(this.tabChuaThu);
            this.tabControl.Location = new System.Drawing.Point(12, 187);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(789, 472);
            this.tabControl.TabIndex = 14;
            // 
            // tabDaThu
            // 
            this.tabDaThu.Controls.Add(this.txtTongCong_DT);
            this.tabDaThu.Controls.Add(this.dgvHDDaThu);
            this.tabDaThu.Location = new System.Drawing.Point(4, 22);
            this.tabDaThu.Name = "tabDaThu";
            this.tabDaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabDaThu.Size = new System.Drawing.Size(781, 446);
            this.tabDaThu.TabIndex = 0;
            this.tabDaThu.Text = "Đã Thu";
            this.tabDaThu.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_DT
            // 
            this.txtTongCong_DT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_DT.Location = new System.Drawing.Point(651, 425);
            this.txtTongCong_DT.Name = "txtTongCong_DT";
            this.txtTongCong_DT.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_DT.TabIndex = 1;
            this.txtTongCong_DT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDDaThu
            // 
            this.dgvHDDaThu.AllowUserToAddRows = false;
            this.dgvHDDaThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDDaThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDDaThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDDaThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.SoHoaDon_DT,
            this.DanhBo_DT,
            this.TieuThu_DT,
            this.GiaBan_DT,
            this.ThueGTGT_DT,
            this.PhiBVMT_DT,
            this.TongCong_DT});
            this.dgvHDDaThu.Location = new System.Drawing.Point(6, 6);
            this.dgvHDDaThu.Name = "dgvHDDaThu";
            this.dgvHDDaThu.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDDaThu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDDaThu.Size = new System.Drawing.Size(768, 419);
            this.dgvHDDaThu.TabIndex = 0;
            this.dgvHDDaThu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHDDaThu_CellContentClick);
            this.dgvHDDaThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDDaThu_CellFormatting);
            this.dgvHDDaThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDDaThu_RowPostPaint);
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "ID_HOADON";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Visible = false;
            // 
            // SoHoaDon_DT
            // 
            this.SoHoaDon_DT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_DT.HeaderText = "Số HĐ";
            this.SoHoaDon_DT.Name = "SoHoaDon_DT";
            this.SoHoaDon_DT.ReadOnly = true;
            // 
            // DanhBo_DT
            // 
            this.DanhBo_DT.DataPropertyName = "DanhBo";
            this.DanhBo_DT.HeaderText = "Danh Bộ";
            this.DanhBo_DT.Name = "DanhBo_DT";
            this.DanhBo_DT.ReadOnly = true;
            // 
            // TieuThu_DT
            // 
            this.TieuThu_DT.DataPropertyName = "TieuThu";
            this.TieuThu_DT.HeaderText = "Tiêu Thụ";
            this.TieuThu_DT.Name = "TieuThu_DT";
            this.TieuThu_DT.ReadOnly = true;
            // 
            // GiaBan_DT
            // 
            this.GiaBan_DT.DataPropertyName = "GiaBan";
            this.GiaBan_DT.HeaderText = "Giá Bán";
            this.GiaBan_DT.Name = "GiaBan_DT";
            this.GiaBan_DT.ReadOnly = true;
            // 
            // ThueGTGT_DT
            // 
            this.ThueGTGT_DT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_DT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_DT.Name = "ThueGTGT_DT";
            this.ThueGTGT_DT.ReadOnly = true;
            // 
            // PhiBVMT_DT
            // 
            this.PhiBVMT_DT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_DT.HeaderText = "Phí BVMT";
            this.PhiBVMT_DT.Name = "PhiBVMT_DT";
            this.PhiBVMT_DT.ReadOnly = true;
            // 
            // TongCong_DT
            // 
            this.TongCong_DT.DataPropertyName = "TongCong";
            this.TongCong_DT.HeaderText = "Tổng Cộng";
            this.TongCong_DT.Name = "TongCong_DT";
            this.TongCong_DT.ReadOnly = true;
            // 
            // tabChuaThu
            // 
            this.tabChuaThu.Controls.Add(this.txtTongCong_CT);
            this.tabChuaThu.Controls.Add(this.dgvHDChuaThu);
            this.tabChuaThu.Location = new System.Drawing.Point(4, 22);
            this.tabChuaThu.Name = "tabChuaThu";
            this.tabChuaThu.Padding = new System.Windows.Forms.Padding(3);
            this.tabChuaThu.Size = new System.Drawing.Size(781, 446);
            this.tabChuaThu.TabIndex = 1;
            this.tabChuaThu.Text = "Chưa Thu";
            this.tabChuaThu.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_CT
            // 
            this.txtTongCong_CT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CT.Location = new System.Drawing.Point(651, 425);
            this.txtTongCong_CT.Name = "txtTongCong_CT";
            this.txtTongCong_CT.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CT.TabIndex = 9;
            this.txtTongCong_CT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDChuaThu
            // 
            this.dgvHDChuaThu.AllowUserToAddRows = false;
            this.dgvHDChuaThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDChuaThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHDChuaThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDChuaThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SoHoaDon_CT,
            this.DanhBo_CT,
            this.TieuThu_CT,
            this.GiaBan_CT,
            this.ThueGTGT_CT,
            this.PhiBVMT_CT,
            this.TongCong_CT});
            this.dgvHDChuaThu.Location = new System.Drawing.Point(6, 6);
            this.dgvHDChuaThu.MultiSelect = false;
            this.dgvHDChuaThu.Name = "dgvHDChuaThu";
            this.dgvHDChuaThu.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDChuaThu.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHDChuaThu.Size = new System.Drawing.Size(768, 419);
            this.dgvHDChuaThu.TabIndex = 8;
            this.dgvHDChuaThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDChuaThu_CellFormatting);
            this.dgvHDChuaThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDChuaThu_RowPostPaint);
            // 
            // SoHoaDon_CT
            // 
            this.SoHoaDon_CT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CT.HeaderText = "Số HĐ";
            this.SoHoaDon_CT.Name = "SoHoaDon_CT";
            this.SoHoaDon_CT.ReadOnly = true;
            // 
            // DanhBo_CT
            // 
            this.DanhBo_CT.DataPropertyName = "DanhBo";
            this.DanhBo_CT.HeaderText = "Danh Bộ";
            this.DanhBo_CT.Name = "DanhBo_CT";
            this.DanhBo_CT.ReadOnly = true;
            // 
            // TieuThu_CT
            // 
            this.TieuThu_CT.DataPropertyName = "TieuThu";
            this.TieuThu_CT.HeaderText = "Tiêu Thụ";
            this.TieuThu_CT.Name = "TieuThu_CT";
            this.TieuThu_CT.ReadOnly = true;
            // 
            // GiaBan_CT
            // 
            this.GiaBan_CT.DataPropertyName = "GiaBan";
            this.GiaBan_CT.HeaderText = "Giá Bán";
            this.GiaBan_CT.Name = "GiaBan_CT";
            this.GiaBan_CT.ReadOnly = true;
            // 
            // ThueGTGT_CT
            // 
            this.ThueGTGT_CT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_CT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_CT.Name = "ThueGTGT_CT";
            this.ThueGTGT_CT.ReadOnly = true;
            // 
            // PhiBVMT_CT
            // 
            this.PhiBVMT_CT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_CT.HeaderText = "Phí BVMT";
            this.PhiBVMT_CT.Name = "PhiBVMT_CT";
            this.PhiBVMT_CT.ReadOnly = true;
            // 
            // TongCong_CT
            // 
            this.TongCong_CT.DataPropertyName = "TongCong";
            this.TongCong_CT.HeaderText = "Tổng Cộng";
            this.TongCong_CT.Name = "TongCong_CT";
            this.TongCong_CT.ReadOnly = true;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(883, 88);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(883, 59);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(883, 30);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(651, 30);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 20);
            this.txtSoHoaDon.TabIndex = 9;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDSHD_KeyPress);
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(757, 30);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 15;
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // frmDangNganHanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 666);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDangNganHanhThu";
            this.Text = "Đăng Ngân Hành Thu";
            this.Load += new System.EventHandler(this.frmDangNganHD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTongHD)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabDaThu.ResumeLayout(false);
            this.tabDaThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDDaThu)).EndInit();
            this.tabChuaThu.ResumeLayout(false);
            this.tabChuaThu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDChuaThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radChuaThu;
        private System.Windows.Forms.RadioButton radDaThu;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvTongHD;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDaThu;
        private System.Windows.Forms.TabPage tabChuaThu;
        private System.Windows.Forms.DataGridView dgvHDDaThu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvHDChuaThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dot;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongPhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.TextBox txtTongCong_DT;
        private System.Windows.Forms.TextBox txtTongCong_CT;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CT;
    }
}