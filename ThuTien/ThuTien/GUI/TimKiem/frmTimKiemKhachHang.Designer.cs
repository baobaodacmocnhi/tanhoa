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
            this.txtSoNha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DangNgan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChiSo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvKinhDoanh = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThuTien_NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtMLT = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTenDuong = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnTimKiemTatCa = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbSoKy = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKinhDoanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLenhHuy)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSoNha
            // 
            this.txtSoNha.Location = new System.Drawing.Point(86, 54);
            this.txtSoNha.Name = "txtSoNha";
            this.txtSoNha.Size = new System.Drawing.Size(73, 20);
            this.txtSoNha.TabIndex = 7;
            this.txtSoNha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số Nhà:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(86, 28);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 20);
            this.txtHoTen.TabIndex = 5;
            this.txtHoTen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHoTen_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(86, 2);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(389, 52);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 10;
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
            this.Code,
            this.TieuThu,
            this.GiaBan,
            this.ThueGTGT,
            this.PhiBVMT,
            this.TongCong,
            this.NgayGiaiTrach,
            this.DangNgan,
            this.HanhThu,
            this.MaDN,
            this.NgayDN,
            this.NgayMN,
            this.NgayDoc,
            this.ChiSo});
            this.dgvHoaDon.Location = new System.Drawing.Point(1, 80);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.Size = new System.Drawing.Size(1358, 280);
            this.dgvHoaDon.TabIndex = 21;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHoaDon_CellMouseDoubleClick);
            this.dgvHoaDon.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHoaDon_ColumnHeaderMouseClick);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
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
            this.MLT.Width = 75;
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
            this.GiaBieu.Width = 40;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.ReadOnly = true;
            this.DinhMuc.Width = 40;
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
            this.SoHoaDon.Width = 90;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 30;
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
            this.DangNgan.Width = 80;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.ReadOnly = true;
            this.HanhThu.Width = 80;
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
            this.ThuTien_NgayNhan});
            this.dgvKinhDoanh.Location = new System.Drawing.Point(1, 391);
            this.dgvKinhDoanh.MultiSelect = false;
            this.dgvKinhDoanh.Name = "dgvKinhDoanh";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dgvKinhDoanh.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvKinhDoanh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKinhDoanh.Size = new System.Drawing.Size(695, 235);
            this.dgvKinhDoanh.TabIndex = 15;
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
            // ThuTien_NgayNhan
            // 
            this.ThuTien_NgayNhan.DataPropertyName = "ThuTien_NgayNhan";
            this.ThuTien_NgayNhan.HeaderText = "Ngày Nhận";
            this.ThuTien_NgayNhan.Name = "ThuTien_NgayNhan";
            this.ThuTien_NgayNhan.Width = 80;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 20);
            this.label4.TabIndex = 13;
            this.label4.Text = "Phòng Kinh Doanh xử lý:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Yellow;
            this.label5.Location = new System.Drawing.Point(633, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lệnh ĐN: màu vàng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(846, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 15);
            this.label6.TabIndex = 20;
            this.label6.Text = "Lệnh Hủy: màu đỏ";
            // 
            // btnInPhieuTieuThu
            // 
            this.btnInPhieuTieuThu.Location = new System.Drawing.Point(432, 0);
            this.btnInPhieuTieuThu.Name = "btnInPhieuTieuThu";
            this.btnInPhieuTieuThu.Size = new System.Drawing.Size(115, 23);
            this.btnInPhieuTieuThu.TabIndex = 12;
            this.btnInPhieuTieuThu.Text = "In Phiếu Đăng Ngân";
            this.btnInPhieuTieuThu.UseVisualStyleBackColor = true;
            this.btnInPhieuTieuThu.Click += new System.EventHandler(this.btnInPhieuTieuThu_Click);
            // 
            // btnXemPKinhDoanh
            // 
            this.btnXemPKinhDoanh.Location = new System.Drawing.Point(221, 368);
            this.btnXemPKinhDoanh.Name = "btnXemPKinhDoanh";
            this.btnXemPKinhDoanh.Size = new System.Drawing.Size(75, 23);
            this.btnXemPKinhDoanh.TabIndex = 14;
            this.btnXemPKinhDoanh.Text = "Xem";
            this.btnXemPKinhDoanh.UseVisualStyleBackColor = true;
            this.btnXemPKinhDoanh.Click += new System.EventHandler(this.btnXemPKinhDoanh_Click);
            // 
            // btnXemLenhHuy
            // 
            this.btnXemLenhHuy.Location = new System.Drawing.Point(809, 368);
            this.btnXemLenhHuy.Name = "btnXemLenhHuy";
            this.btnXemLenhHuy.Size = new System.Drawing.Size(75, 23);
            this.btnXemLenhHuy.TabIndex = 17;
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
            this.label7.TabIndex = 16;
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
            this.dgvLenhHuy.Size = new System.Drawing.Size(646, 235);
            this.dgvLenhHuy.TabIndex = 18;
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
            this.TinhTrang_LH.Width = 500;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(336, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Xóa Điều Kiện";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // txtMLT
            // 
            this.txtMLT.Location = new System.Drawing.Point(230, 2);
            this.txtMLT.Name = "txtMLT";
            this.txtMLT.Size = new System.Drawing.Size(100, 20);
            this.txtMLT.TabIndex = 3;
            this.txtMLT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMLT_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(192, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "MLT:";
            // 
            // txtTenDuong
            // 
            this.txtTenDuong.Location = new System.Drawing.Point(235, 54);
            this.txtTenDuong.Name = "txtTenDuong";
            this.txtTenDuong.Size = new System.Drawing.Size(148, 20);
            this.txtTenDuong.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(165, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Tên Đường:";
            // 
            // btnTimKiemTatCa
            // 
            this.btnTimKiemTatCa.Location = new System.Drawing.Point(470, 52);
            this.btnTimKiemTatCa.Name = "btnTimKiemTatCa";
            this.btnTimKiemTatCa.Size = new System.Drawing.Size(100, 23);
            this.btnTimKiemTatCa.TabIndex = 22;
            this.btnTimKiemTatCa.Text = "Tìm Kiếm Tất Cả";
            this.btnTimKiemTatCa.UseVisualStyleBackColor = true;
            this.btnTimKiemTatCa.Click += new System.EventHandler(this.btnTimKiemTatCa_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Orange;
            this.label10.Location = new System.Drawing.Point(633, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(166, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "Lệnh ĐN lần 2: màu cam";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(846, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(170, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Tờ Trình CH: màu xanh lá";
            // 
            // cmbSoKy
            // 
            this.cmbSoKy.FormattingEnabled = true;
            this.cmbSoKy.Items.AddRange(new object[] {
            "10",
            "16"});
            this.cmbSoKy.Location = new System.Drawing.Point(553, 1);
            this.cmbSoKy.Name = "cmbSoKy";
            this.cmbSoKy.Size = new System.Drawing.Size(50, 21);
            this.cmbSoKy.TabIndex = 25;
            // 
            // frmTimKiemKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 629);
            this.Controls.Add(this.cmbSoKy);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnTimKiemTatCa);
            this.Controls.Add(this.txtTenDuong);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtMLT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnRefresh);
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
            this.Controls.Add(this.txtSoNha);
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

        private System.Windows.Forms.TextBox txtSoNha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridView dgvKinhDoanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnInPhieuTieuThu;
        private System.Windows.Forms.Button btnXemPKinhDoanh;
        private System.Windows.Forms.Button btnXemLenhHuy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLenhHuy;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_LH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TinhTrang_LH;
        private System.Windows.Forms.TextBox txtMLT;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThuTien_NgayNhan;
        private System.Windows.Forms.TextBox txtTenDuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTimKiemTatCa;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn DangNgan;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChiSo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbSoKy;
    }
}