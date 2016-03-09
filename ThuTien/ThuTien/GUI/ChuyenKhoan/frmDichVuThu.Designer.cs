namespace ThuTien.GUI.ChuyenKhoan
{
    partial class frmDichVuThu
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDichVuThu = new System.Windows.Forms.ComboBox();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dateTu = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateDen = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDichVuThu = new System.Windows.Forms.DataGridView();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.To = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDichVu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DangNgan_ChuyenKhoan = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtTongHD = new System.Windows.Forms.TextBox();
            this.txtTongSoTien = new System.Windows.Forms.TextBox();
            this.txtTongPhi = new System.Windows.Forms.TextBox();
            this.btnInDS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.btnInKiemTra = new System.Windows.Forms.Button();
            this.cmbToDot = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbFromDot = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuThu)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Dịch Vụ Thu:";
            // 
            // cmbDichVuThu
            // 
            this.cmbDichVuThu.FormattingEnabled = true;
            this.cmbDichVuThu.Location = new System.Drawing.Point(108, 10);
            this.cmbDichVuThu.Name = "cmbDichVuThu";
            this.cmbDichVuThu.Size = new System.Drawing.Size(100, 21);
            this.cmbDichVuThu.TabIndex = 1;
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(243, 10);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(60, 21);
            this.cmbTo.TabIndex = 42;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Tổ:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(486, 36);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 43;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dateTu
            // 
            this.dateTu.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTu.Location = new System.Drawing.Point(108, 37);
            this.dateTu.Name = "dateTu";
            this.dateTu.Size = new System.Drawing.Size(140, 20);
            this.dateTu.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Từ Ngày:";
            // 
            // dateDen
            // 
            this.dateDen.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dateDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateDen.Location = new System.Drawing.Point(320, 38);
            this.dateDen.Name = "dateDen";
            this.dateDen.Size = new System.Drawing.Size(140, 20);
            this.dateDen.TabIndex = 45;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(256, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Đến Ngày:";
            // 
            // dgvDichVuThu
            // 
            this.dgvDichVuThu.AllowUserToAddRows = false;
            this.dgvDichVuThu.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDichVuThu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDichVuThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MLT,
            this.Ky,
            this.SoHoaDon,
            this.DanhBo,
            this.HoTen,
            this.DiaChi,
            this.SoTien,
            this.Phi,
            this.To,
            this.HanhThu,
            this.TenDichVu,
            this.CreateDate,
            this.NgayGiaiTrach,
            this.GiaBieu,
            this.DangNgan_ChuyenKhoan});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDichVuThu.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDichVuThu.Location = new System.Drawing.Point(12, 64);
            this.dgvDichVuThu.Name = "dgvDichVuThu";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDichVuThu.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvDichVuThu.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDichVuThu.Size = new System.Drawing.Size(1336, 545);
            this.dgvDichVuThu.TabIndex = 84;
            this.dgvDichVuThu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDichVuThu_CellFormatting);
            this.dgvDichVuThu.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDichVuThu_RowPostPaint);
            // 
            // MLT
            // 
            this.MLT.DataPropertyName = "MLT";
            this.MLT.HeaderText = "MLT";
            this.MLT.Name = "MLT";
            this.MLT.Width = 70;
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số Hóa Đơn";
            this.SoHoaDon.Name = "SoHoaDon";
            // 
            // DanhBo
            // 
            this.DanhBo.DataPropertyName = "DanhBo";
            this.DanhBo.HeaderText = "Danh Bộ";
            this.DanhBo.Name = "DanhBo";
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.Width = 150;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.Width = 200;
            // 
            // SoTien
            // 
            this.SoTien.DataPropertyName = "SoTien";
            this.SoTien.HeaderText = "Số Tiền";
            this.SoTien.Name = "SoTien";
            this.SoTien.Width = 80;
            // 
            // Phi
            // 
            this.Phi.DataPropertyName = "Phi";
            this.Phi.HeaderText = "Phí MN";
            this.Phi.Name = "Phi";
            this.Phi.Width = 80;
            // 
            // To
            // 
            this.To.DataPropertyName = "To";
            this.To.HeaderText = "Tổ";
            this.To.Name = "To";
            this.To.Width = 30;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            // 
            // TenDichVu
            // 
            this.TenDichVu.DataPropertyName = "TenDichVu";
            this.TenDichVu.HeaderText = "Dịch Vụ";
            this.TenDichVu.Name = "TenDichVu";
            this.TenDichVu.Width = 80;
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Thu";
            this.CreateDate.Name = "CreateDate";
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            // 
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "GiaBieu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Visible = false;
            // 
            // DangNgan_ChuyenKhoan
            // 
            this.DangNgan_ChuyenKhoan.DataPropertyName = "DangNgan_ChuyenKhoan";
            this.DangNgan_ChuyenKhoan.HeaderText = "DangNgan_ChuyenKhoan";
            this.DangNgan_ChuyenKhoan.Name = "DangNgan_ChuyenKhoan";
            this.DangNgan_ChuyenKhoan.Visible = false;
            // 
            // txtTongHD
            // 
            this.txtTongHD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongHD.Location = new System.Drawing.Point(13, 609);
            this.txtTongHD.Name = "txtTongHD";
            this.txtTongHD.Size = new System.Drawing.Size(41, 20);
            this.txtTongHD.TabIndex = 85;
            this.txtTongHD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSoTien
            // 
            this.txtTongSoTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSoTien.Location = new System.Drawing.Point(723, 609);
            this.txtTongSoTien.Name = "txtTongSoTien";
            this.txtTongSoTien.Size = new System.Drawing.Size(80, 20);
            this.txtTongSoTien.TabIndex = 86;
            this.txtTongSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongPhi
            // 
            this.txtTongPhi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongPhi.Location = new System.Drawing.Point(803, 609);
            this.txtTongPhi.Name = "txtTongPhi";
            this.txtTongPhi.Size = new System.Drawing.Size(80, 20);
            this.txtTongPhi.TabIndex = 87;
            this.txtTongPhi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnInDS
            // 
            this.btnInDS.Location = new System.Drawing.Point(567, 36);
            this.btnInDS.Name = "btnInDS";
            this.btnInDS.Size = new System.Drawing.Size(75, 23);
            this.btnInDS.TabIndex = 88;
            this.btnInDS.Text = "In DS Tồn";
            this.btnInDS.UseVisualStyleBackColor = true;
            this.btnInDS.Click += new System.EventHandler(this.btnInDS_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(309, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 89;
            this.label6.Text = "Nhân Viên:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(375, 10);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 90;
            // 
            // btnInKiemTra
            // 
            this.btnInKiemTra.Location = new System.Drawing.Point(648, 36);
            this.btnInKiemTra.Name = "btnInKiemTra";
            this.btnInKiemTra.Size = new System.Drawing.Size(75, 23);
            this.btnInKiemTra.TabIndex = 91;
            this.btnInKiemTra.Text = "In Kiểm Tra";
            this.btnInKiemTra.UseVisualStyleBackColor = true;
            this.btnInKiemTra.Click += new System.EventHandler(this.btnInKiemTra_Click);
            // 
            // cmbToDot
            // 
            this.cmbToDot.FormattingEnabled = true;
            this.cmbToDot.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbToDot.Location = new System.Drawing.Point(650, 10);
            this.cmbToDot.Name = "cmbToDot";
            this.cmbToDot.Size = new System.Drawing.Size(40, 21);
            this.cmbToDot.TabIndex = 95;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(594, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 94;
            this.label10.Text = "Đến Đợt:";
            // 
            // cmbFromDot
            // 
            this.cmbFromDot.FormattingEnabled = true;
            this.cmbFromDot.Items.AddRange(new object[] {
            "Tất Cả",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cmbFromDot.Location = new System.Drawing.Point(548, 10);
            this.cmbFromDot.Name = "cmbFromDot";
            this.cmbFromDot.Size = new System.Drawing.Size(40, 21);
            this.cmbFromDot.TabIndex = 93;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(499, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 92;
            this.label7.Text = "Từ Đợt:";
            // 
            // frmDichVuThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 666);
            this.Controls.Add(this.cmbToDot);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbFromDot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnInKiemTra);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.btnInDS);
            this.Controls.Add(this.txtTongPhi);
            this.Controls.Add(this.txtTongSoTien);
            this.Controls.Add(this.txtTongHD);
            this.Controls.Add(this.dgvDichVuThu);
            this.Controls.Add(this.dateTu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateDen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDichVuThu);
            this.Controls.Add(this.label1);
            this.Name = "frmDichVuThu";
            this.Text = "Dịch Vụ Thu Hộ";
            this.Load += new System.EventHandler(this.frmDichVuThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDichVuThu;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DateTimePicker dateTu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateDen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDichVuThu;
        private System.Windows.Forms.TextBox txtTongHD;
        private System.Windows.Forms.TextBox txtTongSoTien;
        private System.Windows.Forms.TextBox txtTongPhi;
        private System.Windows.Forms.Button btnInDS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Button btnInKiemTra;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phi;
        private System.Windows.Forms.DataGridViewTextBoxColumn To;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDichVu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DangNgan_ChuyenKhoan;
        private System.Windows.Forms.ComboBox cmbToDot;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbFromDot;
        private System.Windows.Forms.Label label7;
    }
}