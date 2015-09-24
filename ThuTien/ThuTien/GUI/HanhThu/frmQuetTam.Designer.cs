namespace ThuTien.GUI.HanhThu
{
    partial class frmQuetTam
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
            this.label5 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.MaQT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.MaQT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnInDSDiaChi = new System.Windows.Forms.Button();
            this.btnInDSPhanTo = new System.Windows.Forms.Button();
            this.txtTongCong_TG = new System.Windows.Forms.TextBox();
            this.txtTongHD_TG = new System.Windows.Forms.TextBox();
            this.txtTongHD_CQ = new System.Windows.Forms.TextBox();
            this.txtTongCong_CQ = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            this.tabCoQuan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(15, 76);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 3;
            this.lstHD.SelectedIndexChanged += new System.EventHandler(this.lstHD_SelectedIndexChanged);
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(87, 12);
            this.txtSoHoaDon.Multiline = true;
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 45);
            this.txtSoHoaDon.TabIndex = 1;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 134);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 6;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 105);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 76);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaQT_TG,
            this.SoHoaDon_TG,
            this.Ky_TG,
            this.MLT_TG,
            this.SoPhatHanh_TG,
            this.DanhBo_TG,
            this.HoTen_TG,
            this.DiaChi_TG,
            this.TongCong_TG,
            this.GiaBieu_TG,
            this.HanhThu_TG,
            this.To_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHDTuGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDTuGia.Size = new System.Drawing.Size(615, 535);
            this.dgvHDTuGia.TabIndex = 11;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // MaQT_TG
            // 
            this.MaQT_TG.DataPropertyName = "MaQT";
            this.MaQT_TG.HeaderText = "MaQT";
            this.MaQT_TG.Name = "MaQT_TG";
            this.MaQT_TG.ReadOnly = true;
            this.MaQT_TG.Visible = false;
            // 
            // SoHoaDon_TG
            // 
            this.SoHoaDon_TG.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TG.HeaderText = "Số HĐ";
            this.SoHoaDon_TG.Name = "SoHoaDon_TG";
            this.SoHoaDon_TG.ReadOnly = true;
            // 
            // Ky_TG
            // 
            this.Ky_TG.DataPropertyName = "Ky";
            this.Ky_TG.HeaderText = "Kỳ";
            this.Ky_TG.Name = "Ky_TG";
            this.Ky_TG.ReadOnly = true;
            this.Ky_TG.Width = 50;
            // 
            // MLT_TG
            // 
            this.MLT_TG.DataPropertyName = "MLT";
            this.MLT_TG.HeaderText = "MLT";
            this.MLT_TG.Name = "MLT_TG";
            this.MLT_TG.ReadOnly = true;
            // 
            // SoPhatHanh_TG
            // 
            this.SoPhatHanh_TG.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_TG.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_TG.Name = "SoPhatHanh_TG";
            this.SoPhatHanh_TG.ReadOnly = true;
            // 
            // DanhBo_TG
            // 
            this.DanhBo_TG.DataPropertyName = "DanhBo";
            this.DanhBo_TG.HeaderText = "Danh Bộ";
            this.DanhBo_TG.Name = "DanhBo_TG";
            this.DanhBo_TG.ReadOnly = true;
            // 
            // HoTen_TG
            // 
            this.HoTen_TG.DataPropertyName = "HoTen";
            this.HoTen_TG.HeaderText = "HoTen";
            this.HoTen_TG.Name = "HoTen_TG";
            this.HoTen_TG.ReadOnly = true;
            this.HoTen_TG.Visible = false;
            // 
            // DiaChi_TG
            // 
            this.DiaChi_TG.DataPropertyName = "DiaChi";
            this.DiaChi_TG.HeaderText = "DiaChi";
            this.DiaChi_TG.Name = "DiaChi_TG";
            this.DiaChi_TG.ReadOnly = true;
            this.DiaChi_TG.Visible = false;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // GiaBieu_TG
            // 
            this.GiaBieu_TG.DataPropertyName = "GiaBieu";
            this.GiaBieu_TG.HeaderText = "GiaBieu";
            this.GiaBieu_TG.Name = "GiaBieu_TG";
            this.GiaBieu_TG.ReadOnly = true;
            this.GiaBieu_TG.Visible = false;
            // 
            // HanhThu_TG
            // 
            this.HanhThu_TG.DataPropertyName = "HanhThu";
            this.HanhThu_TG.HeaderText = "HanhThu";
            this.HanhThu_TG.Name = "HanhThu_TG";
            this.HanhThu_TG.ReadOnly = true;
            this.HanhThu_TG.Visible = false;
            // 
            // To_TG
            // 
            this.To_TG.DataPropertyName = "To";
            this.To_TG.HeaderText = "To";
            this.To_TG.Name = "To_TG";
            this.To_TG.ReadOnly = true;
            this.To_TG.Visible = false;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(539, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 9;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(433, 12);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 8;
            this.dateTu.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ngày Lập:";
            this.label3.Visible = false;
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(620, 10);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(81, 23);
            this.btnIn.TabIndex = 10;
            this.btnIn.Text = "In Danh Sách";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "(Enter)";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(271, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(638, 590);
            this.tabControl.TabIndex = 29;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.txtTongHD_TG);
            this.tabTuGia.Controls.Add(this.txtTongCong_TG);
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(630, 564);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.txtTongHD_CQ);
            this.tabCoQuan.Controls.Add(this.txtTongCong_CQ);
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(630, 564);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaQT_CQ,
            this.SoHoaDon_CQ,
            this.Ky_CQ,
            this.MLT_CQ,
            this.SoPhatHanh_CQ,
            this.DanhBo_CQ,
            this.HoTen_CQ,
            this.DiaChi_CQ,
            this.TongCong_CQ,
            this.GiaBieu_CQ,
            this.HanhThu_CQ,
            this.To_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvHDCoQuan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(615, 535);
            this.dgvHDCoQuan.TabIndex = 12;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // MaQT_CQ
            // 
            this.MaQT_CQ.DataPropertyName = "MaQT";
            this.MaQT_CQ.HeaderText = "MaQT";
            this.MaQT_CQ.Name = "MaQT_CQ";
            this.MaQT_CQ.ReadOnly = true;
            this.MaQT_CQ.Visible = false;
            // 
            // SoHoaDon_CQ
            // 
            this.SoHoaDon_CQ.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CQ.HeaderText = "Số HĐ";
            this.SoHoaDon_CQ.Name = "SoHoaDon_CQ";
            this.SoHoaDon_CQ.ReadOnly = true;
            // 
            // Ky_CQ
            // 
            this.Ky_CQ.DataPropertyName = "Ky";
            this.Ky_CQ.HeaderText = "Kỳ";
            this.Ky_CQ.Name = "Ky_CQ";
            this.Ky_CQ.ReadOnly = true;
            this.Ky_CQ.Width = 50;
            // 
            // MLT_CQ
            // 
            this.MLT_CQ.DataPropertyName = "MLT";
            this.MLT_CQ.HeaderText = "MLT";
            this.MLT_CQ.Name = "MLT_CQ";
            this.MLT_CQ.ReadOnly = true;
            // 
            // SoPhatHanh_CQ
            // 
            this.SoPhatHanh_CQ.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_CQ.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_CQ.Name = "SoPhatHanh_CQ";
            this.SoPhatHanh_CQ.ReadOnly = true;
            // 
            // DanhBo_CQ
            // 
            this.DanhBo_CQ.DataPropertyName = "DanhBo";
            this.DanhBo_CQ.HeaderText = "Danh Bộ";
            this.DanhBo_CQ.Name = "DanhBo_CQ";
            this.DanhBo_CQ.ReadOnly = true;
            // 
            // HoTen_CQ
            // 
            this.HoTen_CQ.DataPropertyName = "HoTen";
            this.HoTen_CQ.HeaderText = "HoTen";
            this.HoTen_CQ.Name = "HoTen_CQ";
            this.HoTen_CQ.ReadOnly = true;
            this.HoTen_CQ.Visible = false;
            // 
            // DiaChi_CQ
            // 
            this.DiaChi_CQ.DataPropertyName = "DiaChi";
            this.DiaChi_CQ.HeaderText = "DiaChi";
            this.DiaChi_CQ.Name = "DiaChi_CQ";
            this.DiaChi_CQ.ReadOnly = true;
            this.DiaChi_CQ.Visible = false;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // GiaBieu_CQ
            // 
            this.GiaBieu_CQ.DataPropertyName = "GiaBieu";
            this.GiaBieu_CQ.HeaderText = "GiaBieu";
            this.GiaBieu_CQ.Name = "GiaBieu_CQ";
            this.GiaBieu_CQ.ReadOnly = true;
            this.GiaBieu_CQ.Visible = false;
            // 
            // HanhThu_CQ
            // 
            this.HanhThu_CQ.DataPropertyName = "HanhThu";
            this.HanhThu_CQ.HeaderText = "HanhThu";
            this.HanhThu_CQ.Name = "HanhThu_CQ";
            this.HanhThu_CQ.ReadOnly = true;
            this.HanhThu_CQ.Visible = false;
            // 
            // To_CQ
            // 
            this.To_CQ.DataPropertyName = "To";
            this.To_CQ.HeaderText = "To";
            this.To_CQ.Name = "To_CQ";
            this.To_CQ.ReadOnly = true;
            this.To_CQ.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Số Lượng:";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(87, 255);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(50, 20);
            this.txtSoLuong.TabIndex = 26;
            // 
            // btnInDSDiaChi
            // 
            this.btnInDSDiaChi.Location = new System.Drawing.Point(707, 10);
            this.btnInDSDiaChi.Name = "btnInDSDiaChi";
            this.btnInDSDiaChi.Size = new System.Drawing.Size(81, 23);
            this.btnInDSDiaChi.TabIndex = 30;
            this.btnInDSDiaChi.Text = "In DS Địa Chỉ";
            this.btnInDSDiaChi.UseVisualStyleBackColor = true;
            this.btnInDSDiaChi.Click += new System.EventHandler(this.btnInDSDiaChi_Click);
            // 
            // btnInDSPhanTo
            // 
            this.btnInDSPhanTo.Location = new System.Drawing.Point(794, 10);
            this.btnInDSPhanTo.Name = "btnInDSPhanTo";
            this.btnInDSPhanTo.Size = new System.Drawing.Size(90, 23);
            this.btnInDSPhanTo.TabIndex = 32;
            this.btnInDSPhanTo.Text = "In DS Phân Tổ";
            this.btnInDSPhanTo.UseVisualStyleBackColor = true;
            this.btnInDSPhanTo.Click += new System.EventHandler(this.btnInDSPhanTo_Click);
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
            // txtTongHD_TG
            // 
            this.txtTongHD_TG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD_TG.Location = new System.Drawing.Point(6, 541);
            this.txtTongHD_TG.Name = "txtTongHD_TG";
            this.txtTongHD_TG.Size = new System.Drawing.Size(40, 20);
            this.txtTongHD_TG.TabIndex = 13;
            this.txtTongHD_TG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // txtTongCong_CQ
            // 
            this.txtTongCong_CQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_CQ.Location = new System.Drawing.Point(521, 541);
            this.txtTongCong_CQ.Name = "txtTongCong_CQ";
            this.txtTongCong_CQ.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_CQ.TabIndex = 14;
            this.txtTongCong_CQ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmQuetTam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 652);
            this.Controls.Add(this.btnInDSPhanTo);
            this.Controls.Add(this.btnInDSDiaChi);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.label4);
            this.Name = "frmQuetTam";
            this.Text = "Quét Tạm";
            this.Load += new System.EventHandler(this.frmQuetTam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            this.tabTuGia.PerformLayout();
            this.tabCoQuan.ResumeLayout(false);
            this.tabCoQuan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnInDSDiaChi;
        private System.Windows.Forms.Button btnInDSPhanTo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaQT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn To_CQ;
        private System.Windows.Forms.TextBox txtTongCong_TG;
        private System.Windows.Forms.TextBox txtTongHD_TG;
        private System.Windows.Forms.TextBox txtTongHD_CQ;
        private System.Windows.Forms.TextBox txtTongCong_CQ;
    }
}