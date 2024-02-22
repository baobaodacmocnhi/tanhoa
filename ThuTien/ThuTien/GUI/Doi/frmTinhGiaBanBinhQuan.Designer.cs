namespace ThuTien.GUI.Doi
{
    partial class frmTinhGiaBanBinhQuan
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
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvGiaBanBinhQuan = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.txtTongSanLuong = new System.Windows.Forms.TextBox();
            this.txtGiaBanBinhQuan = new System.Windows.Forms.TextBox();
            this.cmbLoai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMa = new System.Windows.Forms.TextBox();
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongTieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBanBinhQuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeThuThang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TyLeThucThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaBanBinhQuan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(210, 11);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 54;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(144, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(106, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Năm:";
            // 
            // dgvGiaBanBinhQuan
            // 
            this.dgvGiaBanBinhQuan.AllowUserToAddRows = false;
            this.dgvGiaBanBinhQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaBanBinhQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGiaBanBinhQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGiaBanBinhQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ky,
            this.Nam,
            this.TongGiaBan,
            this.TongTieuThu,
            this.GiaBanBinhQuan,
            this.TyLeThuThang,
            this.TyLeThucThu});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvGiaBanBinhQuan.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvGiaBanBinhQuan.Location = new System.Drawing.Point(68, 40);
            this.dgvGiaBanBinhQuan.Name = "dgvGiaBanBinhQuan";
            this.dgvGiaBanBinhQuan.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGiaBanBinhQuan.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvGiaBanBinhQuan.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvGiaBanBinhQuan.Size = new System.Drawing.Size(567, 300);
            this.dgvGiaBanBinhQuan.TabIndex = 57;
            this.dgvGiaBanBinhQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvGiaBanBinhQuan_CellFormatting);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Giá Billing";
            this.label4.Visible = false;
            // 
            // txtTongDoanhThu
            // 
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.Location = new System.Drawing.Point(159, 340);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.Size = new System.Drawing.Size(100, 20);
            this.txtTongDoanhThu.TabIndex = 59;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTongSanLuong
            // 
            this.txtTongSanLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongSanLuong.Location = new System.Drawing.Point(259, 340);
            this.txtTongSanLuong.Name = "txtTongSanLuong";
            this.txtTongSanLuong.Size = new System.Drawing.Size(100, 20);
            this.txtTongSanLuong.TabIndex = 60;
            this.txtTongSanLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtGiaBanBinhQuan
            // 
            this.txtGiaBanBinhQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaBanBinhQuan.Location = new System.Drawing.Point(359, 340);
            this.txtGiaBanBinhQuan.Name = "txtGiaBanBinhQuan";
            this.txtGiaBanBinhQuan.Size = new System.Drawing.Size(100, 20);
            this.txtGiaBanBinhQuan.TabIndex = 61;
            this.txtGiaBanBinhQuan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbLoai
            // 
            this.cmbLoai.FormattingEnabled = true;
            this.cmbLoai.Items.AddRange(new object[] {
            "Cắt Tạm",
            "Cắt Hủy"});
            this.cmbLoai.Location = new System.Drawing.Point(6, 33);
            this.cmbLoai.Name = "cmbLoai";
            this.cmbLoai.Size = new System.Drawing.Size(121, 21);
            this.cmbLoai.TabIndex = 62;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Loại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 64;
            this.label3.Text = "Mã";
            // 
            // txtMa
            // 
            this.txtMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMa.Location = new System.Drawing.Point(133, 34);
            this.txtMa.Name = "txtMa";
            this.txtMa.Size = new System.Drawing.Size(100, 20);
            this.txtMa.TabIndex = 65;
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDanhBo.Location = new System.Drawing.Point(133, 73);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(130, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 66;
            this.label5.Text = "Danh Bộ";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(239, 31);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 68;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbLoai);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtDanhBo);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMa);
            this.groupBox1.Location = new System.Drawing.Point(641, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 101);
            this.groupBox1.TabIndex = 69;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phòng Kinh Doanh";
            // 
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // Nam
            // 
            this.Nam.DataPropertyName = "Nam";
            this.Nam.HeaderText = "Năm";
            this.Nam.Name = "Nam";
            this.Nam.ReadOnly = true;
            this.Nam.Visible = false;
            // 
            // TongGiaBan
            // 
            this.TongGiaBan.DataPropertyName = "TongGiaBan";
            this.TongGiaBan.HeaderText = "Doanh Thu";
            this.TongGiaBan.Name = "TongGiaBan";
            this.TongGiaBan.ReadOnly = true;
            // 
            // TongTieuThu
            // 
            this.TongTieuThu.DataPropertyName = "TongTieuThu";
            this.TongTieuThu.HeaderText = "Sản Lượng";
            this.TongTieuThu.Name = "TongTieuThu";
            this.TongTieuThu.ReadOnly = true;
            // 
            // GiaBanBinhQuan
            // 
            this.GiaBanBinhQuan.DataPropertyName = "GiaBanBinhQuan";
            this.GiaBanBinhQuan.HeaderText = "Giá Bán Bình Quân";
            this.GiaBanBinhQuan.Name = "GiaBanBinhQuan";
            this.GiaBanBinhQuan.ReadOnly = true;
            // 
            // TyLeThuThang
            // 
            this.TyLeThuThang.DataPropertyName = "TyLeThuThang";
            this.TyLeThuThang.HeaderText = "Tỷ Lệ Thu Tháng";
            this.TyLeThuThang.Name = "TyLeThuThang";
            this.TyLeThuThang.ReadOnly = true;
            this.TyLeThuThang.Width = 90;
            // 
            // TyLeThucThu
            // 
            this.TyLeThucThu.DataPropertyName = "TyLeThucThu";
            this.TyLeThucThu.HeaderText = "Tỷ Lệ Thực Thu";
            this.TyLeThucThu.Name = "TyLeThucThu";
            this.TyLeThucThu.ReadOnly = true;
            this.TyLeThucThu.Width = 80;
            // 
            // frmTinhGiaBanBinhQuan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1118, 412);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGiaBanBinhQuan);
            this.Controls.Add(this.txtTongSanLuong);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGiaBanBinhQuan);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Name = "frmTinhGiaBanBinhQuan";
            this.Text = "Tính Giá Bán Bình Quân";
            this.Load += new System.EventHandler(this.frmTinhGiaBanBinhQuan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGiaBanBinhQuan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvGiaBanBinhQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
        private System.Windows.Forms.TextBox txtTongSanLuong;
        private System.Windows.Forms.TextBox txtGiaBanBinhQuan;
        private System.Windows.Forms.ComboBox cmbLoai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMa;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nam;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongTieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBanBinhQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeThuThang;
        private System.Windows.Forms.DataGridViewTextBoxColumn TyLeThucThu;
    }
}