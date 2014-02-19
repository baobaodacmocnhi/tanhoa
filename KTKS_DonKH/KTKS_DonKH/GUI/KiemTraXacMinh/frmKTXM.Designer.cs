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
            this.btnLuu = new System.Windows.Forms.Button();
            this.dgvDSKetQuaKiemTra = new System.Windows.Forms.DataGridView();
            this.MaCTKTXM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDungKiemTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NguoiDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtHoTenKHKy = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.dateKTXM = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.txtSoThan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtChiKhoaGoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMucDichSuDung = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtChiMatSo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtChiSo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHieu = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKetQuaKiemTra)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMaDon
            // 
            this.txtMaDon.Location = new System.Drawing.Point(400, 6);
            this.txtMaDon.Name = "txtMaDon";
            this.txtMaDon.Size = new System.Drawing.Size(100, 26);
            this.txtMaDon.TabIndex = 28;
            this.txtMaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDon_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(333, 9);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 19);
            this.label21.TabIndex = 27;
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
            this.groupBox1.Location = new System.Drawing.Point(12, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(691, 130);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Khách Hàng";
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(582, 60);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(100, 26);
            this.txtDinhMuc.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(500, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 19);
            this.label10.TabIndex = 26;
            this.label10.Text = "Định Mức:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(101, 91);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(581, 26);
            this.txtDiaChi.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 19);
            this.label9.TabIndex = 24;
            this.label9.Text = "Địa Chỉ:";
            // 
            // txtHopDong
            // 
            this.txtHopDong.Location = new System.Drawing.Point(394, 29);
            this.txtHopDong.Name = "txtHopDong";
            this.txtHopDong.Size = new System.Drawing.Size(100, 26);
            this.txtHopDong.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(317, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "Hợp Đồng:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(582, 29);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(100, 26);
            this.txtGiaBieu.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(500, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 19);
            this.label7.TabIndex = 22;
            this.label7.Text = "Giá Biểu:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(101, 60);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(393, 26);
            this.txtHoTen.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 19);
            this.label6.TabIndex = 20;
            this.label6.Text = "Khách Hàng:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(101, 29);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(150, 26);
            this.txtDanhBo.TabIndex = 15;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Danh Bộ:";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(552, 27);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(100, 26);
            this.txtDienThoai.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(438, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 19);
            this.label11.TabIndex = 18;
            this.label11.Text = "Điện Thoại:";
            // 
            // txtNoiDungKiemTra
            // 
            this.txtNoiDungKiemTra.Location = new System.Drawing.Point(758, 36);
            this.txtNoiDungKiemTra.Multiline = true;
            this.txtNoiDungKiemTra.Name = "txtNoiDungKiemTra";
            this.txtNoiDungKiemTra.Size = new System.Drawing.Size(497, 113);
            this.txtNoiDungKiemTra.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(754, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 19);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nội Dung Kiểm Tra:";
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::KTKS_DonKH.Properties.Resources.save_24x24;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(1096, 343);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(70, 35);
            this.btnLuu.TabIndex = 32;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // dgvDSKetQuaKiemTra
            // 
            this.dgvDSKetQuaKiemTra.AllowUserToAddRows = false;
            this.dgvDSKetQuaKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKetQuaKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKetQuaKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKetQuaKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTKTXM,
            this.MaDon,
            this.DanhBo,
            this.NoiDungKiemTra,
            this.NguoiDi});
            this.dgvDSKetQuaKiemTra.Location = new System.Drawing.Point(12, 343);
            this.dgvDSKetQuaKiemTra.Name = "dgvDSKetQuaKiemTra";
            this.dgvDSKetQuaKiemTra.Size = new System.Drawing.Size(765, 150);
            this.dgvDSKetQuaKiemTra.TabIndex = 33;
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
            this.NoiDungKiemTra.Width = 420;
            // 
            // NguoiDi
            // 
            this.NguoiDi.DataPropertyName = "NguoiDi";
            this.NguoiDi.HeaderText = "Người Đi";
            this.NguoiDi.Name = "NguoiDi";
            this.NguoiDi.ReadOnly = true;
            // 
            // groupBox2
            // 
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
            this.groupBox2.Controls.Add(this.txtChiKhoaGoc);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtMucDichSuDung);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtChiMatSo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtChiSo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtHieu);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Location = new System.Drawing.Point(12, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1268, 163);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết Quả";
            // 
            // txtHoTenKHKy
            // 
            this.txtHoTenKHKy.Location = new System.Drawing.Point(552, 59);
            this.txtHoTenKHKy.Name = "txtHoTenKHKy";
            this.txtHoTenKHKy.Size = new System.Drawing.Size(200, 26);
            this.txtHoTenKHKy.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(438, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 19);
            this.label17.TabIndex = 30;
            this.label17.Text = "Họ Tên KH Ký:";
            // 
            // dateKTXM
            // 
            this.dateKTXM.CustomFormat = "dd/MM/yyyy";
            this.dateKTXM.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateKTXM.Location = new System.Drawing.Point(110, 27);
            this.dateKTXM.Name = "dateKTXM";
            this.dateKTXM.Size = new System.Drawing.Size(109, 26);
            this.dateKTXM.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(95, 19);
            this.label16.TabIndex = 28;
            this.label16.Text = "Ngày KTXM:";
            // 
            // txtSoThan
            // 
            this.txtSoThan.Location = new System.Drawing.Point(110, 123);
            this.txtSoThan.Name = "txtSoThan";
            this.txtSoThan.Size = new System.Drawing.Size(109, 26);
            this.txtSoThan.TabIndex = 19;
            this.txtSoThan.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "Số Thân:";
            this.label3.Visible = false;
            // 
            // txtChiKhoaGoc
            // 
            this.txtChiKhoaGoc.Location = new System.Drawing.Point(332, 91);
            this.txtChiKhoaGoc.Name = "txtChiKhoaGoc";
            this.txtChiKhoaGoc.Size = new System.Drawing.Size(100, 26);
            this.txtChiKhoaGoc.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 19);
            this.label4.TabIndex = 26;
            this.label4.Text = "Chì Khóa Góc:";
            // 
            // txtMucDichSuDung
            // 
            this.txtMucDichSuDung.Location = new System.Drawing.Point(361, 123);
            this.txtMucDichSuDung.Name = "txtMucDichSuDung";
            this.txtMucDichSuDung.Size = new System.Drawing.Size(300, 26);
            this.txtMucDichSuDung.TabIndex = 25;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(225, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Mục Đích Sử Dụng:";
            // 
            // txtCo
            // 
            this.txtCo.Location = new System.Drawing.Point(110, 91);
            this.txtCo.Name = "txtCo";
            this.txtCo.Size = new System.Drawing.Size(109, 26);
            this.txtCo.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 94);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 19);
            this.label12.TabIndex = 16;
            this.label12.Text = "Cỡ:";
            // 
            // txtChiMatSo
            // 
            this.txtChiMatSo.Location = new System.Drawing.Point(332, 59);
            this.txtChiMatSo.Name = "txtChiMatSo";
            this.txtChiMatSo.Size = new System.Drawing.Size(100, 26);
            this.txtChiMatSo.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(225, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 19);
            this.label13.TabIndex = 22;
            this.label13.Text = "Chì Mặt Số:";
            // 
            // txtChiSo
            // 
            this.txtChiSo.Location = new System.Drawing.Point(332, 27);
            this.txtChiSo.Name = "txtChiSo";
            this.txtChiSo.Size = new System.Drawing.Size(100, 26);
            this.txtChiSo.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(225, 33);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 19);
            this.label14.TabIndex = 20;
            this.label14.Text = "Chỉ Số:";
            // 
            // txtHieu
            // 
            this.txtHieu.Location = new System.Drawing.Point(110, 59);
            this.txtHieu.Name = "txtHieu";
            this.txtHieu.Size = new System.Drawing.Size(109, 26);
            this.txtHieu.TabIndex = 15;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 62);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(40, 19);
            this.label15.TabIndex = 14;
            this.label15.Text = "Hiệu:";
            // 
            // btnSua
            // 
            this.btnSua.Image = global::KTKS_DonKH.Properties.Resources.pencil_24x24;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(824, 343);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(65, 35);
            this.btnSua.TabIndex = 84;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // frmKTXM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1298, 551);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvDSKetQuaKiemTra);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtMaDon);
            this.Controls.Add(this.label21);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.DataGridView dgvDSKetQuaKiemTra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtSoThan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtChiKhoaGoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMucDichSuDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtChiMatSo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtChiSo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHieu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateKTXM;
        private System.Windows.Forms.TextBox txtHoTenKHKy;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTKTXM;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDungKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn NguoiDi;
    }
}