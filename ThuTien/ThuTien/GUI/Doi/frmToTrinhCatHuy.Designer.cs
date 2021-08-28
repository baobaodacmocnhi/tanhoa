namespace ThuTien.GUI.Doi
{
    partial class frmToTrinhCatHuy
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
            this.txtDanhBo = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvToTrinh = new System.Windows.Forms.DataGridView();
            this.MaTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Khoa = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DaKy = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvCTToTrinh = new System.Windows.Forms.DataGridView();
            this.MaTT_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaCTTT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DanhBo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MLT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoDHN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ky = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongCong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TieuThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDate_CT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXem = new System.Windows.Forms.Button();
            this.radPhoGiamDoc = new System.Windows.Forms.RadioButton();
            this.radGiamDoc = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radBa = new System.Windows.Forms.RadioButton();
            this.radOng = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTToTrinh)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Bộ:";
            // 
            // txtDanhBo
            // 
            this.txtDanhBo.Location = new System.Drawing.Point(454, 12);
            this.txtDanhBo.Name = "txtDanhBo";
            this.txtDanhBo.Size = new System.Drawing.Size(100, 20);
            this.txtDanhBo.TabIndex = 1;
            this.txtDanhBo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDanhBo_KeyPress);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(603, 12);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 4;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(765, 12);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 6;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(684, 12);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvToTrinh);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(373, 590);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh Sách Tờ Trình";
            // 
            // dgvToTrinh
            // 
            this.dgvToTrinh.AllowUserToAddRows = false;
            this.dgvToTrinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvToTrinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvToTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvToTrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTT,
            this.CreateDate,
            this.Khoa,
            this.DaKy});
            this.dgvToTrinh.Location = new System.Drawing.Point(6, 19);
            this.dgvToTrinh.MultiSelect = false;
            this.dgvToTrinh.Name = "dgvToTrinh";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvToTrinh.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvToTrinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToTrinh.Size = new System.Drawing.Size(361, 565);
            this.dgvToTrinh.TabIndex = 0;
            this.dgvToTrinh.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvToTrinh_CellContentClick);
            this.dgvToTrinh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvToTrinh_CellFormatting);
            this.dgvToTrinh.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvToTrinh_CellValidating);
            this.dgvToTrinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvToTrinh_RowPostPaint);
            // 
            // MaTT
            // 
            this.MaTT.DataPropertyName = "MaTT";
            this.MaTT.HeaderText = "Mã Tờ Trình";
            this.MaTT.Name = "MaTT";
            // 
            // CreateDate
            // 
            this.CreateDate.DataPropertyName = "CreateDate";
            this.CreateDate.HeaderText = "Ngày Lập";
            this.CreateDate.Name = "CreateDate";
            // 
            // Khoa
            // 
            this.Khoa.DataPropertyName = "Khoa";
            this.Khoa.HeaderText = "Khóa";
            this.Khoa.Name = "Khoa";
            this.Khoa.Width = 50;
            // 
            // DaKy
            // 
            this.DaKy.DataPropertyName = "DaKy";
            this.DaKy.HeaderText = "Đã Ký";
            this.DaKy.Name = "DaKy";
            this.DaKy.Width = 50;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvCTToTrinh);
            this.groupBox2.Location = new System.Drawing.Point(391, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(925, 590);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi Tiết Tờ Trình";
            // 
            // dgvCTToTrinh
            // 
            this.dgvCTToTrinh.AllowUserToAddRows = false;
            this.dgvCTToTrinh.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCTToTrinh.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCTToTrinh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCTToTrinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTT_CT,
            this.MaCTTT,
            this.DanhBo,
            this.MLT,
            this.CoDHN,
            this.HoTen,
            this.DiaChi,
            this.Ky,
            this.TongCong,
            this.TieuThu,
            this.GhiChu,
            this.CreateDate_CT});
            this.dgvCTToTrinh.Location = new System.Drawing.Point(6, 19);
            this.dgvCTToTrinh.Name = "dgvCTToTrinh";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvCTToTrinh.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCTToTrinh.Size = new System.Drawing.Size(913, 565);
            this.dgvCTToTrinh.TabIndex = 22;
            this.dgvCTToTrinh.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCTToTrinh_CellFormatting);
            this.dgvCTToTrinh.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvCTToTrinh_CellValidating);
            this.dgvCTToTrinh.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvCTToTrinh_RowPostPaint);
            // 
            // MaTT_CT
            // 
            this.MaTT_CT.DataPropertyName = "MaTT";
            this.MaTT_CT.HeaderText = "MaTT";
            this.MaTT_CT.Name = "MaTT_CT";
            this.MaTT_CT.Visible = false;
            // 
            // MaCTTT
            // 
            this.MaCTTT.DataPropertyName = "MaCTTT";
            this.MaCTTT.HeaderText = "MaCTTT";
            this.MaCTTT.Name = "MaCTTT";
            this.MaCTTT.Visible = false;
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
            // CoDHN
            // 
            this.CoDHN.DataPropertyName = "CoDHN";
            this.CoDHN.HeaderText = "Cỡ ĐHN";
            this.CoDHN.Name = "CoDHN";
            this.CoDHN.Visible = false;
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
            // Ky
            // 
            this.Ky.DataPropertyName = "Ky";
            this.Ky.HeaderText = "Kỳ";
            this.Ky.Name = "Ky";
            this.Ky.ReadOnly = true;
            this.Ky.Width = 50;
            // 
            // TongCong
            // 
            this.TongCong.DataPropertyName = "TongCong";
            this.TongCong.HeaderText = "Tổng Cộng";
            this.TongCong.Name = "TongCong";
            this.TongCong.ReadOnly = true;
            // 
            // TieuThu
            // 
            this.TieuThu.DataPropertyName = "TieuThu";
            this.TieuThu.HeaderText = "Tiêu Thụ";
            this.TieuThu.Name = "TieuThu";
            this.TieuThu.Width = 50;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            this.GhiChu.Width = 200;
            // 
            // CreateDate_CT
            // 
            this.CreateDate_CT.DataPropertyName = "CreateDate";
            this.CreateDate_CT.HeaderText = "CreateDate";
            this.CreateDate_CT.Name = "CreateDate_CT";
            this.CreateDate_CT.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "(enter)";
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(310, 12);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(75, 23);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // radPhoGiamDoc
            // 
            this.radPhoGiamDoc.AutoSize = true;
            this.radPhoGiamDoc.Checked = true;
            this.radPhoGiamDoc.Location = new System.Drawing.Point(894, 26);
            this.radPhoGiamDoc.Name = "radPhoGiamDoc";
            this.radPhoGiamDoc.Size = new System.Drawing.Size(94, 17);
            this.radPhoGiamDoc.TabIndex = 50;
            this.radPhoGiamDoc.TabStop = true;
            this.radPhoGiamDoc.Text = "Phó Giám Đốc";
            this.radPhoGiamDoc.UseVisualStyleBackColor = true;
            // 
            // radGiamDoc
            // 
            this.radGiamDoc.AutoSize = true;
            this.radGiamDoc.Location = new System.Drawing.Point(894, 3);
            this.radGiamDoc.Name = "radGiamDoc";
            this.radGiamDoc.Size = new System.Drawing.Size(72, 17);
            this.radGiamDoc.TabIndex = 49;
            this.radGiamDoc.Text = "Giám Đốc";
            this.radGiamDoc.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radBa);
            this.panel1.Controls.Add(this.radOng);
            this.panel1.Location = new System.Drawing.Point(1019, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 45);
            this.panel1.TabIndex = 51;
            // 
            // radBa
            // 
            this.radBa.AutoSize = true;
            this.radBa.Location = new System.Drawing.Point(3, 26);
            this.radBa.Name = "radBa";
            this.radBa.Size = new System.Drawing.Size(38, 17);
            this.radBa.TabIndex = 51;
            this.radBa.Text = "Bà";
            this.radBa.UseVisualStyleBackColor = true;
            // 
            // radOng
            // 
            this.radOng.AutoSize = true;
            this.radOng.Checked = true;
            this.radOng.Location = new System.Drawing.Point(3, 3);
            this.radOng.Name = "radOng";
            this.radOng.Size = new System.Drawing.Size(45, 17);
            this.radOng.TabIndex = 50;
            this.radOng.TabStop = true;
            this.radOng.Text = "Ông";
            this.radOng.UseVisualStyleBackColor = true;
            // 
            // frmToTrinhCatHuy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1387, 668);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radPhoGiamDoc);
            this.Controls.Add(this.radGiamDoc);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtDanhBo);
            this.Controls.Add(this.label1);
            this.Name = "frmToTrinhCatHuy";
            this.Text = "Tờ Trình Cắt Hủy Danh Bộ";
            this.Load += new System.EventHandler(this.frmToTrinhCatHuy_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvToTrinh)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCTToTrinh)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDanhBo;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvToTrinh;
        private System.Windows.Forms.DataGridView dgvCTToTrinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.RadioButton radPhoGiamDoc;
        private System.Windows.Forms.RadioButton radGiamDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Khoa;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DaKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTT_CT;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaCTTT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DanhBo;
        private System.Windows.Forms.DataGridViewTextBoxColumn MLT;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoDHN;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ky;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongCong;
        private System.Windows.Forms.DataGridViewTextBoxColumn TieuThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDate_CT;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radBa;
        private System.Windows.Forms.RadioButton radOng;
    }
}