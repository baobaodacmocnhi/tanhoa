namespace KTKS_DonKH.GUI.DongNuoc
{
    partial class frmDongNuoc
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
            this.txtMaThongBao_DN = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiaChiDHN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaDonCu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBoxXuLyDongNuoc = new System.Windows.Forms.GroupBox();
            this.dateDongNuoc = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.btnLapTBDongNuoc = new System.Windows.Forms.Button();
            this.txtQuan_DN = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dateCongVan_DN = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.btnInTBDongNuoc = new System.Windows.Forms.Button();
            this.txtSoCongVan_DN = new System.Windows.Forms.TextBox();
            this.txtPhuong_DN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBoxXuLyMoNuoc = new System.Windows.Forms.GroupBox();
            this.dateMoNuoc = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.btnLapTBMoNuoc = new System.Windows.Forms.Button();
            this.txtHinhThucDN = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnInTBMoNuoc = new System.Windows.Forms.Button();
            this.txtLyDoDN = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtQuan_MN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dateCongVan_MN = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoCongVan_MN = new System.Windows.Forms.TextBox();
            this.txtPhuong_MN = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMaThongBao_MN = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDSBamChi = new System.Windows.Forms.DataGridView();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTDN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTMN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label22 = new System.Windows.Forms.Label();
            this.txtMaDonMoi = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxXuLyDongNuoc.SuspendLayout();
            this.groupBoxXuLyMoNuoc.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSBamChi)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaThongBao_DN
            // 
            this.txtMaThongBao_DN.Location = new System.Drawing.Point(630, 12);
            this.txtMaThongBao_DN.Name = "txtMaThongBao_DN";
            this.txtMaThongBao_DN.Size = new System.Drawing.Size(60, 22);
            this.txtMaThongBao_DN.TabIndex = 3;
            this.txtMaThongBao_DN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaThongBao_DN_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(503, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Mã TB Đóng Nước:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiaChiDHN);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 99);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDiaChiDHN
            // 
            this.txtDiaChiDHN.Location = new System.Drawing.Point(424, 68);
            this.txtDiaChiDHN.Name = "txtDiaChiDHN";
            this.txtDiaChiDHN.Size = new System.Drawing.Size(470, 22);
            this.txtDiaChiDHN.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Địa Chỉ ĐHN:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(424, 40);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(470, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(421, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(218, 40);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(201, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(112, 40);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(6, 40);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ";
            // 
            // txtMaDonCu
            // 
            this.txtMaDonCu.Location = new System.Drawing.Point(248, 12);
            this.txtMaDonCu.Name = "txtMaDonCu";
            this.txtMaDonCu.Size = new System.Drawing.Size(75, 22);
            this.txtMaDonCu.TabIndex = 1;
            this.txtMaDonCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonCu_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 0;
            this.label21.Text = "Mã Đơn Cũ:";
            // 
            // groupBoxXuLyDongNuoc
            // 
            this.groupBoxXuLyDongNuoc.Controls.Add(this.dateDongNuoc);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.label18);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.btnLapTBDongNuoc);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.txtQuan_DN);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.label11);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.dateCongVan_DN);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.label9);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.btnInTBDongNuoc);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.txtSoCongVan_DN);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.txtPhuong_DN);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.label7);
            this.groupBoxXuLyDongNuoc.Controls.Add(this.label8);
            this.groupBoxXuLyDongNuoc.Location = new System.Drawing.Point(12, 145);
            this.groupBoxXuLyDongNuoc.Name = "groupBoxXuLyDongNuoc";
            this.groupBoxXuLyDongNuoc.Size = new System.Drawing.Size(911, 84);
            this.groupBoxXuLyDongNuoc.TabIndex = 5;
            this.groupBoxXuLyDongNuoc.TabStop = false;
            this.groupBoxXuLyDongNuoc.Text = "Xử Lý Đóng Nước";
            // 
            // dateDongNuoc
            // 
            this.dateDongNuoc.CustomFormat = "dd/MM/yyyy";
            this.dateDongNuoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDongNuoc.Location = new System.Drawing.Point(128, 24);
            this.dateDongNuoc.Name = "dateDongNuoc";
            this.dateDongNuoc.Size = new System.Drawing.Size(90, 22);
            this.dateDongNuoc.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(114, 16);
            this.label18.TabIndex = 9;
            this.label18.Text = "Ngày Đóng Nước:";
            // 
            // btnLapTBDongNuoc
            // 
            this.btnLapTBDongNuoc.Location = new System.Drawing.Point(775, 53);
            this.btnLapTBDongNuoc.Name = "btnLapTBDongNuoc";
            this.btnLapTBDongNuoc.Size = new System.Drawing.Size(130, 25);
            this.btnLapTBDongNuoc.TabIndex = 8;
            this.btnLapTBDongNuoc.Text = "Lập TB Đóng Nước";
            this.btnLapTBDongNuoc.UseVisualStyleBackColor = true;
            this.btnLapTBDongNuoc.Click += new System.EventHandler(this.btnLapTBDongNuoc_Click);
            // 
            // txtQuan_DN
            // 
            this.txtQuan_DN.Location = new System.Drawing.Point(660, 52);
            this.txtQuan_DN.Name = "txtQuan_DN";
            this.txtQuan_DN.Size = new System.Drawing.Size(100, 22);
            this.txtQuan_DN.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(611, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Quận:";
            // 
            // dateCongVan_DN
            // 
            this.dateCongVan_DN.CustomFormat = "dd/MM/yyyy";
            this.dateCongVan_DN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCongVan_DN.Location = new System.Drawing.Point(346, 52);
            this.dateCongVan_DN.Name = "dateCongVan_DN";
            this.dateCongVan_DN.Size = new System.Drawing.Size(90, 22);
            this.dateCongVan_DN.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(234, 55);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Ngày Công Văn:";
            // 
            // btnInTBDongNuoc
            // 
            this.btnInTBDongNuoc.Location = new System.Drawing.Point(775, 22);
            this.btnInTBDongNuoc.Name = "btnInTBDongNuoc";
            this.btnInTBDongNuoc.Size = new System.Drawing.Size(130, 25);
            this.btnInTBDongNuoc.TabIndex = 7;
            this.btnInTBDongNuoc.Text = "In TB Đóng Nước";
            this.btnInTBDongNuoc.UseVisualStyleBackColor = true;
            this.btnInTBDongNuoc.Click += new System.EventHandler(this.btnInTBDongNuoc_Click);
            // 
            // txtSoCongVan_DN
            // 
            this.txtSoCongVan_DN.Location = new System.Drawing.Point(128, 52);
            this.txtSoCongVan_DN.Name = "txtSoCongVan_DN";
            this.txtSoCongVan_DN.Size = new System.Drawing.Size(100, 22);
            this.txtSoCongVan_DN.TabIndex = 1;
            // 
            // txtPhuong_DN
            // 
            this.txtPhuong_DN.Location = new System.Drawing.Point(505, 52);
            this.txtPhuong_DN.Name = "txtPhuong_DN";
            this.txtPhuong_DN.Size = new System.Drawing.Size(100, 22);
            this.txtPhuong_DN.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(442, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "Phường:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Công Văn Số:";
            // 
            // groupBoxXuLyMoNuoc
            // 
            this.groupBoxXuLyMoNuoc.Controls.Add(this.dateMoNuoc);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label19);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.btnLapTBMoNuoc);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.txtHinhThucDN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label16);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.btnInTBMoNuoc);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.txtLyDoDN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label15);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.txtQuan_MN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label6);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.dateCongVan_MN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label12);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.txtSoCongVan_MN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.txtPhuong_MN);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label13);
            this.groupBoxXuLyMoNuoc.Controls.Add(this.label14);
            this.groupBoxXuLyMoNuoc.Location = new System.Drawing.Point(12, 235);
            this.groupBoxXuLyMoNuoc.Name = "groupBoxXuLyMoNuoc";
            this.groupBoxXuLyMoNuoc.Size = new System.Drawing.Size(911, 141);
            this.groupBoxXuLyMoNuoc.TabIndex = 6;
            this.groupBoxXuLyMoNuoc.TabStop = false;
            this.groupBoxXuLyMoNuoc.Text = "Xử Lý Mở Nước";
            // 
            // dateMoNuoc
            // 
            this.dateMoNuoc.CustomFormat = "dd/MM/yyyy";
            this.dateMoNuoc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateMoNuoc.Location = new System.Drawing.Point(146, 26);
            this.dateMoNuoc.Name = "dateMoNuoc";
            this.dateMoNuoc.Size = new System.Drawing.Size(90, 22);
            this.dateMoNuoc.TabIndex = 14;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(101, 16);
            this.label19.TabIndex = 13;
            this.label19.Text = "Ngày Mở Nước:";
            // 
            // btnLapTBMoNuoc
            // 
            this.btnLapTBMoNuoc.Location = new System.Drawing.Point(775, 110);
            this.btnLapTBMoNuoc.Name = "btnLapTBMoNuoc";
            this.btnLapTBMoNuoc.Size = new System.Drawing.Size(130, 25);
            this.btnLapTBMoNuoc.TabIndex = 12;
            this.btnLapTBMoNuoc.Text = "Lập TB Mở Nước";
            this.btnLapTBMoNuoc.UseVisualStyleBackColor = true;
            this.btnLapTBMoNuoc.Click += new System.EventHandler(this.btnLapTBMoNuoc_Click);
            // 
            // txtHinhThucDN
            // 
            this.txtHinhThucDN.Location = new System.Drawing.Point(146, 110);
            this.txtHinhThucDN.Name = "txtHinhThucDN";
            this.txtHinhThucDN.Size = new System.Drawing.Size(551, 22);
            this.txtHinhThucDN.TabIndex = 11;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 113);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 16);
            this.label16.TabIndex = 10;
            this.label16.Text = "Hình thức Đóng nước:";
            // 
            // btnInTBMoNuoc
            // 
            this.btnInTBMoNuoc.Location = new System.Drawing.Point(775, 79);
            this.btnInTBMoNuoc.Name = "btnInTBMoNuoc";
            this.btnInTBMoNuoc.Size = new System.Drawing.Size(130, 25);
            this.btnInTBMoNuoc.TabIndex = 8;
            this.btnInTBMoNuoc.Text = "In TB Mở Nước";
            this.btnInTBMoNuoc.UseVisualStyleBackColor = true;
            this.btnInTBMoNuoc.Click += new System.EventHandler(this.btnInTBMoNuoc_Click);
            // 
            // txtLyDoDN
            // 
            this.txtLyDoDN.Location = new System.Drawing.Point(146, 82);
            this.txtLyDoDN.Name = "txtLyDoDN";
            this.txtLyDoDN.Size = new System.Drawing.Size(551, 22);
            this.txtLyDoDN.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 85);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(111, 16);
            this.label15.TabIndex = 8;
            this.label15.Text = "Lý do Đóng nước:";
            // 
            // txtQuan_MN
            // 
            this.txtQuan_MN.Location = new System.Drawing.Point(675, 54);
            this.txtQuan_MN.Name = "txtQuan_MN";
            this.txtQuan_MN.Size = new System.Drawing.Size(100, 22);
            this.txtQuan_MN.TabIndex = 7;
            this.txtQuan_MN.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(629, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Quận:";
            this.label6.Visible = false;
            // 
            // dateCongVan_MN
            // 
            this.dateCongVan_MN.CustomFormat = "dd/MM/yyyy";
            this.dateCongVan_MN.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCongVan_MN.Location = new System.Drawing.Point(364, 54);
            this.dateCongVan_MN.Name = "dateCongVan_MN";
            this.dateCongVan_MN.Size = new System.Drawing.Size(90, 22);
            this.dateCongVan_MN.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(252, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(106, 16);
            this.label12.TabIndex = 2;
            this.label12.Text = "Ngày Công Văn:";
            // 
            // txtSoCongVan_MN
            // 
            this.txtSoCongVan_MN.Location = new System.Drawing.Point(146, 54);
            this.txtSoCongVan_MN.Name = "txtSoCongVan_MN";
            this.txtSoCongVan_MN.Size = new System.Drawing.Size(100, 22);
            this.txtSoCongVan_MN.TabIndex = 1;
            // 
            // txtPhuong_MN
            // 
            this.txtPhuong_MN.Location = new System.Drawing.Point(523, 54);
            this.txtPhuong_MN.Name = "txtPhuong_MN";
            this.txtPhuong_MN.Size = new System.Drawing.Size(100, 22);
            this.txtPhuong_MN.TabIndex = 5;
            this.txtPhuong_MN.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(460, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 16);
            this.label13.TabIndex = 4;
            this.label13.Text = "Phường:";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 16);
            this.label14.TabIndex = 0;
            this.label14.Text = "Công Văn Số:";
            // 
            // txtMaThongBao_MN
            // 
            this.txtMaThongBao_MN.Location = new System.Drawing.Point(810, 12);
            this.txtMaThongBao_MN.Name = "txtMaThongBao_MN";
            this.txtMaThongBao_MN.Size = new System.Drawing.Size(60, 22);
            this.txtMaThongBao_MN.TabIndex = 11;
            this.txtMaThongBao_MN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaThongBao_MN_KeyPress);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(696, 15);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 16);
            this.label17.TabIndex = 10;
            this.label17.Text = "Mã TB Mở Nước:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDSBamChi);
            this.groupBox2.Location = new System.Drawing.Point(12, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(911, 154);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả Xử Lý";
            // 
            // dgvDSBamChi
            // 
            this.dgvDSBamChi.AllowUserToAddRows = false;
            this.dgvDSBamChi.AllowUserToDeleteRows = false;
            this.dgvDSBamChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSBamChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDon,
            this.MaCTDN,
            this.MaCTMN});
            this.dgvDSBamChi.Location = new System.Drawing.Point(6, 22);
            this.dgvDSBamChi.Name = "dgvDSBamChi";
            this.dgvDSBamChi.Size = new System.Drawing.Size(899, 125);
            this.dgvDSBamChi.TabIndex = 0;
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // MaCTDN
            // 
            this.MaCTDN.DataPropertyName = "MaCTDN";
            this.MaCTDN.HeaderText = "Mã ĐN";
            this.MaCTDN.Name = "MaCTDN";
            // 
            // MaCTMN
            // 
            this.MaCTMN.DataPropertyName = "MaCTMN";
            this.MaCTMN.HeaderText = "Mã MN";
            this.MaCTMN.Name = "MaCTMN";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(12, 9);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(93, 18);
            this.label22.TabIndex = 91;
            this.label22.Text = "Đóng Nước";
            // 
            // txtMaDonMoi
            // 
            this.txtMaDonMoi.Location = new System.Drawing.Point(417, 12);
            this.txtMaDonMoi.Name = "txtMaDonMoi";
            this.txtMaDonMoi.Size = new System.Drawing.Size(80, 22);
            this.txtMaDonMoi.TabIndex = 117;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(329, 15);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(82, 16);
            this.label20.TabIndex = 116;
            this.label20.Text = "Mã Đơn Mới:";
            // 
            // frmDongNuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(937, 541);
            this.Controls.Add(this.txtMaDonMoi);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaThongBao_MN);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBoxXuLyMoNuoc);
            this.Controls.Add(this.groupBoxXuLyDongNuoc);
            this.Controls.Add(this.txtMaThongBao_DN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDonCu);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "frmDongNuoc";
            this.Text = "Thông Báo Đóng/Mở Nước";
            this.Load += new System.EventHandler(this.frmDongNuoc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxXuLyDongNuoc.ResumeLayout(false);
            this.groupBoxXuLyDongNuoc.PerformLayout();
            this.groupBoxXuLyMoNuoc.ResumeLayout(false);
            this.groupBoxXuLyMoNuoc.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSBamChi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaThongBao_DN;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaDonCu;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDiaChiDHN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBoxXuLyDongNuoc;
        private System.Windows.Forms.TextBox txtQuan_DN;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dateCongVan_DN;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSoCongVan_DN;
        private System.Windows.Forms.TextBox txtPhuong_DN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBoxXuLyMoNuoc;
        private System.Windows.Forms.TextBox txtHinhThucDN;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtLyDoDN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtQuan_MN;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateCongVan_MN;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoCongVan_MN;
        private System.Windows.Forms.TextBox txtPhuong_MN;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnInTBDongNuoc;
        private System.Windows.Forms.Button btnInTBMoNuoc;
        private System.Windows.Forms.Button btnLapTBDongNuoc;
        private System.Windows.Forms.Button btnLapTBMoNuoc;
        private System.Windows.Forms.TextBox txtMaThongBao_MN;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dateDongNuoc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dateMoNuoc;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvDSBamChi;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTDN;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTMN;
        private System.Windows.Forms.TextBox txtMaDonMoi;
        private System.Windows.Forms.Label label20;
    }
}