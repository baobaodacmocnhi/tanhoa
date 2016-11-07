namespace KTKS_DonKH.GUI.CatHuyDanhBo
{
    partial class frmCTDB
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
            this.components = new System.ComponentModel.Container();
            this.txtMaDon = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxNoiDungXuLy = new System.Windows.Forms.GroupBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.chkNgayXuLy = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cmbNoiDung = new System.Windows.Forms.ComboBox();
            this.dateXuLy = new System.Windows.Forms.DateTimePicker();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLyDo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInPhieu = new System.Windows.Forms.Button();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtHieuLucKy = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.txtNoiDungGhiChu = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dateLap = new System.Windows.Forms.DateTimePicker();
            this.groupBoxGhiChu = new System.Windows.Forms.GroupBox();
            this.btnGhiChu = new System.Windows.Forms.Button();
            this.dgvGhiChu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label28 = new System.Windows.Forms.Label();
            this.txtMaThongBao = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label22 = new System.Windows.Forms.Label();
            this.dgvLichSuCHDB = new System.Windows.Forms.DataGridView();
            this.Loai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayXuLy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LyDo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.lstMa = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label24 = new System.Windows.Forms.Label();
            this.txtDenMa = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtTuMa = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnLuuNhieu = new System.Windows.Forms.Button();
            this.radTXL = new System.Windows.Forms.RadioButton();
            this.radToKH = new System.Windows.Forms.RadioButton();
            this.btnInThongBao = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBoxNoiDungXuLy.SuspendLayout();
            this.groupBoxGhiChu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuCHDB)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(341, 11);
            this.txtMaDon.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 22);
            this.txtMaDon.TabIndex = 1;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(280, 14);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 16);
            this.label21.TabIndex = 0;
            this.label21.Text = "Mã Đơn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(853, 70);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(430, 41);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(415, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(223, 41);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(199, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(118, 41);
            this.txtHopDong.Margin = new System.Windows.Forms.Padding(2);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(10, 41);
            this.txtDanhBo.Margin = new System.Windows.Forms.Padding(2);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // groupBoxNoiDungXuLy
            // 
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtNoiDung);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label11);
            this.groupBoxNoiDungXuLy.Controls.Add(this.chkNgayXuLy);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label19);
            this.groupBoxNoiDungXuLy.Controls.Add(this.cmbNoiDung);
            this.groupBoxNoiDungXuLy.Controls.Add(this.dateXuLy);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtSoTien);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label7);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtGhiChu);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label6);
            this.groupBoxNoiDungXuLy.Controls.Add(this.cmbLyDo);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label5);
            this.groupBoxNoiDungXuLy.Controls.Add(this.btnInPhieu);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtNoiNhan);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label14);
            this.groupBoxNoiDungXuLy.Controls.Add(this.label17);
            this.groupBoxNoiDungXuLy.Controls.Add(this.txtHieuLucKy);
            this.groupBoxNoiDungXuLy.Location = new System.Drawing.Point(11, 111);
            this.groupBoxNoiDungXuLy.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxNoiDungXuLy.Name = "groupBoxNoiDungXuLy";
            this.groupBoxNoiDungXuLy.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxNoiDungXuLy.Size = new System.Drawing.Size(853, 292);
            this.groupBoxNoiDungXuLy.TabIndex = 5;
            this.groupBoxNoiDungXuLy.TabStop = false;
            this.groupBoxNoiDungXuLy.Text = "Nội Dung Xử Lý";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.AllowDrop = true;
            this.txtNoiDung.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(82, 84);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(610, 141);
            this.txtNoiDung.TabIndex = 61;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 60;
            this.label11.Text = "Nội Dung:";
            // 
            // chkNgayXuLy
            // 
            this.chkNgayXuLy.AutoSize = true;
            this.chkNgayXuLy.Location = new System.Drawing.Point(81, 230);
            this.chkNgayXuLy.Margin = new System.Windows.Forms.Padding(2);
            this.chkNgayXuLy.Name = "chkNgayXuLy";
            this.chkNgayXuLy.Size = new System.Drawing.Size(98, 20);
            this.chkNgayXuLy.TabIndex = 15;
            this.chkNgayXuLy.Text = "Ngày Xử Lý:";
            this.chkNgayXuLy.UseVisualStyleBackColor = true;
            this.chkNgayXuLy.CheckedChanged += new System.EventHandler(this.chkNgayXuLy_CheckedChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(78, 259);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(67, 16);
            this.label19.TabIndex = 59;
            this.label19.Text = "Nội Dung:";
            // 
            // cmbNoiDung
            // 
            this.cmbNoiDung.Enabled = false;
            this.cmbNoiDung.FormattingEnabled = true;
            this.cmbNoiDung.Location = new System.Drawing.Point(183, 256);
            this.cmbNoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.cmbNoiDung.Name = "cmbNoiDung";
            this.cmbNoiDung.Size = new System.Drawing.Size(194, 24);
            this.cmbNoiDung.TabIndex = 58;
            // 
            // dateXuLy
            // 
            this.dateXuLy.CustomFormat = "dd/MM/yyyy";
            this.dateXuLy.Enabled = false;
            this.dateXuLy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateXuLy.Location = new System.Drawing.Point(183, 230);
            this.dateXuLy.Margin = new System.Windows.Forms.Padding(2);
            this.dateXuLy.Name = "dateXuLy";
            this.dateXuLy.Size = new System.Drawing.Size(90, 22);
            this.dateXuLy.TabIndex = 16;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(591, 31);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(2);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSoTien.Size = new System.Drawing.Size(100, 22);
            this.txtSoTien.TabIndex = 3;
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            this.txtSoTien.Leave += new System.EventHandler(this.txtSoTien_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(531, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Số Tiền:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(81, 57);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(335, 22);
            this.txtGhiChu.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Ghi Chú:";
            // 
            // cmbLyDo
            // 
            this.cmbLyDo.FormattingEnabled = true;
            this.cmbLyDo.Location = new System.Drawing.Point(81, 29);
            this.cmbLyDo.Margin = new System.Windows.Forms.Padding(2);
            this.cmbLyDo.Name = "cmbLyDo";
            this.cmbLyDo.Size = new System.Drawing.Size(446, 24);
            this.cmbLyDo.TabIndex = 1;
            this.cmbLyDo.SelectedIndexChanged += new System.EventHandler(this.cmbLyDo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Lý Do:";
            // 
            // btnInPhieu
            // 
            this.btnInPhieu.Location = new System.Drawing.Point(725, 254);
            this.btnInPhieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnInPhieu.Name = "btnInPhieu";
            this.btnInPhieu.Size = new System.Drawing.Size(120, 25);
            this.btnInPhieu.TabIndex = 13;
            this.btnInPhieu.Text = "In Phiếu Hủy DB";
            this.btnInPhieu.UseVisualStyleBackColor = true;
            this.btnInPhieu.Click += new System.EventHandler(this.btnInPhieu_Click);
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(697, 84);
            this.txtNoiNhan.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(149, 141);
            this.txtNoiNhan.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(702, 231);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 16);
            this.label14.TabIndex = 11;
            this.label14.Text = "Hiệu Lực Kỳ:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(694, 66);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 16);
            this.label17.TabIndex = 11;
            this.label17.Text = "Nơi Nhận:";
            // 
            // txtHieuLucKy
            // 
            this.txtHieuLucKy.Location = new System.Drawing.Point(787, 228);
            this.txtHieuLucKy.Margin = new System.Windows.Forms.Padding(2);
            this.txtHieuLucKy.Name = "txtHieuLucKy";
            this.txtHieuLucKy.Size = new System.Drawing.Size(58, 22);
            this.txtHieuLucKy.TabIndex = 12;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(868, 253);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 62;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(868, 195);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(868, 224);
            this.btnSua.Margin = new System.Windows.Forms.Padding(2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // txtNoiDungGhiChu
            // 
            this.txtNoiDungGhiChu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiDungGhiChu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiDungGhiChu.Location = new System.Drawing.Point(82, 51);
            this.txtNoiDungGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.txtNoiDungGhiChu.Name = "txtNoiDungGhiChu";
            this.txtNoiDungGhiChu.Size = new System.Drawing.Size(386, 22);
            this.txtNoiDungGhiChu.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Nội Dung:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 27);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Ngày Lập:";
            // 
            // dateLap
            // 
            this.dateLap.CustomFormat = "dd/MM/yyyy";
            this.dateLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateLap.Location = new System.Drawing.Point(82, 22);
            this.dateLap.Margin = new System.Windows.Forms.Padding(2);
            this.dateLap.Name = "dateLap";
            this.dateLap.Size = new System.Drawing.Size(90, 22);
            this.dateLap.TabIndex = 1;
            // 
            // groupBoxGhiChu
            // 
            this.groupBoxGhiChu.Controls.Add(this.btnGhiChu);
            this.groupBoxGhiChu.Controls.Add(this.dateLap);
            this.groupBoxGhiChu.Controls.Add(this.label9);
            this.groupBoxGhiChu.Controls.Add(this.label8);
            this.groupBoxGhiChu.Controls.Add(this.txtNoiDungGhiChu);
            this.groupBoxGhiChu.Controls.Add(this.dgvGhiChu);
            this.groupBoxGhiChu.Controls.Add(this.label28);
            this.groupBoxGhiChu.Location = new System.Drawing.Point(11, 409);
            this.groupBoxGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxGhiChu.Name = "groupBoxGhiChu";
            this.groupBoxGhiChu.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxGhiChu.Size = new System.Drawing.Size(575, 220);
            this.groupBoxGhiChu.TabIndex = 7;
            this.groupBoxGhiChu.TabStop = false;
            this.groupBoxGhiChu.Text = "Ghi Chú";
            // 
            // btnGhiChu
            // 
            this.btnGhiChu.Location = new System.Drawing.Point(472, 50);
            this.btnGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.btnGhiChu.Name = "btnGhiChu";
            this.btnGhiChu.Size = new System.Drawing.Size(75, 25);
            this.btnGhiChu.TabIndex = 0;
            this.btnGhiChu.Text = "Ghi Chú";
            this.btnGhiChu.UseVisualStyleBackColor = true;
            this.btnGhiChu.Click += new System.EventHandler(this.btnGhiChu_Click);
            // 
            // dgvGhiChu
            // 
            this.dgvGhiChu.AllowUserToAddRows = false;
            this.dgvGhiChu.AllowUserToDeleteRows = false;
            this.dgvGhiChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhiChu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayLap,
            this.NoiDung,
            this.NoiNhan,
            this.GhiChu});
            this.dgvGhiChu.Location = new System.Drawing.Point(6, 77);
            this.dgvGhiChu.Margin = new System.Windows.Forms.Padding(2);
            this.dgvGhiChu.Name = "dgvGhiChu";
            this.dgvGhiChu.ReadOnly = true;
            this.dgvGhiChu.Size = new System.Drawing.Size(562, 140);
            this.dgvGhiChu.TabIndex = 14;
            this.dgvGhiChu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvLichSuXuLy_CellMouseClick);
            this.dgvGhiChu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuXuLy_RowPostPaint);
            this.dgvGhiChu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvLichSuXuLy_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NgayLap
            // 
            this.NgayLap.DataPropertyName = "NgayLap";
            this.NgayLap.HeaderText = "Ngày Lập";
            this.NgayLap.Name = "NgayLap";
            this.NgayLap.ReadOnly = true;
            this.NgayLap.Width = 90;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 200;
            // 
            // NoiNhan
            // 
            this.NoiNhan.DataPropertyName = "NoiNhan";
            this.NoiNhan.HeaderText = "Nơi Nhận";
            this.NoiNhan.Name = "NoiNhan";
            this.NoiNhan.ReadOnly = true;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.ReadOnly = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(176, 27);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(170, 16);
            this.label28.TabIndex = 57;
            this.label28.Text = "Chuột Phải để XÓA Ghi Chú";
            // 
            // txtMaThongBao
            // 
            this.txtMaThongBao.Location = new System.Drawing.Point(549, 11);
            this.txtMaThongBao.Margin = new System.Windows.Forms.Padding(2);
            this.txtMaThongBao.Name = "txtMaThongBao";
            this.txtMaThongBao.Size = new System.Drawing.Size(100, 22);
            this.txtMaThongBao.TabIndex = 3;
            this.txtMaThongBao.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaThongBao_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(445, 14);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Mã Thông Báo:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(180, 10);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 18);
            this.label22.TabIndex = 61;
            this.label22.Text = "Cắt Tạm";
            // 
            // dgvLichSuCHDB
            // 
            this.dgvLichSuCHDB.AllowUserToAddRows = false;
            this.dgvLichSuCHDB.AllowUserToDeleteRows = false;
            this.dgvLichSuCHDB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuCHDB.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Loai,
            this.Ma,
            this.CreateDate,
            this.NgayXuLy,
            this.DanhBo,
            this.LyDo});
            this.dgvLichSuCHDB.Location = new System.Drawing.Point(593, 486);
            this.dgvLichSuCHDB.Margin = new System.Windows.Forms.Padding(2);
            this.dgvLichSuCHDB.Name = "dgvLichSuCHDB";
            this.dgvLichSuCHDB.ReadOnly = true;
            this.dgvLichSuCHDB.Size = new System.Drawing.Size(699, 141);
            this.dgvLichSuCHDB.TabIndex = 62;
            this.dgvLichSuCHDB.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuCHDB_CellFormatting);
            this.dgvLichSuCHDB.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvLichSuCHDB_RowPostPaint);
            // 
            // Loai
            // 
            this.Loai.DataPropertyName = "Loai";
            this.Loai.HeaderText = "Loại";
            this.Loai.Name = "Loai";
            this.Loai.ReadOnly = true;
            this.Loai.Width = 70;
            // 
            // Ma
            // 
            this.Ma.DataPropertyName = "Ma";
            this.Ma.HeaderText = "Mã";
            this.Ma.Name = "Ma";
            this.Ma.ReadOnly = true;
            this.Ma.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            this.CreateDate.Width = 90;
            // 
            // NgayXuLy
            // 
            this.NgayXuLy.DataPropertyName = "NgayXuLy";
            this.NgayXuLy.HeaderText = "Ngày Xử Lý";
            this.NgayXuLy.Name = "NgayXuLy";
            this.NgayXuLy.ReadOnly = true;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            this.DanhBo.ReadOnly = true;
            // 
            // LyDo
            // 
            this.LyDo.DataPropertyName = "LyDo";
            this.LyDo.HeaderText = "Lý Do";
            this.LyDo.Name = "LyDo";
            this.LyDo.ReadOnly = true;
            this.LyDo.Width = 200;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(965, 103);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 16);
            this.label20.TabIndex = 105;
            this.label20.Text = "(enter)";
            // 
            // lstMa
            // 
            this.lstMa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstMa.Location = new System.Drawing.Point(1020, 48);
            this.lstMa.Name = "lstMa";
            this.lstMa.Size = new System.Drawing.Size(132, 159);
            this.lstMa.TabIndex = 104;
            this.lstMa.UseCompatibleStateImageBehavior = false;
            this.lstMa.View = System.Windows.Forms.View.Details;
            this.lstMa.SelectedIndexChanged += new System.EventHandler(this.lstMa_SelectedIndexChanged);
            this.lstMa.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstMa_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            this.columnHeader1.Width = 100;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(1016, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 16);
            this.label24.TabIndex = 103;
            this.label24.Text = "Danh Sách:";
            // 
            // txtDenMa
            // 
            this.txtDenMa.Location = new System.Drawing.Point(888, 101);
            this.txtDenMa.Name = "txtDenMa";
            this.txtDenMa.Size = new System.Drawing.Size(70, 22);
            this.txtDenMa.TabIndex = 102;
            this.txtDenMa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDenMa_KeyPress);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(885, 82);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(57, 16);
            this.label25.TabIndex = 101;
            this.label25.Text = "Đến Mã:";
            // 
            // txtTuMa
            // 
            this.txtTuMa.Location = new System.Drawing.Point(888, 56);
            this.txtTuMa.Name = "txtTuMa";
            this.txtTuMa.Size = new System.Drawing.Size(70, 22);
            this.txtTuMa.TabIndex = 100;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(885, 38);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 16);
            this.label26.TabIndex = 99;
            this.label26.Text = "Từ Mã:";
            // 
            // btnLuuNhieu
            // 
            this.btnLuuNhieu.Location = new System.Drawing.Point(1158, 128);
            this.btnLuuNhieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLuuNhieu.Name = "btnLuuNhieu";
            this.btnLuuNhieu.Size = new System.Drawing.Size(75, 25);
            this.btnLuuNhieu.TabIndex = 106;
            this.btnLuuNhieu.Text = "Lưu Nhiều";
            this.btnLuuNhieu.UseVisualStyleBackColor = true;
            this.btnLuuNhieu.Click += new System.EventHandler(this.btnLuuNhieu_Click);
            // 
            // radTXL
            // 
            this.radTXL.AutoSize = true;
            this.radTXL.Location = new System.Drawing.Point(1159, 74);
            this.radTXL.Name = "radTXL";
            this.radTXL.Size = new System.Drawing.Size(78, 20);
            this.radTXL.TabIndex = 111;
            this.radTXL.TabStop = true;
            this.radTXL.Text = "Tổ Xử Lý";
            this.radTXL.UseVisualStyleBackColor = true;
            // 
            // radToKH
            // 
            this.radToKH.AutoSize = true;
            this.radToKH.Checked = true;
            this.radToKH.Location = new System.Drawing.Point(1159, 48);
            this.radToKH.Name = "radToKH";
            this.radToKH.Size = new System.Drawing.Size(64, 20);
            this.radToKH.TabIndex = 110;
            this.radToKH.TabStop = true;
            this.radToKH.Text = "Tổ KH";
            this.radToKH.UseVisualStyleBackColor = true;
            // 
            // btnInThongBao
            // 
            this.btnInThongBao.Location = new System.Drawing.Point(868, 282);
            this.btnInThongBao.Margin = new System.Windows.Forms.Padding(2);
            this.btnInThongBao.Name = "btnInThongBao";
            this.btnInThongBao.Size = new System.Drawing.Size(100, 25);
            this.btnInThongBao.TabIndex = 112;
            this.btnInThongBao.Text = "In Thông Báo";
            this.btnInThongBao.UseVisualStyleBackColor = true;
            this.btnInThongBao.Click += new System.EventHandler(this.btnInThongBao_Click);
            // 
            // frmCTDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1298, 638);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnInThongBao);
            this.Controls.Add(this.radTXL);
            this.Controls.Add(this.radToKH);
            this.Controls.Add(this.btnLuuNhieu);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lstMa);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDenMa);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtTuMa);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.dgvLichSuCHDB);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtMaThongBao);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBoxGhiChu);
            this.Controls.Add(this.groupBoxNoiDungXuLy);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCTDB";
            this.Text = "Cắt Tạm Danh Bộ";
            this.Load += new System.EventHandler(this.frmCTDB_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxNoiDungXuLy.ResumeLayout(false);
            this.groupBoxNoiDungXuLy.PerformLayout();
            this.groupBoxGhiChu.ResumeLayout(false);
            this.groupBoxGhiChu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuCHDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxNoiDungXuLy;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLyDo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNoiDungGhiChu;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateLap;
        private System.Windows.Forms.GroupBox groupBoxGhiChu;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnGhiChu;
        private System.Windows.Forms.TextBox txtMaThongBao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInPhieu;
        private System.Windows.Forms.TextBox txtHieuLucKy;
        private System.Windows.Forms.DataGridView dgvGhiChu;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cmbNoiDung;
        private System.Windows.Forms.DateTimePicker dateXuLy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chkNgayXuLy;
        private System.Windows.Forms.DataGridView dgvLichSuCHDB;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ListView lstMa;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtDenMa;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtTuMa;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnLuuNhieu;
        private System.Windows.Forms.RadioButton radTXL;
        private System.Windows.Forms.RadioButton radToKH;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Loai;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ma;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayXuLy;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LyDo;
        private System.Windows.Forms.Button btnInThongBao;
    }
}