namespace KeToan.GUI.NhapLieu
{
    partial class frmPhieuChi
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
            this.cmbNganHang = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dgvPhieuChi = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayLap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK_No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTK_Co = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KhoanMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.btnXem = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.txtNoiDungDT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDiaChiDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHoTenDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSoCT = new System.Windows.Forms.TextBox();
            this.txtKhoanMuc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSoTK_Co = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSoTK_No = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateNgayLap = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNganHang
            // 
            this.cmbNganHang.FormattingEnabled = true;
            this.cmbNganHang.Location = new System.Drawing.Point(95, 12);
            this.cmbNganHang.Name = "cmbNganHang";
            this.cmbNganHang.Size = new System.Drawing.Size(100, 21);
            this.cmbNganHang.TabIndex = 1;
            this.cmbNganHang.SelectedIndexChanged += new System.EventHandler(this.cmbNganHang_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Ngân Hàng:";
            // 
            // dgvPhieuChi
            // 
            this.dgvPhieuChi.AllowUserToAddRows = false;
            this.dgvPhieuChi.AllowUserToDeleteRows = false;
            this.dgvPhieuChi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuChi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NgayLap,
            this.SoCT,
            this.NoiDung,
            this.HoTen,
            this.SoTK_No,
            this.SoTK_Co,
            this.SoTien,
            this.KhoanMuc});
            this.dgvPhieuChi.Location = new System.Drawing.Point(6, 46);
            this.dgvPhieuChi.Name = "dgvPhieuChi";
            this.dgvPhieuChi.ReadOnly = true;
            this.dgvPhieuChi.Size = new System.Drawing.Size(1064, 429);
            this.dgvPhieuChi.TabIndex = 5;
            this.dgvPhieuChi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuChi_CellContentClick);
            this.dgvPhieuChi.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPhieuChi_CellFormatting);
            this.dgvPhieuChi.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvPhieuChi_RowPostPaint);
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
            // 
            // SoCT
            // 
            this.SoCT.DataPropertyName = "SoCT";
            this.SoCT.HeaderText = "Số CT";
            this.SoCT.Name = "SoCT";
            this.SoCT.ReadOnly = true;
            this.SoCT.Width = 150;
            // 
            // NoiDung
            // 
            this.NoiDung.DataPropertyName = "NoiDung";
            this.NoiDung.HeaderText = "Nội Dung";
            this.NoiDung.Name = "NoiDung";
            this.NoiDung.ReadOnly = true;
            this.NoiDung.Width = 150;
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 150;
            // 
            // SoTK_No
            // 
            this.SoTK_No.DataPropertyName = "SoTK_No";
            this.SoTK_No.HeaderText = "Số TK Nợ";
            this.SoTK_No.Name = "SoTK_No";
            this.SoTK_No.ReadOnly = true;
            // 
            // SoTK_Co
            // 
            this.SoTK_Co.DataPropertyName = "SoTK_Co";
            this.SoTK_Co.HeaderText = "Số TK Có";
            this.SoTK_Co.Name = "SoTK_Co";
            this.SoTK_Co.ReadOnly = true;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.ReadOnly = true;
            // 
            // KhoanMuc
            // 
            this.KhoanMuc.DataPropertyName = "KhoanMuc";
            this.KhoanMuc.HeaderText = "Khoản Mục";
            this.KhoanMuc.Name = "KhoanMuc";
            this.KhoanMuc.ReadOnly = true;
            this.KhoanMuc.Width = 150;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvPhieuChi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dateFrom);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dateTo);
            this.groupBox1.Location = new System.Drawing.Point(12, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1083, 484);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Từ Ngày:";
            // 
            // dateFrom
            // 
            this.dateFrom.CustomFormat = "dd/MM/yyyy";
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFrom.Location = new System.Drawing.Point(130, 19);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(95, 20);
            this.dateFrom.TabIndex = 1;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(396, 17);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 4;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Đến Ngày:";
            // 
            // dateTo
            // 
            this.dateTo.CustomFormat = "dd/MM/yyyy";
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTo.Location = new System.Drawing.Point(295, 19);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(95, 20);
            this.dateTo.TabIndex = 3;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(401, 84);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 22;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Số Chứng Từ:";
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(401, 113);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 23;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(401, 142);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 24;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // txtNoiDungDT
            // 
            this.txtNoiDungDT.Location = new System.Drawing.Point(95, 143);
            this.txtNoiDungDT.Name = "txtNoiDungDT";
            this.txtNoiDungDT.Size = new System.Drawing.Size(300, 20);
            this.txtNoiDungDT.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nội Dung:";
            // 
            // txtDiaChiDT
            // 
            this.txtDiaChiDT.Location = new System.Drawing.Point(95, 117);
            this.txtDiaChiDT.Name = "txtDiaChiDT";
            this.txtDiaChiDT.Size = new System.Drawing.Size(300, 20);
            this.txtDiaChiDT.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Địa Chỉ:";
            // 
            // txtHoTenDT
            // 
            this.txtHoTenDT.Location = new System.Drawing.Point(95, 91);
            this.txtHoTenDT.Name = "txtHoTenDT";
            this.txtHoTenDT.Size = new System.Drawing.Size(300, 20);
            this.txtHoTenDT.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ông Bà:";
            // 
            // txtMaDT
            // 
            this.txtMaDT.Location = new System.Drawing.Point(95, 65);
            this.txtMaDT.Name = "txtMaDT";
            this.txtMaDT.Size = new System.Drawing.Size(100, 20);
            this.txtMaDT.TabIndex = 15;
            this.txtMaDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaDT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đối Tượng:";
            // 
            // txtSoCT
            // 
            this.txtSoCT.Location = new System.Drawing.Point(95, 39);
            this.txtSoCT.Name = "txtSoCT";
            this.txtSoCT.Size = new System.Drawing.Size(100, 20);
            this.txtSoCT.TabIndex = 9;
            // 
            // txtKhoanMuc
            // 
            this.txtKhoanMuc.Location = new System.Drawing.Point(431, 39);
            this.txtKhoanMuc.Name = "txtKhoanMuc";
            this.txtKhoanMuc.Size = new System.Drawing.Size(200, 20);
            this.txtKhoanMuc.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(360, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "Khoản Mục:";
            // 
            // txtSoTK_Co
            // 
            this.txtSoTK_Co.Location = new System.Drawing.Point(432, 12);
            this.txtSoTK_Co.Name = "txtSoTK_Co";
            this.txtSoTK_Co.Size = new System.Drawing.Size(100, 20);
            this.txtSoTK_Co.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(370, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Số TK Có:";
            // 
            // txtSoTK_No
            // 
            this.txtSoTK_No.Location = new System.Drawing.Point(264, 12);
            this.txtSoTK_No.Name = "txtSoTK_No";
            this.txtSoTK_No.Size = new System.Drawing.Size(100, 20);
            this.txtSoTK_No.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số TK Nợ:";
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(254, 39);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtSoTien.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Số Tiền:";
            // 
            // dateNgayLap
            // 
            this.dateNgayLap.CustomFormat = "dd/MM/yyyy";
            this.dateNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateNgayLap.Location = new System.Drawing.Point(600, 12);
            this.dateNgayLap.Name = "dateNgayLap";
            this.dateNgayLap.Size = new System.Drawing.Size(95, 20);
            this.dateNgayLap.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày Lập:";
            // 
            // frmPhieuChi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 676);
            this.Controls.Add(this.txtKhoanMuc);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtSoTK_Co);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtSoTK_No);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateNgayLap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbNganHang);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.txtNoiDungDT);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDiaChiDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHoTenDT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaDT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSoCT);
            this.Name = "frmPhieuChi";
            this.Text = "Phiếu Chi";
            this.Load += new System.EventHandler(this.frmPhieuChi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuChi)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbNganHang;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridView dgvPhieuChi;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.TextBox txtNoiDungDT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDiaChiDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHoTenDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaDT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSoCT;
        private System.Windows.Forms.TextBox txtKhoanMuc;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtSoTK_Co;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSoTK_No;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateNgayLap;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayLap;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK_No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTK_Co;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn KhoanMuc;
    }
}