namespace ThuTien.GUI.TimKiem
{
    partial class frmTimKiemKhachHang
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
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.dgvKinhDoanh = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnInPhieuTieuThu = new System.Windows.Forms.Button();
            this.btnXemPKinhDoanh = new System.Windows.Forms.Button();
            this.btnXemLenhHuy = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLenhHuy = new System.Windows.Forms.DataGridView();
            this.Ky_LH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TinhTrang_LH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DangNgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKinhDoanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLenhHuy)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(86, 54);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(250, 20);
            this.txtDiaChi.TabIndex = 15;
            this.txtDiaChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(86, 28);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 20);
            this.txtHoTen.TabIndex = 13;
            this.txtHoTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(86, 2);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 11;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Danh Bộ:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(342, 51);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 16;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.DanhBo,
            this.MLT,
            this.HoTen,
            this.DiaChi,
            this.GiaBieu,
            this.DinhMuc,
            this.Ky,
            this.SoHoaDon,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.NgayGiaiTrach,
            this.DangNgan,
            this.MaDN,
            this.NgayDN,
            this.NgayMN,
            this.HanhThu,
            this.NgayDoc,
            this.ChiSo});
            this.dgvHoaDon.Location = new System.Drawing.Point(1, 80);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(1358, 280);
            this.dgvHoaDon.TabIndex = 17;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // dgvKinhDoanh
            // 
            this.dgvKinhDoanh.AllowUserToAddRows = false;
            this.dgvKinhDoanh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKinhDoanh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKinhDoanh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKinhDoanh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.NoiDung,
            this.CreateDate});
            this.dgvKinhDoanh.Location = new System.Drawing.Point(1, 391);
            this.dgvKinhDoanh.MultiSelect = false;
            this.dgvKinhDoanh.Name = "dgvKinhDoanh";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvKinhDoanh.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKinhDoanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKinhDoanh.Size = new System.Drawing.Size(695, 235);
            this.dgvKinhDoanh.TabIndex = 18;
            this.dgvKinhDoanh.Visible = false;
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.Width = 150;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 400;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.Width = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Phòng Kinh Doanh xử lý:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(653, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Lệnh ĐN: màu vàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(762, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Lệnh Hủy: màu đỏ";
            // 
            // btnInPhieuTieuThu
            // 
            this.btnInPhieuTieuThu.Location = new System.Drawing.Point(423, 51);
            this.btnInPhieuTieuThu.Name = "btnInPhieuTieuThu";
            this.btnInPhieuTieuThu.Size = new System.Drawing.Size(100, 23);
            this.btnInPhieuTieuThu.TabIndex = 22;
            this.btnInPhieuTieuThu.Text = "In Phiếu Tiêu Thụ";
            this.btnInPhieuTieuThu.UseVisualStyleBackColor = true;
            this.btnInPhieuTieuThu.Click += new System.EventHandler(this.btnInPhieuTieuThu_Click);
            // 
            // btnXemPKinhDoanh
            // 
            this.btnXemPKinhDoanh.Location = new System.Drawing.Point(221, 368);
            this.btnXemPKinhDoanh.Name = "btnXemPKinhDoanh";
            this.btnXemPKinhDoanh.Size = new System.Drawing.Size(75, 23);
            this.btnXemPKinhDoanh.TabIndex = 23;
            this.btnXemPKinhDoanh.Text = "Xem";
            this.btnXemPKinhDoanh.UseVisualStyleBackColor = true;
            this.btnXemPKinhDoanh.Click += new System.EventHandler(this.btnXemPKinhDoanh_Click);
            // 
            // btnXemLenhHuy
            // 
            this.btnXemLenhHuy.Location = new System.Drawing.Point(809, 368);
            this.btnXemLenhHuy.Name = "btnXemLenhHuy";
            this.btnXemLenhHuy.Size = new System.Drawing.Size(75, 23);
            this.btnXemLenhHuy.TabIndex = 26;
            this.btnXemLenhHuy.Text = "Xem";
            this.btnXemLenhHuy.UseVisualStyleBackColor = true;
            this.btnXemLenhHuy.Click += new System.EventHandler(this.btnXemLenhHuy_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(713, 368);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 25;
            this.label7.Text = "Lệnh Hủy:";
            // 
            // dgvLenhHuy
            // 
            this.dgvLenhHuy.AllowUserToAddRows = false;
            this.dgvLenhHuy.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLenhHuy.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLenhHuy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLenhHuy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ky_LH,
            this.TinhTrang_LH});
            this.dgvLenhHuy.Location = new System.Drawing.Point(702, 391);
            this.dgvLenhHuy.MultiSelect = false;
            this.dgvLenhHuy.Name = "dgvLenhHuy";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvLenhHuy.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLenhHuy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLenhHuy.Size = new System.Drawing.Size(264, 235);
            this.dgvLenhHuy.TabIndex = 24;
            this.dgvLenhHuy.Visible = false;
            // 
            // Ky_LH
            // 
            this.Ky_LH.DataPropertyName = "Ky";
            this.Ky_LH.HeaderText = "Kỳ";
            this.Ky_LH.Name = "Ky_LH";
            this.Ky_LH.Width = 50;
            // 
            // TinhTrang_LH
            // 
            this.TinhTrang_LH.DataPropertyName = "TinhTrang";
            this.TinhTrang_LH.HeaderText = "Tình Trạng";
            this.TinhTrang_LH.Name = "TinhTrang_LH";
            this.TinhTrang_LH.Width = 150;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Visible = false;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            this.DanhBo.Width = 90;
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.ReadOnly = true;
            this.MLT.Width = 70;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.ReadOnly = true;
            this.GiaBieu.Width = 50;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.ReadOnly = true;
            this.DinhMuc.Width = 50;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon.Name = "SoHoaDon";
            this.SoHoaDon.ReadOnly = true;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.ReadOnly = true;
            this.TieuThu.Width = 40;
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            this.GiaBan.ReadOnly = true;
            this.GiaBan.Width = 70;
            // 
            // ThueGTGT
            // 
            this.ThueGTGT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT.HeaderText = "Thuế GTGT";
            this.ThueGTGT.Name = "ThueGTGT";
            this.ThueGTGT.ReadOnly = true;
            this.ThueGTGT.Width = 70;
            // 
            // PhiBVMT
            // 
            this.PhiBVMT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT.HeaderText = "Phí BVMT";
            this.PhiBVMT.Name = "PhiBVMT";
            this.PhiBVMT.ReadOnly = true;
            this.PhiBVMT.Width = 70;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            this.TongCong.Width = 70;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.ReadOnly = true;
            this.NgayGiaiTrach.Width = 80;
            // 
            // DangNgan
            // 
            this.DangNgan.DataPropertyName = "DangNgan";
            this.DangNgan.HeaderText = "Đăng Ngân";
            this.DangNgan.Name = "DangNgan";
            this.DangNgan.ReadOnly = true;
            // 
            // MaDN
            // 
            this.MaDN.DataPropertyName = "MaDN";
            this.MaDN.HeaderText = "Số Lệnh";
            this.MaDN.Name = "MaDN";
            this.MaDN.ReadOnly = true;
            this.MaDN.Width = 50;
            // 
            // NgayDN
            // 
            this.NgayDN.DataPropertyName = "NgayDN";
            this.NgayDN.HeaderText = "Khóa Nước";
            this.NgayDN.Name = "NgayDN";
            this.NgayDN.ReadOnly = true;
            this.NgayDN.Width = 80;
            // 
            // NgayMN
            // 
            this.NgayMN.DataPropertyName = "NgayMN";
            this.NgayMN.HeaderText = "Mở Nước";
            this.NgayMN.Name = "NgayMN";
            this.NgayMN.ReadOnly = true;
            this.NgayMN.Width = 80;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.ReadOnly = true;
            // 
            // NgayDoc
            // 
            this.NgayDoc.DataPropertyName = "NgayDoc";
            this.NgayDoc.HeaderText = "NgayDoc";
            this.NgayDoc.Name = "NgayDoc";
            this.NgayDoc.ReadOnly = true;
            this.NgayDoc.Visible = false;
            // 
            // ChiSo
            // 
            this.ChiSo.DataPropertyName = "ChiSo";
            this.ChiSo.HeaderText = "ChiSo";
            this.ChiSo.Name = "ChiSo";
            this.ChiSo.ReadOnly = true;
            this.ChiSo.Visible = false;
            // 
            // frmTimKiemKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 629);
            this.Controls.Add(this.btnXemLenhHuy);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgvLenhHuy);
            this.Controls.Add(this.btnXemPKinhDoanh);
            this.Controls.Add(this.btnInPhieuTieuThu);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvKinhDoanh);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Name = "frmTimKiemKhachHang";
            this.Text = "Tìm Kiếm Thông Tin Khách Hàng";
            this.Load += new System.EventHandler(this.frmTimKiemKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKinhDoanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLenhHuy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridView dgvKinhDoanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInPhieuTieuThu;
        private System.Windows.Forms.Button btnXemPKinhDoanh;
        private System.Windows.Forms.Button btnXemLenhHuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLenhHuy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_LH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang_LH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DangNgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSo;
    }
}