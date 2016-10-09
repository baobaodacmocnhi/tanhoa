namespace KTKS_DonKH.GUI.ThaoThuTraLoi
{
    partial class frmTTTL
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
            this.txtLoTrinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHopDong = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkThuBao = new System.Windows.Forms.CheckBox();
            this.chkThuMoi = new System.Windows.Forms.CheckBox();
            this.chkDieuChinh_GB_DM = new System.Windows.Forms.CheckBox();
            this.chkThayDHN = new System.Windows.Forms.CheckBox();
            this.chkKiemDinhDHN_Dung = new System.Windows.Forms.CheckBox();
            this.chkKiemDinhDHN_Sai = new System.Windows.Forms.CheckBox();
            this.chkGiamNuocXaBo = new System.Windows.Forms.CheckBox();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvLichSuTTTL = new System.Windows.Forms.DataGridView();
            this.MaCTTTTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeViec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVeViec = new System.Windows.Forms.ComboBox();
            this.txtMaCTTTTL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateGhiChu = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvGhiChu = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCapNhatGhiChu = new System.Windows.Forms.Button();
            this.label28 = new System.Windows.Forms.Label();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTTTL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(358, 7);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.ReadOnly = true;
            this.txtMaDon.Size = new System.Drawing.Size(88, 21);
            this.txtMaDon.TabIndex = 1;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(299, 10);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(54, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Mã Đơn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoTrinh);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDinhMuc);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtGiaBieu);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDiaChi);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHoTen);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtHopDong);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(10, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 82);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.Location = new System.Drawing.Point(374, 21);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.Size = new System.Drawing.Size(88, 21);
            this.txtLoTrinh.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lộ Trình:";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(630, 21);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(31, 21);
            this.txtDinhMuc.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(563, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Định Mức:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(527, 21);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(31, 21);
            this.txtGiaBieu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giá Biểu:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(370, 49);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(489, 21);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(86, 49);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(228, 21);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(226, 21);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(88, 21);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(66, 21);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(88, 21);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkThuBao);
            this.groupBox2.Controls.Add(this.chkThuMoi);
            this.groupBox2.Controls.Add(this.chkDieuChinh_GB_DM);
            this.groupBox2.Controls.Add(this.chkThayDHN);
            this.groupBox2.Controls.Add(this.chkKiemDinhDHN_Dung);
            this.groupBox2.Controls.Add(this.chkKiemDinhDHN_Sai);
            this.groupBox2.Controls.Add(this.chkGiamNuocXaBo);
            this.groupBox2.Controls.Add(this.txtNoiNhan);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtNoiDung);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtVeViec);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(10, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(865, 282);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội Dung Thư";
            // 
            // chkThuBao
            // 
            this.chkThuBao.AutoSize = true;
            this.chkThuBao.Location = new System.Drawing.Point(688, 254);
            this.chkThuBao.Name = "chkThuBao";
            this.chkThuBao.Size = new System.Drawing.Size(72, 19);
            this.chkThuBao.TabIndex = 12;
            this.chkThuBao.Text = "Thư Báo";
            this.chkThuBao.UseVisualStyleBackColor = true;
            // 
            // chkThuMoi
            // 
            this.chkThuMoi.AutoSize = true;
            this.chkThuMoi.Location = new System.Drawing.Point(688, 230);
            this.chkThuMoi.Name = "chkThuMoi";
            this.chkThuMoi.Size = new System.Drawing.Size(71, 19);
            this.chkThuMoi.TabIndex = 11;
            this.chkThuMoi.Text = "Thư Mời";
            this.chkThuMoi.UseVisualStyleBackColor = true;
            // 
            // chkDieuChinh_GB_DM
            // 
            this.chkDieuChinh_GB_DM.AutoSize = true;
            this.chkDieuChinh_GB_DM.Location = new System.Drawing.Point(688, 169);
            this.chkDieuChinh_GB_DM.Name = "chkDieuChinh_GB_DM";
            this.chkDieuChinh_GB_DM.Size = new System.Drawing.Size(131, 19);
            this.chkDieuChinh_GB_DM.TabIndex = 10;
            this.chkDieuChinh_GB_DM.Text = "Điều Chỉnh GB-ĐM";
            this.chkDieuChinh_GB_DM.UseVisualStyleBackColor = true;
            // 
            // chkThayDHN
            // 
            this.chkThayDHN.AutoSize = true;
            this.chkThayDHN.Location = new System.Drawing.Point(688, 146);
            this.chkThayDHN.Name = "chkThayDHN";
            this.chkThayDHN.Size = new System.Drawing.Size(82, 19);
            this.chkThayDHN.TabIndex = 9;
            this.chkThayDHN.Text = "Thay ĐHN";
            this.chkThayDHN.UseVisualStyleBackColor = true;
            // 
            // chkKiemDinhDHN_Dung
            // 
            this.chkKiemDinhDHN_Dung.AutoSize = true;
            this.chkKiemDinhDHN_Dung.Location = new System.Drawing.Point(688, 122);
            this.chkKiemDinhDHN_Dung.Name = "chkKiemDinhDHN_Dung";
            this.chkKiemDinhDHN_Dung.Size = new System.Drawing.Size(165, 19);
            this.chkKiemDinhDHN_Dung.TabIndex = 8;
            this.chkKiemDinhDHN_Dung.Text = "Thử Kiểm Định ĐHN (sai)";
            this.chkKiemDinhDHN_Dung.UseVisualStyleBackColor = true;
            // 
            // chkKiemDinhDHN_Sai
            // 
            this.chkKiemDinhDHN_Sai.AutoSize = true;
            this.chkKiemDinhDHN_Sai.Location = new System.Drawing.Point(688, 98);
            this.chkKiemDinhDHN_Sai.Name = "chkKiemDinhDHN_Sai";
            this.chkKiemDinhDHN_Sai.Size = new System.Drawing.Size(177, 19);
            this.chkKiemDinhDHN_Sai.TabIndex = 7;
            this.chkKiemDinhDHN_Sai.Text = "Thử Kiểm Định ĐHN (đúng)";
            this.chkKiemDinhDHN_Sai.UseVisualStyleBackColor = true;
            // 
            // chkGiamNuocXaBo
            // 
            this.chkGiamNuocXaBo.AutoSize = true;
            this.chkGiamNuocXaBo.Location = new System.Drawing.Point(688, 74);
            this.chkGiamNuocXaBo.Name = "chkGiamNuocXaBo";
            this.chkGiamNuocXaBo.Size = new System.Drawing.Size(162, 19);
            this.chkGiamNuocXaBo.TabIndex = 6;
            this.chkGiamNuocXaBo.Text = "Giảm Lượng Nước Xả Bỏ";
            this.chkGiamNuocXaBo.UseVisualStyleBackColor = true;
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.Location = new System.Drawing.Point(550, 72);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(131, 201);
            this.txtNoiNhan.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(547, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 15);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nơi Nhận:";
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiDung.Location = new System.Drawing.Point(10, 72);
            this.txtNoiDung.Multiline = true;
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(534, 201);
            this.txtNoiDung.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 15);
            this.label11.TabIndex = 2;
            this.label11.Text = "Nội Dung:";
            // 
            // txtVeViec
            // 
            this.txtVeViec.Location = new System.Drawing.Point(66, 21);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(479, 21);
            this.txtVeViec.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Về Việc:";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(698, 402);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvLichSuTTTL
            // 
            this.dgvLichSuTTTL.AllowUserToAddRows = false;
            this.dgvLichSuTTTL.AllowUserToDeleteRows = false;
            this.dgvLichSuTTTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSuTTTL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTTTTL,
            this.MaDon,
            this.VeViec});
            this.dgvLichSuTTTL.Location = new System.Drawing.Point(881, 11);
            this.dgvLichSuTTTL.Name = "dgvLichSuTTTL";
            this.dgvLichSuTTTL.Size = new System.Drawing.Size(471, 176);
            this.dgvLichSuTTTL.TabIndex = 5;
            this.dgvLichSuTTTL.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLichSuTTTL_CellFormatting);
            // 
            // MaCTTTTL
            // 
            this.MaCTTTTL.DataPropertyName = "MaCTTTTL";
            this.MaCTTTTL.HeaderText = "Mã Thư";
            this.MaCTTTTL.Name = "MaCTTTTL";
            // 
            // MaDon
            // 
            this.MaDon.DataPropertyName = "MaDon";
            this.MaDon.HeaderText = "Mã Đơn";
            this.MaDon.Name = "MaDon";
            // 
            // VeViec
            // 
            this.VeViec.DataPropertyName = "VeViec";
            this.VeViec.HeaderText = "Về Việc";
            this.VeViec.Name = "VeViec";
            this.VeViec.Width = 200;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 410);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Về Việc:";
            // 
            // cmbVeViec
            // 
            this.cmbVeViec.FormattingEnabled = true;
            this.cmbVeViec.Location = new System.Drawing.Point(76, 408);
            this.cmbVeViec.Name = "cmbVeViec";
            this.cmbVeViec.Size = new System.Drawing.Size(479, 23);
            this.cmbVeViec.TabIndex = 14;
            this.cmbVeViec.SelectedIndexChanged += new System.EventHandler(this.cmbVeViec_SelectedIndexChanged);
            // 
            // txtMaCTTTTL
            // 
            this.txtMaCTTTTL.Location = new System.Drawing.Point(509, 7);
            this.txtMaCTTTTL.Name = "txtMaCTTTTL";
            this.txtMaCTTTTL.Size = new System.Drawing.Size(88, 21);
            this.txtMaCTTTTL.TabIndex = 16;
            this.txtMaCTTTTL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaCTTTTL_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(451, 10);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mã Thư:";
            // 
            // dateGhiChu
            // 
            this.dateGhiChu.CustomFormat = "dd/MM/yyyy";
            this.dateGhiChu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateGhiChu.Location = new System.Drawing.Point(967, 193);
            this.dateGhiChu.Name = "dateGhiChu";
            this.dateGhiChu.Size = new System.Drawing.Size(88, 21);
            this.dateGhiChu.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(878, 199);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(85, 15);
            this.label13.TabIndex = 18;
            this.label13.Text = "Ngày Ghi Chú:";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(935, 221);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(253, 21);
            this.txtGhiChu.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(878, 223);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 15);
            this.label14.TabIndex = 19;
            this.label14.Text = "Ghi Chú:";
            // 
            // dgvGhiChu
            // 
            this.dgvGhiChu.AllowUserToAddRows = false;
            this.dgvGhiChu.AllowUserToDeleteRows = false;
            this.dgvGhiChu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhiChu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayGhiChu,
            this.GhiChu});
            this.dgvGhiChu.Location = new System.Drawing.Point(881, 248);
            this.dgvGhiChu.Name = "dgvGhiChu";
            this.dgvGhiChu.Size = new System.Drawing.Size(411, 176);
            this.dgvGhiChu.TabIndex = 21;
            this.dgvGhiChu.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGhiChu_CellMouseClick);
            this.dgvGhiChu.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvGhiChu_MouseClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // NgayGhiChu
            // 
            this.NgayGhiChu.DataPropertyName = "NgayGhiChu";
            this.NgayGhiChu.HeaderText = "Ngày";
            this.NgayGhiChu.Name = "NgayGhiChu";
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // btnCapNhatGhiChu
            // 
            this.btnCapNhatGhiChu.Location = new System.Drawing.Point(1194, 219);
            this.btnCapNhatGhiChu.Name = "btnCapNhatGhiChu";
            this.btnCapNhatGhiChu.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhatGhiChu.TabIndex = 22;
            this.btnCapNhatGhiChu.Text = "Cập Nhật";
            this.btnCapNhatGhiChu.UseVisualStyleBackColor = true;
            this.btnCapNhatGhiChu.Click += new System.EventHandler(this.btnCapNhatGhiChu_Click);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.ForeColor = System.Drawing.Color.Red;
            this.label28.Location = new System.Drawing.Point(1032, 430);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(158, 15);
            this.label28.TabIndex = 57;
            this.label28.Text = "Chuột Phải để XÓA Ghi Chú";
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xóaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // frmTTTL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1428, 487);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.btnCapNhatGhiChu);
            this.Controls.Add(this.dgvGhiChu);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dateGhiChu);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtMaCTTTTL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbVeViec);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvLichSuTTTL);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmTTTL";
            this.Text = "Thảo Thư Trả Lời";
            this.Load += new System.EventHandler(this.frmTTTL_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSuTTTL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhiChu)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDon;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHopDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.CheckBox chkThuBao;
        private System.Windows.Forms.CheckBox chkThuMoi;
        private System.Windows.Forms.CheckBox chkDieuChinh_GB_DM;
        private System.Windows.Forms.CheckBox chkThayDHN;
        private System.Windows.Forms.CheckBox chkKiemDinhDHN_Dung;
        private System.Windows.Forms.CheckBox chkKiemDinhDHN_Sai;
        private System.Windows.Forms.CheckBox chkGiamNuocXaBo;
        private System.Windows.Forms.TextBox txtLoTrinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvLichSuTTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTTTTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn VeViec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVeViec;
        private System.Windows.Forms.TextBox txtMaCTTTTL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateGhiChu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.Button btnCapNhatGhiChu;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}