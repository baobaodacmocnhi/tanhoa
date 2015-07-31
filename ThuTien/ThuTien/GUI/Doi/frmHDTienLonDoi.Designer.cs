namespace ThuTien.GUI.Doi
{
    partial class frmHDTienLonDoi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHDCoQuan = new System.Windows.Forms.DataGridView();
            this.NgayGiaiTrach_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ThueGTGT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_CQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCoQuan = new System.Windows.Forms.TabPage();
            this.ThueGTGT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhiBVMT_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.GiaBan_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSoTien = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabTuGia = new System.Windows.Forms.TabPage();
            this.dgvHDTuGia = new System.Windows.Forms.DataGridView();
            this.NgayGiaiTrach_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoHoaDon_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo_TG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbDot = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.cmbKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).BeginInit();
            this.tabCoQuan.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabTuGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHDCoQuan
            // 
            this.dgvHDCoQuan.AllowUserToAddRows = false;
            this.dgvHDCoQuan.AllowUserToDeleteRows = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDCoQuan.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvHDCoQuan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDCoQuan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayGiaiTrach_CQ,
            this.SoHoaDon_CQ,
            this.DanhBo_CQ,
            this.TieuThu_CQ,
            this.GiaBan_CQ,
            this.ThueGTGT_CQ,
            this.PhiBVMT_CQ,
            this.TongCong_CQ});
            this.dgvHDCoQuan.Location = new System.Drawing.Point(6, 6);
            this.dgvHDCoQuan.MultiSelect = false;
            this.dgvHDCoQuan.Name = "dgvHDCoQuan";
            this.dgvHDCoQuan.ReadOnly = true;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDCoQuan.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvHDCoQuan.Size = new System.Drawing.Size(805, 562);
            this.dgvHDCoQuan.TabIndex = 8;
            this.dgvHDCoQuan.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDCoQuan_CellFormatting);
            this.dgvHDCoQuan.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDCoQuan_RowPostPaint);
            // 
            // NgayGiaiTrach_CQ
            // 
            this.NgayGiaiTrach_CQ.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_CQ.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_CQ.Name = "NgayGiaiTrach_CQ";
            this.NgayGiaiTrach_CQ.ReadOnly = true;
            this.NgayGiaiTrach_CQ.Width = 80;
            // 
            // SoHoaDon_CQ
            // 
            this.SoHoaDon_CQ.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_CQ.HeaderText = "Số HĐ";
            this.SoHoaDon_CQ.Name = "SoHoaDon_CQ";
            this.SoHoaDon_CQ.ReadOnly = true;
            // 
            // DanhBo_CQ
            // 
            this.DanhBo_CQ.DataPropertyName = "DanhBo";
            this.DanhBo_CQ.HeaderText = "Danh Bộ";
            this.DanhBo_CQ.Name = "DanhBo_CQ";
            this.DanhBo_CQ.ReadOnly = true;
            // 
            // TieuThu_CQ
            // 
            this.TieuThu_CQ.DataPropertyName = "TieuThu";
            this.TieuThu_CQ.HeaderText = "Tiêu Thụ";
            this.TieuThu_CQ.Name = "TieuThu_CQ";
            this.TieuThu_CQ.ReadOnly = true;
            this.TieuThu_CQ.Width = 80;
            // 
            // GiaBan_CQ
            // 
            this.GiaBan_CQ.DataPropertyName = "GiaBan";
            this.GiaBan_CQ.HeaderText = "Giá Bán";
            this.GiaBan_CQ.Name = "GiaBan_CQ";
            this.GiaBan_CQ.ReadOnly = true;
            this.GiaBan_CQ.Width = 80;
            // 
            // ThueGTGT_CQ
            // 
            this.ThueGTGT_CQ.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_CQ.HeaderText = "Thuế GTGT";
            this.ThueGTGT_CQ.Name = "ThueGTGT_CQ";
            this.ThueGTGT_CQ.ReadOnly = true;
            // 
            // PhiBVMT_CQ
            // 
            this.PhiBVMT_CQ.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_CQ.HeaderText = "Phí BVMT";
            this.PhiBVMT_CQ.Name = "PhiBVMT_CQ";
            this.PhiBVMT_CQ.ReadOnly = true;
            // 
            // TongCong_CQ
            // 
            this.TongCong_CQ.DataPropertyName = "TongCong";
            this.TongCong_CQ.HeaderText = "Tổng Cộng";
            this.TongCong_CQ.Name = "TongCong_CQ";
            this.TongCong_CQ.ReadOnly = true;
            // 
            // tabCoQuan
            // 
            this.tabCoQuan.Controls.Add(this.dgvHDCoQuan);
            this.tabCoQuan.Location = new System.Drawing.Point(4, 22);
            this.tabCoQuan.Name = "tabCoQuan";
            this.tabCoQuan.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoQuan.Size = new System.Drawing.Size(819, 574);
            this.tabCoQuan.TabIndex = 1;
            this.tabCoQuan.Text = "Cơ Quan";
            this.tabCoQuan.UseVisualStyleBackColor = true;
            // 
            // ThueGTGT_TG
            // 
            this.ThueGTGT_TG.DataPropertyName = "ThueGTGT";
            this.ThueGTGT_TG.HeaderText = "Thuế GTGT";
            this.ThueGTGT_TG.Name = "ThueGTGT_TG";
            this.ThueGTGT_TG.ReadOnly = true;
            // 
            // TongCong_TG
            // 
            this.TongCong_TG.DataPropertyName = "TongCong";
            this.TongCong_TG.HeaderText = "Tổng Cộng";
            this.TongCong_TG.Name = "TongCong_TG";
            this.TongCong_TG.ReadOnly = true;
            // 
            // PhiBVMT_TG
            // 
            this.PhiBVMT_TG.DataPropertyName = "PhiBVMT";
            this.PhiBVMT_TG.HeaderText = "Phí BVMT";
            this.PhiBVMT_TG.Name = "PhiBVMT_TG";
            this.PhiBVMT_TG.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(545, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 52;
            this.label5.Text = "Số Tiền:";
            // 
            // GiaBan_TG
            // 
            this.GiaBan_TG.DataPropertyName = "GiaBan";
            this.GiaBan_TG.HeaderText = "Giá Bán";
            this.GiaBan_TG.Name = "GiaBan_TG";
            this.GiaBan_TG.ReadOnly = true;
            this.GiaBan_TG.Width = 80;
            // 
            // TieuThu_TG
            // 
            this.TieuThu_TG.DataPropertyName = "TieuThu";
            this.TieuThu_TG.HeaderText = "Tiêu Thụ";
            this.TieuThu_TG.Name = "TieuThu_TG";
            this.TieuThu_TG.ReadOnly = true;
            this.TieuThu_TG.Width = 80;
            // 
            // txtSoTien
            // 
            this.txtSoTien.Location = new System.Drawing.Point(598, 12);
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(100, 20);
            this.txtSoTien.TabIndex = 53;
            this.txtSoTien.Text = "1.000.000";
            this.txtSoTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSoTien_KeyPress);
            this.txtSoTien.Leave += new System.EventHandler(this.txtSoTien_Leave);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabTuGia);
            this.tabControl.Controls.Add(this.tabCoQuan);
            this.tabControl.Location = new System.Drawing.Point(12, 39);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(827, 600);
            this.tabControl.TabIndex = 51;
            // 
            // tabTuGia
            // 
            this.tabTuGia.Controls.Add(this.dgvHDTuGia);
            this.tabTuGia.Location = new System.Drawing.Point(4, 22);
            this.tabTuGia.Name = "tabTuGia";
            this.tabTuGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabTuGia.Size = new System.Drawing.Size(819, 574);
            this.tabTuGia.TabIndex = 0;
            this.tabTuGia.Text = "Tư Gia";
            this.tabTuGia.UseVisualStyleBackColor = true;
            // 
            // dgvHDTuGia
            // 
            this.dgvHDTuGia.AllowUserToAddRows = false;
            this.dgvHDTuGia.AllowUserToDeleteRows = false;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHDTuGia.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvHDTuGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHDTuGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NgayGiaiTrach_TG,
            this.SoHoaDon_TG,
            this.DanhBo_TG,
            this.TieuThu_TG,
            this.GiaBan_TG,
            this.ThueGTGT_TG,
            this.PhiBVMT_TG,
            this.TongCong_TG});
            this.dgvHDTuGia.Location = new System.Drawing.Point(6, 6);
            this.dgvHDTuGia.Name = "dgvHDTuGia";
            this.dgvHDTuGia.ReadOnly = true;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHDTuGia.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvHDTuGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHDTuGia.Size = new System.Drawing.Size(805, 562);
            this.dgvHDTuGia.TabIndex = 0;
            this.dgvHDTuGia.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvHDTuGia_CellFormatting);
            this.dgvHDTuGia.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvHDTuGia_RowPostPaint);
            // 
            // NgayGiaiTrach_TG
            // 
            this.NgayGiaiTrach_TG.DataPropertyName = "NgayGiaiTrach";
            this.NgayGiaiTrach_TG.HeaderText = "Ngày Giải Trách";
            this.NgayGiaiTrach_TG.Name = "NgayGiaiTrach_TG";
            this.NgayGiaiTrach_TG.ReadOnly = true;
            this.NgayGiaiTrach_TG.Width = 80;
            // 
            // SoHoaDon_TG
            // 
            this.SoHoaDon_TG.DataPropertyName = "SoHoaDon";
            this.SoHoaDon_TG.HeaderText = "Số HĐ";
            this.SoHoaDon_TG.Name = "SoHoaDon_TG";
            this.SoHoaDon_TG.ReadOnly = true;
            // 
            // DanhBo_TG
            // 
            this.DanhBo_TG.DataPropertyName = "DanhBo";
            this.DanhBo_TG.HeaderText = "Danh Bộ";
            this.DanhBo_TG.Name = "DanhBo_TG";
            this.DanhBo_TG.ReadOnly = true;
            // 
            // cmbDot
            // 
            this.cmbDot.FormattingEnabled = true;
            this.cmbDot.Items.AddRange(new object[] {
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
            this.cmbDot.Location = new System.Drawing.Point(333, 12);
            this.cmbDot.Name = "cmbDot";
            this.cmbDot.Size = new System.Drawing.Size(50, 21);
            this.cmbDot.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Đợt:";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(704, 10);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 47;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cmbKy
            // 
            this.cmbKy.FormattingEnabled = true;
            this.cmbKy.Items.AddRange(new object[] {
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
            "12"});
            this.cmbKy.Location = new System.Drawing.Point(244, 12);
            this.cmbKy.Name = "cmbKy";
            this.cmbKy.Size = new System.Drawing.Size(50, 21);
            this.cmbKy.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 43;
            this.label3.Text = "Kỳ:";
            // 
            // cmbNam
            // 
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Location = new System.Drawing.Point(150, 12);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(60, 21);
            this.cmbNam.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Năm:";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(418, 12);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 55;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(389, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Tổ:";
            // 
            // frmHDTienLonDoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 660);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSoTien);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.cmbDot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cmbKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label2);
            this.Name = "frmHDTienLonDoi";
            this.Text = "Hóa Đơn Tiền Lớn Đội";
            this.Load += new System.EventHandler(this.frmHDTienLonDoi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDCoQuan)).EndInit();
            this.tabCoQuan.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabTuGia.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHDTuGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHDCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_CQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_CQ;
        private System.Windows.Forms.TabPage tabCoQuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn ThueGTGT_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhiBVMT_TG;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu_TG;
        private System.Windows.Forms.TextBox txtSoTien;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabTuGia;
        private System.Windows.Forms.DataGridView dgvHDTuGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayGiaiTrach_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoHoaDon_TG;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo_TG;
        private System.Windows.Forms.ComboBox cmbDot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cmbKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Label label4;
    }
}