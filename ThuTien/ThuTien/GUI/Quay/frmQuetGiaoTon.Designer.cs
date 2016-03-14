namespace ThuTien.GUI.Quay
{
    partial class frmQuetGiaoTon
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
            this.lbNhanVien = new System.Windows.Forms.Label();
            this.btnCopyToClipboard = new System.Windows.Forms.Button();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstHD = new System.Windows.Forms.ListView();
            this.btnInDSPhanTo = new System.Windows.Forms.Button();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.In_CQ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaQT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.In_TG = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaQT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HopDong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInPhieuBao = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateLap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInDS = new System.Windows.Forms.Button();
            this.tabCoQuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 94;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // lbNhanVien
            // 
            this.lbNhanVien.AutoSize = true;
            this.lbNhanVien.Location = new System.Drawing.Point(335, 15);
            this.lbNhanVien.Name = "lbNhanVien";
            this.lbNhanVien.Size = new System.Drawing.Size(60, 13);
            this.lbNhanVien.TabIndex = 111;
            this.lbNhanVien.Text = "Nhân Viên:";
            // 
            // btnCopyToClipboard
            // 
            this.btnCopyToClipboard.Location = new System.Drawing.Point(30, 281);
            this.btnCopyToClipboard.Name = "btnCopyToClipboard";
            this.btnCopyToClipboard.Size = new System.Drawing.Size(110, 23);
            this.btnCopyToClipboard.TabIndex = 110;
            this.btnCopyToClipboard.Text = "Copy to Clipboard";
            this.btnCopyToClipboard.UseVisualStyleBackColor = true;
            this.btnCopyToClipboard.Click += new System.EventHandler(this.btnCopyToClipboard_Click);
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(401, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 112;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Danh Sách Hóa Đơn";
            this.columnHeader1.Width = 120;
            // 
            // lstHD
            // 
            this.lstHD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(125, 173);
            this.lstHD.TabIndex = 107;
            this.lstHD.UseCompatibleStateImageBehavior = false;
            this.lstHD.View = System.Windows.Forms.View.Details;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // btnInDSPhanTo
            // 
            this.btnInDSPhanTo.Location = new System.Drawing.Point(856, 10);
            this.btnInDSPhanTo.Name = "btnInDSPhanTo";
            this.btnInDSPhanTo.Size = new System.Drawing.Size(90, 23);
            this.btnInDSPhanTo.TabIndex = 106;
            this.btnInDSPhanTo.Text = "In DS Phân Tổ";
            this.btnInDSPhanTo.UseVisualStyleBackColor = true;
            this.btnInDSPhanTo.Click += new System.EventHandler(this.btnInDSPhanTo_Click);
            // 
            // txtTongHD_CQ
            // 
            this.txtTongHD_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_CQ.Location = new System.Drawing.Point(6, 541);
            this.txtTongHD_CQ.Name = "txtTongHD_CQ";
            this.txtTongHD_CQ.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_CQ.TabIndex = 15;
            this.txtTongHD_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 102;
            this.label7.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(90, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 101;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(661, 564);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(521, 541);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 14;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_CQ,
            this.MaQT_CQ,
            this.SoHoaDon_CQ,
            this.Ky_CQ,
            this.MLT_CQ,
            this.SoPhatHanh_CQ,
            this.DanhBo_CQ,
            this.HoTen_CQ,
            this.DiaChi_CQ,
            this.TongCong_CQ,
            this.HopDong_CQ,
            this.GiaBieu_CQ,
            this.HanhThu_CQ,
            this.To_CQ});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHDCoQuan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(647, 535);
            this.dgvHDCoQuan.TabIndex = 12;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // In_CQ
            // 
            this.In_CQ.DataPropertyName = "In";
            this.In_CQ.HeaderText = "In";
            this.In_CQ.Name = "In_CQ";
            this.In_CQ.Width = 30;
            // 
            // MaQT_CQ
            // 
            this.MaQT_CQ.DataPropertyName = "MaQT";
            this.MaQT_CQ.HeaderText = "MaQT";
            this.MaQT_CQ.Name = "MaQT_CQ";
            this.MaQT_CQ.Visible = false;
            // 
            // SoHoaDon_CQ
            // 
            this.SoHoaDon_CQ.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CQ.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon_CQ.Name = "SoHoaDon_CQ";
            // 
            // Ky_CQ
            // 
            this.Ky_CQ.DataPropertyName = "Ky";
            this.Ky_CQ.HeaderText = "Kỳ";
            this.Ky_CQ.Name = "Ky_CQ";
            this.Ky_CQ.Width = 50;
            // 
            // MLT_CQ
            // 
            this.MLT_CQ.DataPropertyName = "MLT";
            this.MLT_CQ.HeaderText = "MLT";
            this.MLT_CQ.Name = "MLT_CQ";
            // 
            // SoPhatHanh_CQ
            // 
            this.SoPhatHanh_CQ.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_CQ.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_CQ.Name = "SoPhatHanh_CQ";
            // 
            // DanhBo_CQ
            // 
            this.DanhBo_CQ.DataPropertyName = "DanhBo";
            this.DanhBo_CQ.HeaderText = "Danh Bộ";
            this.DanhBo_CQ.Name = "DanhBo_CQ";
            // 
            // HoTen_CQ
            // 
            this.HoTen_CQ.DataPropertyName = "HoTen";
            this.HoTen_CQ.HeaderText = "HoTen";
            this.HoTen_CQ.Name = "HoTen_CQ";
            this.HoTen_CQ.Visible = false;
            // 
            // DiaChi_CQ
            // 
            this.DiaChi_CQ.DataPropertyName = "DiaChi";
            this.DiaChi_CQ.HeaderText = "DiaChi";
            this.DiaChi_CQ.Name = "DiaChi_CQ";
            this.DiaChi_CQ.Visible = false;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            // 
            // HopDong_CQ
            // 
            this.HopDong_CQ.DataPropertyName = "HopDong";
            this.HopDong_CQ.HeaderText = "HopDong";
            this.HopDong_CQ.Name = "HopDong_CQ";
            this.HopDong_CQ.Visible = false;
            // 
            // GiaBieu_CQ
            // 
            this.GiaBieu_CQ.DataPropertyName = "GiaBieu";
            this.GiaBieu_CQ.HeaderText = "GiaBieu";
            this.GiaBieu_CQ.Name = "GiaBieu_CQ";
            this.GiaBieu_CQ.Visible = false;
            // 
            // HanhThu_CQ
            // 
            this.HanhThu_CQ.DataPropertyName = "HanhThu";
            this.HanhThu_CQ.HeaderText = "HanhThu";
            this.HanhThu_CQ.Name = "HanhThu_CQ";
            this.HanhThu_CQ.Visible = false;
            // 
            // To_CQ
            // 
            this.To_CQ.DataPropertyName = "To";
            this.To_CQ.HeaderText = "To";
            this.To_CQ.Name = "To_CQ";
            this.To_CQ.Visible = false;
            // 
            // txtTongCong_TG
            // 
            this.txtTongCong_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_TG.Location = new System.Drawing.Point(521, 541);
            this.txtTongCong_TG.Name = "txtTongCong_TG";
            this.txtTongCong_TG.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_TG.TabIndex = 12;
            this.txtTongCong_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(156, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 98;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(156, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 97;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(156, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 96;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(15, 25);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 95;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_TG,
            this.MaQT_TG,
            this.SoHoaDon_TG,
            this.Ky_TG,
            this.MLT_TG,
            this.SoPhatHanh_TG,
            this.DanhBo_TG,
            this.HoTen_TG,
            this.DiaChi_TG,
            this.HopDong_TG,
            this.TongCong_TG,
            this.GiaBieu_TG,
            this.HanhThu_TG,
            this.To_TG});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHDTuGia.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvHDTuGia.Size = new System.Drawing.Size(647, 535);
            this.dgvHDTuGia.TabIndex = 11;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // In_TG
            // 
            this.In_TG.DataPropertyName = "In";
            this.In_TG.HeaderText = "In";
            this.In_TG.Name = "In_TG";
            this.In_TG.Width = 30;
            // 
            // MaQT_TG
            // 
            this.MaQT_TG.DataPropertyName = "MaQT";
            this.MaQT_TG.HeaderText = "MaQT";
            this.MaQT_TG.Name = "MaQT_TG";
            this.MaQT_TG.Visible = false;
            // 
            // SoHoaDon_TG
            // 
            this.SoHoaDon_TG.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TG.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon_TG.Name = "SoHoaDon_TG";
            // 
            // Ky_TG
            // 
            this.Ky_TG.DataPropertyName = "Ky";
            this.Ky_TG.HeaderText = "Kỳ";
            this.Ky_TG.Name = "Ky_TG";
            this.Ky_TG.Width = 50;
            // 
            // MLT_TG
            // 
            this.MLT_TG.DataPropertyName = "MLT";
            this.MLT_TG.HeaderText = "MLT";
            this.MLT_TG.Name = "MLT_TG";
            // 
            // SoPhatHanh_TG
            // 
            this.SoPhatHanh_TG.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_TG.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_TG.Name = "SoPhatHanh_TG";
            // 
            // DanhBo_TG
            // 
            this.DanhBo_TG.DataPropertyName = "DanhBo";
            this.DanhBo_TG.HeaderText = "Danh Bộ";
            this.DanhBo_TG.Name = "DanhBo_TG";
            // 
            // HoTen_TG
            // 
            this.HoTen_TG.DataPropertyName = "HoTen";
            this.HoTen_TG.HeaderText = "HoTen";
            this.HoTen_TG.Name = "HoTen_TG";
            this.HoTen_TG.Visible = false;
            // 
            // DiaChi_TG
            // 
            this.DiaChi_TG.DataPropertyName = "DiaChi";
            this.DiaChi_TG.HeaderText = "DiaChi";
            this.DiaChi_TG.Name = "DiaChi_TG";
            this.DiaChi_TG.Visible = false;
            // 
            // HopDong_TG
            // 
            this.HopDong_TG.DataPropertyName = "HopDong";
            this.HopDong_TG.HeaderText = "HopDong";
            this.HopDong_TG.Name = "HopDong_TG";
            this.HopDong_TG.Visible = false;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            // 
            // GiaBieu_TG
            // 
            this.GiaBieu_TG.DataPropertyName = "GiaBieu";
            this.GiaBieu_TG.HeaderText = "GiaBieu";
            this.GiaBieu_TG.Name = "GiaBieu_TG";
            this.GiaBieu_TG.Visible = false;
            // 
            // HanhThu_TG
            // 
            this.HanhThu_TG.DataPropertyName = "HanhThu";
            this.HanhThu_TG.HeaderText = "HanhThu";
            this.HanhThu_TG.Name = "HanhThu_TG";
            this.HanhThu_TG.Visible = false;
            // 
            // To_TG
            // 
            this.To_TG.DataPropertyName = "To";
            this.To_TG.HeaderText = "To";
            this.To_TG.Name = "To_TG";
            this.To_TG.Visible = false;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(247, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(669, 590);
            this.tabControl.TabIndex = 104;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(661, 564);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(6, 541);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_TG.TabIndex = 13;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(121, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 103;
            this.label6.Text = "(Enter)";
            // 
            // btnInPhieuBao
            // 
            this.btnInPhieuBao.Location = new System.Drawing.Point(769, 10);
            this.btnInPhieuBao.Name = "btnInPhieuBao";
            this.btnInPhieuBao.Size = new System.Drawing.Size(81, 23);
            this.btnInPhieuBao.TabIndex = 100;
            this.btnInPhieuBao.Text = "In Phiếu Báo";
            this.btnInPhieuBao.UseVisualStyleBackColor = true;
            this.btnInPhieuBao.Click += new System.EventHandler(this.btnInPhieuBao_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(688, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 99;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(279, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 114;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 113;
            this.label2.Text = "Tổ:";
            // 
            // dateLap
            // 
            this.dateLap.CustomFormat = "dd/MM/yyyy";
            this.dateLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLap.Location = new System.Drawing.Point(582, 12);
            this.dateLap.Name = "dateLap";
            this.dateLap.Size = new System.Drawing.Size(100, 20);
            this.dateLap.TabIndex = 116;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "Ngày Lập:";
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(952, 10);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 23);
            this.btnInDS.TabIndex = 117;
            this.btnInDS.Text = "In DS";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // frmQuetGiaoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 652);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.dateLap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbNhanVien);
            this.Controls.Add(this.btnCopyToClipboard);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.btnInDSPhanTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnInPhieuBao);
            this.Controls.Add(this.btnXem);
            this.Name = "frmQuetGiaoTon";
            this.Text = "Quét Giao Tồn";
            this.Load += new System.EventHandler(this.frmQuetGiaoTon_Load);
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbNhanVien;
        private System.Windows.Forms.Button btnCopyToClipboard;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView lstHD;
        private System.Windows.Forms.Button btnInDSPhanTo;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.TextBox txtTongCong_CQ;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInPhieuBao;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_CQ;
        private System.Windows.Forms.DataGridViewCheckBoxColumn In_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HopDong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_TG;
        private System.Windows.Forms.DateTimePicker dateLap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInDS;
    }
}