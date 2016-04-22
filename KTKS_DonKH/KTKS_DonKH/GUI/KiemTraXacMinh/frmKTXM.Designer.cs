namespace KTKS_DonKH.GUI.KiemTraXacMinh
{
    partial class frmKTXM
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
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNoiDungKiemTra = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvDSKetQuaKiemTra = new System.Windows.Forms.DataGridView();
            this.MaCTKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToXuLy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDungKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txtTieuThuTrungBinh = new System.Windows.Forms.TextBox();
            this.cmbViTriDHN2 = new System.Windows.Forms.ComboBox();
            this.cmbViTriDHN1 = new System.Windows.Forms.ComboBox();
            this.lbTheoYeuCau = new System.Windows.Forms.Label();
            this.txtTheoYeuCau = new System.Windows.Forms.TextBox();
            this.cmbChiKhoaGoc = new System.Windows.Forms.ComboBox();
            this.cmbChiMatSo = new System.Windows.Forms.ComboBox();
            this.cmbTinhTrangChiSo = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbHienTrangKiemTra = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtHoTenKHKy = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dateKTXM = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoThan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMucDichSuDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChiSo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHieu = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbTinhTrangDHN = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).BeginInit();
            this.groupBox2.SuspendLayout();
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
            this.txtDinhMuc.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(454, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 17);
            this.label10.TabIndex = 26;
            this.label10.Text = "Định Mức:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(98, 84);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(522, 25);
            this.txtDiaChi.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Địa Chỉ:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(358, 22);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(89, 25);
            this.txtHopDong.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(279, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Hợp Đồng:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(531, 22);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(89, 25);
            this.txtGiaBieu.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(454, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 17);
            this.label7.TabIndex = 22;
            this.label7.Text = "Giá Biểu:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 53);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(350, 25);
            this.txtHoTen.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(98, 22);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(134, 25);
            this.txtDanhBo.TabIndex = 15;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 14;
            this.label2.Text = "Danh Bộ:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(540, 73);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(89, 25);
            this.txtDienThoai.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(430, 76);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 17);
            this.label11.TabIndex = 23;
            this.label11.Text = "Điện Thoại:";
            // 
            // txtNoiDungKiemTra
            // 
            this.txtNoiDungKiemTra.Location = new System.Drawing.Point(753, 42);
            this.txtNoiDungKiemTra.Multiline = true;
            this.txtNoiDungKiemTra.Name = "txtNoiDungKiemTra";
            this.txtNoiDungKiemTra.Size = new System.Drawing.Size(375, 87);
            this.txtNoiDungKiemTra.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(750, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nội Dung Kiểm Tra:";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::KTKS_DonKH.Properties.Resources.add_24x24;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(815, 335);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(77, 35);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // dgvDSKetQuaKiemTra
            // 
            this.dgvDSKetQuaKiemTra.AllowUserToAddRows = false;
            this.dgvDSKetQuaKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKetQuaKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKetQuaKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTKTXM,
            this.ToXuLy,
            this.MaDon,
            this.DanhBo,
            this.NoiDungKiemTra,
            this.CreateBy});
            this.dgvDSKetQuaKiemTra.Location = new System.Drawing.Point(12, 335);
            this.dgvDSKetQuaKiemTra.Name = "dgvDSKetQuaKiemTra";
            this.dgvDSKetQuaKiemTra.Size = new System.Drawing.Size(760, 134);
            this.dgvDSKetQuaKiemTra.TabIndex = 6;
            this.dgvDSKetQuaKiemTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSKetQuaKiemTra_CellContentClick);
            this.dgvDSKetQuaKiemTra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDSKetQuaKiemTra_CellFormatting);
            this.dgvDSKetQuaKiemTra.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDSKetQuaKiemTra_RowPostPaint);
            // 
            // MaCTKTXM
            // 
            this.MaCTKTXM.DataPropertyName = "MaCTKTXM";
            this.MaCTKTXM.HeaderText = "MaCTKTXM";
            this.MaCTKTXM.Name = "MaCTKTXM";
            this.MaCTKTXM.Visible = false;
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
            // NoiDungKiemTra
            // 
            this.NoiDungKiemTra.DataPropertyName = "NoiDungKiemTra";
            this.NoiDungKiemTra.HeaderText = "Kết Qủa";
            this.NoiDungKiemTra.Name = "NoiDungKiemTra";
            this.NoiDungKiemTra.ReadOnly = true;
            this.NoiDungKiemTra.Width = 250;
            // 
            // CreateBy
            // 
            this.CreateBy.DataPropertyName = "CreateBy";
            this.CreateBy.HeaderText = "Người Thực Hiện";
            this.CreateBy.Name = "CreateBy";
            this.CreateBy.ReadOnly = true;
            this.CreateBy.Width = 200;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.txtTieuThuTrungBinh);
            this.groupBox2.Controls.Add(this.cmbViTriDHN2);
            this.groupBox2.Controls.Add(this.cmbViTriDHN1);
            this.groupBox2.Controls.Add(this.lbTheoYeuCau);
            this.groupBox2.Controls.Add(this.txtTheoYeuCau);
            this.groupBox2.Controls.Add(this.cmbChiKhoaGoc);
            this.groupBox2.Controls.Add(this.cmbChiMatSo);
            this.groupBox2.Controls.Add(this.cmbTinhTrangChiSo);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.cmbHienTrangKiemTra);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.txtHoTenKHKy);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtDienThoai);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtNoiDungKiemTra);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.dateKTXM);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txtSoThan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMucDichSuDung);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtChiSo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtHieu);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1137, 171);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(897, 138);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(132, 17);
            this.label24.TabIndex = 31;
            this.label24.Text = "Tiêu Thụ Trung Bình:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(305, 22);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(123, 17);
            this.label23.TabIndex = 4;
            this.label23.Text = "Vị Trí ĐHN lắp đặt";
            // 
            // txtTieuThuTrungBinh
            // 
            this.txtTieuThuTrungBinh.Location = new System.Drawing.Point(1035, 135);
            this.txtTieuThuTrungBinh.Name = "txtTieuThuTrungBinh";
            this.txtTieuThuTrungBinh.Size = new System.Drawing.Size(93, 25);
            this.txtTieuThuTrungBinh.TabIndex = 32;
            this.txtTieuThuTrungBinh.Text = "0";
            // 
            // cmbViTriDHN2
            // 
            this.cmbViTriDHN2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViTriDHN2.FormattingEnabled = true;
            this.cmbViTriDHN2.Items.AddRange(new object[] {
            "",
            "Trong Sân",
            "Trong Nhà",
            "Vỉa Hè"});
            this.cmbViTriDHN2.Location = new System.Drawing.Point(395, 42);
            this.cmbViTriDHN2.MaxDropDownItems = 50;
            this.cmbViTriDHN2.Name = "cmbViTriDHN2";
            this.cmbViTriDHN2.Size = new System.Drawing.Size(80, 25);
            this.cmbViTriDHN2.TabIndex = 6;
            // 
            // cmbViTriDHN1
            // 
            this.cmbViTriDHN1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViTriDHN1.FormattingEnabled = true;
            this.cmbViTriDHN1.Items.AddRange(new object[] {
            "",
            "Bên Trái",
            "Bên Phải",
            "Ở Giữa"});
            this.cmbViTriDHN1.Location = new System.Drawing.Point(308, 42);
            this.cmbViTriDHN1.MaxDropDownItems = 50;
            this.cmbViTriDHN1.Name = "cmbViTriDHN1";
            this.cmbViTriDHN1.Size = new System.Drawing.Size(80, 25);
            this.cmbViTriDHN1.TabIndex = 5;
            // 
            // lbTheoYeuCau
            // 
            this.lbTheoYeuCau.AutoSize = true;
            this.lbTheoYeuCau.Location = new System.Drawing.Point(583, 138);
            this.lbTheoYeuCau.Name = "lbTheoYeuCau";
            this.lbTheoYeuCau.Size = new System.Drawing.Size(164, 17);
            this.lbTheoYeuCau.TabIndex = 29;
            this.lbTheoYeuCau.Text = "Thực Hiện Theo Yêu Cầu:";
            this.lbTheoYeuCau.Visible = false;
            // 
            // txtTheoYeuCau
            // 
            this.txtTheoYeuCau.Location = new System.Drawing.Point(753, 135);
            this.txtTheoYeuCau.Name = "txtTheoYeuCau";
            this.txtTheoYeuCau.Size = new System.Drawing.Size(138, 25);
            this.txtTheoYeuCau.TabIndex = 30;
            this.txtTheoYeuCau.Visible = false;
            // 
            // cmbChiKhoaGoc
            // 
            this.cmbChiKhoaGoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiKhoaGoc.FormattingEnabled = true;
            this.cmbChiKhoaGoc.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiKhoaGoc.Location = new System.Drawing.Point(308, 104);
            this.cmbChiKhoaGoc.MaxDropDownItems = 50;
            this.cmbChiKhoaGoc.Name = "cmbChiKhoaGoc";
            this.cmbChiKhoaGoc.Size = new System.Drawing.Size(70, 25);
            this.cmbChiKhoaGoc.TabIndex = 20;
            // 
            // cmbChiMatSo
            // 
            this.cmbChiMatSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiMatSo.FormattingEnabled = true;
            this.cmbChiMatSo.Items.AddRange(new object[] {
            "",
            "Còn",
            "Không",
            "Lấp",
            "Mục đứt",
            "Đứt"});
            this.cmbChiMatSo.Location = new System.Drawing.Point(308, 73);
            this.cmbChiMatSo.MaxDropDownItems = 50;
            this.cmbChiMatSo.Name = "cmbChiMatSo";
            this.cmbChiMatSo.Size = new System.Drawing.Size(70, 25);
            this.cmbChiMatSo.TabIndex = 18;
            // 
            // cmbTinhTrangChiSo
            // 
            this.cmbTinhTrangChiSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTinhTrangChiSo.FormattingEnabled = true;
            this.cmbTinhTrangChiSo.Items.AddRange(new object[] {
            "",
            "Chạy",
            "NCN",
            "Chạy lết",
            "Chạy ngược",
            "Kẹt số",
            "Tuôn số",
            "Không nước",
            "Kiếng mờ",
            "Mất ĐHN",
            "Không ĐHN",
            "Lấp mất",
            "Bể kiếng",
            "Mất mặt số",
            "Chủ gỡ",
            "Hầm sâu",
            "Chất đồ",
            "Gắn ngược",
            "Đóng nước",
            "Cắt ống bên ngoài",
            "Kẹt khóa"});
            this.cmbTinhTrangChiSo.Location = new System.Drawing.Point(540, 42);
            this.cmbTinhTrangChiSo.MaxDropDownItems = 50;
            this.cmbTinhTrangChiSo.Name = "cmbTinhTrangChiSo";
            this.cmbTinhTrangChiSo.Size = new System.Drawing.Size(165, 25);
            this.cmbTinhTrangChiSo.TabIndex = 10;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(537, 22);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(128, 17);
            this.label19.TabIndex = 9;
            this.label19.Text = "Chỉ Số lúc Kiểm Tra";
            // 
            // cmbHienTrangKiemTra
            // 
            this.cmbHienTrangKiemTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHienTrangKiemTra.FormattingEnabled = true;
            this.cmbHienTrangKiemTra.Location = new System.Drawing.Point(114, 42);
            this.cmbHienTrangKiemTra.MaxDropDownItems = 50;
            this.cmbHienTrangKiemTra.Name = "cmbHienTrangKiemTra";
            this.cmbHienTrangKiemTra.Size = new System.Drawing.Size(188, 25);
            this.cmbHienTrangKiemTra.TabIndex = 3;
            this.cmbHienTrangKiemTra.SelectedIndexChanged += new System.EventHandler(this.cmbTinhTrangKiemTra_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(111, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(134, 17);
            this.label18.TabIndex = 2;
            this.label18.Text = "Hiện Trạng Kiểm Tra";
            // 
            // txtHoTenKHKy
            // 
            this.txtHoTenKHKy.Location = new System.Drawing.Point(540, 104);
            this.txtHoTenKHKy.Name = "txtHoTenKHKy";
            this.txtHoTenKHKy.Size = new System.Drawing.Size(178, 25);
            this.txtHoTenKHKy.TabIndex = 26;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(430, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(104, 17);
            this.label17.TabIndex = 25;
            this.label17.Text = "Họ Tên KH Ký:";
            // 
            // dateKTXM
            // 
            this.dateKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKTXM.Location = new System.Drawing.Point(11, 42);
            this.dateKTXM.Name = "dateKTXM";
            this.dateKTXM.Size = new System.Drawing.Size(97, 25);
            this.dateKTXM.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 17);
            this.label16.TabIndex = 0;
            this.label16.Text = "Ngày Kiểm Tra";
            // 
            // txtSoThan
            // 
            this.txtSoThan.Location = new System.Drawing.Point(73, 135);
            this.txtSoThan.Name = "txtSoThan";
            this.txtSoThan.Size = new System.Drawing.Size(97, 25);
            this.txtSoThan.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Số Thân:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(176, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Chì Khóa Góc:";
            // 
            // txtMucDichSuDung
            // 
            this.txtMucDichSuDung.Location = new System.Drawing.Point(308, 135);
            this.txtMucDichSuDung.Name = "txtMucDichSuDung";
            this.txtMucDichSuDung.Size = new System.Drawing.Size(231, 25);
            this.txtMucDichSuDung.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Mục Đích Sử Dụng:";
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(73, 104);
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(97, 25);
            this.txtCo.TabIndex = 14;
            this.txtCo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCo_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Cỡ:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(176, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 17);
            this.label13.TabIndex = 17;
            this.label13.Text = "Chì Mặt Số:";
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(481, 42);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(50, 25);
            this.txtChiSo.TabIndex = 8;
            this.txtChiSo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChiSo_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(478, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 17);
            this.label14.TabIndex = 7;
            this.label14.Text = "Chỉ Số";
            // 
            // txtHieu
            // 
            this.txtHieu.Location = new System.Drawing.Point(73, 73);
            this.txtHieu.Name = "txtHieu";
            this.txtHieu.Size = new System.Drawing.Size(97, 25);
            this.txtHieu.TabIndex = 12;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 76);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(39, 17);
            this.label15.TabIndex = 11;
            this.label15.Text = "Hiệu:";
            // 
            // cmbTinhTrangDHN
            // 
            this.cmbTinhTrangDHN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTinhTrangDHN.FormattingEnabled = true;
            this.cmbTinhTrangDHN.Items.AddRange(new object[] {
            "",
            "Còn",
            "Mất",
            "Không ĐHN",
            "Lấp mất",
            "Bể kiếng",
            "Mất mặt số",
            "Chủ gỡ",
            "Hầm sâu",
            "Chất đồ",
            "Gắn ngược",
            "Đóng nước",
            "Cắt ống bên ngoài",
            "Kẹt khóa"});
            this.cmbTinhTrangDHN.Location = new System.Drawing.Point(778, 418);
            this.cmbTinhTrangDHN.MaxDropDownItems = 50;
            this.cmbTinhTrangDHN.Name = "cmbTinhTrangDHN";
            this.cmbTinhTrangDHN.Size = new System.Drawing.Size(165, 25);
            this.cmbTinhTrangDHN.TabIndex = 5;
            this.cmbTinhTrangDHN.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(775, 398);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(122, 17);
            this.label20.TabIndex = 4;
            this.label20.Text = "ĐHN lúc Kiểm Tra";
            this.label20.Visible = false;
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(1080, 335);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 35);
            this.btnSua.TabIndex = 5;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(458, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(445, 17);
            this.label22.TabIndex = 7;
            this.label22.Text = "Gắn mới Danh Bộ nhập theo dạng: GM-Mã Đơn (GM1-14 / GMTXL1-14)";
            // 
            // frmKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1154, 493);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.cmbTinhTrangDHN);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDSKetQuaKiemTra);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmKTXM";
            this.Text = "Kết Quả Kiểm Tra Xác Minh";
            this.Load += new System.EventHandler(this.frmKTXM_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label11;
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
        private System.Windows.Forms.TextBox txtNoiDungKiemTra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvDSKetQuaKiemTra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoThan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMucDichSuDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChiSo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHieu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateKTXM;
        private System.Windows.Forms.TextBox txtHoTenKHKy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.ComboBox cmbTinhTrangDHN;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cmbChiKhoaGoc;
        private System.Windows.Forms.ComboBox cmbChiMatSo;
        private System.Windows.Forms.ComboBox cmbTinhTrangChiSo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbHienTrangKiemTra;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lbTheoYeuCau;
        private System.Windows.Forms.TextBox txtTheoYeuCau;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTKTXM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ToXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDungKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ComboBox cmbViTriDHN2;
        private System.Windows.Forms.ComboBox cmbViTriDHN1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTieuThuTrungBinh;
    }
}