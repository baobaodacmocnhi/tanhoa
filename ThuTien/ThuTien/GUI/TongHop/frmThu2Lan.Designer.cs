namespace ThuTien.GUI.TongHop
{
    partial class frmThu2Lan
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
            this.label5 = new System.Windows.Forms.Label();
            this.lstHD = new System.Windows.Forms.ListBox();
            this.txtSoHoaDon = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.MaHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayGiaiTrach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoPhatHanh_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_DT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Số Hóa Đơn:";
            // 
            // lstHD
            // 
            this.lstHD.FormattingEnabled = true;
            this.lstHD.Location = new System.Drawing.Point(15, 51);
            this.lstHD.Name = "lstHD";
            this.lstHD.Size = new System.Drawing.Size(120, 173);
            this.lstHD.TabIndex = 36;
            this.lstHD.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstHD_MouseDoubleClick);
            // 
            // txtSoHoaDon
            // 
            this.txtSoHoaDon.Location = new System.Drawing.Point(87, 12);
            this.txtSoHoaDon.Name = "txtSoHoaDon";
            this.txtSoHoaDon.Size = new System.Drawing.Size(100, 20);
            this.txtSoHoaDon.TabIndex = 32;
            this.txtSoHoaDon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoHoaDon_KeyPress);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(161, 109);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 35;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(161, 80);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Visible = false;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(161, 51);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 33;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Danh Sách Hóa Đơn:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(663, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 42;
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
            this.NgayGiaiTrach,
            this.SoHoaDon_DT,
            this.Ky_DT,
            this.MLT_DT,
            this.SoPhatHanh_DT,
            this.DanhBo_DT,
            this.TieuThu_DT,
            this.GiaBan_DT,
            this.ThueGTGT_DT,
            this.PhiBVMT_DT,
            this.TongCong_DT});
            this.dgvHoaDon.Location = new System.Drawing.Point(262, 39);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHoaDon.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(805, 615);
            this.dgvHoaDon.TabIndex = 43;
            // 
            // MaHD
            // 
            this.MaHD.DataPropertyName = "MaHD";
            this.MaHD.HeaderText = "MaHD";
            this.MaHD.Name = "MaHD";
            this.MaHD.ReadOnly = true;
            this.MaHD.Visible = false;
            // 
            // NgayGiaiTrach
            // 
            this.NgayGiaiTrach.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach.Name = "NgayGiaiTrach";
            this.NgayGiaiTrach.ReadOnly = true;
            this.NgayGiaiTrach.Width = 80;
            // 
            // SoHoaDon_DT
            // 
            this.SoHoaDon_DT.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_DT.HeaderText = "Số HĐ";
            this.SoHoaDon_DT.Name = "SoHoaDon_DT";
            this.SoHoaDon_DT.ReadOnly = true;
            // 
            // Ky_DT
            // 
            this.Ky_DT.DataPropertyName = "Ky";
            this.Ky_DT.HeaderText = "Kỳ";
            this.Ky_DT.Name = "Ky_DT";
            this.Ky_DT.ReadOnly = true;
            this.Ky_DT.Visible = false;
            // 
            // MLT_DT
            // 
            this.MLT_DT.DataPropertyName = "MLT";
            this.MLT_DT.HeaderText = "MLT";
            this.MLT_DT.Name = "MLT_DT";
            this.MLT_DT.ReadOnly = true;
            this.MLT_DT.Visible = false;
            // 
            // SoPhatHanh_DT
            // 
            this.SoPhatHanh_DT.DataPropertyName = "SoPhatHanh";
            this.SoPhatHanh_DT.HeaderText = "Số Phát Hành";
            this.SoPhatHanh_DT.Name = "SoPhatHanh_DT";
            this.SoPhatHanh_DT.ReadOnly = true;
            this.SoPhatHanh_DT.Visible = false;
            // 
            // DanhBo_DT
            // 
            this.DanhBo_DT.DataPropertyName = "DanhBo";
            this.DanhBo_DT.HeaderText = "Danh Bộ";
            this.DanhBo_DT.Name = "DanhBo_DT";
            this.DanhBo_DT.ReadOnly = true;
            // 
            // TieuThu_DT
            // 
            this.TieuThu_DT.DataPropertyName = "TieuThu";
            this.TieuThu_DT.HeaderText = "Tiêu Thụ";
            this.TieuThu_DT.Name = "TieuThu_DT";
            this.TieuThu_DT.ReadOnly = true;
            this.TieuThu_DT.Width = 80;
            // 
            // GiaBan_DT
            // 
            this.GiaBan_DT.DataPropertyName = "GiaBan";
            this.GiaBan_DT.HeaderText = "Giá Bán";
            this.GiaBan_DT.Name = "GiaBan_DT";
            this.GiaBan_DT.ReadOnly = true;
            this.GiaBan_DT.Width = 80;
            // 
            // ThueGTGT_DT
            // 
            this.ThueGTGT_DT.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_DT.HeaderText = "Thuế GTGT";
            this.ThueGTGT_DT.Name = "ThueGTGT_DT";
            this.ThueGTGT_DT.ReadOnly = true;
            // 
            // PhiBVMT_DT
            // 
            this.PhiBVMT_DT.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_DT.HeaderText = "Phí BVMT";
            this.PhiBVMT_DT.Name = "PhiBVMT_DT";
            this.PhiBVMT_DT.ReadOnly = true;
            // 
            // TongCong_DT
            // 
            this.TongCong_DT.DataPropertyName = "TongCong";
            this.TongCong_DT.HeaderText = "Tổng Cộng";
            this.TongCong_DT.Name = "TongCong_DT";
            this.TongCong_DT.ReadOnly = true;
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
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
            this.cmbDot.Location = new System.Drawing.Point(607, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(50, 21);
            this.cmbDot.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(574, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Đợt:";
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
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
            this.cmbKy.Location = new System.Drawing.Point(518, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(490, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 46;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(424, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(386, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Năm:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(193, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "(Enter)";
            // 
            // frmThu2Lan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 690);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvHoaDon);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lstHD);
            this.Controls.Add(this.txtSoHoaDon);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label4);
            this.Name = "frmThu2Lan";
            this.Text = "Thu 2 Lần";
            this.Load += new System.EventHandler(this.frmThu2Lan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstHD;
        private System.Windows.Forms.TextBox txtSoHoaDon;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoPhatHanh_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_DT;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_DT;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
    }
}