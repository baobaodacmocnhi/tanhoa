namespace ThuTien.GUI.Doi
{
    partial class frmPhanTichHD0
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaBieu = new System.Windows.Forms.TextBox();
            this.txtDinhMuc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbNhanVien = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DinhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(525, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Giá Biểu:";
            // 
            // txtGiaBieu
            // 
            this.txtGiaBieu.Location = new System.Drawing.Point(581, 13);
            this.txtGiaBieu.Name = "txtGiaBieu";
            this.txtGiaBieu.Size = new System.Drawing.Size(50, 20);
            this.txtGiaBieu.TabIndex = 5;
            // 
            // txtDinhMuc
            // 
            this.txtDinhMuc.Location = new System.Drawing.Point(699, 13);
            this.txtDinhMuc.Name = "txtDinhMuc";
            this.txtDinhMuc.Size = new System.Drawing.Size(50, 20);
            this.txtDinhMuc.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(637, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Định Mức:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(796, 13);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(50, 20);
            this.txtCode.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(755, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Code:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(858, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 10;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaHD,
            this.SoHoaDon,
            this.Ky,
            this.DanhBo,
            this.MLT,
            this.HoTen,
            this.DiaChi,
            this.GiaBieu,
            this.DinhMuc,
            this.Code,
            this.TieuThu,
            this.HanhThu});
            this.dgvHoaDon.Location = new System.Drawing.Point(12, 39);
            this.dgvHoaDon.Name = "dgvHoaDon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(1120, 592);
            this.dgvHoaDon.TabIndex = 11;
            this.dgvHoaDon.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHoaDon_CellFormatting);
            this.dgvHoaDon.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHoaDon_RowPostPaint);
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
            "Tất cả",
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
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(469, 13);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(441, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(375, 13);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Năm:";
            // 
            // cmbNhanVien
            // 
            this.cmbNhanVien.FormattingEnabled = true;
            this.cmbNhanVien.Location = new System.Drawing.Point(213, 12);
            this.cmbNhanVien.Name = "cmbNhanVien";
            this.cmbNhanVien.Size = new System.Drawing.Size(118, 21);
            this.cmbNhanVien.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(147, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 47;
            this.label6.Text = "Nhân Viên:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(91, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(50, 21);
            this.cmbTo.TabIndex = 46;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Tổ:";
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.Visible = false;
            // 
            // SoHoaDon
            // 
            this.SoHoaDon.DataPropertyName = "SoHoaDon";
            this.SoHoaDon.HeaderText = "Số HĐ";
            this.SoHoaDon.Name = "SoHoaDon";
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.Width = 50;
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
            this.MLT.Visible = false;
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
            // GiaBieu
            // 
            this.GiaBieu.DataPropertyName = "GiaBieu";
            this.GiaBieu.HeaderText = "Giá Biểu";
            this.GiaBieu.Name = "GiaBieu";
            this.GiaBieu.Width = 50;
            // 
            // DinhMuc
            // 
            this.DinhMuc.DataPropertyName = "DinhMuc";
            this.DinhMuc.HeaderText = "Định Mức";
            this.DinhMuc.Name = "DinhMuc";
            this.DinhMuc.Width = 50;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 50;
            // 
            // HanhThu
            // 
            this.HanhThu.DataPropertyName = "HanhThu";
            this.HanhThu.HeaderText = "Hành Thu";
            this.HanhThu.Name = "HanhThu";
            this.HanhThu.Width = 150;
            // 
            // frmPhanTichHD0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 643);
            this.Controls.Add(this.cmbNhanVien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDinhMuc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtGiaBieu);
            this.Controls.Add(this.label1);
            this.Name = "frmPhanTichHD0";
            this.Text = "Phân Tích Hóa Đơn = 0";
            this.Load += new System.EventHandler(this.frmPhanTichHD0_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGiaBieu;
        private System.Windows.Forms.TextBox txtDinhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbNhanVien;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn DinhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanhThu;
    }
}