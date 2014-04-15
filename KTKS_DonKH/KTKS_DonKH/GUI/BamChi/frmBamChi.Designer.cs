namespace KTKS_DonKH.GUI.BamChi
{
    partial class frmBamChi
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
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMucDichSuDung = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cmbChiKhoaGoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSoThan = new System.Windows.Forms.TextBox();
            this.cmbChiMatSo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtTheoYeuCau = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDayChi = new System.Windows.Forms.TextBox();
            this.cmbTinhTrangChiSo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtVienChi = new System.Windows.Forms.TextBox();
            this.cmbTinhTrangKiemTra = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHieu = new System.Windows.Forms.TextBox();
            this.txtCo = new System.Windows.Forms.TextBox();
            this.txtMaSoBC = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dateBamChi = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChiSo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSNhapBamChi = new System.Windows.Forms.DataGridView();
            this.MaCTBC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSNhapBamChi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(363, 5);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(89, 25);
            this.txtMaDon.TabIndex = 1;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(296, 8);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 17);
            this.label21.TabIndex = 0;
            this.label21.Text = "Mã Đơn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtGiaBieu);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 116);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(531, 53);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(89, 25);
            this.txtDinhMuc.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 17);
            this.label10.TabIndex = 8;
            this.label10.Text = "Định Mức:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(98, 84);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(522, 25);
            this.txtDiaChi.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Địa Chỉ:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(358, 22);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(89, 25);
            this.txtHopDong.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "Hợp Đồng:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(531, 22);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(89, 25);
            this.txtGiaBieu.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Giá Biểu:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 53);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(350, 25);
            this.txtHoTen.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(98, 22);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(134, 25);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Danh Bộ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtMucDichSuDung);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cmbChiKhoaGoc);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSoThan);
            this.groupBox2.Controls.Add(this.cmbChiMatSo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtTheoYeuCau);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtDayChi);
            this.groupBox2.Controls.Add(this.cmbTinhTrangChiSo);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtVienChi);
            this.groupBox2.Controls.Add(this.cmbTinhTrangKiemTra);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.cmbTrangThai);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtHieu);
            this.groupBox2.Controls.Add(this.txtCo);
            this.groupBox2.Controls.Add(this.txtMaSoBC);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dateBamChi);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtChiSo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(957, 125);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả";
            // 
            // txtMucDichSuDung
            // 
            this.txtMucDichSuDung.Location = new System.Drawing.Point(11, 90);
            this.txtMucDichSuDung.Name = "txtMucDichSuDung";
            this.txtMucDichSuDung.Size = new System.Drawing.Size(212, 25);
            this.txtMucDichSuDung.TabIndex = 19;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 70);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(123, 17);
            this.label22.TabIndex = 18;
            this.label22.Text = "Mục Đích Sử Dụng";
            // 
            // cmbChiKhoaGoc
            // 
            this.cmbChiKhoaGoc.FormattingEnabled = true;
            this.cmbChiKhoaGoc.Items.AddRange(new object[] {
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiKhoaGoc.Location = new System.Drawing.Point(857, 41);
            this.cmbChiKhoaGoc.Name = "cmbChiKhoaGoc";
            this.cmbChiKhoaGoc.Size = new System.Drawing.Size(70, 25);
            this.cmbChiKhoaGoc.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(854, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 16;
            this.label1.Text = "Chì Khóa Góc";
            // 
            // txtSoThan
            // 
            this.txtSoThan.Location = new System.Drawing.Point(678, 41);
            this.txtSoThan.Name = "txtSoThan";
            this.txtSoThan.Size = new System.Drawing.Size(97, 25);
            this.txtSoThan.TabIndex = 13;
            // 
            // cmbChiMatSo
            // 
            this.cmbChiMatSo.FormattingEnabled = true;
            this.cmbChiMatSo.Items.AddRange(new object[] {
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiMatSo.Location = new System.Drawing.Point(781, 41);
            this.cmbChiMatSo.Name = "cmbChiMatSo";
            this.cmbChiMatSo.Size = new System.Drawing.Size(70, 25);
            this.cmbChiMatSo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(676, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Số Thân:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(643, 70);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(164, 17);
            this.label17.TabIndex = 28;
            this.label17.Text = "Thực Hiện Theo Yêu Cầu:";
            // 
            // txtTheoYeuCau
            // 
            this.txtTheoYeuCau.Location = new System.Drawing.Point(646, 90);
            this.txtTheoYeuCau.Name = "txtTheoYeuCau";
            this.txtTheoYeuCau.Size = new System.Drawing.Size(281, 25);
            this.txtTheoYeuCau.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(574, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 26;
            this.label4.Text = "Dây Chì";
            // 
            // txtDayChi
            // 
            this.txtDayChi.Location = new System.Drawing.Point(577, 90);
            this.txtDayChi.Name = "txtDayChi";
            this.txtDayChi.Size = new System.Drawing.Size(50, 25);
            this.txtDayChi.TabIndex = 27;
            this.txtDayChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDayChi_KeyPress);
            // 
            // cmbTinhTrangChiSo
            // 
            this.cmbTinhTrangChiSo.FormattingEnabled = true;
            this.cmbTinhTrangChiSo.Items.AddRange(new object[] {
            "Chạy",
            "NCN",
            "Chạy lết",
            "Chạy ngược",
            "Kẹt số",
            "Tuôn số",
            "Không nước",
            "Kiếng mờ"});
            this.cmbTinhTrangChiSo.Location = new System.Drawing.Point(356, 42);
            this.cmbTinhTrangChiSo.Name = "cmbTinhTrangChiSo";
            this.cmbTinhTrangChiSo.Size = new System.Drawing.Size(165, 25);
            this.cmbTinhTrangChiSo.TabIndex = 7;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(353, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(115, 17);
            this.label19.TabIndex = 6;
            this.label19.Text = "Tình Trạng Chỉ Số";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(502, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 17);
            this.label13.TabIndex = 24;
            this.label13.Text = "Viên Chì";
            // 
            // txtVienChi
            // 
            this.txtVienChi.Location = new System.Drawing.Point(505, 90);
            this.txtVienChi.Name = "txtVienChi";
            this.txtVienChi.Size = new System.Drawing.Size(50, 25);
            this.txtVienChi.TabIndex = 25;
            this.txtVienChi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVienChi_KeyPress);
            // 
            // cmbTinhTrangKiemTra
            // 
            this.cmbTinhTrangKiemTra.FormattingEnabled = true;
            this.cmbTinhTrangKiemTra.Items.AddRange(new object[] {
            "Nhà đóng cửa",
            "Nhà có tang, trẻ em, người già",
            "Bấm chì ĐHN",
            "BB chạy ngược",
            "BB mất ĐHN bồi thường",
            "BB mất ĐHN không bồi thường",
            "BB đứt chì MS bồi thường",
            "BB đứt chì MS không bồi thường",
            "BB sai kỹ thuật",
            "BB gian lận ĐHN",
            "BB phối hợp gian lận nước"});
            this.cmbTinhTrangKiemTra.Location = new System.Drawing.Point(106, 42);
            this.cmbTinhTrangKiemTra.Name = "cmbTinhTrangKiemTra";
            this.cmbTinhTrangKiemTra.Size = new System.Drawing.Size(188, 25);
            this.cmbTinhTrangKiemTra.TabIndex = 3;
            this.cmbTinhTrangKiemTra.SelectedIndexChanged += new System.EventHandler(this.cmbTinhTrangKiemTra_SelectedIndexChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(778, 21);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 17);
            this.label20.TabIndex = 14;
            this.label20.Text = "Chì Mặt Số";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(103, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(132, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Tình Trạng Kiểm Tra";
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Bấm Chì Góc - COUDE",
            "Bấm Chì Thân",
            "Đóng Cửa",
            "Lấp Chừa Mặt Số",
            "Còn Chì",
            "Đóng Nước",
            "Mở Nước",
            "Hầm Sâu",
            "Trở Ngại Khác"});
            this.cmbTrangThai.Location = new System.Drawing.Point(229, 90);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(161, 25);
            this.cmbTrangThai.TabIndex = 21;
            this.cmbTrangThai.SelectedIndexChanged += new System.EventHandler(this.cmbTrangThai_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(619, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 10;
            this.label12.Text = "Cỡ:";
            // 
            // txtHieu
            // 
            this.txtHieu.Location = new System.Drawing.Point(527, 41);
            this.txtHieu.Name = "txtHieu";
            this.txtHieu.Size = new System.Drawing.Size(89, 25);
            this.txtHieu.TabIndex = 9;
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(622, 41);
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(50, 25);
            this.txtCo.TabIndex = 11;
            this.txtCo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCo_KeyPress);
            // 
            // txtMaSoBC
            // 
            this.txtMaSoBC.Location = new System.Drawing.Point(396, 90);
            this.txtMaSoBC.Name = "txtMaSoBC";
            this.txtMaSoBC.Size = new System.Drawing.Size(89, 25);
            this.txtMaSoBC.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(528, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 17);
            this.label15.TabIndex = 8;
            this.label15.Text = "Hiệu:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(393, 70);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Mã Số Bấm Chì";
            // 
            // dateBamChi
            // 
            this.dateBamChi.CustomFormat = "dd/MM/yyyy";
            this.dateBamChi.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBamChi.Location = new System.Drawing.Point(11, 42);
            this.dateBamChi.Name = "dateBamChi";
            this.dateBamChi.Size = new System.Drawing.Size(89, 25);
            this.dateBamChi.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(96, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Ngày Bấm Chì";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(226, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Trạng Thái";
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(300, 42);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(50, 25);
            this.txtChiSo.TabIndex = 5;
            this.txtChiSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChiSo_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 17);
            this.label14.TabIndex = 4;
            this.label14.Text = "Chỉ Số:";
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(904, 92);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 35);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(658, 92);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSNhapBamChi
            // 
            this.dgvDSNhapBamChi.AllowUserToAddRows = false;
            this.dgvDSNhapBamChi.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSNhapBamChi.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSNhapBamChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSNhapBamChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTBC,
            this.ToXuLy,
            this.MaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.NguoiDi});
            this.dgvDSNhapBamChi.Location = new System.Drawing.Point(12, 289);
            this.dgvDSNhapBamChi.Name = "dgvDSNhapBamChi";
            this.dgvDSNhapBamChi.Size = new System.Drawing.Size(1013, 254);
            this.dgvDSNhapBamChi.TabIndex = 6;
            this.dgvDSNhapBamChi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSNhapBamChi_CellContentClick);
            this.dgvDSNhapBamChi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSNhapBamChi_CellFormatting);
            this.dgvDSNhapBamChi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSNhapBamChi_RowPostPaint);
            // 
            // MaCTBC
            // 
            this.MaCTBC.DataPropertyName = "MaCTBC";
            this.MaCTBC.HeaderText = "MaCTKTXM";
            this.MaCTBC.Name = "MaCTBC";
            this.MaCTBC.Visible = false;
            // 
            // ToXuLy
            // 
            this.ToXuLy.DataPropertyName = "ToXuLy";
            this.ToXuLy.HeaderText = "TXL";
            this.ToXuLy.Name = "ToXuLy";
            this.ToXuLy.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ToXuLy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ToXuLy.Width = 50;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            this.MaDon.ReadOnly = true;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Khách Hàng";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 200;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 300;
            // 
            // NguoiDi
            // 
            this.NguoiDi.DataPropertyName = "CreateBy";
            this.NguoiDi.HeaderText = "Người Đi";
            this.NguoiDi.Name = "NguoiDi";
            this.NguoiDi.ReadOnly = true;
            this.NguoiDi.Width = 200;
            // 
            // frmBamChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1038, 552);
            this.Controls.Add(this.dgvDSNhapBamChi);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBamChi";
            this.Text = "Nhập Bấm Chì";
            this.Load += new System.EventHandler(this.frmNhapBamChi_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSNhapBamChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTheoYeuCau;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtMaSoBC;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateBamChi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDayChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVienChi;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChiSo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHieu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSNhapBamChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTBC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiDi;
        private System.Windows.Forms.ComboBox cmbTinhTrangKiemTra;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cmbTinhTrangChiSo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtSoThan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbChiKhoaGoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChiMatSo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtMucDichSuDung;
        private System.Windows.Forms.Label label22;
    }
}