namespace KTKS_DonKH.GUI.ThuMoi
{
    partial class frmThaoThuMoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtMaDonMoi = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNoiNhan = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLuuy = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtVeViec = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtVaoLuc = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCanCu = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaDonCu = new System.Windows.Forms.TextBox();
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
            this.dgvDSThu = new System.Windows.Forms.DataGridView();
            this.IDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CanCu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VaoLuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.radDutChi = new System.Windows.Forms.RadioButton();
            this.radCDDM = new System.Windows.Forms.RadioButton();
            this.txtIDCT = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.radRong = new System.Windows.Forms.RadioButton();
            this.label34 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dgvHinh = new System.Windows.Forms.DataGridView();
            this.ID_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image_Hinh = new System.Windows.Forms.DataGridViewImageColumn();
            this.Name_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bytes_Hinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnChonFile = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.xoaFile_dgvHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinh)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaDonMoi
            // 
            this.txtMaDonMoi.Location = new System.Drawing.Point(427, 12);
            this.txtMaDonMoi.Name = "txtMaDonMoi";
            this.txtMaDonMoi.Size = new System.Drawing.Size(80, 22);
            this.txtMaDonMoi.TabIndex = 1;
            this.txtMaDonMoi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonMoi_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(329, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(92, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Mã Đơn(New):";
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(674, 229);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 25);
            this.btnIn.TabIndex = 12;
            this.btnIn.Text = "In Thư";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(584, 232);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 25);
            this.btnXoa.TabIndex = 8;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(584, 201);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 25);
            this.btnSua.TabIndex = 7;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(584, 170);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 25);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNoiNhan);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtLuuy);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtVeViec);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtVaoLuc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtCanCu);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(12, 149);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(566, 207);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Nội Dung Thư";
            // 
            // txtNoiNhan
            // 
            this.txtNoiNhan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoiNhan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtNoiNhan.Location = new System.Drawing.Point(70, 155);
            this.txtNoiNhan.Multiline = true;
            this.txtNoiNhan.Name = "txtNoiNhan";
            this.txtNoiNhan.Size = new System.Drawing.Size(487, 44);
            this.txtNoiNhan.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Nơi Nhận";
            // 
            // txtLuuy
            // 
            this.txtLuuy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtLuuy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtLuuy.Location = new System.Drawing.Point(70, 105);
            this.txtLuuy.Multiline = true;
            this.txtLuuy.Name = "txtLuuy";
            this.txtLuuy.Size = new System.Drawing.Size(487, 44);
            this.txtLuuy.TabIndex = 7;
            this.txtLuuy.Text = "Nếu quá thời hạn trên, Ông (Bà) không đến liên hệ. Công ty Cổ phần Cấp nước Tân H" +
                "òa sẽ giải quyết theo quy định: điều chỉnh định mức = 0 và tạm ngưng cung cấp nư" +
                "ớc.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Lưu ý";
            // 
            // txtVeViec
            // 
            this.txtVeViec.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtVeViec.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtVeViec.Location = new System.Drawing.Point(70, 77);
            this.txtVeViec.Name = "txtVeViec";
            this.txtVeViec.Size = new System.Drawing.Size(487, 22);
            this.txtVeViec.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 4;
            this.label10.Text = "Về Việc:";
            // 
            // txtVaoLuc
            // 
            this.txtVaoLuc.Location = new System.Drawing.Point(70, 49);
            this.txtVaoLuc.Name = "txtVaoLuc";
            this.txtVaoLuc.Size = new System.Drawing.Size(487, 22);
            this.txtVaoLuc.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 52);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Vào Lúc:";
            // 
            // txtCanCu
            // 
            this.txtCanCu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCanCu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtCanCu.Location = new System.Drawing.Point(70, 21);
            this.txtCanCu.Name = "txtCanCu";
            this.txtCanCu.Size = new System.Drawing.Size(487, 22);
            this.txtCanCu.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 16);
            this.label12.TabIndex = 0;
            this.label12.Text = "Căn Cứ:";
            // 
            // txtMaDonCu
            // 
            this.txtMaDonCu.Location = new System.Drawing.Point(248, 12);
            this.txtMaDonCu.Name = "txtMaDonCu";
            this.txtMaDonCu.Size = new System.Drawing.Size(75, 22);
            this.txtMaDonCu.TabIndex = 15;
            this.txtMaDonCu.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDonCu_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(166, 15);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 16);
            this.label21.TabIndex = 14;
            this.label21.Text = "Mã Đơn Cũ:";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(763, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtLoTrinh
            // 
            this.txtLoTrinh.Location = new System.Drawing.Point(432, 24);
            this.txtLoTrinh.Name = "txtLoTrinh";
            this.txtLoTrinh.Size = new System.Drawing.Size(100, 22);
            this.txtLoTrinh.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(367, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lộ Trình:";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(718, 24);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(35, 22);
            this.txtDinhMuc.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(647, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Định Mức:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(606, 24);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(35, 22);
            this.txtGiaBieu.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Giá Biểu:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(422, 52);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(331, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(363, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa Chỉ:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(98, 52);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(260, 22);
            this.txtHoTen.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khách Hàng:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(261, 24);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 22);
            this.txtHopDong.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hợp Đồng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(77, 24);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 22);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // dgvDSThu
            // 
            this.dgvDSThu.AllowUserToAddRows = false;
            this.dgvDSThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCT,
            this.Lan,
            this.CreateDate,
            this.CanCu,
            this.VaoLuc});
            this.dgvDSThu.Location = new System.Drawing.Point(12, 362);
            this.dgvDSThu.Name = "dgvDSThu";
            this.dgvDSThu.Size = new System.Drawing.Size(616, 126);
            this.dgvDSThu.TabIndex = 13;
            this.dgvDSThu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDSThu_CellContentClick);
            // 
            // IDCT
            // 
            this.IDCT.DataPropertyName = "IDCT";
            this.IDCT.HeaderText = "SoPhieu";
            this.IDCT.Name = "IDCT";
            this.IDCT.Visible = false;
            // 
            // Lan
            // 
            this.Lan.DataPropertyName = "Lan";
            this.Lan.HeaderText = "Lần";
            this.Lan.Name = "Lan";
            this.Lan.Width = 50;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // CanCu
            // 
            this.CanCu.DataPropertyName = "CanCu";
            this.CanCu.HeaderText = "Căn Cứ";
            this.CanCu.Name = "CanCu";
            this.CanCu.Width = 200;
            // 
            // VaoLuc
            // 
            this.VaoLuc.DataPropertyName = "VaoLuc";
            this.VaoLuc.HeaderText = "Vào Lúc";
            this.VaoLuc.Name = "VaoLuc";
            this.VaoLuc.Width = 200;
            // 
            // radDutChi
            // 
            this.radDutChi.AutoSize = true;
            this.radDutChi.Checked = true;
            this.radDutChi.Location = new System.Drawing.Point(674, 149);
            this.radDutChi.Name = "radDutChi";
            this.radDutChi.Size = new System.Drawing.Size(67, 20);
            this.radDutChi.TabIndex = 9;
            this.radDutChi.TabStop = true;
            this.radDutChi.Text = "Đứt Chì";
            this.radDutChi.UseVisualStyleBackColor = true;
            // 
            // radCDDM
            // 
            this.radCDDM.AutoSize = true;
            this.radCDDM.Location = new System.Drawing.Point(674, 175);
            this.radCDDM.Name = "radCDDM";
            this.radCDDM.Size = new System.Drawing.Size(64, 20);
            this.radCDDM.TabIndex = 10;
            this.radCDDM.TabStop = true;
            this.radCDDM.Text = "CĐĐM";
            this.radCDDM.UseVisualStyleBackColor = true;
            // 
            // txtIDCT
            // 
            this.txtIDCT.Location = new System.Drawing.Point(572, 12);
            this.txtIDCT.Name = "txtIDCT";
            this.txtIDCT.Size = new System.Drawing.Size(80, 22);
            this.txtIDCT.TabIndex = 3;
            this.txtIDCT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDCT_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(513, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Mã Thư";
            // 
            // radRong
            // 
            this.radRong.AutoSize = true;
            this.radRong.Location = new System.Drawing.Point(674, 201);
            this.radRong.Name = "radRong";
            this.radRong.Size = new System.Drawing.Size(59, 20);
            this.radRong.TabIndex = 11;
            this.radRong.TabStop = true;
            this.radRong.Text = "Rỗng";
            this.radRong.UseVisualStyleBackColor = true;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Red;
            this.label34.Location = new System.Drawing.Point(424, 37);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(168, 16);
            this.label34.TabIndex = 136;
            this.label34.Text = "Ctrl+T: Cập Nhật Tiến Trình";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label32);
            this.groupBox4.Controls.Add(this.dgvHinh);
            this.groupBox4.Controls.Add(this.btnChonFile);
            this.groupBox4.Location = new System.Drawing.Point(637, 353);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 135);
            this.groupBox4.TabIndex = 137;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "File Scan";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.Red;
            this.label32.Location = new System.Drawing.Point(121, 18);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(146, 16);
            this.label32.TabIndex = 32;
            this.label32.Text = "Chuột Phải để XÓA File";
            // 
            // dgvHinh
            // 
            this.dgvHinh.AllowUserToAddRows = false;
            this.dgvHinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_Hinh,
            this.Image_Hinh,
            this.Name_Hinh,
            this.Bytes_Hinh});
            this.dgvHinh.Location = new System.Drawing.Point(6, 43);
            this.dgvHinh.Name = "dgvHinh";
            this.dgvHinh.Size = new System.Drawing.Size(261, 86);
            this.dgvHinh.TabIndex = 10;
            this.dgvHinh.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvHinh_CellMouseClick);
            this.dgvHinh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvHinh_MouseClick);
            this.dgvHinh.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvHinh_MouseDoubleClick);
            // 
            // ID_Hinh
            // 
            this.ID_Hinh.DataPropertyName = "ID";
            this.ID_Hinh.HeaderText = "ID";
            this.ID_Hinh.Name = "ID_Hinh";
            this.ID_Hinh.Visible = false;
            // 
            // Image_Hinh
            // 
            this.Image_Hinh.HeaderText = "Image";
            this.Image_Hinh.Image = global::KTKS_DonKH.Properties.Resources.file_24x24;
            this.Image_Hinh.Name = "Image_Hinh";
            this.Image_Hinh.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Image_Hinh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Image_Hinh.Width = 50;
            // 
            // Name_Hinh
            // 
            this.Name_Hinh.DataPropertyName = "Name";
            this.Name_Hinh.HeaderText = "File";
            this.Name_Hinh.Name = "Name_Hinh";
            this.Name_Hinh.Width = 150;
            // 
            // Bytes_Hinh
            // 
            this.Bytes_Hinh.DataPropertyName = "Bytes";
            this.Bytes_Hinh.HeaderText = "Bytes";
            this.Bytes_Hinh.Name = "Bytes_Hinh";
            this.Bytes_Hinh.Visible = false;
            // 
            // btnChonFile
            // 
            this.btnChonFile.Location = new System.Drawing.Point(40, 17);
            this.btnChonFile.Name = "btnChonFile";
            this.btnChonFile.Size = new System.Drawing.Size(75, 25);
            this.btnChonFile.TabIndex = 8;
            this.btnChonFile.Text = "Chọn File";
            this.btnChonFile.UseVisualStyleBackColor = true;
            this.btnChonFile.Click += new System.EventHandler(this.btnChonFile_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xoaFile_dgvHinh});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(101, 26);
            // 
            // xoaFile_dgvHinh
            // 
            this.xoaFile_dgvHinh.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xoaFile_dgvHinh.Name = "xoaFile_dgvHinh";
            this.xoaFile_dgvHinh.Size = new System.Drawing.Size(100, 22);
            this.xoaFile_dgvHinh.Text = "Xóa";
            this.xoaFile_dgvHinh.Click += new System.EventHandler(this.xoaFile_dgvHinh_Click);
            // 
            // frmThaoThuMoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(923, 562);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.radRong);
            this.Controls.Add(this.txtIDCT);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.radCDDM);
            this.Controls.Add(this.radDutChi);
            this.Controls.Add(this.dgvDSThu);
            this.Controls.Add(this.txtMaDonMoi);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtMaDonCu);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmThaoThuMoi";
            this.Text = "Thảo Thư Mời";
            this.Load += new System.EventHandler(this.frmThaoThuMoi_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmThaoThuMoi_KeyUp);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSThu)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHinh)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMaDonMoi;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCanCu;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtMaDonCu;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLoTrinh;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.TextBox txtVeViec;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtVaoLuc;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvDSThu;
        private System.Windows.Forms.RadioButton radDutChi;
        private System.Windows.Forms.RadioButton radCDDM;
        private System.Windows.Forms.TextBox txtIDCT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radRong;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lan;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CanCu;
        private System.Windows.Forms.DataGridViewTextBoxColumn VaoLuc;
        private System.Windows.Forms.TextBox txtNoiNhan;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLuuy;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.DataGridView dgvHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_Hinh;
        private System.Windows.Forms.DataGridViewImageColumn Image_Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_Hinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bytes_Hinh;
        private System.Windows.Forms.Button btnChonFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem xoaFile_dgvHinh;
    }
}