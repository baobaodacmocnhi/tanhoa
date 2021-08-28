namespace ThuTien.GUI.TongHop
{
    partial class frmDangKyKiemTra
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
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDangKyKiemTra = new System.Windows.Forms.DataGridView();
            this.MaDKKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCTDangKyKiemTra = new System.Windows.Forms.DataGridView();
            this.MaCTDKKT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDKKT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNV_HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayNhan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GB_DM_Cu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dateNhap = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.txtTongSo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBaoBinhThuong = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBaoTrung = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKyKiemTra)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDangKyKiemTra)).BeginInit();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(844, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 99;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(212, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 98;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(763, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 97;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(682, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 96;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(475, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 93;
            this.label10.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(533, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 94;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1119, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 91;
            this.label8.Text = "Nhân Viên:";
            this.label8.Visible = false;
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(1185, 7);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 92;
            this.cmbNhanVien.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDangKyKiemTra);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(275, 590);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Tờ Trình";
            // 
            // dgvDangKyKiemTra
            // 
            this.dgvDangKyKiemTra.AllowUserToAddRows = false;
            this.dgvDangKyKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDangKyKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDangKyKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangKyKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDKKT,
            this.CreateDate});
            this.dgvDangKyKiemTra.Location = new System.Drawing.Point(6, 19);
            this.dgvDangKyKiemTra.MultiSelect = false;
            this.dgvDangKyKiemTra.Name = "dgvDangKyKiemTra";
            this.dgvDangKyKiemTra.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDangKyKiemTra.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDangKyKiemTra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangKyKiemTra.Size = new System.Drawing.Size(261, 565);
            this.dgvDangKyKiemTra.TabIndex = 0;
            this.dgvDangKyKiemTra.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDangKyKiemTra_CellContentClick);
            this.dgvDangKyKiemTra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDangKyKiemTra_CellFormatting);
            this.dgvDangKyKiemTra.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDangKyKiemTra_RowPostPaint);
            // 
            // MaDKKT
            // 
            this.MaDKKT.DataPropertyName = "MaDKKT";
            this.MaDKKT.HeaderText = "Mã Tờ Trình";
            this.MaDKKT.Name = "MaDKKT";
            this.MaDKKT.ReadOnly = true;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            this.CreateDate.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCTDangKyKiemTra);
            this.groupBox2.Location = new System.Drawing.Point(293, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(871, 590);
            this.groupBox2.TabIndex = 101;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Tờ Trình";
            // 
            // dgvCTDangKyKiemTra
            // 
            this.dgvCTDangKyKiemTra.AllowUserToAddRows = false;
            this.dgvCTDangKyKiemTra.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTDangKyKiemTra.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCTDangKyKiemTra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTDangKyKiemTra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaCTDKKT,
            this.MaDKKT_CT,
            this.MaNV_HanhThu,
            this.HanhThu,
            this.DanhBo,
            this.MLT,
            this.DiaChi,
            this.NgayNhan,
            this.GB_DM_Cu,
            this.NoiDung});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCTDangKyKiemTra.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCTDangKyKiemTra.Location = new System.Drawing.Point(6, 19);
            this.dgvCTDangKyKiemTra.Name = "dgvCTDangKyKiemTra";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCTDangKyKiemTra.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCTDangKyKiemTra.Size = new System.Drawing.Size(858, 565);
            this.dgvCTDangKyKiemTra.TabIndex = 96;
            this.dgvCTDangKyKiemTra.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCTDangKyKiemTra_CellFormatting);
            this.dgvCTDangKyKiemTra.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCTDangKyKiemTra_CellValidating);
            this.dgvCTDangKyKiemTra.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCTDangKyKiemTra_RowPostPaint);
            // 
            // MaCTDKKT
            // 
            this.MaCTDKKT.DataPropertyName = "MaCTDKKT";
            this.MaCTDKKT.HeaderText = "MaCTDKKT";
            this.MaCTDKKT.Name = "MaCTDKKT";
            this.MaCTDKKT.Visible = false;
            // 
            // MaDKKT_CT
            // 
            this.MaDKKT_CT.DataPropertyName = "MaDKKT";
            this.MaDKKT_CT.HeaderText = "MaDKKT_CT";
            this.MaDKKT_CT.Name = "MaDKKT_CT";
            this.MaDKKT_CT.Visible = false;
            // 
            // MaNV_HanhThu
            // 
            this.MaNV_HanhThu.DataPropertyName = "MaNV_HanhThu";
            this.MaNV_HanhThu.HeaderText = "MaNV_HanhThu";
            this.MaNV_HanhThu.Name = "MaNV_HanhThu";
            this.MaNV_HanhThu.Visible = false;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.Width = 80;
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 80;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // NgayNhan
            // 
            this.NgayNhan.DataPropertyName = "NgayNhan";
            this.NgayNhan.HeaderText = "Ngày Nhập";
            this.NgayNhan.Name = "NgayNhan";
            // 
            // GB_DM_Cu
            // 
            this.GB_DM_Cu.DataPropertyName = "GB_DM_Cu";
            this.GB_DM_Cu.HeaderText = "GB - ĐM Cũ";
            this.GB_DM_Cu.Name = "GB_DM_Cu";
            this.GB_DM_Cu.Width = 90;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.Width = 150;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 102;
            this.label2.Text = "(enter)";
            // 
            // dateNhap
            // 
            this.dateNhap.CustomFormat = "dd/MM/yyyy";
            this.dateNhap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNhap.Location = new System.Drawing.Point(369, 12);
            this.dateNhap.Name = "dateNhap";
            this.dateNhap.Size = new System.Drawing.Size(100, 20);
            this.dateNhap.TabIndex = 104;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 103;
            this.label1.Text = "Ngày Nhập:";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(925, 12);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 105;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(1170, 60);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(100, 20);
            this.dateTu.TabIndex = 107;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1167, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 106;
            this.label3.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(1170, 99);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(100, 20);
            this.dateDen.TabIndex = 109;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1167, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 108;
            this.label4.Text = "Đến Ngày:";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.Location = new System.Drawing.Point(1170, 125);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(75, 23);
            this.btnBaoCao.TabIndex = 110;
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // txtTongSo
            // 
            this.txtTongSo.Location = new System.Drawing.Point(1170, 186);
            this.txtTongSo.Name = "txtTongSo";
            this.txtTongSo.Size = new System.Drawing.Size(100, 20);
            this.txtTongSo.TabIndex = 111;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1167, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 112;
            this.label5.Text = "Tổng Số:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1167, 209);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 114;
            this.label6.Text = "Báo Bình Thường:";
            // 
            // txtBaoBinhThuong
            // 
            this.txtBaoBinhThuong.Location = new System.Drawing.Point(1170, 225);
            this.txtBaoBinhThuong.Name = "txtBaoBinhThuong";
            this.txtBaoBinhThuong.Size = new System.Drawing.Size(100, 20);
            this.txtBaoBinhThuong.TabIndex = 113;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1167, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 116;
            this.label7.Text = "Báo Trùng:";
            // 
            // txtBaoTrung
            // 
            this.txtBaoTrung.Location = new System.Drawing.Point(1170, 264);
            this.txtBaoTrung.Name = "txtBaoTrung";
            this.txtBaoTrung.Size = new System.Drawing.Size(100, 20);
            this.txtBaoTrung.TabIndex = 115;
            // 
            // frmDangKyKiemTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1315, 675);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBaoTrung);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBaoBinhThuong);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTongSo);
            this.Controls.Add(this.btnBaoCao);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dateNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbNhanVien);
            this.Name = "frmDangKyKiemTra";
            this.Text = "Chuyển Kinh Doanh";
            this.Load += new System.EventHandler(this.frmChuyenKinhDoanh_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangKyKiemTra)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTDangKyKiemTra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDangKyKiemTra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvCTDangKyKiemTra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDKKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DateTimePicker dateNhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTDKKT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDKKT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNV_HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayNhan;
        private System.Windows.Forms.DataGridViewTextBoxColumn GB_DM_Cu;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.TextBox txtTongSo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBaoBinhThuong;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBaoTrung;
    }
}