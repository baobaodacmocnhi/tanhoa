namespace TanHoa.GUI.KinhDoanh
{
    partial class frmDieuChinh
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
            this.radBienDong = new System.Windows.Forms.RadioButton();
            this.radHoaDon = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.chkDieuChinhGia = new System.Windows.Forms.CheckBox();
            this.chkTieuThu = new System.Windows.Forms.CheckBox();
            this.chkDinhMuc = new System.Windows.Forms.CheckBox();
            this.chkGiaBieu = new System.Windows.Forms.CheckBox();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtTong = new System.Windows.Forms.TextBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.txtTongCong_BD = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThongTin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDoDieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KyHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TangGiam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_End = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCSN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SH_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SX_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DV_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HCSN_BD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_DieuChinhGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaDieuChinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiTietMoi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DieuChinhGia = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // radBienDong
            // 
            this.radBienDong.AutoSize = true;
            this.radBienDong.Location = new System.Drawing.Point(12, 12);
            this.radBienDong.Name = "radBienDong";
            this.radBienDong.Size = new System.Drawing.Size(75, 17);
            this.radBienDong.TabIndex = 0;
            this.radBienDong.Text = "Biến Động";
            this.radBienDong.UseVisualStyleBackColor = true;
            this.radBienDong.CheckedChanged += new System.EventHandler(this.radBienDong_CheckedChanged);
            // 
            // radHoaDon
            // 
            this.radHoaDon.AutoSize = true;
            this.radHoaDon.Location = new System.Drawing.Point(12, 35);
            this.radHoaDon.Name = "radHoaDon";
            this.radHoaDon.Size = new System.Drawing.Size(68, 17);
            this.radHoaDon.TabIndex = 1;
            this.radHoaDon.Text = "Hóa Đơn";
            this.radHoaDon.UseVisualStyleBackColor = true;
            this.radHoaDon.CheckedChanged += new System.EventHandler(this.radHoaDon_CheckedChanged);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.chkDieuChinhGia);
            this.groupBox.Controls.Add(this.chkTieuThu);
            this.groupBox.Controls.Add(this.chkDinhMuc);
            this.groupBox.Controls.Add(this.chkGiaBieu);
            this.groupBox.Location = new System.Drawing.Point(364, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(335, 46);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Chi Tiết Lọc";
            // 
            // chkDieuChinhGia
            // 
            this.chkDieuChinhGia.AutoSize = true;
            this.chkDieuChinhGia.Location = new System.Drawing.Point(231, 23);
            this.chkDieuChinhGia.Name = "chkDieuChinhGia";
            this.chkDieuChinhGia.Size = new System.Drawing.Size(97, 17);
            this.chkDieuChinhGia.TabIndex = 2;
            this.chkDieuChinhGia.Text = "Điều Chỉnh Giá";
            this.chkDieuChinhGia.UseVisualStyleBackColor = true;
            // 
            // chkTieuThu
            // 
            this.chkTieuThu.AutoSize = true;
            this.chkTieuThu.Location = new System.Drawing.Point(156, 23);
            this.chkTieuThu.Name = "chkTieuThu";
            this.chkTieuThu.Size = new System.Drawing.Size(69, 17);
            this.chkTieuThu.TabIndex = 2;
            this.chkTieuThu.Text = "Tiêu Thụ";
            this.chkTieuThu.UseVisualStyleBackColor = true;
            // 
            // chkDinhMuc
            // 
            this.chkDinhMuc.AutoSize = true;
            this.chkDinhMuc.Location = new System.Drawing.Point(78, 23);
            this.chkDinhMuc.Name = "chkDinhMuc";
            this.chkDinhMuc.Size = new System.Drawing.Size(72, 17);
            this.chkDinhMuc.TabIndex = 1;
            this.chkDinhMuc.Text = "Định Mức";
            this.chkDinhMuc.UseVisualStyleBackColor = true;
            // 
            // chkGiaBieu
            // 
            this.chkGiaBieu.AutoSize = true;
            this.chkGiaBieu.Location = new System.Drawing.Point(6, 23);
            this.chkGiaBieu.Name = "chkGiaBieu";
            this.chkGiaBieu.Size = new System.Drawing.Size(66, 17);
            this.chkGiaBieu.TabIndex = 0;
            this.chkGiaBieu.Text = "Giá Biểu";
            this.chkGiaBieu.UseVisualStyleBackColor = true;
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(177, 12);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(100, 20);
            this.dateFrom.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ Ngày:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Đến Ngày:";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(177, 38);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(100, 20);
            this.dateTo.TabIndex = 5;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(283, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 7;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.CreateDate,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.ThongTin,
            this.LyDoDieuChinh,
            this.KyHD,
            this.TangGiam,
            this.TongCong_Start,
            this.TongCong_BD,
            this.TongCong_End,
            this.GiaBieu,
            this.GiaBieu_BD,
            this.DinhMuc,
            this.DinhMuc_BD,
            this.TieuThu,
            this.TieuThu_BD,
            this.HoTen_BD,
            this.DiaChi_BD,
            this.SH,
            this.SX,
            this.DV,
            this.HCSN,
            this.SH_BD,
            this.SX_BD,
            this.DV_BD,
            this.HCSN_BD,
            this.TieuThu_DieuChinhGia,
            this.GiaDieuChinh,
            this.ChiTietMoi,
            this.DieuChinhGia});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.Location = new System.Drawing.Point(12, 64);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.Size = new System.Drawing.Size(1344, 431);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView_CellFormatting);
            // 
            // txtTong
            // 
            this.txtTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTong.Location = new System.Drawing.Point(12, 501);
            this.txtTong.Name = "txtTong";
            this.txtTong.Size = new System.Drawing.Size(50, 20);
            this.txtTong.TabIndex = 9;
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(705, 10);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(75, 23);
            this.btnXuatExcel.TabIndex = 10;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // txtTongCong_BD
            // 
            this.txtTongCong_BD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongCong_BD.Location = new System.Drawing.Point(830, 501);
            this.txtTongCong_BD.Name = "txtTongCong_BD";
            this.txtTongCong_BD.Size = new System.Drawing.Size(100, 20);
            this.txtTongCong_BD.TabIndex = 11;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.Width = 80;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            // 
            // ThongTin
            // 
            this.ThongTin.DataPropertyName = "ThongTin";
            this.ThongTin.HeaderText = "Thông Tin";
            this.ThongTin.Name = "ThongTin";
            // 
            // LyDoDieuChinh
            // 
            this.LyDoDieuChinh.DataPropertyName = "LyDoDieuChinh";
            this.LyDoDieuChinh.HeaderText = "Lý Do";
            this.LyDoDieuChinh.Name = "LyDoDieuChinh";
            // 
            // KyHD
            // 
            this.KyHD.DataPropertyName = "KyHD";
            this.KyHD.HeaderText = "Kỳ";
            this.KyHD.Name = "KyHD";
            this.KyHD.Width = 50;
            // 
            // TangGiam
            // 
            this.TangGiam.DataPropertyName = "TangGiam";
            this.TangGiam.HeaderText = "Tăng Giảm";
            this.TangGiam.Name = "TangGiam";
            this.TangGiam.Width = 50;
            // 
            // TongCong_Start
            // 
            this.TongCong_Start.DataPropertyName = "TongCong_Start";
            this.TongCong_Start.HeaderText = "Tổng Cộng Trước";
            this.TongCong_Start.Name = "TongCong_Start";
            this.TongCong_Start.Width = 70;
            // 
            // TongCong_BD
            // 
            this.TongCong_BD.DataPropertyName = "TongCong_BD";
            this.TongCong_BD.HeaderText = "Tổng Cộng BD";
            this.TongCong_BD.Name = "TongCong_BD";
            this.TongCong_BD.Width = 70;
            // 
            // TongCong_End
            // 
            this.TongCong_End.DataPropertyName = "TongCong_End";
            this.TongCong_End.HeaderText = "Tổng Cộng Sau";
            this.TongCong_End.Name = "TongCong_End";
            this.TongCong_End.Width = 70;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "Giá Biểu Cũ";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 40;
            // 
            // GiaBieu_BD
            // 
            this.GiaBieu_BD.DataPropertyName = "GiaBieu_BD";
            this.GiaBieu_BD.HeaderText = "Giá Biểu Mới";
            this.GiaBieu_BD.Name = "GiaBieu_BD";
            this.GiaBieu_BD.Width = 40;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức Cũ";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Width = 40;
            // 
            // DinhMuc_BD
            // 
            this.DinhMuc_BD.DataPropertyName = "DinhMuc_BD";
            this.DinhMuc_BD.HeaderText = "Định Mức Mới";
            this.DinhMuc_BD.Name = "DinhMuc_BD";
            this.DinhMuc_BD.Width = 40;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ Cũ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 40;
            // 
            // TieuThu_BD
            // 
            this.TieuThu_BD.DataPropertyName = "TieuThu_BD";
            this.TieuThu_BD.HeaderText = "Tiêu Thụ Mới";
            this.TieuThu_BD.Name = "TieuThu_BD";
            this.TieuThu_BD.Width = 40;
            // 
            // HoTen_BD
            // 
            this.HoTen_BD.DataPropertyName = "HoTen_BD";
            this.HoTen_BD.HeaderText = "Tên Mới";
            this.HoTen_BD.Name = "HoTen_BD";
            // 
            // DiaChi_BD
            // 
            this.DiaChi_BD.DataPropertyName = "DiaChi_BD";
            this.DiaChi_BD.HeaderText = "Địa Chỉ Mới";
            this.DiaChi_BD.Name = "DiaChi_BD";
            // 
            // SH
            // 
            this.SH.DataPropertyName = "SH";
            this.SH.HeaderText = "SH Cũ";
            this.SH.Name = "SH";
            this.SH.Width = 30;
            // 
            // SX
            // 
            this.SX.DataPropertyName = "SX";
            this.SX.HeaderText = "SX Cũ";
            this.SX.Name = "SX";
            this.SX.Width = 30;
            // 
            // DV
            // 
            this.DV.DataPropertyName = "DV";
            this.DV.HeaderText = "DV Cũ";
            this.DV.Name = "DV";
            this.DV.Width = 30;
            // 
            // HCSN
            // 
            this.HCSN.DataPropertyName = "HCSN";
            this.HCSN.HeaderText = "HCSN Cũ";
            this.HCSN.Name = "HCSN";
            this.HCSN.Width = 40;
            // 
            // SH_BD
            // 
            this.SH_BD.DataPropertyName = "SH_BD";
            this.SH_BD.HeaderText = "SH Mới";
            this.SH_BD.Name = "SH_BD";
            this.SH_BD.Width = 30;
            // 
            // SX_BD
            // 
            this.SX_BD.DataPropertyName = "SX_BD";
            this.SX_BD.HeaderText = "SX Mới";
            this.SX_BD.Name = "SX_BD";
            this.SX_BD.Width = 30;
            // 
            // DV_BD
            // 
            this.DV_BD.DataPropertyName = "DV_BD";
            this.DV_BD.HeaderText = "DV Mới";
            this.DV_BD.Name = "DV_BD";
            this.DV_BD.Width = 30;
            // 
            // HCSN_BD
            // 
            this.HCSN_BD.DataPropertyName = "HCSN_BD";
            this.HCSN_BD.HeaderText = "HCSN Mới";
            this.HCSN_BD.Name = "HCSN_BD";
            this.HCSN_BD.Width = 40;
            // 
            // TieuThu_DieuChinhGia
            // 
            this.TieuThu_DieuChinhGia.DataPropertyName = "TieuThu_DieuChinhGia";
            this.TieuThu_DieuChinhGia.HeaderText = "Tiêu Thụ Điều Chỉnh Giá";
            this.TieuThu_DieuChinhGia.Name = "TieuThu_DieuChinhGia";
            this.TieuThu_DieuChinhGia.Width = 75;
            // 
            // GiaDieuChinh
            // 
            this.GiaDieuChinh.DataPropertyName = "GiaDieuChinh";
            this.GiaDieuChinh.HeaderText = "Giá Điều Chỉnh";
            this.GiaDieuChinh.Name = "GiaDieuChinh";
            this.GiaDieuChinh.Width = 50;
            // 
            // ChiTietMoi
            // 
            this.ChiTietMoi.DataPropertyName = "ChiTietMoi";
            this.ChiTietMoi.HeaderText = "Chi Tiết";
            this.ChiTietMoi.Name = "ChiTietMoi";
            // 
            // DieuChinhGia
            // 
            this.DieuChinhGia.DataPropertyName = "DieuChinhGia";
            this.DieuChinhGia.HeaderText = "DieuChinhGia";
            this.DieuChinhGia.Name = "DieuChinhGia";
            this.DieuChinhGia.Visible = false;
            // 
            // frmDieuChinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 533);
            this.Controls.Add(this.txtTongCong_BD);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.txtTong);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFrom);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.radHoaDon);
            this.Controls.Add(this.radBienDong);
            this.Name = "frmDieuChinh";
            this.Text = "Điều Chỉnh";
            this.Load += new System.EventHandler(this.frmDieuChinh_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radBienDong;
        private System.Windows.Forms.RadioButton radHoaDon;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.CheckBox chkDieuChinhGia;
        private System.Windows.Forms.CheckBox chkTieuThu;
        private System.Windows.Forms.CheckBox chkDinhMuc;
        private System.Windows.Forms.CheckBox chkGiaBieu;
        private System.Windows.Forms.TextBox txtTong;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.TextBox txtTongCong_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThongTin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDoDieuChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn KyHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TangGiam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SX;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCSN;
        private System.Windows.Forms.DataGridViewTextBoxColumn SH_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SX_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DV_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn HCSN_BD;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_DieuChinhGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaDieuChinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiTietMoi;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DieuChinhGia;
    }
}